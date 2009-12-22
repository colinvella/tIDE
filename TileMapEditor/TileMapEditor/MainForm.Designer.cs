namespace TileMapEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.SplitContainer m_splitContainerVertical;
            System.Windows.Forms.ToolStripSeparator m_tileSheetToolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator m_viewSeparator2;
            System.Windows.Forms.ToolStripSeparator m_fileSeparator1;
            System.Windows.Forms.ToolStripSeparator m_fileSeparator2;
            System.Windows.Forms.ToolStripSeparator m_editMenuSeparator1;
            System.Windows.Forms.ToolStripSeparator m_editMenuSeparator2;
            System.Windows.Forms.ToolStripSeparator m_editMenuSeparator3;
            System.Windows.Forms.ToolStripSeparator m_viewMenuSeparator1;
            System.Windows.Forms.ToolStripSeparator m_viewMenuSeparator2;
            System.Windows.Forms.ToolStripSeparator m_LayerSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator m_tileSheetSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.Windows.Forms.ToolStripLabel m_viewZoomLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_mapTreeView = new TileMapEditor.Control.MapTreeView();
            this.m_tilePicker = new TileMapEditor.Control.TilePicker();
            this.m_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.m_splitContainerLeftRight = new System.Windows.Forms.SplitContainer();
            this.m_toolStripContainerInner = new System.Windows.Forms.ToolStripContainer();
            this.m_mapPanel = new TileMapEditor.Control.MapPanel();
            this.m_toolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_toolsSelectButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsSingleTileButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsTileBlockButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsEraserButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsDropperButton = new System.Windows.Forms.ToolStripButton();
            this.m_toolsTileBrushButton = new TileMapEditor.Control.CustomToolStripSplitButton();
            this.m_splitter = new System.Windows.Forms.Splitter();
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.m_fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editUndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editRedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editCutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editSelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editClearSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editInvertSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMakeTileBrushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editManageTileBrushesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy6MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy7MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy9MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomBy10MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewZoomOutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewWindowModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewLayerCompositingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_viewTileGuidesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerVisibilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerBringForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerSendBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pluginsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pluginsReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_editUndoButton = new System.Windows.Forms.ToolStripButton();
            this.m_editRedoButton = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editCutButton = new System.Windows.Forms.ToolStripButton();
            this.m_editCopyButton = new System.Windows.Forms.ToolStripButton();
            this.m_editPasteButton = new System.Windows.Forms.ToolStripButton();
            this.m_editDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editSelectAllButton = new System.Windows.Forms.ToolStripButton();
            this.m_editClearSelectionButton = new System.Windows.Forms.ToolStripButton();
            this.m_editInvertSelection = new System.Windows.Forms.ToolStripButton();
            this.m_editToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editMakeTileBrushButton = new System.Windows.Forms.ToolStripButton();
            this.m_editManageTileBrushesButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_viewZoomComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.m_viewZoomInButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_viewWindowModeButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewLayerCompositingButton = new System.Windows.Forms.ToolStripButton();
            this.m_viewTileGuidesButton = new System.Windows.Forms.ToolStripButton();
            this.m_mapToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_mapPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_layerNewButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerVisibilityButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_layerBringForwardButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerSendBackwardButton = new System.Windows.Forms.ToolStripButton();
            this.m_layerToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_layerDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_tileSheetNewButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetPropertiesButton = new System.Windows.Forms.ToolStripButton();
            this.m_tileSheetDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            m_splitContainerVertical = new System.Windows.Forms.SplitContainer();
            m_tileSheetToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_viewSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_fileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_fileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_editMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_editMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_editMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            m_viewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            m_viewMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_LayerSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            m_tileSheetSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            m_viewZoomLabel = new System.Windows.Forms.ToolStripLabel();
            m_splitContainerVertical.Panel1.SuspendLayout();
            m_splitContainerVertical.Panel2.SuspendLayout();
            m_splitContainerVertical.SuspendLayout();
            this.m_toolStripContainer.ContentPanel.SuspendLayout();
            this.m_toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.m_toolStripContainer.SuspendLayout();
            this.m_splitContainerLeftRight.Panel1.SuspendLayout();
            this.m_splitContainerLeftRight.Panel2.SuspendLayout();
            this.m_splitContainerLeftRight.SuspendLayout();
            this.m_toolStripContainerInner.ContentPanel.SuspendLayout();
            this.m_toolStripContainerInner.RightToolStripPanel.SuspendLayout();
            this.m_toolStripContainerInner.SuspendLayout();
            this.m_toolsToolStrip.SuspendLayout();
            this.m_menuStrip.SuspendLayout();
            this.m_editToolStrip.SuspendLayout();
            this.m_viewToolStrip.SuspendLayout();
            this.m_mapToolStrip.SuspendLayout();
            this.m_layerToolStrip.SuspendLayout();
            this.m_tileSheetToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_splitContainerVertical
            // 
            m_splitContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            m_splitContainerVertical.Location = new System.Drawing.Point(0, 0);
            m_splitContainerVertical.Name = "m_splitContainerVertical";
            m_splitContainerVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerVertical.Panel1
            // 
            m_splitContainerVertical.Panel1.Controls.Add(this.m_mapTreeView);
            // 
            // m_splitContainerVertical.Panel2
            // 
            m_splitContainerVertical.Panel2.Controls.Add(this.m_tilePicker);
            m_splitContainerVertical.Size = new System.Drawing.Size(200, 438);
            m_splitContainerVertical.SplitterDistance = 191;
            m_splitContainerVertical.TabIndex = 1;
            // 
            // m_mapTreeView
            // 
            this.m_mapTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mapTreeView.Location = new System.Drawing.Point(0, 0);
            this.m_mapTreeView.Map = null;
            this.m_mapTreeView.Name = "m_mapTreeView";
            this.m_mapTreeView.SelectedComponent = null;
            this.m_mapTreeView.Size = new System.Drawing.Size(200, 191);
            this.m_mapTreeView.TabIndex = 0;
            this.m_mapTreeView.NewTileSheet += new System.EventHandler(this.OnTileSheetNew);
            this.m_mapTreeView.ComponentChanged += new TileMapEditor.Control.MapTreeViewEventHandler(this.OnTreeComponentChanged);
            this.m_mapTreeView.LayerVisibility += new System.EventHandler(this.OnLayerVisibility);
            this.m_mapTreeView.BringLayerForward += new System.EventHandler(this.OnLayerBringForward);
            this.m_mapTreeView.LayerProperties += new System.EventHandler(this.OnLayerProperties);
            this.m_mapTreeView.DeleteTileSheet += new System.EventHandler(this.OnTileSheetDelete);
            this.m_mapTreeView.MapProperties += new System.EventHandler(this.OnMapProperties);
            this.m_mapTreeView.SendLayerBackward += new System.EventHandler(this.OnLayerSendBackward);
            this.m_mapTreeView.NewLayer += new System.EventHandler(this.OnLayerNew);
            this.m_mapTreeView.DeleteLayer += new System.EventHandler(this.OnLayerDelete);
            this.m_mapTreeView.TileSheetProperties += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tilePicker.Location = new System.Drawing.Point(0, 0);
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.Size = new System.Drawing.Size(200, 243);
            this.m_tilePicker.TabIndex = 0;
            this.m_tilePicker.TileSelected += new TileMapEditor.Control.TilePickerEventHandler(this.OnPickerTileSelected);
            // 
            // m_tileSheetToolStripSeparator1
            // 
            m_tileSheetToolStripSeparator1.Name = "m_tileSheetToolStripSeparator1";
            m_tileSheetToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_viewSeparator2
            // 
            m_viewSeparator2.Name = "m_viewSeparator2";
            m_viewSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_fileSeparator1
            // 
            m_fileSeparator1.Name = "m_fileSeparator1";
            m_fileSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // m_fileSeparator2
            // 
            m_fileSeparator2.Name = "m_fileSeparator2";
            m_fileSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // m_editMenuSeparator1
            // 
            m_editMenuSeparator1.Name = "m_editMenuSeparator1";
            m_editMenuSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // m_editMenuSeparator2
            // 
            m_editMenuSeparator2.Name = "m_editMenuSeparator2";
            m_editMenuSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // m_editMenuSeparator3
            // 
            m_editMenuSeparator3.Name = "m_editMenuSeparator3";
            m_editMenuSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // m_viewMenuSeparator1
            // 
            m_viewMenuSeparator1.Name = "m_viewMenuSeparator1";
            m_viewMenuSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // m_viewMenuSeparator2
            // 
            m_viewMenuSeparator2.Name = "m_viewMenuSeparator2";
            m_viewMenuSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // m_LayerSeparator1
            // 
            m_LayerSeparator1.Name = "m_LayerSeparator1";
            m_LayerSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // m_tileSheetSeparator1
            // 
            m_tileSheetSeparator1.Name = "m_tileSheetSeparator1";
            m_tileSheetSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // m_viewZoomLabel
            // 
            m_viewZoomLabel.Image = global::TileMapEditor.Properties.Resources.ViewZoom;
            m_viewZoomLabel.Name = "m_viewZoomLabel";
            m_viewZoomLabel.Size = new System.Drawing.Size(16, 22);
            m_viewZoomLabel.ToolTipText = "Zooming factor";
            // 
            // m_toolStripContainer
            // 
            this.m_toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // m_toolStripContainer.ContentPanel
            // 
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitContainerLeftRight);
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitter);
            this.m_toolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 438);
            this.m_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            this.m_toolStripContainer.RightToolStripPanelVisible = false;
            this.m_toolStripContainer.Size = new System.Drawing.Size(784, 562);
            this.m_toolStripContainer.TabIndex = 0;
            this.m_toolStripContainer.Text = "toolStripContainer1";
            // 
            // m_toolStripContainer.TopToolStripPanel
            // 
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_viewToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_mapToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_layerToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_menuStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_editToolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_tileSheetToolStrip);
            // 
            // m_splitContainerLeftRight
            // 
            this.m_splitContainerLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainerLeftRight.Location = new System.Drawing.Point(4, 0);
            this.m_splitContainerLeftRight.Name = "m_splitContainerLeftRight";
            // 
            // m_splitContainerLeftRight.Panel1
            // 
            this.m_splitContainerLeftRight.Panel1.Controls.Add(m_splitContainerVertical);
            // 
            // m_splitContainerLeftRight.Panel2
            // 
            this.m_splitContainerLeftRight.Panel2.Controls.Add(this.m_toolStripContainerInner);
            this.m_splitContainerLeftRight.Size = new System.Drawing.Size(780, 438);
            this.m_splitContainerLeftRight.SplitterDistance = 200;
            this.m_splitContainerLeftRight.TabIndex = 3;
            // 
            // m_toolStripContainerInner
            // 
            // 
            // m_toolStripContainerInner.ContentPanel
            // 
            this.m_toolStripContainerInner.ContentPanel.Controls.Add(this.m_mapPanel);
            this.m_toolStripContainerInner.ContentPanel.Size = new System.Drawing.Size(543, 438);
            this.m_toolStripContainerInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_toolStripContainerInner.Location = new System.Drawing.Point(0, 0);
            this.m_toolStripContainerInner.Name = "m_toolStripContainerInner";
            // 
            // m_toolStripContainerInner.RightToolStripPanel
            // 
            this.m_toolStripContainerInner.RightToolStripPanel.Controls.Add(this.m_toolsToolStrip);
            this.m_toolStripContainerInner.Size = new System.Drawing.Size(576, 438);
            this.m_toolStripContainerInner.TabIndex = 1;
            this.m_toolStripContainerInner.Text = "toolStripContainer1";
            this.m_toolStripContainerInner.TopToolStripPanelVisible = false;
            // 
            // m_mapPanel
            // 
            this.m_mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mapPanel.EditTool = TileMapEditor.Control.EditTool.SingleTile;
            this.m_mapPanel.Enabled = false;
            this.m_mapPanel.Location = new System.Drawing.Point(0, 0);
            this.m_mapPanel.Map = null;
            this.m_mapPanel.Name = "m_mapPanel";
            this.m_mapPanel.SelectedLayer = null;
            this.m_mapPanel.SelectedTileIndex = 0;
            this.m_mapPanel.SelectedTileSheet = null;
            this.m_mapPanel.Size = new System.Drawing.Size(543, 438);
            this.m_mapPanel.TabIndex = 0;
            this.m_mapPanel.TilePicked += new TileMapEditor.Control.MapPanelEventHandler(this.OnMapTilePicked);
            this.m_mapPanel.MapChanged += new System.EventHandler(this.OnMapChanged);
            // 
            // m_toolsToolStrip
            // 
            this.m_toolsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolsSelectButton,
            this.m_toolsSingleTileButton,
            this.m_toolsTileBlockButton,
            this.m_toolsEraserButton,
            this.m_toolsDropperButton,
            this.m_toolsTileBrushButton});
            this.m_toolsToolStrip.Location = new System.Drawing.Point(0, 3);
            this.m_toolsToolStrip.Name = "m_toolsToolStrip";
            this.m_toolsToolStrip.Size = new System.Drawing.Size(33, 149);
            this.m_toolsToolStrip.TabIndex = 0;
            // 
            // m_toolsSelectButton
            // 
            this.m_toolsSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsSelectButton.Image = global::TileMapEditor.Properties.Resources.ToolsSelect;
            this.m_toolsSelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsSelectButton.Name = "m_toolsSelectButton";
            this.m_toolsSelectButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsSelectButton.Text = "toolStripButton1";
            this.m_toolsSelectButton.ToolTipText = "Select tiles [ S ]";
            this.m_toolsSelectButton.Click += new System.EventHandler(this.OnToolsSelect);
            // 
            // m_toolsSingleTileButton
            // 
            this.m_toolsSingleTileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsSingleTileButton.Image = global::TileMapEditor.Properties.Resources.ToolsSingleTile;
            this.m_toolsSingleTileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsSingleTileButton.Name = "m_toolsSingleTileButton";
            this.m_toolsSingleTileButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsSingleTileButton.Text = "toolStripButton1";
            this.m_toolsSingleTileButton.ToolTipText = "Lay individual tiles [ T ]";
            this.m_toolsSingleTileButton.Click += new System.EventHandler(this.OnToolsSingleTile);
            // 
            // m_toolsTileBlockButton
            // 
            this.m_toolsTileBlockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsTileBlockButton.Image = global::TileMapEditor.Properties.Resources.ToolsTileBlock;
            this.m_toolsTileBlockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsTileBlockButton.Name = "m_toolsTileBlockButton";
            this.m_toolsTileBlockButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsTileBlockButton.Text = "toolStripButton2";
            this.m_toolsTileBlockButton.ToolTipText = "Lay a block of tiles [ B ]";
            this.m_toolsTileBlockButton.Click += new System.EventHandler(this.OnToolsTileBlock);
            // 
            // m_toolsEraserButton
            // 
            this.m_toolsEraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsEraserButton.Image = global::TileMapEditor.Properties.Resources.ToolsEraser;
            this.m_toolsEraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsEraserButton.Name = "m_toolsEraserButton";
            this.m_toolsEraserButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsEraserButton.Text = "toolStripButton3";
            this.m_toolsEraserButton.ToolTipText = "Erase tiles [ E ]";
            this.m_toolsEraserButton.Click += new System.EventHandler(this.OnToolsEraser);
            // 
            // m_toolsDropperButton
            // 
            this.m_toolsDropperButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsDropperButton.Image = global::TileMapEditor.Properties.Resources.ToolsDropper;
            this.m_toolsDropperButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsDropperButton.Name = "m_toolsDropperButton";
            this.m_toolsDropperButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsDropperButton.Text = "toolStripButton4";
            this.m_toolsDropperButton.ToolTipText = "Pick tiles from the map [ P ]";
            this.m_toolsDropperButton.Click += new System.EventHandler(this.OnToolsDropper);
            // 
            // m_toolsTileBrushButton
            // 
            this.m_toolsTileBrushButton.Checked = false;
            this.m_toolsTileBrushButton.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.m_toolsTileBrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolsTileBrushButton.Image = global::TileMapEditor.Properties.Resources.ToolsTileBrush;
            this.m_toolsTileBrushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolsTileBrushButton.Name = "m_toolsTileBrushButton";
            this.m_toolsTileBrushButton.Size = new System.Drawing.Size(31, 20);
            this.m_toolsTileBrushButton.Text = "toolStripSplitButton1";
            this.m_toolsTileBrushButton.ToolTipText = "Lay a tile brush";
            this.m_toolsTileBrushButton.ButtonClick += new System.EventHandler(this.OnToolsTileBrush);
            // 
            // m_splitter
            // 
            this.m_splitter.Location = new System.Drawing.Point(0, 0);
            this.m_splitter.Name = "m_splitter";
            this.m_splitter.Size = new System.Drawing.Size(4, 438);
            this.m_splitter.TabIndex = 1;
            this.m_splitter.TabStop = false;
            // 
            // m_menuStrip
            // 
            this.m_menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileMenuItem,
            this.m_editMenuItem,
            this.m_viewMenuItem,
            this.m_mapMenuItem,
            this.m_layerMenuItem,
            this.m_tileSheetMenuItem,
            this.m_pluginsMenuItem,
            this.m_helpMenuItem});
            this.m_menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_menuStrip.Name = "m_menuStrip";
            this.m_menuStrip.Size = new System.Drawing.Size(784, 24);
            this.m_menuStrip.TabIndex = 0;
            this.m_menuStrip.Text = "Menu Strip";
            // 
            // m_fileMenuItem
            // 
            this.m_fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileNewMenuItem,
            this.m_fileOpenMenuItem,
            m_fileSeparator1,
            this.m_fileSaveMenuItem,
            this.m_fileSaveAsMenuItem,
            m_fileSeparator2,
            this.exitToolStripMenuItem});
            this.m_fileMenuItem.Image = global::TileMapEditor.Properties.Resources.File;
            this.m_fileMenuItem.Name = "m_fileMenuItem";
            this.m_fileMenuItem.Size = new System.Drawing.Size(53, 20);
            this.m_fileMenuItem.Text = "&File";
            // 
            // m_fileNewMenuItem
            // 
            this.m_fileNewMenuItem.Image = global::TileMapEditor.Properties.Resources.FileNew;
            this.m_fileNewMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_fileNewMenuItem.Name = "m_fileNewMenuItem";
            this.m_fileNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.m_fileNewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_fileNewMenuItem.Text = "&New";
            this.m_fileNewMenuItem.Click += new System.EventHandler(this.OnFileNew);
            // 
            // m_fileOpenMenuItem
            // 
            this.m_fileOpenMenuItem.Image = global::TileMapEditor.Properties.Resources.FileOpen;
            this.m_fileOpenMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_fileOpenMenuItem.Name = "m_fileOpenMenuItem";
            this.m_fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.m_fileOpenMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_fileOpenMenuItem.Text = "&Open";
            // 
            // m_fileSaveMenuItem
            // 
            this.m_fileSaveMenuItem.Enabled = false;
            this.m_fileSaveMenuItem.Image = global::TileMapEditor.Properties.Resources.FileSave;
            this.m_fileSaveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_fileSaveMenuItem.Name = "m_fileSaveMenuItem";
            this.m_fileSaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.m_fileSaveMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_fileSaveMenuItem.Text = "&Save";
            // 
            // m_fileSaveAsMenuItem
            // 
            this.m_fileSaveAsMenuItem.Image = global::TileMapEditor.Properties.Resources.FileSaveAs;
            this.m_fileSaveAsMenuItem.Name = "m_fileSaveAsMenuItem";
            this.m_fileSaveAsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_fileSaveAsMenuItem.Text = "Save &As";
            this.m_fileSaveAsMenuItem.Click += new System.EventHandler(this.OnFileSaveAs);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // m_editMenuItem
            // 
            this.m_editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_editUndoMenuItem,
            this.m_editRedoMenuItem,
            m_editMenuSeparator1,
            this.m_editCutMenuItem,
            this.m_editCopyMenuItem,
            this.m_editPasteMenuItem,
            this.m_editDeleteMenuItem,
            m_editMenuSeparator2,
            this.m_editSelectAllMenuItem,
            this.m_editClearSelectionMenuItem,
            this.m_editInvertSelectionMenuItem,
            m_editMenuSeparator3,
            this.m_editMakeTileBrushMenuItem,
            this.m_editManageTileBrushesMenuItem});
            this.m_editMenuItem.Image = global::TileMapEditor.Properties.Resources.Edit;
            this.m_editMenuItem.Name = "m_editMenuItem";
            this.m_editMenuItem.Size = new System.Drawing.Size(55, 20);
            this.m_editMenuItem.Text = "&Edit";
            // 
            // m_editUndoMenuItem
            // 
            this.m_editUndoMenuItem.Enabled = false;
            this.m_editUndoMenuItem.Image = global::TileMapEditor.Properties.Resources.EditUndo;
            this.m_editUndoMenuItem.Name = "m_editUndoMenuItem";
            this.m_editUndoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.m_editUndoMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editUndoMenuItem.Text = "&Undo";
            // 
            // m_editRedoMenuItem
            // 
            this.m_editRedoMenuItem.Enabled = false;
            this.m_editRedoMenuItem.Image = global::TileMapEditor.Properties.Resources.EditRedo;
            this.m_editRedoMenuItem.Name = "m_editRedoMenuItem";
            this.m_editRedoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.m_editRedoMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editRedoMenuItem.Text = "&Redo";
            // 
            // m_editCutMenuItem
            // 
            this.m_editCutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editCutMenuItem.Image")));
            this.m_editCutMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCutMenuItem.Name = "m_editCutMenuItem";
            this.m_editCutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_editCutMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editCutMenuItem.Text = "Cu&t";
            this.m_editCutMenuItem.Click += new System.EventHandler(this.OnEditCut);
            // 
            // m_editCopyMenuItem
            // 
            this.m_editCopyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editCopyMenuItem.Image")));
            this.m_editCopyMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCopyMenuItem.Name = "m_editCopyMenuItem";
            this.m_editCopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.m_editCopyMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editCopyMenuItem.Text = "&Copy";
            this.m_editCopyMenuItem.Click += new System.EventHandler(this.OnEditCopy);
            // 
            // m_editPasteMenuItem
            // 
            this.m_editPasteMenuItem.Enabled = false;
            this.m_editPasteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editPasteMenuItem.Image")));
            this.m_editPasteMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editPasteMenuItem.Name = "m_editPasteMenuItem";
            this.m_editPasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.m_editPasteMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editPasteMenuItem.Text = "&Paste";
            this.m_editPasteMenuItem.Click += new System.EventHandler(this.OnEditPaste);
            // 
            // m_editDeleteMenuItem
            // 
            this.m_editDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.EditDelete;
            this.m_editDeleteMenuItem.Name = "m_editDeleteMenuItem";
            this.m_editDeleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.m_editDeleteMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editDeleteMenuItem.Text = "Delete";
            this.m_editDeleteMenuItem.Click += new System.EventHandler(this.OnEditDelete);
            // 
            // m_editSelectAllMenuItem
            // 
            this.m_editSelectAllMenuItem.Image = global::TileMapEditor.Properties.Resources.EditSelectAll;
            this.m_editSelectAllMenuItem.Name = "m_editSelectAllMenuItem";
            this.m_editSelectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.m_editSelectAllMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editSelectAllMenuItem.Text = "Select &All";
            this.m_editSelectAllMenuItem.Click += new System.EventHandler(this.OnEditSelectAll);
            // 
            // m_editClearSelectionMenuItem
            // 
            this.m_editClearSelectionMenuItem.Image = global::TileMapEditor.Properties.Resources.EditClearSelection;
            this.m_editClearSelectionMenuItem.Name = "m_editClearSelectionMenuItem";
            this.m_editClearSelectionMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editClearSelectionMenuItem.Text = "Clear Selection";
            this.m_editClearSelectionMenuItem.Click += new System.EventHandler(this.OnEditClearSelection);
            // 
            // m_editInvertSelectionMenuItem
            // 
            this.m_editInvertSelectionMenuItem.Image = global::TileMapEditor.Properties.Resources.EditInvertSelection;
            this.m_editInvertSelectionMenuItem.Name = "m_editInvertSelectionMenuItem";
            this.m_editInvertSelectionMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.m_editInvertSelectionMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editInvertSelectionMenuItem.Text = "Invert Selection";
            this.m_editInvertSelectionMenuItem.Click += new System.EventHandler(this.OnEditInvertSelection);
            // 
            // m_editMakeTileBrushMenuItem
            // 
            this.m_editMakeTileBrushMenuItem.Image = global::TileMapEditor.Properties.Resources.EditMakeTileBrush;
            this.m_editMakeTileBrushMenuItem.Name = "m_editMakeTileBrushMenuItem";
            this.m_editMakeTileBrushMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editMakeTileBrushMenuItem.Text = "Make Tile Brush";
            this.m_editMakeTileBrushMenuItem.Click += new System.EventHandler(this.OnEditMakeTileBrush);
            // 
            // m_editManageTileBrushesMenuItem
            // 
            this.m_editManageTileBrushesMenuItem.Image = global::TileMapEditor.Properties.Resources.EditManageTileBrushes;
            this.m_editManageTileBrushesMenuItem.Name = "m_editManageTileBrushesMenuItem";
            this.m_editManageTileBrushesMenuItem.Size = new System.Drawing.Size(192, 22);
            this.m_editManageTileBrushesMenuItem.Text = "Manage Tile Brushes...";
            // 
            // m_viewMenuItem
            // 
            this.m_viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewZoomMenuItem,
            this.m_viewZoomInMenuItem,
            this.m_viewZoomOutMenuItem,
            m_viewMenuSeparator1,
            this.m_viewWindowModeMenuItem,
            m_viewMenuSeparator2,
            this.m_viewLayerCompositingMenuItem,
            this.m_viewTileGuidesMenuItem});
            this.m_viewMenuItem.Image = global::TileMapEditor.Properties.Resources.View;
            this.m_viewMenuItem.Name = "m_viewMenuItem";
            this.m_viewMenuItem.Size = new System.Drawing.Size(60, 20);
            this.m_viewMenuItem.Text = "&View";
            // 
            // m_viewZoomMenuItem
            // 
            this.m_viewZoomMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_viewZoomBy1MenuItem,
            this.m_viewZoomBy2MenuItem,
            this.m_viewZoomBy3MenuItem,
            this.m_viewZoomBy4MenuItem,
            this.m_viewZoomBy5MenuItem,
            this.m_viewZoomBy6MenuItem,
            this.m_viewZoomBy7MenuItem,
            this.m_viewZoomBy8MenuItem,
            this.m_viewZoomBy9MenuItem,
            this.m_viewZoomBy10MenuItem});
            this.m_viewZoomMenuItem.Image = global::TileMapEditor.Properties.Resources.ViewZoom;
            this.m_viewZoomMenuItem.Name = "m_viewZoomMenuItem";
            this.m_viewZoomMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewZoomMenuItem.Text = "Zoom";
            // 
            // m_viewZoomBy1MenuItem
            // 
            this.m_viewZoomBy1MenuItem.Name = "m_viewZoomBy1MenuItem";
            this.m_viewZoomBy1MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.m_viewZoomBy1MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy1MenuItem.Tag = "1";
            this.m_viewZoomBy1MenuItem.Text = "To Scale";
            this.m_viewZoomBy1MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy2MenuItem
            // 
            this.m_viewZoomBy2MenuItem.Name = "m_viewZoomBy2MenuItem";
            this.m_viewZoomBy2MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy2MenuItem.Tag = "2";
            this.m_viewZoomBy2MenuItem.Text = "x 2";
            this.m_viewZoomBy2MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy3MenuItem
            // 
            this.m_viewZoomBy3MenuItem.Name = "m_viewZoomBy3MenuItem";
            this.m_viewZoomBy3MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy3MenuItem.Tag = "3";
            this.m_viewZoomBy3MenuItem.Text = "x 3";
            this.m_viewZoomBy3MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy4MenuItem
            // 
            this.m_viewZoomBy4MenuItem.Name = "m_viewZoomBy4MenuItem";
            this.m_viewZoomBy4MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy4MenuItem.Tag = "4";
            this.m_viewZoomBy4MenuItem.Text = "x 4";
            this.m_viewZoomBy4MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy5MenuItem
            // 
            this.m_viewZoomBy5MenuItem.Name = "m_viewZoomBy5MenuItem";
            this.m_viewZoomBy5MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy5MenuItem.Tag = "5";
            this.m_viewZoomBy5MenuItem.Text = "x 5";
            this.m_viewZoomBy5MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy6MenuItem
            // 
            this.m_viewZoomBy6MenuItem.Name = "m_viewZoomBy6MenuItem";
            this.m_viewZoomBy6MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy6MenuItem.Tag = "6";
            this.m_viewZoomBy6MenuItem.Text = "x 6";
            this.m_viewZoomBy6MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy7MenuItem
            // 
            this.m_viewZoomBy7MenuItem.Name = "m_viewZoomBy7MenuItem";
            this.m_viewZoomBy7MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy7MenuItem.Tag = "7";
            this.m_viewZoomBy7MenuItem.Text = "x 7";
            this.m_viewZoomBy7MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy8MenuItem
            // 
            this.m_viewZoomBy8MenuItem.Name = "m_viewZoomBy8MenuItem";
            this.m_viewZoomBy8MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy8MenuItem.Tag = "8";
            this.m_viewZoomBy8MenuItem.Text = "x 8";
            this.m_viewZoomBy8MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy9MenuItem
            // 
            this.m_viewZoomBy9MenuItem.Name = "m_viewZoomBy9MenuItem";
            this.m_viewZoomBy9MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy9MenuItem.Tag = "9";
            this.m_viewZoomBy9MenuItem.Text = "x 9";
            this.m_viewZoomBy9MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomBy10MenuItem
            // 
            this.m_viewZoomBy10MenuItem.Name = "m_viewZoomBy10MenuItem";
            this.m_viewZoomBy10MenuItem.Size = new System.Drawing.Size(158, 22);
            this.m_viewZoomBy10MenuItem.Tag = "10";
            this.m_viewZoomBy10MenuItem.Text = "x 10";
            this.m_viewZoomBy10MenuItem.Click += new System.EventHandler(this.OnViewZoom);
            // 
            // m_viewZoomInMenuItem
            // 
            this.m_viewZoomInMenuItem.Image = global::TileMapEditor.Properties.Resources.ViewZoomIn;
            this.m_viewZoomInMenuItem.Name = "m_viewZoomInMenuItem";
            this.m_viewZoomInMenuItem.ShortcutKeyDisplayString = "Ctrl++";
            this.m_viewZoomInMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.m_viewZoomInMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewZoomInMenuItem.Text = "Zoom In";
            this.m_viewZoomInMenuItem.Click += new System.EventHandler(this.OnViewZoomIn);
            // 
            // m_viewZoomOutMenuItem
            // 
            this.m_viewZoomOutMenuItem.Image = global::TileMapEditor.Properties.Resources.ViewZoomOut;
            this.m_viewZoomOutMenuItem.Name = "m_viewZoomOutMenuItem";
            this.m_viewZoomOutMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            this.m_viewZoomOutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.m_viewZoomOutMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewZoomOutMenuItem.Text = "Zoom Out";
            this.m_viewZoomOutMenuItem.Click += new System.EventHandler(this.OnViewZoomOut);
            // 
            // m_viewWindowModeMenuItem
            // 
            this.m_viewWindowModeMenuItem.Image = global::TileMapEditor.Properties.Resources.ViewFullScreen;
            this.m_viewWindowModeMenuItem.Name = "m_viewWindowModeMenuItem";
            this.m_viewWindowModeMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.m_viewWindowModeMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewWindowModeMenuItem.Text = "Full Screen";
            this.m_viewWindowModeMenuItem.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewLayerCompositingMenuItem
            // 
            this.m_viewLayerCompositingMenuItem.Image = global::TileMapEditor.Properties.Resources.ViewLayerCompositing;
            this.m_viewLayerCompositingMenuItem.Name = "m_viewLayerCompositingMenuItem";
            this.m_viewLayerCompositingMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewLayerCompositingMenuItem.Text = "Show All Layers";
            this.m_viewLayerCompositingMenuItem.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewTileGuidesMenuItem
            // 
            this.m_viewTileGuidesMenuItem.Image = global::TileMapEditor.Properties.Resources.VewTileGuides;
            this.m_viewTileGuidesMenuItem.Name = "m_viewTileGuidesMenuItem";
            this.m_viewTileGuidesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.m_viewTileGuidesMenuItem.Size = new System.Drawing.Size(174, 22);
            this.m_viewTileGuidesMenuItem.Text = "Tile Guides";
            this.m_viewTileGuidesMenuItem.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_mapMenuItem
            // 
            this.m_mapMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesMenuItem});
            this.m_mapMenuItem.Image = global::TileMapEditor.Properties.Resources.Map;
            this.m_mapMenuItem.Name = "m_mapMenuItem";
            this.m_mapMenuItem.Size = new System.Drawing.Size(59, 20);
            this.m_mapMenuItem.Text = "&Map";
            // 
            // m_mapPropertiesMenuItem
            // 
            this.m_mapPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.MapProperties;
            this.m_mapPropertiesMenuItem.Name = "m_mapPropertiesMenuItem";
            this.m_mapPropertiesMenuItem.Size = new System.Drawing.Size(136, 22);
            this.m_mapPropertiesMenuItem.Text = "Properties...";
            this.m_mapPropertiesMenuItem.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_layerMenuItem
            // 
            this.m_layerMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewMenuItem,
            this.m_layerPropertiesMenuItem,
            this.m_layerVisibilityMenuItem,
            m_LayerSeparator1,
            this.m_layerBringForwardMenuItem,
            this.m_layerSendBackwardMenuItem,
            toolStripMenuItem1,
            this.m_layerDeleteMenuItem});
            this.m_layerMenuItem.Image = global::TileMapEditor.Properties.Resources.Layer;
            this.m_layerMenuItem.Name = "m_layerMenuItem";
            this.m_layerMenuItem.Size = new System.Drawing.Size(63, 20);
            this.m_layerMenuItem.Text = "&Layer";
            // 
            // m_layerNewMenuItem
            // 
            this.m_layerNewMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerNew;
            this.m_layerNewMenuItem.Name = "m_layerNewMenuItem";
            this.m_layerNewMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerNewMenuItem.Text = "&New...";
            this.m_layerNewMenuItem.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerPropertiesMenuItem
            // 
            this.m_layerPropertiesMenuItem.Enabled = false;
            this.m_layerPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerProperties;
            this.m_layerPropertiesMenuItem.Name = "m_layerPropertiesMenuItem";
            this.m_layerPropertiesMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerPropertiesMenuItem.Text = "Properties...";
            this.m_layerPropertiesMenuItem.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerVisibilityMenuItem
            // 
            this.m_layerVisibilityMenuItem.Enabled = false;
            this.m_layerVisibilityMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerInvisible;
            this.m_layerVisibilityMenuItem.Name = "m_layerVisibilityMenuItem";
            this.m_layerVisibilityMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.m_layerVisibilityMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerVisibilityMenuItem.Text = "Make Invisibile";
            this.m_layerVisibilityMenuItem.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerBringForwardMenuItem
            // 
            this.m_layerBringForwardMenuItem.Enabled = false;
            this.m_layerBringForwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardMenuItem.Name = "m_layerBringForwardMenuItem";
            this.m_layerBringForwardMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerBringForwardMenuItem.Text = "Bring Forward";
            this.m_layerBringForwardMenuItem.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardMenuItem
            // 
            this.m_layerSendBackwardMenuItem.Enabled = false;
            this.m_layerSendBackwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardMenuItem.Name = "m_layerSendBackwardMenuItem";
            this.m_layerSendBackwardMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerSendBackwardMenuItem.Text = "Send Backward";
            this.m_layerSendBackwardMenuItem.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerDeleteMenuItem
            // 
            this.m_layerDeleteMenuItem.Enabled = false;
            this.m_layerDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerDelete;
            this.m_layerDeleteMenuItem.Name = "m_layerDeleteMenuItem";
            this.m_layerDeleteMenuItem.Size = new System.Drawing.Size(189, 22);
            this.m_layerDeleteMenuItem.Text = "Delete";
            this.m_layerDeleteMenuItem.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_tileSheetMenuItem
            // 
            this.m_tileSheetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewMenuItem,
            this.m_tileSheetPropertiesMenuItem,
            m_tileSheetSeparator1,
            this.m_tileSheetDeleteMenuItem});
            this.m_tileSheetMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheet;
            this.m_tileSheetMenuItem.Name = "m_tileSheetMenuItem";
            this.m_tileSheetMenuItem.Size = new System.Drawing.Size(86, 20);
            this.m_tileSheetMenuItem.Text = "&Tile Sheet";
            // 
            // m_tileSheetNewMenuItem
            // 
            this.m_tileSheetNewMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetNew;
            this.m_tileSheetNewMenuItem.Name = "m_tileSheetNewMenuItem";
            this.m_tileSheetNewMenuItem.Size = new System.Drawing.Size(136, 22);
            this.m_tileSheetNewMenuItem.Text = "New...";
            this.m_tileSheetNewMenuItem.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetPropertiesMenuItem
            // 
            this.m_tileSheetPropertiesMenuItem.Enabled = false;
            this.m_tileSheetPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesMenuItem.Name = "m_tileSheetPropertiesMenuItem";
            this.m_tileSheetPropertiesMenuItem.Size = new System.Drawing.Size(136, 22);
            this.m_tileSheetPropertiesMenuItem.Text = "Properties...";
            this.m_tileSheetPropertiesMenuItem.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tileSheetDeleteMenuItem
            // 
            this.m_tileSheetDeleteMenuItem.Enabled = false;
            this.m_tileSheetDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteMenuItem.Name = "m_tileSheetDeleteMenuItem";
            this.m_tileSheetDeleteMenuItem.Size = new System.Drawing.Size(136, 22);
            this.m_tileSheetDeleteMenuItem.Text = "Delete";
            this.m_tileSheetDeleteMenuItem.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // m_pluginsMenuItem
            // 
            this.m_pluginsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_pluginsReloadMenuItem,
            this.toolStripSeparator1});
            this.m_pluginsMenuItem.Image = global::TileMapEditor.Properties.Resources.Plugin;
            this.m_pluginsMenuItem.Name = "m_pluginsMenuItem";
            this.m_pluginsMenuItem.Size = new System.Drawing.Size(74, 20);
            this.m_pluginsMenuItem.Text = "&Plugins";
            // 
            // m_pluginsReloadMenuItem
            // 
            this.m_pluginsReloadMenuItem.Image = global::TileMapEditor.Properties.Resources.PluginReload;
            this.m_pluginsReloadMenuItem.Name = "m_pluginsReloadMenuItem";
            this.m_pluginsReloadMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_pluginsReloadMenuItem.Text = "Reload Plugins";
            this.m_pluginsReloadMenuItem.Click += new System.EventHandler(this.OnPluginsReload);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // m_helpMenuItem
            // 
            this.m_helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.m_helpMenuItem.Image = global::TileMapEditor.Properties.Resources.Help;
            this.m_helpMenuItem.Name = "m_helpMenuItem";
            this.m_helpMenuItem.Size = new System.Drawing.Size(60, 20);
            this.m_helpMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::TileMapEditor.Properties.Resources.HelpAbout;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // m_editToolStrip
            // 
            this.m_editToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_editToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_editUndoButton,
            this.m_editRedoButton,
            this.m_editToolStripSeparator1,
            this.m_editCutButton,
            this.m_editCopyButton,
            this.m_editPasteButton,
            this.m_editDeleteButton,
            this.m_editToolStripSeparator2,
            this.m_editSelectAllButton,
            this.m_editClearSelectionButton,
            this.m_editInvertSelection,
            this.m_editToolStripSeparator3,
            this.m_editMakeTileBrushButton,
            this.m_editManageTileBrushesButton});
            this.m_editToolStrip.Location = new System.Drawing.Point(9, 24);
            this.m_editToolStrip.Name = "m_editToolStrip";
            this.m_editToolStrip.Size = new System.Drawing.Size(283, 25);
            this.m_editToolStrip.TabIndex = 1;
            // 
            // m_editUndoButton
            // 
            this.m_editUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editUndoButton.Enabled = false;
            this.m_editUndoButton.Image = global::TileMapEditor.Properties.Resources.EditUndo;
            this.m_editUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editUndoButton.Name = "m_editUndoButton";
            this.m_editUndoButton.Size = new System.Drawing.Size(23, 22);
            this.m_editUndoButton.Text = "Undo";
            // 
            // m_editRedoButton
            // 
            this.m_editRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editRedoButton.Enabled = false;
            this.m_editRedoButton.Image = global::TileMapEditor.Properties.Resources.EditRedo;
            this.m_editRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editRedoButton.Name = "m_editRedoButton";
            this.m_editRedoButton.Size = new System.Drawing.Size(23, 22);
            this.m_editRedoButton.Text = "Redo";
            // 
            // m_editToolStripSeparator1
            // 
            this.m_editToolStripSeparator1.Name = "m_editToolStripSeparator1";
            this.m_editToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_editCutButton
            // 
            this.m_editCutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editCutButton.Image = ((System.Drawing.Image)(resources.GetObject("m_editCutButton.Image")));
            this.m_editCutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCutButton.Name = "m_editCutButton";
            this.m_editCutButton.Size = new System.Drawing.Size(23, 22);
            this.m_editCutButton.Text = "Cut";
            this.m_editCutButton.ToolTipText = "Cut selected area";
            this.m_editCutButton.Click += new System.EventHandler(this.OnEditCut);
            // 
            // m_editCopyButton
            // 
            this.m_editCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editCopyButton.Image = ((System.Drawing.Image)(resources.GetObject("m_editCopyButton.Image")));
            this.m_editCopyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCopyButton.Name = "m_editCopyButton";
            this.m_editCopyButton.Size = new System.Drawing.Size(23, 22);
            this.m_editCopyButton.Text = "Copy";
            this.m_editCopyButton.ToolTipText = "Copy selected area";
            this.m_editCopyButton.Click += new System.EventHandler(this.OnEditCopy);
            // 
            // m_editPasteButton
            // 
            this.m_editPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editPasteButton.Enabled = false;
            this.m_editPasteButton.Image = ((System.Drawing.Image)(resources.GetObject("m_editPasteButton.Image")));
            this.m_editPasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editPasteButton.Name = "m_editPasteButton";
            this.m_editPasteButton.Size = new System.Drawing.Size(23, 22);
            this.m_editPasteButton.Text = "Paste";
            this.m_editPasteButton.Click += new System.EventHandler(this.OnEditPaste);
            // 
            // m_editDeleteButton
            // 
            this.m_editDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editDeleteButton.Image = global::TileMapEditor.Properties.Resources.EditDelete;
            this.m_editDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editDeleteButton.Name = "m_editDeleteButton";
            this.m_editDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.m_editDeleteButton.Text = "Delete";
            this.m_editDeleteButton.ToolTipText = "Delete selected area";
            this.m_editDeleteButton.Click += new System.EventHandler(this.OnEditDelete);
            // 
            // m_editToolStripSeparator2
            // 
            this.m_editToolStripSeparator2.Name = "m_editToolStripSeparator2";
            this.m_editToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_editSelectAllButton
            // 
            this.m_editSelectAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editSelectAllButton.Image = global::TileMapEditor.Properties.Resources.EditSelectAll;
            this.m_editSelectAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editSelectAllButton.Name = "m_editSelectAllButton";
            this.m_editSelectAllButton.Size = new System.Drawing.Size(23, 22);
            this.m_editSelectAllButton.Text = "Select All";
            this.m_editSelectAllButton.ToolTipText = "Select the whole layer";
            this.m_editSelectAllButton.Click += new System.EventHandler(this.OnEditSelectAll);
            // 
            // m_editClearSelectionButton
            // 
            this.m_editClearSelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editClearSelectionButton.Image = global::TileMapEditor.Properties.Resources.EditClearSelection;
            this.m_editClearSelectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editClearSelectionButton.Name = "m_editClearSelectionButton";
            this.m_editClearSelectionButton.Size = new System.Drawing.Size(23, 22);
            this.m_editClearSelectionButton.Text = "Clear Selection";
            this.m_editClearSelectionButton.ToolTipText = "Clear selection";
            this.m_editClearSelectionButton.Click += new System.EventHandler(this.OnEditClearSelection);
            // 
            // m_editInvertSelection
            // 
            this.m_editInvertSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editInvertSelection.Image = global::TileMapEditor.Properties.Resources.EditInvertSelection;
            this.m_editInvertSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editInvertSelection.Name = "m_editInvertSelection";
            this.m_editInvertSelection.Size = new System.Drawing.Size(23, 22);
            this.m_editInvertSelection.Text = "Invert Selection";
            this.m_editInvertSelection.ToolTipText = "Invert selection";
            this.m_editInvertSelection.Click += new System.EventHandler(this.OnEditInvertSelection);
            // 
            // m_editToolStripSeparator3
            // 
            this.m_editToolStripSeparator3.Name = "m_editToolStripSeparator3";
            this.m_editToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_editMakeTileBrushButton
            // 
            this.m_editMakeTileBrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editMakeTileBrushButton.Image = global::TileMapEditor.Properties.Resources.EditMakeTileBrush;
            this.m_editMakeTileBrushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editMakeTileBrushButton.Name = "m_editMakeTileBrushButton";
            this.m_editMakeTileBrushButton.Size = new System.Drawing.Size(23, 22);
            this.m_editMakeTileBrushButton.Text = "Make Tile Brush";
            this.m_editMakeTileBrushButton.ToolTipText = "Make a new tile brush from the current selection";
            this.m_editMakeTileBrushButton.Click += new System.EventHandler(this.OnEditMakeTileBrush);
            // 
            // m_editManageTileBrushesButton
            // 
            this.m_editManageTileBrushesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_editManageTileBrushesButton.Image = global::TileMapEditor.Properties.Resources.EditManageTileBrushes;
            this.m_editManageTileBrushesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editManageTileBrushesButton.Name = "m_editManageTileBrushesButton";
            this.m_editManageTileBrushesButton.Size = new System.Drawing.Size(23, 22);
            this.m_editManageTileBrushesButton.Text = "Manage Tile Brushes";
            this.m_editManageTileBrushesButton.ToolTipText = "Manage tile brushes";
            this.m_editManageTileBrushesButton.Click += new System.EventHandler(this.OnEditManageTileBrushes);
            // 
            // m_viewToolStrip
            // 
            this.m_viewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            m_viewZoomLabel,
            this.m_viewZoomComboBox,
            this.m_viewZoomInButton,
            this.m_viewZoomOutButton,
            this.m_viewSeparator1,
            this.m_viewWindowModeButton,
            m_viewSeparator2,
            this.m_viewLayerCompositingButton,
            this.m_viewTileGuidesButton});
            this.m_viewToolStrip.Location = new System.Drawing.Point(292, 24);
            this.m_viewToolStrip.Name = "m_viewToolStrip";
            this.m_viewToolStrip.Size = new System.Drawing.Size(232, 25);
            this.m_viewToolStrip.TabIndex = 5;
            // 
            // m_viewZoomComboBox
            // 
            this.m_viewZoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_viewZoomComboBox.DropDownWidth = 60;
            this.m_viewZoomComboBox.Items.AddRange(new object[] {
            "To Scale",
            "x 2",
            "x 3",
            "x 4",
            "x 5",
            "x 6",
            "x 7",
            "x 8",
            "x 9",
            "x 10"});
            this.m_viewZoomComboBox.Name = "m_viewZoomComboBox";
            this.m_viewZoomComboBox.Size = new System.Drawing.Size(75, 25);
            this.m_viewZoomComboBox.SelectedIndexChanged += new System.EventHandler(this.OnViewZoomComboBox);
            // 
            // m_viewZoomInButton
            // 
            this.m_viewZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewZoomInButton.Image = global::TileMapEditor.Properties.Resources.ViewZoomIn;
            this.m_viewZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_viewZoomInButton.Name = "m_viewZoomInButton";
            this.m_viewZoomInButton.Size = new System.Drawing.Size(23, 22);
            this.m_viewZoomInButton.Text = "Zoom In";
            this.m_viewZoomInButton.Click += new System.EventHandler(this.OnViewZoomIn);
            // 
            // m_viewZoomOutButton
            // 
            this.m_viewZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewZoomOutButton.Enabled = false;
            this.m_viewZoomOutButton.Image = global::TileMapEditor.Properties.Resources.ViewZoomOut;
            this.m_viewZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_viewZoomOutButton.Name = "m_viewZoomOutButton";
            this.m_viewZoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.m_viewZoomOutButton.Text = "Zoom Out";
            this.m_viewZoomOutButton.Click += new System.EventHandler(this.OnViewZoomOut);
            // 
            // m_viewSeparator1
            // 
            this.m_viewSeparator1.Name = "m_viewSeparator1";
            this.m_viewSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_viewWindowModeButton
            // 
            this.m_viewWindowModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewWindowModeButton.Image = global::TileMapEditor.Properties.Resources.ViewFullScreen;
            this.m_viewWindowModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_viewWindowModeButton.Name = "m_viewWindowModeButton";
            this.m_viewWindowModeButton.Size = new System.Drawing.Size(23, 22);
            this.m_viewWindowModeButton.Text = "Window Mode";
            this.m_viewWindowModeButton.ToolTipText = "View in full screen mode";
            this.m_viewWindowModeButton.Click += new System.EventHandler(this.OnViewWindowMode);
            // 
            // m_viewLayerCompositingButton
            // 
            this.m_viewLayerCompositingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewLayerCompositingButton.Image = global::TileMapEditor.Properties.Resources.ViewLayerCompositingShowAll;
            this.m_viewLayerCompositingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_viewLayerCompositingButton.Name = "m_viewLayerCompositingButton";
            this.m_viewLayerCompositingButton.Size = new System.Drawing.Size(23, 22);
            this.m_viewLayerCompositingButton.Text = "Layer Mode";
            this.m_viewLayerCompositingButton.ToolTipText = "Show all layers";
            this.m_viewLayerCompositingButton.Click += new System.EventHandler(this.OnViewLayerCompositing);
            // 
            // m_viewTileGuidesButton
            // 
            this.m_viewTileGuidesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_viewTileGuidesButton.Image = global::TileMapEditor.Properties.Resources.VewTileGuidesShow;
            this.m_viewTileGuidesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_viewTileGuidesButton.Name = "m_viewTileGuidesButton";
            this.m_viewTileGuidesButton.Size = new System.Drawing.Size(23, 22);
            this.m_viewTileGuidesButton.Text = "Tile Guides";
            this.m_viewTileGuidesButton.ToolTipText = "Show tile guides";
            this.m_viewTileGuidesButton.Click += new System.EventHandler(this.OnViewTileGuides);
            // 
            // m_mapToolStrip
            // 
            this.m_mapToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_mapToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesButton});
            this.m_mapToolStrip.Location = new System.Drawing.Point(115, 49);
            this.m_mapToolStrip.Name = "m_mapToolStrip";
            this.m_mapToolStrip.Size = new System.Drawing.Size(35, 25);
            this.m_mapToolStrip.TabIndex = 2;
            // 
            // m_mapPropertiesButton
            // 
            this.m_mapPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_mapPropertiesButton.Image = global::TileMapEditor.Properties.Resources.MapProperties;
            this.m_mapPropertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_mapPropertiesButton.Name = "m_mapPropertiesButton";
            this.m_mapPropertiesButton.Size = new System.Drawing.Size(23, 22);
            this.m_mapPropertiesButton.Text = "Map Properties";
            this.m_mapPropertiesButton.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_layerToolStrip
            // 
            this.m_layerToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_layerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewButton,
            this.m_layerPropertiesButton,
            this.m_layerVisibilityButton,
            this.m_layerToolStripSeparator1,
            this.m_layerBringForwardButton,
            this.m_layerSendBackwardButton,
            this.m_layerToolStripSeparator2,
            this.m_layerDeleteButton});
            this.m_layerToolStrip.Location = new System.Drawing.Point(3, 74);
            this.m_layerToolStrip.Name = "m_layerToolStrip";
            this.m_layerToolStrip.Size = new System.Drawing.Size(162, 25);
            this.m_layerToolStrip.TabIndex = 4;
            // 
            // m_layerNewButton
            // 
            this.m_layerNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerNewButton.Image = global::TileMapEditor.Properties.Resources.LayerNew;
            this.m_layerNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerNewButton.Name = "m_layerNewButton";
            this.m_layerNewButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerNewButton.Text = "New Layer";
            this.m_layerNewButton.ToolTipText = "New layer";
            this.m_layerNewButton.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerPropertiesButton
            // 
            this.m_layerPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerPropertiesButton.Enabled = false;
            this.m_layerPropertiesButton.Image = global::TileMapEditor.Properties.Resources.LayerProperties;
            this.m_layerPropertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerPropertiesButton.Name = "m_layerPropertiesButton";
            this.m_layerPropertiesButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerPropertiesButton.Text = "Layer Properties";
            this.m_layerPropertiesButton.ToolTipText = "Layer properties";
            this.m_layerPropertiesButton.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerVisibilityButton
            // 
            this.m_layerVisibilityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerVisibilityButton.Enabled = false;
            this.m_layerVisibilityButton.Image = global::TileMapEditor.Properties.Resources.LayerInvisible;
            this.m_layerVisibilityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerVisibilityButton.Name = "m_layerVisibilityButton";
            this.m_layerVisibilityButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerVisibilityButton.Text = "Make Layer Invisible";
            this.m_layerVisibilityButton.ToolTipText = "Make layer invisible";
            this.m_layerVisibilityButton.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerToolStripSeparator1
            // 
            this.m_layerToolStripSeparator1.Name = "m_layerToolStripSeparator1";
            this.m_layerToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_layerBringForwardButton
            // 
            this.m_layerBringForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerBringForwardButton.Enabled = false;
            this.m_layerBringForwardButton.Image = global::TileMapEditor.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerBringForwardButton.Name = "m_layerBringForwardButton";
            this.m_layerBringForwardButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerBringForwardButton.Text = "Bring Forward";
            this.m_layerBringForwardButton.ToolTipText = "Bring layer forward";
            this.m_layerBringForwardButton.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardButton
            // 
            this.m_layerSendBackwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerSendBackwardButton.Enabled = false;
            this.m_layerSendBackwardButton.Image = global::TileMapEditor.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerSendBackwardButton.Name = "m_layerSendBackwardButton";
            this.m_layerSendBackwardButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerSendBackwardButton.Text = "Send Backward";
            this.m_layerSendBackwardButton.ToolTipText = "Send layer backward";
            this.m_layerSendBackwardButton.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerToolStripSeparator2
            // 
            this.m_layerToolStripSeparator2.Name = "m_layerToolStripSeparator2";
            this.m_layerToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_layerDeleteButton
            // 
            this.m_layerDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_layerDeleteButton.Enabled = false;
            this.m_layerDeleteButton.Image = global::TileMapEditor.Properties.Resources.LayerDelete;
            this.m_layerDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_layerDeleteButton.Name = "m_layerDeleteButton";
            this.m_layerDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.m_layerDeleteButton.Text = "Delete Layer";
            this.m_layerDeleteButton.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_tileSheetToolStrip
            // 
            this.m_tileSheetToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_tileSheetToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewButton,
            this.m_tileSheetPropertiesButton,
            m_tileSheetToolStripSeparator1,
            this.m_tileSheetDeleteButton});
            this.m_tileSheetToolStrip.Location = new System.Drawing.Point(63, 99);
            this.m_tileSheetToolStrip.Name = "m_tileSheetToolStrip";
            this.m_tileSheetToolStrip.Size = new System.Drawing.Size(87, 25);
            this.m_tileSheetToolStrip.TabIndex = 3;
            // 
            // m_tileSheetNewButton
            // 
            this.m_tileSheetNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetNewButton.Image = global::TileMapEditor.Properties.Resources.TileSheetNew;
            this.m_tileSheetNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tileSheetNewButton.Name = "m_tileSheetNewButton";
            this.m_tileSheetNewButton.Size = new System.Drawing.Size(23, 22);
            this.m_tileSheetNewButton.Text = "New Tile Sheet";
            this.m_tileSheetNewButton.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetPropertiesButton
            // 
            this.m_tileSheetPropertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetPropertiesButton.Enabled = false;
            this.m_tileSheetPropertiesButton.Image = global::TileMapEditor.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tileSheetPropertiesButton.Name = "m_tileSheetPropertiesButton";
            this.m_tileSheetPropertiesButton.Size = new System.Drawing.Size(23, 22);
            this.m_tileSheetPropertiesButton.Text = "Tile Sheet Properties";
            this.m_tileSheetPropertiesButton.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tileSheetDeleteButton
            // 
            this.m_tileSheetDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_tileSheetDeleteButton.Enabled = false;
            this.m_tileSheetDeleteButton.Image = global::TileMapEditor.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tileSheetDeleteButton.Name = "m_tileSheetDeleteButton";
            this.m_tileSheetDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.m_tileSheetDeleteButton.Text = "Delete Tile Sheet";
            this.m_tileSheetDeleteButton.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.m_toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.m_menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Map Editor .NET";
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.ResizeEnd += new System.EventHandler(this.OnFormResizeEnd);
            m_splitContainerVertical.Panel1.ResumeLayout(false);
            m_splitContainerVertical.Panel2.ResumeLayout(false);
            m_splitContainerVertical.ResumeLayout(false);
            this.m_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.PerformLayout();
            this.m_toolStripContainer.ResumeLayout(false);
            this.m_toolStripContainer.PerformLayout();
            this.m_splitContainerLeftRight.Panel1.ResumeLayout(false);
            this.m_splitContainerLeftRight.Panel2.ResumeLayout(false);
            this.m_splitContainerLeftRight.ResumeLayout(false);
            this.m_toolStripContainerInner.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainerInner.RightToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainerInner.RightToolStripPanel.PerformLayout();
            this.m_toolStripContainerInner.ResumeLayout(false);
            this.m_toolStripContainerInner.PerformLayout();
            this.m_toolsToolStrip.ResumeLayout(false);
            this.m_toolsToolStrip.PerformLayout();
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.m_editToolStrip.ResumeLayout(false);
            this.m_editToolStrip.PerformLayout();
            this.m_viewToolStrip.ResumeLayout(false);
            this.m_viewToolStrip.PerformLayout();
            this.m_mapToolStrip.ResumeLayout(false);
            this.m_mapToolStrip.PerformLayout();
            this.m_layerToolStrip.ResumeLayout(false);
            this.m_layerToolStrip.PerformLayout();
            this.m_tileSheetToolStrip.ResumeLayout(false);
            this.m_tileSheetToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer m_toolStripContainer;
        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editUndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editRedoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editCutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editPasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editSelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerDeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetDeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerBringForwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerSendBackwardMenuItem;
        private Control.MapTreeView m_mapTreeView;
        private System.Windows.Forms.ToolStrip m_editToolStrip;
        private System.Windows.Forms.ToolStripButton m_editCutButton;
        private System.Windows.Forms.ToolStripButton m_editCopyButton;
        private System.Windows.Forms.ToolStripButton m_editPasteButton;
        private System.Windows.Forms.ToolStripButton m_editUndoButton;
        private System.Windows.Forms.ToolStripButton m_editRedoButton;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator1;
        private System.Windows.Forms.SplitContainer m_splitContainerLeftRight;
        private TileMapEditor.Control.TilePicker m_tilePicker;
        private TileMapEditor.Control.MapPanel m_mapPanel;
        private System.Windows.Forms.ToolStrip m_mapToolStrip;
        private System.Windows.Forms.ToolStripButton m_mapPropertiesButton;
        private System.Windows.Forms.ToolStrip m_tileSheetToolStrip;
        private System.Windows.Forms.ToolStripButton m_tileSheetNewButton;
        private System.Windows.Forms.ToolStripButton m_tileSheetPropertiesButton;
        private System.Windows.Forms.ToolStripButton m_tileSheetDeleteButton;
        private System.Windows.Forms.ToolStrip m_layerToolStrip;
        private System.Windows.Forms.ToolStripButton m_layerNewButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy3MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy4MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy5MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy6MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy7MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy8MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy9MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomBy10MenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomInMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomOutMenuItem;
        private System.Windows.Forms.ToolStrip m_viewToolStrip;
        private System.Windows.Forms.ToolStripButton m_viewZoomInButton;
        private System.Windows.Forms.ToolStripButton m_viewZoomOutButton;
        private System.Windows.Forms.ToolStripButton m_layerPropertiesButton;
        private System.Windows.Forms.ToolStripSeparator m_layerToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_layerBringForwardButton;
        private System.Windows.Forms.ToolStripButton m_layerSendBackwardButton;
        private System.Windows.Forms.ToolStripSeparator m_layerToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_layerDeleteButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewZoomMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_viewSeparator1;
        private System.Windows.Forms.ToolStripButton m_viewTileGuidesButton;
        private System.Windows.Forms.ToolStripButton m_viewLayerCompositingButton;
        private System.Windows.Forms.ToolStripComboBox m_viewZoomComboBox;
        private System.Windows.Forms.ToolStripMenuItem m_editClearSelectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editInvertSelectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editDeleteMenuItem;
        private System.Windows.Forms.ToolStripButton m_editDeleteButton;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_editSelectAllButton;
        private System.Windows.Forms.ToolStripButton m_editClearSelectionButton;
        private System.Windows.Forms.ToolStripButton m_editInvertSelection;
        private System.Windows.Forms.ToolStripMenuItem m_pluginsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_pluginsReloadMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip m_toolsToolStrip;
        private System.Windows.Forms.ToolStripButton m_toolsSelectButton;
        private System.Windows.Forms.ToolStripButton m_toolsSingleTileButton;
        private System.Windows.Forms.ToolStripButton m_toolsTileBlockButton;
        private System.Windows.Forms.ToolStripButton m_toolsEraserButton;
        private System.Windows.Forms.ToolStripButton m_toolsDropperButton;
        private TileMapEditor.Control.CustomToolStripSplitButton m_toolsTileBrushButton;
        private System.Windows.Forms.ToolStripContainer m_toolStripContainerInner;
        private System.Windows.Forms.ToolStripMenuItem m_editMakeTileBrushMenuItem;
        private System.Windows.Forms.ToolStripButton m_editMakeTileBrushButton;
        private System.Windows.Forms.ToolStripMenuItem m_editManageTileBrushesMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_editToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_editManageTileBrushesButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Splitter m_splitter;
        private System.Windows.Forms.ToolStripMenuItem m_viewWindowModeMenuItem;
        private System.Windows.Forms.ToolStripButton m_viewWindowModeButton;
        private System.Windows.Forms.ToolStripMenuItem m_viewLayerCompositingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_viewTileGuidesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerVisibilityMenuItem;
        private System.Windows.Forms.ToolStripButton m_layerVisibilityButton;
    }
}