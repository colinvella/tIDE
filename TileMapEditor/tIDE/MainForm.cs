using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;
using xTile.Format;
using xTile.Layers;
using xTile.ObjectModel;
using xTile.Tiles;

using TileMapEditor.AutoTiles;
using TileMapEditor.Commands;
using TileMapEditor.Controls;
using TileMapEditor.Dialogs;
using TileMapEditor.Format;
using TileMapEditor.Help;
using TileMapEditor.Plugin;
using TileMapEditor.TileBrushes;
using System.Globalization;
using System.Threading;
using TileMapEditor.Localisation;

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

        private string[] m_arguments;

        private WindowMode m_windowMode;
        private System.Drawing.Rectangle m_windowBounds;

        private Map m_map;

        private CommandHistory m_commandHistory;
        private xTile.ObjectModel.Component m_selectedComponent;
        private TileBrushCollection m_tileBrushCollection;
        private bool m_needsSaving;
        private string m_filename;

        private CommandHistoryDialog m_commandHistoryDialog;

        private PluginManager m_pluginManager;

        private HelpForm m_helpForm;

        #endregion

        #region Private Methods

        private void RegisterFileFormats()
        {
            // Tiled TMX format
            xTile.Format.FormatManager.Instance.RegisterMapFormat(new TiledTmxFormat());
        }

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

            toolStripPanel.Hide();

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

            toolStripPanel.Show();
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

        private void UpdateRecentFilesMenu()
        {
            StringCollection filenames = RecentFilesManager.Filenames;
            m_fileRecentFilesMenuItem.Enabled = filenames.Count > 0;
            m_fileRecentFilesMenuItem.DropDownItems.Clear();
            foreach (string filename in filenames)
                m_fileRecentFilesMenuItem.DropDownItems.Add(filename, Properties.Resources.FileOpen, OnFileOpenRecent);
        }

        private void UpdateFileControls()
        {
            m_fileSaveMenuItem.Enabled
                = m_fileSaveButton.Enabled
                = m_needsSaving;

            UpdateRecentFilesMenu();
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

            // history
            m_editHistoryMenuItem.Enabled = m_editHistoryButton.Enabled
                = m_commandHistory.CanUndo() || m_commandHistory.CanRedo();

            m_editUndoButton.ToolTipText
                = "Undo: " + m_commandHistory.UndoDescription;
            m_editRedoButton.ToolTipText
                = "Redo: " + m_commandHistory.RedoDescription;

            if (m_commandHistoryDialog != null
                && !m_commandHistoryDialog.IsDisposed)
                m_commandHistoryDialog.UpdateHistory();

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

            m_layerMakeInvisibleMenuItem.Enabled
                = m_layerMakeVisibleMenuItem.Enabled
                = m_layerMakeInvisibileButton.Enabled
                = m_layerMakeVisibileButton.Enabled
                = layer != null;

            if (layer == null)
                return;

            bool visible = layer.Visible;

            m_layerMakeInvisibleMenuItem.Visible = visible;
            m_layerMakeVisibleMenuItem.Visible = !visible;

            m_layerToolStrip.SuspendLayout();
            m_layerMakeInvisibileButton.Visible = visible;
            m_layerMakeVisibileButton.Visible = !visible;
            m_layerToolStrip.ResumeLayout();

            m_mapTreeView.UpdateTree();
        }

        private void UpdateLayerCompositingControls()
        {
            bool showAll = m_mapPanel.LayerCompositing == LayerCompositing.ShowAll;
            m_viewLayersShowAllMenuItem.Visible = !showAll;
            m_viewLayersHighlightSelectedMenuItem.Visible = showAll;

            m_viewToolStrip.SuspendLayout();
            m_viewLayersShowAllButton.Visible = !showAll;
            m_viewLayersHighlightSelectedButton.Visible = showAll;
            m_viewToolStrip.ResumeLayout();
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
            Layer layer = m_mapPanel.SelectedLayer;

            m_layerPropertiesMenuItem.Enabled
                = m_layerPropertiesButton.Enabled
                = m_layerOffsetMenuItem.Enabled
                = m_layerOffsetButton.Enabled
                = m_layerDeleteMenuItem.Enabled
                = m_layerDeleteButton.Enabled
                = layer != null;

            UpdateLayerOrderingControls();

            UpdateLayerVisibilityControls();

            UpdateLayerCompositingControls();
        }

        private void UpdateTileGuidesControls()
        {
            bool tileGuides = m_mapPanel.TileGuides;

            /*
            m_viewShowTileGuidesButton.ToolTipText = tileGuides
                ? "Hide tile guides" : "Show tile guides";

            m_viewShowTileGuidesMenuItem.Image
                = m_viewShowTileGuidesButton.Image = tileGuides
                    ? Properties.Resources.VewTileGuidesHide
                    : Properties.Resources.VewTileGuidesShow;

            m_viewShowTileGuidesMenuItem.Text = tileGuides
                ? "Hide Tile Guides" : "Show Tile Guides";*/
            m_viewShowTileGuidesMenuItem.Visible = !tileGuides;
            m_viewHideTileGuidesMenuItem.Visible = tileGuides;

            m_viewToolStrip.SuspendLayout();
            m_viewShowTileGuidesButton.Visible = !tileGuides;
            m_viewHideTileGuidesButton.Visible = tileGuides;
            m_viewToolStrip.ResumeLayout();
        }

        private void UpdateTileSheetControls()
        {
            // properties, auto tiles and delete enabled if tile sheet selected
            m_tileSheetPropertiesMenuItem.Enabled
                = m_tileSheetPropertiesButton.Enabled
                = m_tileSheetAutoTilesMenuItem.Enabled
                = m_tileSheetAutoTilesButton.Enabled
                = m_tileSheetDeleteMenuItem.Enabled
                = m_tileSheetDeleteButton.Enabled
                = m_mapTreeView.SelectedComponent is TileSheet;

            // dependency button enabled if tile sheet selected and has dependencies
            m_tileSheetRemoveDependenciesMenuItem.Enabled
                = m_tileSheetRemoveDependenciesButton.Enabled
                = m_mapTreeView.SelectedComponent is TileSheet
                    && m_map.DependsOnTileSheet((TileSheet)m_mapTreeView.SelectedComponent);

            // auto update
            bool autoUpdate = m_tilePicker.AutoUpdate;
            m_tileSheetAutoUpdateEnableMenuItem.Visible = !autoUpdate;
            m_tileSheetAutoUpdateDisableMenuItem.Visible = autoUpdate;

            m_tileSheetToolStrip.SuspendLayout();
            m_tileSheetAutoUpdateEnableButton.Visible = !autoUpdate;
            m_tileSheetAutoUpdateDisableButton.Visible = autoUpdate;
            m_tileSheetToolStrip.ResumeLayout();
        }

        private void UpdateToolButtons()
        {
            EditTool editTool = m_mapPanel.EditTool;

            m_toolsSelectButton.Checked = editTool == EditTool.Select;
            m_toolsSingleTileButton.Checked = editTool == EditTool.SingleTile;
            m_toolsTileBlockButton.Checked = editTool == EditTool.TileBlock;
            m_toolsEraserButton.Checked = editTool == EditTool.Eraser;
            m_toolsDropperButton.Checked = editTool == EditTool.Dropper;
            m_toolsTextureButton.Checked = editTool == EditTool.Texture;
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
            UpdateLayerControls();
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

        private void OpenFile(string filename)
        {
            FormatManager formatManager = FormatManager.Instance;

            StartWaitCursor();
            
            string basePath = Path.GetDirectoryName(filename);
            string oldCurrentDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(basePath);
            
            Map newMap = null;
            try
            {
                newMap = formatManager.LoadMap(filename);

                RecentFilesManager.StoreFilename(filename);

                // convert relative image source paths to absolute paths
                foreach (TileSheet tileSheet in newMap.TileSheets)
                    tileSheet.ImageSource = PathHelper.GetAbsolutePath(basePath, tileSheet.ImageSource);

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
                m_filename = filename;
                m_commandHistory.Clear();

                // refresh tile brush definitions
                m_tileBrushCollection.LoadFromMap(m_map);

                // refresh auto tile definitions
                AutoTileManager.Instance.Refresh(m_map);

                // push to top of recent file list
                RecentFilesManager.StoreFilename(filename);

                UpdateAllControls();
            }
            catch (Exception exception)
            {
                m_loadErrorMessageBox.VariableDictionary["message"] = exception.Message;
                m_loadErrorMessageBox.Show();                   
            }

            Directory.SetCurrentDirectory(oldCurrentDirectory);

            StopWaitCursor();
        }

        private bool SaveFile(string filename)
        {
            FormatManager formatManager = FormatManager.Instance;

            string fileExtension
                = Path.GetExtension(filename).Replace(".", "");

            IMapFormat selectedMapFormat
                = formatManager.GetMapFormatByExtension(fileExtension);

            // check format compatibility
            CompatibilityReport compatibilityReport = selectedMapFormat.DetermineCompatibility(m_map);

            // show incompatibilities if not Full
            CompatibilityLevel compatibilityLevel = compatibilityReport.CompatibilityLevel;
            if (compatibilityLevel != CompatibilityLevel.Full)
            {
                FormatCompatibilityDialog formatCompatibilityDialog
                    = new FormatCompatibilityDialog(compatibilityReport);
                if (formatCompatibilityDialog.ShowDialog(this) == DialogResult.Cancel)
                    return false;
            }

            // make image source paths relative
            string basePath = Path.GetDirectoryName(filename);
            foreach (TileSheet tileSheet in m_map.TileSheets)
                tileSheet.ImageSource = PathHelper.GetRelativePath(basePath, tileSheet.ImageSource);

            try
            {
                Stream stream = new FileStream(filename, FileMode.Create);
                selectedMapFormat.Store(m_map, stream);
                stream.Close();

                // restore paths
                foreach (TileSheet tileSheet in m_map.TileSheets)
                    tileSheet.ImageSource = PathHelper.GetAbsolutePath(basePath, tileSheet.ImageSource);

                m_needsSaving = false;
                RecentFilesManager.StoreFilename(filename);
                UpdateFileControls();
                return true;
            }
            catch (Exception exception)
            {
                m_saveErrorMessageBox.VariableDictionary["message"] = exception.Message;
                m_saveErrorMessageBox.Show();                   

                // restore paths
                foreach (TileSheet tileSheet in m_map.TileSheets)
                    tileSheet.ImageSource = PathHelper.GetAbsolutePath(basePath, tileSheet.ImageSource);

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
            xTile.Format.FormatManager fm = xTile.Format.FormatManager.Instance;

            m_windowMode = WindowMode.Windowed;
            m_windowBounds = this.Bounds;

            // register supported formats for xTile
            RegisterFileFormats();

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

            UpdateRecentFilesMenu();
            ArrangeToolStripLayout();

            // handle opening by file association or command line
            if (m_arguments.Length == 1 && m_arguments[0].ToLower().EndsWith(".tide"))
                OpenFile(m_arguments[0]);
        }

        private void OnMainFormResizeEnd(object sender, EventArgs eventArgs)
        {
            ArrangeToolStripLayout();
        }

        private void OnMainFormClosing(object sender, FormClosingEventArgs formClosingEventArgs)
        {
            if (m_needsSaving &&
                m_unsavedMessageBox.Show() == DialogResult.No)
                formClosingEventArgs.Cancel = true;
        }

        private void OnCustomToolStripAdded(object sender, ControlEventArgs controlEventArgs)
        {
            ArrangeToolStripLayout();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Layer selectedLayer = null;
            if (m_selectedComponent != null
                && m_selectedComponent is Layer)
                selectedLayer = (Layer)m_selectedComponent;

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
                case Keys.Left:
                    if (selectedLayer != null)
                    {
                        Rectangle viewport = m_mapPanel.Viewport;
                        viewport.X = Math.Max(0,
                            viewport.X - selectedLayer.TileSize.Width);
                        m_mapPanel.Viewport = viewport;
                        keyEventArgs.Handled = true;
                    }    
                    break;
                case Keys.Right:
                    if (selectedLayer != null)
                    {
                        Rectangle viewport = m_mapPanel.Viewport;
                        viewport.X = Math.Min(m_map.DisplaySize.Width - viewport.Width,
                            viewport.X + selectedLayer.TileSize.Width);
                        m_mapPanel.Viewport = viewport;
                        keyEventArgs.Handled = true;
                    }
                    break;
                case Keys.Up:
                    if (selectedLayer != null)
                    {
                        Rectangle viewport = m_mapPanel.Viewport;
                        viewport.Y = Math.Max(0,
                            viewport.Y - selectedLayer.TileSize.Height);
                        m_mapPanel.Viewport = viewport;
                        keyEventArgs.Handled = true;
                    }
                    break;
                case Keys.Down:
                    if (selectedLayer != null)
                    {
                        Rectangle viewport = m_mapPanel.Viewport;
                        viewport.Y = Math.Min(m_map.DisplaySize.Height - viewport.Height,
                            viewport.Y + selectedLayer.TileSize.Height);
                        m_mapPanel.Viewport = viewport;
                        keyEventArgs.Handled = true;
                    }
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
            if (!m_needsSaving
                && m_unsavedMessageBox.Show() == DialogResult.No)
                return;

            Map map = new Map("Untitled Map");

            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(map, true);

            if (mapPropertiesDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_map = map;
                m_mapTreeView.Map = m_map;
                m_mapTreeView.UpdateTree();
                m_tilePicker.Map = map;
                m_mapPanel.Map = map;

                m_commandHistory.Clear();
                m_selectedComponent = null;

                // refresh tile brush definitions
                m_tileBrushCollection.LoadFromMap(m_map);

                // refresh auto tile definitions
                AutoTileManager.Instance.Refresh(m_map);

                UpdateAllControls();
            }
        }

        private void OnFileOpen(object sender, EventArgs eventArgs)
        {
            if (m_needsSaving &&
                m_unsavedMessageBox.Show() == DialogResult.No) return;

            FormatManager formatManager = FormatManager.Instance;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Map";
            openFileDialog.Filter = GenerateFileDialogFilter();
            openFileDialog.DefaultExt = formatManager.DefaultFormat.FileExtension;
            openFileDialog.AddExtension = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            OpenFile(openFileDialog.FileName);
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
            saveFileDialog.DefaultExt = formatManager.DefaultFormat.FileExtension;
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(m_filename);
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(m_filename);

            if (saveFileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            string newFilename = saveFileDialog.FileName;
            if (SaveFile(newFilename))
            {
                m_filename = newFilename;
                UpdateEditorTitle();
            }
        }

        private void OnFilePageSetup(object sender, EventArgs e)
        {
            PrintManager.Instance.ShowPageSetupDialog(this);
        }

        private void OnFilePrintPreview(object sender, EventArgs e)
        {
            Layer selectedLayer = m_mapPanel.SelectedLayer;
            if (selectedLayer == null)
                return;

            PrintManager.Instance.ShowPrintPreviewDialog(this,
                m_mapPanel.GenerateImage(selectedLayer));
        }

        private void OnFilePrint(object sender, EventArgs eventArgs)
        {
            Layer selectedLayer = m_mapPanel.SelectedLayer;
            if (selectedLayer == null)
                return;

            PrintManager.Instance.Print(this,
                m_mapPanel.GenerateImage(selectedLayer));
        }

        private void OnFileOptions(object sender, EventArgs eventArgs)
        {
            OptonsDialog optionsDialog = new OptonsDialog();
            if (optionsDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            Visible = false;
            LanguageManager.ApplyLanguage(this);
            ArrangeToolStripLayout();
            UpdateRecentFilesMenu();
            m_mapTreeView.UpdateTree();
            Visible = true;
        }

        private void OnFileOpenRecent(object sender, EventArgs eventArgs)
        {
            if (m_needsSaving &&
                m_unsavedMessageBox.Show() == DialogResult.No)
                return;

            string filename = ((ToolStripMenuItem)sender).Text;

            if (File.Exists(filename))
            {
                OpenFile(filename);
            }
            else
            {
                if (MessageBox.Show(this,
                    "Cannot find this file. Do you want to remove it from the Recent Files list?",
                    "Open file " + filename,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    RecentFilesManager.RemoveFilename(filename);
                    UpdateRecentFilesMenu();
                }
            }
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

        private void OnEditHistory(object sender, EventArgs eventArgs)
        {
            if (m_commandHistoryDialog == null ||
                m_commandHistoryDialog.IsDisposed)
            {
                m_commandHistoryDialog = new CommandHistoryDialog();
                m_commandHistoryDialog.HistoryChanged +=new HistoryChangedHandler(OnCommandHistoryChanged);
                m_commandHistoryDialog.Show(this);

                // CenterParent does not work with SizableToolWindow
                m_commandHistoryDialog.Location = new System.Drawing.Point(
                    Location.X + (Width - m_commandHistoryDialog.Width) / 2,
                    Location.Y + (Height - m_commandHistoryDialog.Height) / 2);
            }
            else
                m_commandHistoryDialog.Visible = true;
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

            TileBrushDialog tileBrushDialog
                = new TileBrushDialog(m_map, m_tileBrushCollection, newTileBrush);
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
            TileBrushDialog tileBrushDialog
                = new TileBrushDialog(m_map, m_tileBrushCollection);
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

        private void OnZoomChanged(object sender, EventArgs eventArgs)
        {
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
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                int splitterWidth = m_splitContainerLeftRight.SplitterDistance;
                this.Bounds = m_windowBounds;
                m_splitContainerLeftRight.SplitterDistance = splitterWidth;

                m_windowMode = WindowMode.Windowed;
            }

            m_viewFullScreenMenuItem.Visible = m_windowMode == WindowMode.Windowed;
            m_viewWindowedMenuItem.Visible = m_windowMode == WindowMode.Fullscreen;

            m_viewToolStrip.SuspendLayout();
            m_viewFullScreenButton.Visible = m_windowMode == WindowMode.Windowed;
            m_viewWindowedButton.Visible = m_windowMode == WindowMode.Fullscreen;
            m_viewToolStrip.ResumeLayout();
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
            Size viewPortSize = xTile.Dimensions.Size.FromString(sizeTag);

            Rectangle viewport = new Rectangle(
                xTile.Dimensions.Location.Origin, viewPortSize);

            m_mapPanel.AutoScaleViewport = false;
            m_mapPanel.Viewport = viewport;

            foreach (ToolStripMenuItem toolStripMenuItem in m_viewViewportMenuItem.DropDownItems)
                toolStripMenuItem.Checked
                    = toolStripMenuItem == toolStripMenuItemSelected;
        }

        private void OnMapProperties(object sender, EventArgs eventArgs)
        {
            MapPropertiesDialog mapPropertiesDialog = new MapPropertiesDialog(m_map, false);

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
            MapStatisticsDialog mapStatisticsDialog = new MapStatisticsDialog(m_map, m_mapPanel.Viewport);
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

        private void OnLayerOffset(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is Layer))
                return;

            Layer layer = (Layer)m_selectedComponent;
            LayerOffsetDialog layerOffsetDialog
                = new LayerOffsetDialog(layer);

            if (layerOffsetDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateLayerControls();
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

        private void OnTileSheetAutoTiles(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;

            AutoTileDialog autoTileDialog = new AutoTileDialog(tileSheet);

            if (autoTileDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            StartWaitCursor();

            m_needsSaving = true;
            UpdateFileControls();
            UpdateEditControls();
            UpdateTileSheetControls();
            m_mapTreeView.UpdateTree();

            AutoTileManager.Instance.Refresh(tileSheet);

            StopWaitCursor();
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

            Command command = new TileSheetRemoveDependencyCommand(m_map, tileSheet);
            m_commandHistory.Do(command);

            m_needsSaving = true;
            UpdateEditControls();
            m_tileSheetRemoveDependenciesMenuItem.Enabled
                = m_tileSheetRemoveDependenciesButton.Enabled = false;

            m_dependencyRemovedMessageBox.Show();
        }

        private void OnTileSheetDelete(object sender, EventArgs eventArgs)
        {
            if (m_selectedComponent == null
                || !(m_selectedComponent is TileSheet))
                return;

            TileSheet tileSheet = (TileSheet)m_selectedComponent;

            if (m_map.DependsOnTileSheet(tileSheet))
            {
                m_hasDependencyMessageBox.Show();
                return;
            }

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
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog(this);
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
            xTile.ObjectModel.Component component = mapTreeViewEventArgs.Component;

            // enable/disable layer menu items as applicable
            bool layerSelected = component != null && component is Layer;

            m_mapPanel.Enabled = layerSelected;

            m_layerPropertiesMenuItem.Enabled
                = m_layerPropertiesButton.Enabled
                = m_layerOffsetMenuItem.Enabled
                = m_layerOffsetButton.Enabled
                = m_layerMakeInvisibleMenuItem.Enabled
                = m_layerMakeInvisibileButton.Enabled
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

        private void OnToolsTexture(object sender, EventArgs eventArgs)
        {
            m_mapPanel.EditTool = EditTool.Texture;
            // TODO: sample from selection here
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

        private void OnCommandHistoryChanged(object sender, EventArgs eventArgs)
        {
            UpdateAllControls();
        }

        #endregion

        #region Public Methods

        public MainForm(string[] arguments)
        {
            InitializeComponent();

            m_arguments = arguments;

            m_commandHistory = CommandHistory.Instance;
            m_tileBrushCollection = new TileBrushCollection();
        }

        #endregion

    }
}
