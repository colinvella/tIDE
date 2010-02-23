using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Format;
using Tiling.Layers;
using Tiling.ObjectModel;
using Tiling.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Controls;
using TileMapEditor.Dialogs;
using TileMapEditor.Help;
using TileMapEditor.Plugin;

namespace TileMapEditor
{
    public partial class MainForm : Form
    {
        private enum WindowMode
        {
            Windowed,
            Fullscreen
        }

        #region Private Variables

        private WindowMode m_windowMode;
        private System.Drawing.Rectangle m_windowBounds;

        private Map m_map;

        private CommandHistory m_commandHistory;
        private Tiling.ObjectModel.Component m_selectedComponent;
        private TileBrushCollection m_tileBrushCollection;
        private bool m_needsSaving;
        private string m_filename;

        private PluginManager m_pluginManager;

        private HelpForm m_helpForm;

        #endregion

        #region Private Methods

        private string GenerateFileDialogFilter()
        {
            FormatManager formatManager = FormatManager.Instance;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (IMapFormat mapFormat in formatManager.MapFormats)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append('|');
                stringBuilder.Append(mapFormat.FileExtensionDescriptor);
                stringBuilder.Append("|*.");
                stringBuilder.Append(mapFormat.FileExtension);
            }

            return stringBuilder.ToString();
        }

        private void ArrangeToolStripLayout()
        {
            ToolStripPanel toolStripPanel = m_toolStripContainer.TopToolStripPanel;

            toolStripPanel.ControlAdded -= this.OnCustomToolStripAdded;

            // determine custom toolstrips implemented by plugins
            List<ToolStrip> customToolStrips = new List<ToolStrip>();
            foreach (ToolStrip toolStrip in toolStripPanel.Controls)
            {
                if (toolStrip != m_menuStrip
                    && toolStrip != m_fileToolStrip
                    && toolStrip != m_editToolStrip
                    && toolStrip != m_viewToolStrip
                    && toolStrip != m_mapToolStrip
                    && toolStrip != m_layerToolStrip
                    && toolStrip != m_tileSheetToolStrip)
                    customToolStrips.Add(toolStrip);
            }

            // clear strip panel
            toolStripPanel.Controls.Clear();

            // add strips in reverse order (for some odd reason)

            toolStripPanel.Join(m_menuStrip);

            toolStripPanel.Join(m_viewToolStrip, 1);
            toolStripPanel.Join(m_editToolStrip, 1);
            toolStripPanel.Join(m_fileToolStrip, 1);

            // add in custom toolstrips in reverse order
            customToolStrips.Reverse();
            foreach (ToolStrip toolStrip in customToolStrips)
                toolStripPanel.Join(toolStrip, 2);

            // add built-in strips in reverse order
            toolStripPanel.Join(m_tileSheetToolStrip, 2);
            toolStripPanel.Join(m_layerToolStrip, 2);
            toolStripPanel.Join(m_mapToolStrip, 2);      


            toolStripPanel.ControlAdded += this.OnCustomToolStripAdded;
        }

        private void StartWaitCursor()
        {
            Application.UseWaitCursor = true;
            // needed to allow application to process cursor message
            Application.DoEvents();
        }

        private void StopWaitCursor()
        {
            Application.UseWaitCursor = false;
            // needed to force immediate cursor change without
            // waiting for mouse move
            Cursor = Cursor;
        }

        private void UpdateFileControls()
        {
            m_fileSaveMenuItem.Enabled
                = m_fileSaveButton.Enabled
                = m_needsSaving;
        }

        private void UpdateEditControls()
        {
            Layer selectedLayer = m_mapPanel.SelectedLayer;
            TileSelection tileSelection = m_mapPanel.TileSelection;
            bool selectedLayerAndTiles
                = selectedLayer != null && !tileSelection.IsEmpty();

            // undo, redo
            m_editUndoMenuItem.Enabled = m_editUndoButton.Enabled
                = m_commandHistory.CanUndo();
            m_editRedoMenuItem.Enabled = m_editRedoButton.Enabled
                = m_commandHistory.CanRedo();

            m_editUndoButton.ToolTipText
                = "Undo: " + m_commandHistory.UndoDescription;
            m_editRedoButton.ToolTipText
                = "Redo: " + m_commandHistory.RedoDescription;

            // cut, copy, paste

            m_editCutMenuItem.Enabled = m_editCutButton.Enabled
                = m_editCopyMenuItem.Enabled = m_editCopyButton.Enabled
                = m_editDeleteMenuItem.Enabled = m_editDeleteButton.Enabled
                = selectedLayerAndTiles;

            m_editPasteMenuItem.Enabled = m_editPasteButton.Enabled
                = ClipBoardManager.Instance.HasTileBrush();

            // selection

            m_editSelectAllMenuItem.Enabled
                = m_editSelectAllButton.Enabled
                = m_editClearSelectionMenuItem.Enabled
                = m_editClearSelectionButton.Enabled
                = m_editInvertSelectionMenuItem.Enabled
                = m_editInvertSelectionButton.Enabled
                = selectedLayer != null;

            // tile brushes

            m_editMakeTileBrushMenuItem.Enabled
                = m_editMakeTileBrushButton.Enabled
                = selectedLayerAndTiles;

            m_editManageTileBrushesMenuItem.Enabled
                = m_editManageTileBrushesButton.Enabled
                = m_tileBrushCollection.TileBrushes.Count > 0;
        }

