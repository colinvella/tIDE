using xTile;

namespace TileMapEditor.Controls
{
    partial class MapTreeView
    {
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.ImageList m_imageList;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label m_labelCaption;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTreeView));
            System.Windows.Forms.Panel m_treePanel;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_layersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_layerNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_layerPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerVisibilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerBringForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerSendBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_layerDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapStatisticsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tileSheetNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tileSheetPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetAutoTilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tileSheetDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            m_labelCaption = new System.Windows.Forms.Label();
            m_treePanel = new System.Windows.Forms.Panel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            m_treePanel.SuspendLayout();
            this.m_layersContextMenuStrip.SuspendLayout();
            this.m_layerContextMenuStrip.SuspendLayout();
            this.m_mapContextMenuStrip.SuspendLayout();
            this.m_tileSheetsContextMenuStrip.SuspendLayout();
            this.m_tileSheetContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.AccessibleDescription = null;
            m_labelCaption.AccessibleName = null;
            resources.ApplyResources(m_labelCaption, "m_labelCaption");
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_labelCaption.Font = null;
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Name = "m_labelCaption";
            // 
            // m_treePanel
            // 
            m_treePanel.AccessibleDescription = null;
            m_treePanel.AccessibleName = null;
            resources.ApplyResources(m_treePanel, "m_treePanel");
            m_treePanel.BackgroundImage = null;
            m_treePanel.Controls.Add(this.m_treeView);
            m_treePanel.Font = null;
            m_treePanel.Name = "m_treePanel";
            // 
            // m_treeView
            // 
            this.m_treeView.AccessibleDescription = null;
            this.m_treeView.AccessibleName = null;
            resources.ApplyResources(this.m_treeView, "m_treeView");
            this.m_treeView.BackgroundImage = null;
            this.m_treeView.Font = null;
            this.m_treeView.ImageList = this.m_imageList;
            this.m_treeView.Name = "m_treeView";
            this.m_treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("m_treeView.Nodes")))});
            this.m_treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            this.m_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelect);
            this.m_treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnBeforeSelect);
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "Map.png");
            this.m_imageList.Images.SetKeyName(1, "LayerFolder.png");
            this.m_imageList.Images.SetKeyName(2, "LayerVisible.png");
            this.m_imageList.Images.SetKeyName(3, "LayerInvisible.png");
            this.m_imageList.Images.SetKeyName(4, "TileSheetFolder.png");
            this.m_imageList.Images.SetKeyName(5, "TileSheet.png");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.AccessibleDescription = null;
            toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.AccessibleDescription = null;
            toolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.AccessibleDescription = null;
            toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // m_layersContextMenuStrip
            // 
            this.m_layersContextMenuStrip.AccessibleDescription = null;
            this.m_layersContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_layersContextMenuStrip, "m_layersContextMenuStrip");
            this.m_layersContextMenuStrip.BackgroundImage = null;
            this.m_layersContextMenuStrip.Font = null;
            this.m_layersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerNewMenuItem});
            this.m_layersContextMenuStrip.Name = "m_contextMenuLayers";
            // 
            // m_layerNewMenuItem
            // 
            this.m_layerNewMenuItem.AccessibleDescription = null;
            this.m_layerNewMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerNewMenuItem, "m_layerNewMenuItem");
            this.m_layerNewMenuItem.BackgroundImage = null;
            this.m_layerNewMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerNew;
            this.m_layerNewMenuItem.Name = "m_layerNewMenuItem";
            this.m_layerNewMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerNewMenuItem.Click += new System.EventHandler(this.OnLayerNew);
            // 
            // m_layerContextMenuStrip
            // 
            this.m_layerContextMenuStrip.AccessibleDescription = null;
            this.m_layerContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_layerContextMenuStrip, "m_layerContextMenuStrip");
            this.m_layerContextMenuStrip.BackgroundImage = null;
            this.m_layerContextMenuStrip.Font = null;
            this.m_layerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_layerPropertiesMenuItem,
            this.m_layerVisibilityMenuItem,
            toolStripMenuItem1,
            this.m_layerBringForwardMenuItem,
            this.m_layerSendBackwardMenuItem,
            toolStripSeparator2,
            this.m_layerDeleteMenuItem});
            this.m_layerContextMenuStrip.Name = "m_contextMenuLayer";
            this.m_layerContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextMenuLayerOpening);
            // 
            // m_layerPropertiesMenuItem
            // 
            this.m_layerPropertiesMenuItem.AccessibleDescription = null;
            this.m_layerPropertiesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerPropertiesMenuItem, "m_layerPropertiesMenuItem");
            this.m_layerPropertiesMenuItem.BackgroundImage = null;
            this.m_layerPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerProperties;
            this.m_layerPropertiesMenuItem.Name = "m_layerPropertiesMenuItem";
            this.m_layerPropertiesMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerPropertiesMenuItem.Click += new System.EventHandler(this.OnLayerProperties);
            // 
            // m_layerVisibilityMenuItem
            // 
            this.m_layerVisibilityMenuItem.AccessibleDescription = null;
            this.m_layerVisibilityMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerVisibilityMenuItem, "m_layerVisibilityMenuItem");
            this.m_layerVisibilityMenuItem.BackgroundImage = null;
            this.m_layerVisibilityMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerInvisible;
            this.m_layerVisibilityMenuItem.Name = "m_layerVisibilityMenuItem";
            this.m_layerVisibilityMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerVisibilityMenuItem.Click += new System.EventHandler(this.OnLayerVisibility);
            // 
            // m_layerBringForwardMenuItem
            // 
            this.m_layerBringForwardMenuItem.AccessibleDescription = null;
            this.m_layerBringForwardMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerBringForwardMenuItem, "m_layerBringForwardMenuItem");
            this.m_layerBringForwardMenuItem.BackgroundImage = null;
            this.m_layerBringForwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerBringForward;
            this.m_layerBringForwardMenuItem.Name = "m_layerBringForwardMenuItem";
            this.m_layerBringForwardMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerBringForwardMenuItem.Click += new System.EventHandler(this.OnLayerBringForward);
            // 
            // m_layerSendBackwardMenuItem
            // 
            this.m_layerSendBackwardMenuItem.AccessibleDescription = null;
            this.m_layerSendBackwardMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerSendBackwardMenuItem, "m_layerSendBackwardMenuItem");
            this.m_layerSendBackwardMenuItem.BackgroundImage = null;
            this.m_layerSendBackwardMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerSendBackward;
            this.m_layerSendBackwardMenuItem.Name = "m_layerSendBackwardMenuItem";
            this.m_layerSendBackwardMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerSendBackwardMenuItem.Click += new System.EventHandler(this.OnLayerSendBackward);
            // 
            // m_layerDeleteMenuItem
            // 
            this.m_layerDeleteMenuItem.AccessibleDescription = null;
            this.m_layerDeleteMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_layerDeleteMenuItem, "m_layerDeleteMenuItem");
            this.m_layerDeleteMenuItem.BackgroundImage = null;
            this.m_layerDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.LayerDelete;
            this.m_layerDeleteMenuItem.Name = "m_layerDeleteMenuItem";
            this.m_layerDeleteMenuItem.ShortcutKeyDisplayString = null;
            this.m_layerDeleteMenuItem.Click += new System.EventHandler(this.OnLayerDelete);
            // 
            // m_mapContextMenuStrip
            // 
            this.m_mapContextMenuStrip.AccessibleDescription = null;
            this.m_mapContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_mapContextMenuStrip, "m_mapContextMenuStrip");
            this.m_mapContextMenuStrip.BackgroundImage = null;
            this.m_mapContextMenuStrip.Font = null;
            this.m_mapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mapPropertiesMenuItem,
            this.m_mapStatisticsMenuItem});
            this.m_mapContextMenuStrip.Name = "m_contextMenuMap";
            // 
            // m_mapPropertiesMenuItem
            // 
            this.m_mapPropertiesMenuItem.AccessibleDescription = null;
            this.m_mapPropertiesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_mapPropertiesMenuItem, "m_mapPropertiesMenuItem");
            this.m_mapPropertiesMenuItem.BackgroundImage = null;
            this.m_mapPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.MapProperties;
            this.m_mapPropertiesMenuItem.Name = "m_mapPropertiesMenuItem";
            this.m_mapPropertiesMenuItem.ShortcutKeyDisplayString = null;
            this.m_mapPropertiesMenuItem.Click += new System.EventHandler(this.OnMapProperties);
            // 
            // m_mapStatisticsMenuItem
            // 
            this.m_mapStatisticsMenuItem.AccessibleDescription = null;
            this.m_mapStatisticsMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_mapStatisticsMenuItem, "m_mapStatisticsMenuItem");
            this.m_mapStatisticsMenuItem.BackgroundImage = null;
            this.m_mapStatisticsMenuItem.Image = global::TileMapEditor.Properties.Resources.MapStatistics;
            this.m_mapStatisticsMenuItem.Name = "m_mapStatisticsMenuItem";
            this.m_mapStatisticsMenuItem.ShortcutKeyDisplayString = null;
            this.m_mapStatisticsMenuItem.Click += new System.EventHandler(this.OnMapStatistics);
            // 
            // m_tileSheetsContextMenuStrip
            // 
            this.m_tileSheetsContextMenuStrip.AccessibleDescription = null;
            this.m_tileSheetsContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetsContextMenuStrip, "m_tileSheetsContextMenuStrip");
            this.m_tileSheetsContextMenuStrip.BackgroundImage = null;
            this.m_tileSheetsContextMenuStrip.Font = null;
            this.m_tileSheetsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetNewMenuItem});
            this.m_tileSheetsContextMenuStrip.Name = "m_tileSheetsContextMenuStrip";
            // 
            // m_tileSheetNewMenuItem
            // 
            this.m_tileSheetNewMenuItem.AccessibleDescription = null;
            this.m_tileSheetNewMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetNewMenuItem, "m_tileSheetNewMenuItem");
            this.m_tileSheetNewMenuItem.BackgroundImage = null;
            this.m_tileSheetNewMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetNew;
            this.m_tileSheetNewMenuItem.Name = "m_tileSheetNewMenuItem";
            this.m_tileSheetNewMenuItem.ShortcutKeyDisplayString = null;
            this.m_tileSheetNewMenuItem.Click += new System.EventHandler(this.OnTileSheetNew);
            // 
            // m_tileSheetContextMenuStrip
            // 
            this.m_tileSheetContextMenuStrip.AccessibleDescription = null;
            this.m_tileSheetContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetContextMenuStrip, "m_tileSheetContextMenuStrip");
            this.m_tileSheetContextMenuStrip.BackgroundImage = null;
            this.m_tileSheetContextMenuStrip.Font = null;
            this.m_tileSheetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tileSheetPropertiesMenuItem,
            this.m_tileSheetAutoTilesMenuItem,
            toolStripSeparator1,
            this.m_tileSheetDeleteMenuItem});
            this.m_tileSheetContextMenuStrip.Name = "m_tileSheetContextMenuStrip";
            // 
            // m_tileSheetPropertiesMenuItem
            // 
            this.m_tileSheetPropertiesMenuItem.AccessibleDescription = null;
            this.m_tileSheetPropertiesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetPropertiesMenuItem, "m_tileSheetPropertiesMenuItem");
            this.m_tileSheetPropertiesMenuItem.BackgroundImage = null;
            this.m_tileSheetPropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetProperties;
            this.m_tileSheetPropertiesMenuItem.Name = "m_tileSheetPropertiesMenuItem";
            this.m_tileSheetPropertiesMenuItem.ShortcutKeyDisplayString = null;
            this.m_tileSheetPropertiesMenuItem.Click += new System.EventHandler(this.OnTileSheetProperties);
            // 
            // m_tileSheetAutoTilesMenuItem
            // 
            this.m_tileSheetAutoTilesMenuItem.AccessibleDescription = null;
            this.m_tileSheetAutoTilesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetAutoTilesMenuItem, "m_tileSheetAutoTilesMenuItem");
            this.m_tileSheetAutoTilesMenuItem.BackgroundImage = null;
            this.m_tileSheetAutoTilesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetAutoTiles;
            this.m_tileSheetAutoTilesMenuItem.Name = "m_tileSheetAutoTilesMenuItem";
            this.m_tileSheetAutoTilesMenuItem.ShortcutKeyDisplayString = null;
            this.m_tileSheetAutoTilesMenuItem.Click += new System.EventHandler(this.OnTileSheetAutoTiles);
            // 
            // m_tileSheetDeleteMenuItem
            // 
            this.m_tileSheetDeleteMenuItem.AccessibleDescription = null;
            this.m_tileSheetDeleteMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_tileSheetDeleteMenuItem, "m_tileSheetDeleteMenuItem");
            this.m_tileSheetDeleteMenuItem.BackgroundImage = null;
            this.m_tileSheetDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.TileSheetDelete;
            this.m_tileSheetDeleteMenuItem.Name = "m_tileSheetDeleteMenuItem";
            this.m_tileSheetDeleteMenuItem.ShortcutKeyDisplayString = null;
            this.m_tileSheetDeleteMenuItem.Click += new System.EventHandler(this.OnTileSheetDelete);
            // 
            // MapTreeView
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(m_treePanel);
            this.Controls.Add(m_labelCaption);
            this.Font = null;
            this.Name = "MapTreeView";
            m_treePanel.ResumeLayout(false);
            this.m_layersContextMenuStrip.ResumeLayout(false);
            this.m_layerContextMenuStrip.ResumeLayout(false);
            this.m_mapContextMenuStrip.ResumeLayout(false);
            this.m_tileSheetsContextMenuStrip.ResumeLayout(false);
            this.m_tileSheetContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_layersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_layerNewMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_layerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_layerPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerBringForwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerSendBackwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerDeleteMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_mapContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_mapPropertiesMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_tileSheetsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetNewMenuItem;
        private System.Windows.Forms.ContextMenuStrip m_tileSheetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetDeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_layerVisibilityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_mapStatisticsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_tileSheetAutoTilesMenuItem;


        #region Public Methods

        #endregion
    }
}
