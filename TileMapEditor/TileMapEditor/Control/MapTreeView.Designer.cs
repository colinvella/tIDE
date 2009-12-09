using Tiling;

namespace TileMapEditor.Control
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
            System.Windows.Forms.Panel m_treePanel;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Layers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tile Sheets");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Map", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTreeView));
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            m_labelCaption = new System.Windows.Forms.Label();
            m_treePanel = new System.Windows.Forms.Panel();
            m_treePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Location = new System.Drawing.Point(0, 0);
            m_labelCaption.Name = "m_labelCaption";
            m_labelCaption.Padding = new System.Windows.Forms.Padding(2);
            m_labelCaption.Size = new System.Drawing.Size(150, 20);
            m_labelCaption.TabIndex = 1;
            m_labelCaption.Text = "Map Explorer";
            m_labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_treePanel
            // 
            m_treePanel.Controls.Add(this.m_treeView);
            m_treePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            m_treePanel.Location = new System.Drawing.Point(0, 20);
            m_treePanel.Name = "m_treePanel";
            m_treePanel.Size = new System.Drawing.Size(150, 130);
            m_treePanel.TabIndex = 2;
            // 
            // m_treeView
            // 
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.ImageIndex = 0;
            this.m_treeView.ImageList = this.m_imageList;
            this.m_treeView.Location = new System.Drawing.Point(0, 0);
            this.m_treeView.Name = "m_treeView";
            treeNode1.ImageKey = "LayerFolder.png";
            treeNode1.Name = "Layers";
            treeNode1.SelectedImageKey = "LayerFolder.png";
            treeNode1.Text = "Layers";
            treeNode2.ImageKey = "TileSheetFolder.png";
            treeNode2.Name = "TileSheets";
            treeNode2.SelectedImageKey = "TileSheetFolder.png";
            treeNode2.Text = "Tile Sheets";
            treeNode3.ImageKey = "Map.png";
            treeNode3.Name = "Map";
            treeNode3.SelectedImageKey = "Map.png";
            treeNode3.Text = "Map";
            this.m_treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.m_treeView.SelectedImageIndex = 0;
            this.m_treeView.Size = new System.Drawing.Size(150, 130);
            this.m_treeView.TabIndex = 0;
            this.m_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_treeView_AfterSelect);
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "Map.png");
            this.m_imageList.Images.SetKeyName(1, "Layer.png");
            this.m_imageList.Images.SetKeyName(2, "TileSheet.png");
            this.m_imageList.Images.SetKeyName(3, "LayerFolder.png");
            this.m_imageList.Images.SetKeyName(4, "TileSheetFolder.png");
            // 
            // MapTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(m_treePanel);
            this.Controls.Add(m_labelCaption);
            this.Name = "MapTreeView";
            m_treePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Public Methods

        #endregion
    }
}
