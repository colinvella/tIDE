namespace tIDE.Controls
{
    partial class MapPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPanel));
            this.m_verticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.m_horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.m_animationTimer = new System.Windows.Forms.Timer(this.components);
            this.m_tileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tilePropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_innerPanel = new tIDE.Controls.CustomPanel();
            this.m_tileSizeMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_textureToolMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_tileContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_verticalScrollBar
            // 
            resources.ApplyResources(this.m_verticalScrollBar, "m_verticalScrollBar");
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVerticalScroll);
            // 
            // m_horizontalScrollBar
            // 
            resources.ApplyResources(this.m_horizontalScrollBar, "m_horizontalScrollBar");
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnHorizontalScroll);
            // 
            // m_animationTimer
            // 
            this.m_animationTimer.Tick += new System.EventHandler(this.OnAnimationTimer);
            // 
            // m_tileContextMenuStrip
            // 
            this.m_tileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tilePropertiesMenuItem,
            this.tileAnimationToolStripMenuItem});
            this.m_tileContextMenuStrip.Name = "m_tileContextMenuStrip";
            resources.ApplyResources(this.m_tileContextMenuStrip, "m_tileContextMenuStrip");
            // 
            // m_tilePropertiesMenuItem
            // 
            this.m_tilePropertiesMenuItem.Image = global::tIDE.Properties.Resources.TileProperties;
            this.m_tilePropertiesMenuItem.Name = "m_tilePropertiesMenuItem";
            resources.ApplyResources(this.m_tilePropertiesMenuItem, "m_tilePropertiesMenuItem");
            this.m_tilePropertiesMenuItem.Click += new System.EventHandler(this.OnTileProperties);
            // 
            // tileAnimationToolStripMenuItem
            // 
            this.tileAnimationToolStripMenuItem.Image = global::tIDE.Properties.Resources.TileAnimation;
            this.tileAnimationToolStripMenuItem.Name = "tileAnimationToolStripMenuItem";
            resources.ApplyResources(this.tileAnimationToolStripMenuItem, "tileAnimationToolStripMenuItem");
            this.tileAnimationToolStripMenuItem.Click += new System.EventHandler(this.OnTileAnimation);
            // 
            // m_innerPanel
            // 
            this.m_innerPanel.BackgroundImage = global::tIDE.Properties.Resources.ImageBackground;
            resources.ApplyResources(this.m_innerPanel, "m_innerPanel");
            this.m_innerPanel.Name = "m_innerPanel";
            this.m_innerPanel.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.m_innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMapPaint);
            this.m_innerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.m_innerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.m_innerPanel.Resize += new System.EventHandler(this.OnResizeDisplay);
            this.m_innerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.m_innerPanel.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            // 
            // m_tileSizeMessageBox
            // 
            resources.ApplyResources(this.m_tileSizeMessageBox, "m_tileSizeMessageBox");
            this.m_tileSizeMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_tileSizeMessageBox.Owner = this;
            // 
            // m_textureToolMessageBox
            // 
            resources.ApplyResources(this.m_textureToolMessageBox, "m_textureToolMessageBox");
            this.m_textureToolMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_textureToolMessageBox.Owner = this;
            // 
            // MapPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_horizontalScrollBar);
            this.Controls.Add(this.m_verticalScrollBar);
            this.Controls.Add(this.m_innerPanel);
            this.Name = "MapPanel";
            this.m_tileContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar m_verticalScrollBar;
        private System.Windows.Forms.HScrollBar m_horizontalScrollBar;
        private CustomPanel m_innerPanel;
        private System.Windows.Forms.Timer m_animationTimer;
        private System.Windows.Forms.ContextMenuStrip m_tileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_tilePropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileAnimationToolStripMenuItem;
        private CustomMessageBox m_tileSizeMessageBox;
        private CustomMessageBox m_textureToolMessageBox;
    }
}
