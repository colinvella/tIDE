namespace TileMapEditor.Dialogs
{
    partial class TileAnimationDialog
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
            TileMapEditor.Controls.CustomPanel m_customPanel;
            System.Windows.Forms.SplitContainer m_splitContainerOuter;
            System.Windows.Forms.SplitContainer m_splitContainerInner;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileAnimationDialog));
            this.m_tilePicker = new TileMapEditor.Controls.TilePicker();
            this.m_previewPanel = new TileMapEditor.Controls.CustomPanel();
            this.m_animationListView = new System.Windows.Forms.ListView();
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_imageListAnimation = new System.Windows.Forms.ImageList(this.components);
            m_customPanel = new TileMapEditor.Controls.CustomPanel();
            m_splitContainerOuter = new System.Windows.Forms.SplitContainer();
            m_splitContainerInner = new System.Windows.Forms.SplitContainer();
            m_customPanel.SuspendLayout();
            m_splitContainerOuter.Panel1.SuspendLayout();
            m_splitContainerOuter.Panel2.SuspendLayout();
            m_splitContainerOuter.SuspendLayout();
            m_splitContainerInner.Panel1.SuspendLayout();
            m_splitContainerInner.Panel2.SuspendLayout();
            m_splitContainerInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_customPanel
            // 
            m_customPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            m_customPanel.Controls.Add(m_splitContainerOuter);
            m_customPanel.Location = new System.Drawing.Point(12, 12);
            m_customPanel.Name = "m_customPanel";
            m_customPanel.Size = new System.Drawing.Size(560, 359);
            m_customPanel.TabIndex = 0;
            // 
            // m_splitContainerOuter
            // 
            m_splitContainerOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            m_splitContainerOuter.Location = new System.Drawing.Point(0, 0);
            m_splitContainerOuter.Name = "m_splitContainerOuter";
            // 
            // m_splitContainerOuter.Panel1
            // 
            m_splitContainerOuter.Panel1.Controls.Add(this.m_tilePicker);
            // 
            // m_splitContainerOuter.Panel2
            // 
            m_splitContainerOuter.Panel2.Controls.Add(m_splitContainerInner);
            m_splitContainerOuter.Size = new System.Drawing.Size(560, 359);
            m_splitContainerOuter.SplitterDistance = 186;
            m_splitContainerOuter.TabIndex = 0;
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.AutoUpdate = false;
            this.m_tilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tilePicker.Location = new System.Drawing.Point(0, 0);
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.Size = new System.Drawing.Size(186, 359);
            this.m_tilePicker.TabIndex = 0;
            this.m_tilePicker.TileDrag += new TileMapEditor.Controls.TileDragEventHandler(this.OnTileDrag);
            // 
            // m_splitContainerInner
            // 
            m_splitContainerInner.Dock = System.Windows.Forms.DockStyle.Fill;
            m_splitContainerInner.Location = new System.Drawing.Point(0, 0);
            m_splitContainerInner.Name = "m_splitContainerInner";
            m_splitContainerInner.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerInner.Panel1
            // 
            m_splitContainerInner.Panel1.Controls.Add(this.m_previewPanel);
            // 
            // m_splitContainerInner.Panel2
            // 
            m_splitContainerInner.Panel2.Controls.Add(this.m_animationListView);
            m_splitContainerInner.Size = new System.Drawing.Size(370, 359);
            m_splitContainerInner.SplitterDistance = 180;
            m_splitContainerInner.TabIndex = 0;
            // 
            // m_previewPanel
            // 
            this.m_previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_previewPanel.Location = new System.Drawing.Point(0, 0);
            this.m_previewPanel.Name = "m_previewPanel";
            this.m_previewPanel.Size = new System.Drawing.Size(370, 180);
            this.m_previewPanel.TabIndex = 0;
            // 
            // m_animationListView
            // 
            this.m_animationListView.AllowDrop = true;
            this.m_animationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_animationListView.Location = new System.Drawing.Point(0, 0);
            this.m_animationListView.Name = "m_animationListView";
            this.m_animationListView.Size = new System.Drawing.Size(370, 175);
            this.m_animationListView.TabIndex = 0;
            this.m_animationListView.UseCompatibleStateImageBehavior = false;
            this.m_animationListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTileDragDrop);
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Enabled = false;
            this.m_buttonOk.Location = new System.Drawing.Point(335, 377);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 1;
            this.m_buttonOk.Text = "&Ok";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonApply.Enabled = false;
            this.m_buttonApply.Location = new System.Drawing.Point(416, 377);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(75, 23);
            this.m_buttonApply.TabIndex = 2;
            this.m_buttonApply.Text = "&Apply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Location = new System.Drawing.Point(497, 377);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 3;
            this.m_buttonCancel.Text = "&Cancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_imageListAnimation
            // 
            this.m_imageListAnimation.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_imageListAnimation.ImageSize = new System.Drawing.Size(16, 16);
            this.m_imageListAnimation.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TileAnimationDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonOk);
            this.Controls.Add(m_customPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TileAnimationDialog";
            this.Text = "Tile Animation";
            this.Load += new System.EventHandler(this.TileAnimationDialog_Load);
            m_customPanel.ResumeLayout(false);
            m_splitContainerOuter.Panel1.ResumeLayout(false);
            m_splitContainerOuter.Panel2.ResumeLayout(false);
            m_splitContainerOuter.ResumeLayout(false);
            m_splitContainerInner.Panel1.ResumeLayout(false);
            m_splitContainerInner.Panel2.ResumeLayout(false);
            m_splitContainerInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonCancel;
        private TileMapEditor.Controls.TilePicker m_tilePicker;
        private TileMapEditor.Controls.CustomPanel m_previewPanel;
        private System.Windows.Forms.ListView m_animationListView;
        private System.Windows.Forms.ImageList m_imageListAnimation;

    }
}