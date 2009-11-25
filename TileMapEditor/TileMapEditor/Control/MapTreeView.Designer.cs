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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Layers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tile Sheets");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Map", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapTreeView));
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // m_treeView
            // 
            this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeView.ImageIndex = 0;
            this.m_treeView.ImageList = this.m_imageList;
            this.m_treeView.Location = new System.Drawing.Point(0, 0);
            this.m_treeView.Name = "m_treeView";
            treeNode1.ImageKey = "Collection.png";
            treeNode1.Name = "Layers";
            treeNode1.SelectedImageKey = "Collection.png";
            treeNode1.Text = "Layers";
            treeNode2.ImageKey = "Collection.png";
            treeNode2.Name = "TileSheets";
            treeNode2.SelectedImageKey = "Collection.png";
            treeNode2.Text = "Tile Sheets";
            treeNode3.ImageKey = "Map.png";
            treeNode3.Name = "Map";
            treeNode3.SelectedImageKey = "Map.png";
            treeNode3.Text = "Map";
            this.m_treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.m_treeView.SelectedImageIndex = 0;
            this.m_treeView.Size = new System.Drawing.Size(150, 150);
            this.m_treeView.TabIndex = 0;
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "Map.png");
            this.m_imageList.Images.SetKeyName(1, "Collection.png");
            this.m_imageList.Images.SetKeyName(2, "Layer.png");
            this.m_imageList.Images.SetKeyName(3, "TileSheet.png");
            // 
            // MapTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_treeView);
            this.Name = "MapTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        #region Public Methods

        #endregion
    }
}