        private void UpdateZoomControls()
        {
            int zoom = m_mapPanel.Zoom;
            foreach (ToolStripMenuItem toolStripMenuItem in m_viewZoomMenuItem.DropDownItems)
                toolStripMenuItem.Checked = toolStripMenuItem.Tag.ToString() == zoom.ToString();

            m_viewZoomComboBox.SelectedIndex = zoom - 1;

            m_viewZoomInMenuItem.Enabled = m_viewZoomInButton.Enabled = zoom < 10;
            m_viewZoomOutMenuItem.Enabled = m_viewZoomOutButton.Enabled = zoom > 1;
        }

        private void UpdateLayerVisibilityControls()
        {
            Layer layer = m_mapPanel.SelectedLayer;

            m_layerVisibilityMenuItem.Enabled
                = m_layerVisibilityButton.Enabled = layer != null;

            if (layer == null)
                return;

            bool visible = layer.Visible;

            m_layerVisibilityMenuItem.Text = visible
                ? "Make Invisible"
                : "Make Visible";
            m_layerVisibilityButton.ToolTipText = visible
                ? "Make layer invisible"
                : "Make layer visible";

            m_layerVisibilityMenuItem.Image
                = m_layerVisibilityButton.Image
                = visible
                    ? Properties.Resources.LayerInvisible
                    : Properties.Resources.LayerVisible;

            m_mapTreeView.UpdateTree();
        }

        private void UpdateLayerCompositingControls()
        {
            if (m_mapPanel.LayerCompositing == LayerCompositing.DimUnselected)
            {
                m_viewLayerCompositingMenuItem.Image
                    = m_viewLayerCompositingButton.Image
                    = Properties.Resources.ViewLayerCompositingShowAll;

                m_viewLayerCompositingMenuItem.Text = "Show All Layers";
                m_viewLayerCompositingButton.ToolTipText = "Show all layers";
            }
            else
            {
                m_viewLayerCompositingMenuItem.Image
                    = m_viewLayerCompositingButton.Image
                    = Properties.Resources.ViewLayerCompositingDimUnselected;

                m_viewLayerCompositingMenuItem.Text = "Dim Unselected Layers";
                m_viewLayerCompositingButton.ToolTipText = "Dim unselected layers";
            }
        }

        private void UpdateLayerOrderingControls()
        {
            Layer layer = m_mapPanel.SelectedLayer;

            if (layer == null)
                return;

            int layerIndex = m_map.Layers.IndexOf(layer);

            m_layerBringForwardMenuItem.Enabled
                = m_layerBringForwardButton.Enabled
                = layerIndex < m_map.Layers.Count - 1;

            m_layerSendBackwardMenuItem.Enabled
                = m_layerSendBackwardButton.Enabled
                = layerIndex > 0;
        }

        private void UpdateLayerControls()
        {
            UpdateLayerOrderingControls();

            UpdateLayerVisibilityControls();

            UpdateLayerCompositingControls();
        }

        private void UpdateTileGuidesControls()
        {
            bool tileGuides = m_mapPanel.TileGuides;

            m_viewTileGuidesButton.ToolTipText = tileGuides
                ? "Hide tile guides" : "Show tile guides";

            m_viewTileGuidesMenuItem.Image
                = m_viewTileGuidesButton.Image = tileGuides
                    ? Properties.Resources.VewTileGuidesHide
                    : Properties.Resources.VewTileGuidesShow;

            m_viewTileGuidesMenuItem.Text = tileGuides
                ? "Hide Tile Guides" : "Show Tile Guides";
        }

        private void UpdateTileSheetControls()
        {
            // properties and delete enabled if tile sheet selected
            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetPropertiesButton.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = m_tileSheetDeleteButton.Enabled
                = m_mapTreeView.SelectedComponent is TileSheet;

            // dependency button enabled if tile sheet selected and has dependencies
            m_tileSheetRemoveDependenciesMenuItem.Enabled
                = m_tileSheetRemoveDependenciesButton.Enabled
                = m_mapTreeView.SelectedComponent is TileSheet
                    && m_map.DependsOnTileSheet((TileSheet)m_mapTreeView.SelectedComponent);

            if (m_tilePicker.AutoUpdate)
            {
                m_tileSheetAutoUpdateMenuItem.Image = m_tileSheetAutoUpdateButton.Image
                    = Properties.Resources.TileSheetAutoUpdateDisable;
                m_tileSheetAutoUpdateMenuItem.Text = "Disable Auto Update";
                m_tileSheetAutoUpdateButton.ToolTipText = "Disable automatic update of tile sheets from disk";
            }
            else
            {
                m_tileSheetAutoUpdateMenuItem.Image = m_tileSheetAutoUpdateButton.Image
                    = Properties.Resources.TileSheetAutoUpdateEnable;
                m_tileSheetAutoUpdateMenuItem.Text = "Enable Auto Update";
                m_tileSheetAutoUpdateButton.ToolTipText = "Enable automatic update of tile sheets from disk";
            }
        }

