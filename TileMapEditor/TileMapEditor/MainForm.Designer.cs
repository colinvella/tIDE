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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.m_mapPanel = new System.Windows.Forms.Panel();
            this.m_splitter = new System.Windows.Forms.Splitter();
            this.m_mapTreeView = new TileMapEditor.Control.MapTreeView();
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.m_fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editUndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editRedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editCutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_editPasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_editSelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_LayerSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_layerBringForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerSendBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_layerDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_tileSheetDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.m_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_mapPanel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_splitter);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_mapTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 538);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 562);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.m_menuStrip);
            // 
            // m_mapPanel
            // 
            this.m_mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mapPanel.Location = new System.Drawing.Point(204, 0);
            this.m_mapPanel.Name = "m_mapPanel";
            this.m_mapPanel.Size = new System.Drawing.Size(580, 538);
            this.m_mapPanel.TabIndex = 2;
            // 
            // m_splitter
            // 
            this.m_splitter.Location = new System.Drawing.Point(200, 0);
            this.m_splitter.Name = "m_splitter";
            this.m_splitter.Size = new System.Drawing.Size(4, 538);
            this.m_splitter.TabIndex = 1;
            this.m_splitter.TabStop = false;
            // 
            // m_mapTreeView
            // 
            this.m_mapTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_mapTreeView.Location = new System.Drawing.Point(0, 0);
            this.m_mapTreeView.Map = null;
            this.m_mapTreeView.Name = "m_mapTreeView";
            this.m_mapTreeView.Size = new System.Drawing.Size(200, 538);
            this.m_mapTreeView.TabIndex = 0;
            // 
            // m_menuStrip
            // 
            this.m_menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_fileMenuItem,
            this.m_editMenuItem,
            this.m_mapMenuItem,
            this.m_layerMenuItem,
            this.m_tileSheetMenuItem,
            this.m_helpMenuItem});
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
            this.m_fileSeparator1,
            this.m_fileSaveMenuItem,
            this.m_fileSaveAsMenuItem,
            this.m_fileSeparator2,
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
            this.m_fileNewMenuItem.Size = new System.Drawing.Size(146, 22);
            this.m_fileNewMenuItem.Text = "&New";
            this.m_fileNewMenuItem.Click += new System.EventHandler(this.OnFileNew);
            // 
            // m_fileOpenMenuItem
            // 
            this.m_fileOpenMenuItem.Image = global::TileMapEditor.Properties.Resources.FileOpen;
            this.m_fileOpenMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_fileOpenMenuItem.Name = "m_fileOpenMenuItem";
            this.m_fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.m_fileOpenMenuItem.Size = new System.Drawing.Size(146, 22);
            this.m_fileOpenMenuItem.Text = "&Open";
            // 
            // m_fileSeparator1
            // 
            this.m_fileSeparator1.Name = "m_fileSeparator1";
            this.m_fileSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // m_fileSaveMenuItem
            // 
            this.m_fileSaveMenuItem.Image = global::TileMapEditor.Properties.Resources.FileSave;
            this.m_fileSaveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_fileSaveMenuItem.Name = "m_fileSaveMenuItem";
            this.m_fileSaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.m_fileSaveMenuItem.Size = new System.Drawing.Size(146, 22);
            this.m_fileSaveMenuItem.Text = "&Save";
            // 
            // m_fileSaveAsMenuItem
            // 
            this.m_fileSaveAsMenuItem.Image = global::TileMapEditor.Properties.Resources.FileSaveAs;
            this.m_fileSaveAsMenuItem.Name = "m_fileSaveAsMenuItem";
            this.m_fileSaveAsMenuItem.Size = new System.Drawing.Size(146, 22);
            this.m_fileSaveAsMenuItem.Text = "Save &As";
            // 
            // m_fileSeparator2
            // 
            this.m_fileSeparator2.Name = "m_fileSeparator2";
            this.m_fileSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // m_editMenuItem
            // 
            this.m_editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_editUndoMenuItem,
            this.m_editRedoMenuItem,
            this.toolStripSeparator3,
            this.m_editCutMenuItem,
            this.m_editCopyMenuItem,
            this.m_editPasteMenuItem,
            this.toolStripSeparator4,
            this.m_editSelectAllMenuItem});
            this.m_editMenuItem.Image = global::TileMapEditor.Properties.Resources.Edit;
            this.m_editMenuItem.Name = "m_editMenuItem";
            this.m_editMenuItem.Size = new System.Drawing.Size(55, 20);
            this.m_editMenuItem.Text = "&Edit";
            // 
            // m_editUndoMenuItem
            // 
            this.m_editUndoMenuItem.Image = global::TileMapEditor.Properties.Resources.EditUndo;
            this.m_editUndoMenuItem.Name = "m_editUndoMenuItem";
            this.m_editUndoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.m_editUndoMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editUndoMenuItem.Text = "&Undo";
            // 
            // m_editRedoMenuItem
            // 
            this.m_editRedoMenuItem.Image = global::TileMapEditor.Properties.Resources.EditRedo;
            this.m_editRedoMenuItem.Name = "m_editRedoMenuItem";
            this.m_editRedoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.m_editRedoMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editRedoMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // m_editCutMenuItem
            // 
            this.m_editCutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editCutMenuItem.Image")));
            this.m_editCutMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCutMenuItem.Name = "m_editCutMenuItem";
            this.m_editCutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_editCutMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editCutMenuItem.Text = "Cu&t";
            // 
            // m_editCopyMenuItem
            // 
            this.m_editCopyMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editCopyMenuItem.Image")));
            this.m_editCopyMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editCopyMenuItem.Name = "m_editCopyMenuItem";
            this.m_editCopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.m_editCopyMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editCopyMenuItem.Text = "&Copy";
            // 
            // m_editPasteMenuItem
            // 
            this.m_editPasteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_editPasteMenuItem.Image")));
            this.m_editPasteMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_editPasteMenuItem.Name = "m_editPasteMenuItem";
            this.m_editPasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.m_editPasteMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editPasteMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // m_editSelectAllMenuItem
            // 
            this.m_editSelectAllMenuItem.Name = "m_editSelectAllMenuItem";
            this.m_editSelectAllMenuItem.Size = new System.Drawing.Size(144, 22);
            this.m_editSelectAllMenuItem.Text = "Select &All";
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
            this.m_LayerSeparator1,
            this.m_layerBringForwardMenuItem,
            this.m_layerSendBackwardMenuItem,
            this.toolStripMenuItem1,
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
            this.m_layerNewMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerNewMenuItem.Text = "&New...";
            // 
            // m_layerPropertiesMenuItem
            // 
            this.m_layerPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerProperties;
            this.m_layerPropertiesMenuItem.Name = "m_layerPropertiesMenuItem";
            this.m_layerPropertiesMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerPropertiesMenuItem.Text = "Properties...";
            // 
            // m_LayerSeparator1
            // 
            this.m_LayerSeparator1.Name = "m_LayerSeparator1";
            this.m_LayerSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // m_layerBringForwardMenuItem
            // 
            this.m_layerBringForwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardMenuItem.Name = "m_layerBringForwardMenuItem";
            this.m_layerBringForwardMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerBringForwardMenuItem.Text = "Bring Forward";
            // 
            // m_layerSendBackwardMenuItem
            // 
            this.m_layerSendBackwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardMenuItem.Name = "m_layerSendBackwardMenuItem";
            this.m_layerSendBackwardMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerSendBackwardMenuItem.Text = "Send Backward";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // m_layerDeleteMenuItem
            // 
            this.m_layerDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerDelete;
            this.m_layerDeleteMenuItem.Name = "m_layerDeleteMenuItem";
            this.m_layerDeleteMenuItem.Size = new System.Drawing.Size(154, 22);
            this.m_layerDeleteMenuItem.Text = "Delete";
            // 
            // m_tileSheetMenuItem
            // 
            this.m_tileSheetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewMenuItem,
            this.m_tileSheetPropertiesMenuItem,
            this.m_tileSheetSeparator1,
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
            this.m_tileSheetNewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_tileSheetNewMenuItem.Text = "New...";
            this.m_tileSheetNewMenuItem.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetPropertiesMenuItem
            // 
            this.m_tileSheetPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesMenuItem.Name = "m_tileSheetPropertiesMenuItem";
            this.m_tileSheetPropertiesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_tileSheetPropertiesMenuItem.Text = "Properties...";
            // 
            // m_tileSheetSeparator1
            // 
            this.m_tileSheetSeparator1.Name = "m_tileSheetSeparator1";
            this.m_tileSheetSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // m_tileSheetDeleteMenuItem
            // 
            this.m_tileSheetDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteMenuItem.Name = "m_tileSheetDeleteMenuItem";
            this.m_tileSheetDeleteMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_tileSheetDeleteMenuItem.Text = "Delete";
            // 
            // m_helpMenuItem
            // 
            this.m_helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::TileMapEditor.Properties.Resources.HelpAbout;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.m_menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Map Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_fileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_fileSaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_fileSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editUndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editRedoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_editCutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_editPasteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem m_editSelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerDeleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_LayerSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetDeleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_tileSheetSeparator1;
        private System.Windows.Forms.Splitter m_splitter;
        private System.Windows.Forms.Panel m_mapPanel;
        private System.Windows.Forms.ToolStripMenuItem m_layerBringForwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerSendBackwardMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private Control.MapTreeView m_mapTreeView;
    }
}