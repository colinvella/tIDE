namespace TileMapEditor.Controls
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
            this.m_innerPanel = new TileMapEditor.Controls.CustomPanel();
            this.m_tileContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_verticalScrollBar
            // 
            this.m_verticalScrollBar.AccessibleDescription = null;
            this.m_verticalScrollBar.AccessibleName = null;
            resources.ApplyResources(this.m_verticalScrollBar, "m_verticalScrollBar");
            this.m_verticalScrollBar.BackgroundImage = null;
            this.m_verticalScrollBar.Font = null;
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVerticalScroll);
            // 
            // m_horizontalScrollBar
            // 
            this.m_horizontalScrollBar.AccessibleDescription = null;
            this.m_horizontalScrollBar.AccessibleName = null;
            resources.ApplyResources(this.m_horizontalScrollBar, "m_horizontalScrollBar");
            this.m_horizontalScrollBar.BackgroundImage = null;
            this.m_horizontalScrollBar.Font = null;
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnHorizontalScroll);
            // 
            // m_animationTimer
            // 
            this.m_animationTimer.Tick += new System.EventHandler(this.OnAnimationTimer);
            // 
            // m_tileContextMenuStrip
            // 
            this.m_tileContextMenuStrip.AccessibleDescription = null;
            this.m_tileContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_tileContextMenuStrip, "m_tileContextMenuStrip");
            this.m_tileContextMenuStrip.BackgroundImage = null;
            this.m_tileContextMenuStrip.Font = null;
            this.m_tileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tilePropertiesMenuItem,
            this.tileAnimationToolStripMenuItem});
            this.m_tileContextMenuStrip.Name = "m_tileContextMenuStrip";
            // 
            // m_tilePropertiesMenuItem
            // 
            this.m_tilePropertiesMenuItem.AccessibleDescription = null;
            this.m_tilePropertiesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_tilePropertiesMenuItem, "m_tilePropertiesMenuItem");
            this.m_tilePropertiesMenuItem.BackgroundImage = null;
            this.m_tilePropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileProperties;
            this.m_tilePropertiesMenuItem.Name = "m_tilePropertiesMenuItem";
            this.m_tilePropertiesMenuItem.ShortcutKeyDisplayString = null;
            this.m_tilePropertiesMenuItem.Click += new System.EventHandler(this.OnTileProperties);
            // 
            // tileAnimationToolStripMenuItem
            // 
            this.tileAnimationToolStripMenuItem.AccessibleDescription = null;
            this.tileAnimationToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.tileAnimationToolStripMenuItem, "tileAnimationToolStripMenuItem");
            this.tileAnimationToolStripMenuItem.BackgroundImage = null;
            this.tileAnimationToolStripMenuItem.Image = global::TileMapEditor.Properties.Resources.TileAnimation;
            this.tileAnimationToolStripMenuItem.Name = "tileAnimationToolStripMenuItem";
            this.tileAnimationToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.tileAnimationToolStripMenuItem.Click += new System.EventHandler(this.OnTileAnimation);
            // 
            // m_innerPanel
            // 
            this.m_innerPanel.AccessibleDescription = null;
            this.m_innerPanel.AccessibleName = null;
            resources.ApplyResources(this.m_innerPanel, "m_innerPanel");
            this.m_innerPanel.BackgroundImage = global::TileMapEditor.Properties.Resources.ImageBackground;
            this.m_innerPanel.Font = null;
            this.m_innerPanel.Name = "m_innerPanel";
            this.m_innerPanel.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.m_innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMapPaint);
            this.m_innerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.m_innerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.m_innerPanel.Resize += new System.EventHandler(this.OnResizeDisplay);
            this.m_innerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.m_innerPanel.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            // 
            // MapPanel
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_innerPanel);
            this.Controls.Add(this.m_horizontalScrollBar);
            this.Controls.Add(this.m_verticalScrollBar);
            this.Font = null;
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
    }
}