        private void UpdateToolButtons()
        {
            EditTool editTool = m_mapPanel.EditTool;

            m_toolsSelectButton.Checked = editTool == EditTool.Select;
            m_toolsSingleTileButton.Checked = editTool == EditTool.SingleTile;
            m_toolsTileBlockButton.Checked = editTool == EditTool.TileBlock;
            m_toolsEraserButton.Checked = editTool == EditTool.Eraser;
            m_toolsDropperButton.Checked = editTool == EditTool.Dropper;
            m_toolsTileBrushButton.Checked = editTool == EditTool.TileBrush;
        }

        private void UpdateTileBrushDropDown()
        {
            m_toolsTileBrushButton.DropDown.Items.Clear();

            if (m_tileBrushCollection.TileBrushes.Count == 0)
            {
                m_mapPanel.SelectedTileBrush = null;
                return;
            }

            ToolStripMenuItem toolStripMenuItemLast = null;
            foreach (TileBrush tileBrush in m_tileBrushCollection.TileBrushes)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(tileBrush.Id, tileBrush.ImageRepresentation);
                toolStripMenuItem.Tag = tileBrush;
                toolStripMenuItem.Click += OnToolsTileBrushSelected;
                m_toolsTileBrushButton.DropDown.Items.Add(toolStripMenuItem);

                toolStripMenuItemLast = toolStripMenuItem;
            }

            toolStripMenuItemLast.Checked = true;
            m_mapPanel.SelectedTileBrush = (TileBrush)toolStripMenuItemLast.Tag;
        }

        private void UpdateAllControls()
        {
            UpdateEditorTitle();
            UpdateFileControls();
            UpdateEditControls();
            UpdateZoomControls();
            UpdateLayerVisibilityControls();
            UpdateTileSheetControls();
            UpdateToolButtons();
            UpdateTileBrushDropDown();

            m_mapTreeView.UpdateTree();
            m_tilePicker.UpdatePicker();
        }

        private void UpdateEditorTitle()
        {
            string shortName = Path.GetFileNameWithoutExtension(m_filename);
            this.Text = shortName + " - tIDE";
        }

        private string GetRelativePath(string basePath, string absolutePath)
        {
            basePath = basePath.Trim();
            absolutePath = absolutePath.Trim();

            if (!Path.IsPathRooted(basePath) || !Path.IsPathRooted(absolutePath))
                return absolutePath;

            // absolute path within base
            if (absolutePath.StartsWith(basePath))
                return absolutePath.Remove(0, basePath.Length);

            // remove common root
            while (basePath.Length > 0 && absolutePath.Length > 0)
            {
                if (char.ToLower(basePath[0]) == char.ToLower(absolutePath[0]))
                {
                    basePath = basePath.Remove(0, 1);
                    absolutePath = absolutePath.Remove(0, 1);
                }
                else
                    break;
            }

            int levels = basePath.Split(new char[] { Path.DirectorySeparatorChar }).Length;
            while (levels-- > 0)
                absolutePath = ".." + Path.DirectorySeparatorChar + absolutePath;

            return absolutePath;
        }

        private string GetAbsolutePath(string basePath, string relativePath)
        {
            basePath = basePath.Trim();
            relativePath = relativePath.Trim();

            if (!Path.IsPathRooted(basePath) || Path.IsPathRooted(relativePath))
                return relativePath;

            while (relativePath.StartsWith(".." + Path.DirectorySeparatorChar))
            {
                relativePath = relativePath.Remove(0, 3);
                int index = basePath.LastIndexOf(Path.DirectorySeparatorChar);
                if (index <= 2)
                    break;
                else
                    basePath = basePath.Remove(index + 1);
            }

            return basePath + relativePath;
        }

        private bool SaveFile(string filename)
        {
            FormatManager formatManager = FormatManager.Instance;

            string fileExtension
                = Path.GetExtension(filename).Replace(".", "");

            IMapFormat selectedMapFormat
                = formatManager.GetMapFormatByExtension(fileExtension);

            // make image source paths relative
            string basePath = Path.GetDirectoryName(filename);
            foreach (TileSheet tileSheet in m_map.TileSheets)
                tileSheet.ImageSource = GetRelativePath(basePath, tileSheet.ImageSource);

            try
            {
                Stream stream = new FileStream(filename, FileMode.Create);
                selectedMapFormat.Store(m_map, stream);
                stream.Close();

                // restore paths
                foreach (TileSheet tileSheet in m_map.TileSheets)
                    tileSheet.ImageSource = GetAbsolutePath(basePath, tileSheet.ImageSource);

                m_needsSaving = false;
                UpdateFileControls();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                    "An error occured whilst saving the file. Details: " + exception.Message,
                    "Save Map", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // restore paths
                foreach (TileSheet tileSheet in m_map.TileSheets)
                    tileSheet.ImageSource = GetAbsolutePath(basePath, tileSheet.ImageSource);

                return false;
            }
        }

        private void ShowHelp(HelpMode helpMode)
        {
            if (m_helpForm == null)
                m_helpForm = new HelpForm();
            if (m_helpForm.Visible)
                m_helpForm.BringToFront();
            else
                m_helpForm.Show();
            m_helpForm.HelpMode = helpMode;
        }

        private void OnMainFormLoad(object sender, EventArgs eventArgs)
        {
            Tiling.Format.FormatManager fm = Tiling.Format.FormatManager.Instance;

            m_windowMode = WindowMode.Windowed;
            m_windowBounds = this.Bounds;

            m_commandHistory = CommandHistory.Instance;

            m_tileBrushCollection = new TileBrushCollection();

            m_map = new Map("Untitled");
            m_needsSaving = false;
            m_filename = "Untitled.tide";
            this.Text = "Untitled - tIDE";

            m_mapTreeView.Map = m_map;
            m_tilePicker.Map = m_map;
            m_mapPanel.Map = m_map;
            m_mapPanel.TileBrushCollection = m_tileBrushCollection;

            m_selectedComponent = m_map;

            m_viewZoomComboBox.SelectedIndex = 0;

            ArrangeToolStripLayout();

            m_pluginManager = new PluginManager(m_menuStrip, m_toolStripContainer, m_mapPanel);
            OnPluginsReload(this, EventArgs.Empty);

            ArrangeToolStripLayout();
        }

        private void OnMainFormResizeEnd(object sender, EventArgs eventArgs)
        {
            ArrangeToolStripLayout();
        }

        private void OnMainFormClosing(object sender, FormClosingEventArgs formClosingEventArgs)
        {
            if (m_needsSaving &&
                MessageBox.Show(this,
                    "You have unsaved changes. Are you sure you want to exit the application?",
                    "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.No)
                formClosingEventArgs.Cancel = true;
        }

        private void OnCustomToolStripAdded(object sender, ControlEventArgs controlEventArgs)
        {
            ArrangeToolStripLayout();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.S:
                    m_mapPanel.EditTool = EditTool.Select;
                    UpdateToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.T:
                    m_mapPanel.EditTool = EditTool.SingleTile;
                    UpdateToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.B:
                    m_mapPanel.EditTool = EditTool.TileBlock;
                    UpdateToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.E:
                    m_mapPanel.EditTool = EditTool.Eraser;
                    UpdateToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.P:
                    m_mapPanel.EditTool = EditTool.Dropper;
                    UpdateToolButtons();
                    keyEventArgs.SuppressKeyPress = true;
                    break;
                case Keys.ControlKey:
                    m_mapPanel.CtrlKeyPressed = true;
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.ControlKey:
                    m_mapPanel.CtrlKeyPressed = false;
                    break;
            }
        }

        private void OnFileNew(object sender, EventArgs eventArgs)
        {
            if (MessageBox.Show(this, "Start a new map project?", "New map", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            Map map = new Map("Untitled Map");

            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(map);

            if (mapPropertiesDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_map = map;
                m_mapTreeView.Map = m_map;
                m_mapTreeView.UpdateTree();
                m_tilePicker.Map = map;
                m_mapPanel.Map = map;

                m_commandHistory.Clear();
                m_selectedComponent = null;
            }
        }

        private void OnFileOpen(object sender, EventArgs eventArgs)
        {
            if (m_needsSaving
                && MessageBox.Show(this,
                    "Any unsaved changes in the current map will be lost. Do you want to continue?",
                    "Open Map", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            FormatManager formatManager = FormatManager.Instance;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Map";
            openFileDialog.Filter = GenerateFileDialogFilter();
            openFileDialog.DefaultExt = formatManager.StandardFormat.FileExtension;
            openFileDialog.AddExtension = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            StartWaitCursor();

            string fileExtension
                = Path.GetExtension(openFileDialog.FileName).Replace(".", "");

            IMapFormat selectedMapFormat
                = formatManager.GetMapFormatByExtension(fileExtension);

            Map newMap = null;
            try
            {
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open);
                newMap = selectedMapFormat.Load(stream);
                stream.Close();

                // convert relative image source paths to absolute paths
                string basePath = Path.GetDirectoryName(openFileDialog.FileName);
                foreach (TileSheet tileSheet in newMap.TileSheets)
                    tileSheet.ImageSource = GetAbsolutePath(basePath, tileSheet.ImageSource);

                ClipBoardManager.Instance.StoreTileBrush(null);
                m_tileBrushCollection.TileBrushes.Clear();

                m_map = newMap;

                foreach (TileSheet tileSheet in m_map.TileSheets)
                    TileImageCache.Instance.Refresh(tileSheet);
                
                m_mapTreeView.Map = m_map;
                m_tilePicker.Map = m_map;
                m_mapPanel.Map = m_map;

                m_mapTreeView.UpdateTree();
                m_tilePicker.UpdatePicker();

                if (m_map.Layers.Count == 0)
                {
                    m_selectedComponent = null;
                    m_mapTreeView.SelectedComponent = null;
                }
                else
                {
                    m_selectedComponent = m_mapTreeView.SelectedComponent = m_map.Layers[m_map.Layers.Count - 1];
                }

                m_mapPanel.Enabled = true;
                m_mapPanel.Invalidate(true);

                m_needsSaving = false;
                m_filename = openFileDialog.FileName;
                m_commandHistory.Clear();
                UpdateAllControls();
            }
            catch (Exception exception)
            {
                MessageBox.Show(this,
                    "An error occured whilst opening the file. Details: " + exception.Message,
                    "Open Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            StopWaitCursor();
        }

        private void OnFileSave(object sender, EventArgs eventArgs)
        {
            SaveFile(m_filename);
        }

        private void OnFileSaveAs(object sender, EventArgs eventArgs)
        {
            FormatManager formatManager = FormatManager.Instance;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Map";
            saveFileDialog.Filter = GenerateFileDialogFilter();
            saveFileDialog.DefaultExt = formatManager.StandardFormat.FileExtension;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            string newFilename = saveFileDialog.FileName;
            if (SaveFile(newFilename))
            {
                m_filename = newFilename;
                UpdateEditorTitle();
            }
        }

        private void OnPageSetup(object sender, EventArgs e)
        {
            PrintManager.Instance.ShowPageSetupDialog(this);
        }

        private void OnPrintPreview(object sender, EventArgs e)
        {
            Layer selectedLayer = m_mapPanel.SelectedLayer;
            if (selectedLayer == null)
                return;

            PrintManager.Instance.ShowPrintPreviewDialog(this,
                m_mapPanel.GenerateImage(selectedLayer));
        }

        private void OnPrint(object sender, EventArgs eventArgs)
        {
            Layer selectedLayer = m_mapPanel.SelectedLayer;
            if (selectedLayer == null)
                return;

            PrintManager.Instance.Print(this,
                m_mapPanel.GenerateImage(selectedLayer));
        }

        private void OnFileExit(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void OnEditUndo(object sender, EventArgs eventArgs)
        {
            if (m_commandHistory.CanUndo())
                m_commandHistory.Undo();
            UpdateAllControls();
        }

        private void OnEditRedo(object sender, EventArgs eventArgs)
        {
            if (m_commandHistory.CanRedo())
                m_commandHistory.Redo();
            UpdateAllControls();
        }

        private void OnEditCut(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            TileSelection tileSelection = m_mapPanel.TileSelection;
            if (tileSelection.IsEmpty())
                return;

            Command command = new EditCutCommand(layer, tileSelection);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
        }

        private void OnEditCopy(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            TileSelection tileSelection = m_mapPanel.TileSelection;
            if (tileSelection.IsEmpty())
                return;

            Command command = new EditCopyCommand(layer, tileSelection);
            m_commandHistory.Do(command);

            UpdateEditControls();
        }

        private void OnEditPaste(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            TileSelection tileSelection = m_mapPanel.TileSelection;
            if (tileSelection.IsEmpty())
                return;

            if (!ClipBoardManager.Instance.HasTileBrush())
                return;

            TileBrush tileBrush = ClipBoardManager.Instance.RetrieveTileBrush();
            Command command = new EditPasteCommand(layer, tileBrush,
                tileSelection.Bounds.Location, tileSelection, true);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
        }

        private void OnEditDelete(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Command command = new EditDeleteCommand(layer, m_mapPanel.TileSelection);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
        }

        private void OnEditSelectAll(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Command command = new EditChangeSelectionCommand(layer,
                m_mapPanel.TileSelection, ChangeSelectionType.SelectAll);
            m_commandHistory.Do(command);

            UpdateEditControls();
        }

        private void OnEditClearSelection(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Command command = new EditChangeSelectionCommand(layer,
                m_mapPanel.TileSelection, ChangeSelectionType.Clear);
            m_commandHistory.Do(command);

            UpdateEditControls();
        }

        private void OnEditInvertSelection(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Command command = new EditChangeSelectionCommand(layer,
                m_mapPanel.TileSelection, ChangeSelectionType.Invert);
            m_commandHistory.Do(command);

            UpdateEditControls();
        }

        private void OnEditMakeTileBrush(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            TileSelection tileSelection = m_mapPanel.TileSelection;
            if (tileSelection.IsEmpty())
                return;

            string tileBrushId = m_tileBrushCollection.GenerateId();
            TileBrush newTileBrush = new TileBrush(tileBrushId, layer, tileSelection);

            TileBrushDialog tileBrushDialog = new TileBrushDialog(m_tileBrushCollection, newTileBrush);
            if (tileBrushDialog.ShowDialog(this) == DialogResult.OK)
            {
                UpdateTileBrushDropDown();
                m_mapPanel.TileSelection.Clear();

                OnToolsTileBrush(sender, eventArgs);

                UpdateTileBrushDropDown();
                UpdateEditControls();
            }
        }

        private void OnEditManageTileBrushes(object sender, EventArgs eventArgs)
        {
            TileBrushDialog tileBrushDialog = new TileBrushDialog(m_tileBrushCollection);
            tileBrushDialog.ShowDialog(this);

            UpdateTileBrushDropDown();
            UpdateEditControls();
        }

        private void OnViewZoom(object sender, EventArgs eventArgs)
        {
            ToolStripDropDownItem toolStripDropDownItem = (ToolStripDropDownItem)sender;
            if (toolStripDropDownItem.Tag == null)
                return;
            int zoom = int.Parse(toolStripDropDownItem.Tag.ToString());
            m_mapPanel.Zoom = zoom;

            UpdateZoomControls();
        }

        private void OnViewZoomComboBox(object sender, EventArgs eventArgs)
        {
            m_mapPanel.Zoom = m_viewZoomComboBox.SelectedIndex + 1;
            UpdateZoomControls();
            m_viewToolStrip.Focus();
        }

        private void OnViewZoomIn(object sender, EventArgs eventArgs)
        {
            if (m_mapPanel.Zoom == 10)
                return;

            ++m_mapPanel.Zoom;
            UpdateZoomControls();
        }

        private void OnViewZoomOut(object sender, EventArgs eventArgs)
        {
            if (m_mapPanel.Zoom == 1)
                return;

            --m_mapPanel.Zoom;
            UpdateZoomControls();
        }

        private void OnViewWindowMode(object sender, EventArgs eventArgs)
        {
            if (m_windowMode == WindowMode.Windowed)
            {
                m_windowBounds = this.Bounds;

                this.FormBorderStyle = FormBorderStyle.None;
                int splitterWidth = m_splitContainerLeftRight.SplitterDistance;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                m_splitContainerLeftRight.SplitterDistance = splitterWidth;

                m_windowMode = WindowMode.Fullscreen;
                m_viewWindowModeMenuItem.Image
                    = m_viewWindowModeButton.Image
                    = Properties.Resources.ViewWindowed;
                m_viewWindowModeMenuItem.Text = "Windowed";
                m_viewWindowModeButton.ToolTipText = "View in windowed mode";
                 
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                int splitterWidth = m_splitContainerLeftRight.SplitterDistance;
                this.Bounds = m_windowBounds;
                m_splitContainerLeftRight.SplitterDistance = splitterWidth;

                m_windowMode = WindowMode.Windowed;
                m_viewWindowModeMenuItem.Image 
                    = m_viewWindowModeButton.Image
                    = Properties.Resources.ViewFullScreen;
                m_viewWindowModeMenuItem.Text = "Full Screen";
                m_viewWindowModeButton.ToolTipText = "View in full screen mode";
            }
        }

        private void OnViewLayerCompositing(object sender, EventArgs eventArgs)
        {
            m_mapPanel.LayerCompositing
                = m_mapPanel.LayerCompositing == LayerCompositing.DimUnselected
                ? LayerCompositing.ShowAll
                : LayerCompositing.DimUnselected;
            UpdateLayerCompositingControls();
        }

        private void OnViewTileGuides(object sender, EventArgs eventArgs)
        {
            m_mapPanel.TileGuides = !m_mapPanel.TileGuides;
            UpdateTileGuidesControls();
        }

        private void OnViewViewportScaleToWindow(object sender, EventArgs eventArgs)
        {
            m_mapPanel.AutoScaleViewport = true;
            foreach (ToolStripMenuItem toolStripMenuItem in m_viewViewportMenuItem.DropDownItems)
                toolStripMenuItem.Checked
                    = toolStripMenuItem == m_viewViewportScaleToWindowMenuItem;
        }

        private void OnViewViewportSetSize(object sender, EventArgs eventArgs)
        {
            ToolStripMenuItem toolStripMenuItemSelected = (ToolStripMenuItem)sender;
            string sizeTag = toolStripMenuItemSelected.Tag.ToString();
            Size viewPortSize = Tiling.Dimensions.Size.FromString(sizeTag);

            Rectangle viewport = new Rectangle(
                Tiling.Dimensions.Location.Origin, viewPortSize);

            m_mapPanel.AutoScaleViewport = false;
            m_mapPanel.Viewport = viewport;

            foreach (ToolStripMenuItem toolStripMenuItem in m_viewViewportMenuItem.DropDownItems)
                toolStripMenuItem.Checked
                    = toolStripMenuItem == toolStripMenuItemSelected;
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map);

            if (mapPropertiesDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_needsSaving = true;
                UpdateFileControls();
                UpdateEditControls();
                m_mapTreeView.UpdateTree();
            }
        }

        private void OnMapStatistics(object sender, EventArgs eventArgs)
        {
            MapStatisticsDialog mapStatisticsDialog = new MapStatisticsDialog(m_map);
            mapStatisticsDialog.ShowDialog(this);
        }

        private void OnLayerNew(object sender, EventArgs eventArgs)
        {
            Size tileSize = m_map.TileSheets.Count > 0
                ? m_map.TileSheets[0].TileSize
                : new Size(8, 8);

            Layer layer = new Layer("untitled layer", m_map,
                new Size(100, 25), tileSize);
            LayerPropertiesDialog layerPropertiesDialog = new LayerPropertiesDialog(layer, true);

            if (layerPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_mapPanel.Enabled = true;

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = layer;

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerControls();
        }

        private void OnLayerProperties(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;
            LayerPropertiesDialog layerPropertiesDialog
                = new LayerPropertiesDialog(layer, false);

            if (layerPropertiesDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_mapTreeView.UpdateTree();

                m_needsSaving = true;
                UpdateFileControls();
                UpdateEditControls();
                UpdateLayerControls();
            }
        }

        private void OnLayerVisibility(object sender, EventArgs eventArgs)
        {
            Layer layer = m_mapPanel.SelectedLayer;

            if (layer == null)
                return;

            Command command = new LayerVisibilityCommand(layer, !layer.Visible);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerVisibilityControls();
        }

        private void OnLayerBringForward(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;

            Command command = new LayerOrderCommand(layer, LayerOrderCommandType.BringForward);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = layer;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerControls();
        }

        private void OnLayerSendBackward(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;

            Command command = new LayerOrderCommand(layer, LayerOrderCommandType.SendBackward);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = layer;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerControls();
        }

        private void OnLayerDelete(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;

            Command command = new LayerDeleteCommand(m_map, layer, m_mapTreeView);
            m_commandHistory.Do(command);

            if (m_map.Layers.Count == 0)
                m_mapPanel.Enabled = false;

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerControls();
        }

        private void OnTileSheetNew(object sender, EventArgs eventArgs)
        {
            TileSheet tileSheet = new TileSheet("untitled tile sheet", m_map, "",
                new Size(8, 8), new Size(8, 8));
            TileSheetPropertiesDialog tileSheetPropertiesDialog
                = new TileSheetPropertiesDialog(tileSheet, true, m_mapTreeView);

            if (tileSheetPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            StartWaitCursor();

            m_mapPanel.LoadTileSheet(tileSheet);

            StopWaitCursor();

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateTileSheetControls();
            m_tilePicker.UpdatePicker();
        }

        private void OnTileSheetProperties(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;
            TileSheetPropertiesDialog TileSheetPropertiesDialog
                = new TileSheetPropertiesDialog(tileSheet, false, m_mapTreeView);

            if (TileSheetPropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            StartWaitCursor();

            m_tilePicker.UpdatePicker();
            m_tilePicker.RefreshSelectedTileSheet();

            StopWaitCursor();

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateTileSheetControls();
            m_mapTreeView.UpdateTree();
        }

        private void OnTileSheetAutoUpdate(object sender, EventArgs eventArgs)
        {
            m_tilePicker.AutoUpdate = !m_tilePicker.AutoUpdate;
            UpdateTileSheetControls();
        }

        private void OnTileSheetRemoveDependencies(object sender, EventArgs e)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;

            if (MessageBox.Show(this,
                "Remove all dependencies on this tile sheet?",
                "Remove dependencies on Tile Sheet \"" + tileSheet.Id + "\"", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            Command command = new TileSheetRemoveDependencyCommand(m_map, tileSheet);
            m_commandHistory.Do(command);

            UpdateEditControls();
            m_tileSheetRemoveDependenciesMenuItem.Enabled
                = m_tileSheetRemoveDependenciesButton.Enabled = false;
        }

        private void OnTileSheetDelete(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;

            if (m_map.DependsOnTileSheet(tileSheet))
            {
                MessageBox.Show("At least one layer is using tiles from this Tile Sheet. Use the Remove Dependencies command or manually clear or replace these tiles",
                     "Delete Tile Sheet \"" + tileSheet.Id + "\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to delete this Tile Sheet?",
                "Delete Tile Sheet \"" + tileSheet.Id + "\"",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            Command command = new TileSheetDeleteCommand(m_map, tileSheet, m_mapTreeView);
            m_commandHistory.Do(command);

            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetPropertiesButton.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = m_tileSheetDeleteButton.Enabled = false;

            m_tilePicker.UpdatePicker();

            m_mapPanel.DisposeTileSheet(tileSheet);

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateTileSheetControls();
            m_selectedComponent = m_mapTreeView.SelectedComponent;
        }

        private void OnPluginsReload(object sender, EventArgs eventArgs)
        {
            m_pluginManager.UnloadPlugins();
            m_pluginManager.LoadPlugins();
        }

        private void OnHelpContents(object sender, EventArgs eventArgs)
        {
            ShowHelp(HelpMode.Contents);
        }

        private void OnHelpIndex(object sender, EventArgs eventArgs)
        {
            ShowHelp(HelpMode.Index);
        }

        private void OnHelpSearch(object sender, EventArgs eventArgs)
        {
            ShowHelp(HelpMode.Search);
        }

        private void OnHelpAbout(object sender, EventArgs eventArgs)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void OnPickerTileSelected(object sender, TilePickerEventArgs tilePickerEventArgs)
        {
            m_mapPanel.SelectedTileSheet = tilePickerEventArgs.TileSheet;
            m_mapPanel.SelectedTileIndex = tilePickerEventArgs.TileIndex;

            m_mapPanel.TileSelection.Clear();

            if (m_mapPanel.EditTool == EditTool.Select
                || m_mapPanel.EditTool == EditTool.Dropper
                || m_mapPanel.EditTool == EditTool.Eraser)
            {
                m_mapPanel.EditTool = EditTool.SingleTile;
                UpdateToolButtons();
            }
        }

        private void OnTreeComponentChanged(object sender, MapTreeViewEventArgs mapTreeViewEventArgs)
        {
            Tiling.ObjectModel.Component component = mapTreeViewEventArgs.Component;

            // enable/disable layer menu items as applicable
            bool layerSelected = component != null && component is Layer;

            m_mapPanel.Enabled = layerSelected;

            m_layerPropertiesMenuItem.Enabled
                = m_layerPropertiesButton.Enabled
                = m_layerVisibilityMenuItem.Enabled
                = m_layerVisibilityButton.Enabled
                = m_layerDeleteMenuItem.Enabled
                = m_layerDeleteButton.Enabled
                = layerSelected;

            // print commands
            m_filePageSetupMenuItem.Enabled
                = m_filePageSetupButton.Enabled
                = m_filePrintPreviewMenuItem.Enabled
                = m_filePrintPreviewButton.Enabled
                = m_filePrintMenuItem.Enabled
                = m_filePrintButton.Enabled
                = layerSelected;

            if (layerSelected)
            {
                Layer layer = (Layer)component;

                m_mapPanel.SelectedLayer = layer;
            }
            else
            {
                m_mapPanel.SelectedLayer = null;
            }

            m_selectedComponent = component;

            UpdateEditControls();
            UpdateLayerOrderingControls();

            // enable/disable tile sheet menu items as applicable
            UpdateTileSheetControls();
        }

        private void OnToolsSelect(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Select;
            UpdateToolButtons();
        }

        private void OnToolsSingleTile(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.SingleTile;
            m_mapPanel.TileSelection.Clear();
            UpdateToolButtons();
        }

        private void OnToolsTileBlock(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.TileBlock;
            m_mapPanel.TileSelection.Clear();
            UpdateToolButtons();
        }

        private void OnToolsEraser(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Eraser;
            m_mapPanel.TileSelection.Clear();
            UpdateToolButtons();
        }

        private void OnToolsDropper(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Dropper;
            m_mapPanel.TileSelection.Clear();
            UpdateToolButtons();
        }

        private void OnToolsTileBrush(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.TileBrush;
            UpdateToolButtons();
        }

        private void OnToolsTileBrushSelected(object sender, EventArgs eventArgs)
        {
            ToolStripMenuItem toolStripMenuItemSelected = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem toolStripMenuItem in m_toolsTileBrushButton.DropDownItems)
            {
                bool matched = toolStripMenuItem == toolStripMenuItemSelected;
                toolStripMenuItem.Checked = matched;
                if (matched)
                {
                    TileBrush tileBrush = (TileBrush)toolStripMenuItem.Tag;
                    m_mapPanel.SelectedTileBrush = tileBrush;
                }
            }

            if (m_mapPanel.EditTool != EditTool.TileBrush)
            {
                m_mapPanel.EditTool = EditTool.TileBrush;
                UpdateToolButtons();
            }
        }

        private void OnMapChanged(object sender, EventArgs eventArgs)
        {
            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
        }

        private void OnMapTilePicked(MapPanelEventArgs mapPanelEventArgs)
        {
            Tile tile = mapPanelEventArgs.Tile;
            if (tile != null)
            {
                m_tilePicker.SelectedTileSheet = tile.TileSheet;
                m_tilePicker.SelectedTileIndex = tile.TileIndex;
            }

            UpdateToolButtons();
        }

        private void OnTileHover(MapPanelEventArgs mapPanelEventArgs)
        {
            Tile tile = mapPanelEventArgs.Tile;
            Location tileLocation = mapPanelEventArgs.Location;
            m_tileLocationStatusLabel.Text = "Pos " + mapPanelEventArgs.Location.ToString();

            m_tileSheetStatusLabel.Text = tile == null ? "" : "Tsh " + tile.TileSheet.Id;

            m_tileIndexStatusLabel.Text = tile == null ? "" : "Idx " + tile.TileIndex;

            m_tilePropertiesStatusLabel.Visible = tile != null && tile.Properties.Count > 0;
        }

        private void OnTileSelectionChanged(object sender, EventArgs eventArgs)
        {
            UpdateEditControls();
        }

        private void OnTilePropertiesChanged(MapPanelEventArgs mapPanelEventArgs)
        {
            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
        }

        #endregion

        #region Public Methods

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion
    }
}
