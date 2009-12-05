namespace TileMapEditor.Control
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
            this.m_verticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.m_horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.m_animationTimer = new System.Windows.Forms.Timer(this.components);
            this.m_innerPanel = new TileMapEditor.Control.CustomPanel();
            this.SuspendLayout();
            // 
            // m_verticalScrollBar
            // 
            this.m_verticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_verticalScrollBar.Location = new System.Drawing.Point(301, 0);
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Size = new System.Drawing.Size(17, 238);
            this.m_verticalScrollBar.TabIndex = 0;
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVerticalScroll);
            // 
            // m_horizontalScrollBar
            // 
            this.m_horizontalScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_horizontalScrollBar.Location = new System.Drawing.Point(0, 221);
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Size = new System.Drawing.Size(301, 17);
            this.m_horizontalScrollBar.TabIndex = 1;
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnHorizontalScroll);
            // 
            // m_animationTimer
            // 
            this.m_animationTimer.Enabled = true;
            this.m_animationTimer.Tick += new System.EventHandler(this.m_animationTimer_Tick);
            // 
            // m_innerPanel
            // 
            this.m_innerPanel.BackgroundImage = global::TileMapEditor.Properties.Resources.ImageBackground;
            this.m_innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_innerPanel.Location = new System.Drawing.Point(0, 0);
            this.m_innerPanel.Name = "m_innerPanel";
            this.m_innerPanel.Size = new System.Drawing.Size(301, 221);
            this.m_innerPanel.TabIndex = 2;
            this.m_innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMapPaint);
            this.m_innerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.m_innerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.m_innerPanel.Resize += new System.EventHandler(this.OnResizeDisplay);
            this.m_innerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // MapPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_innerPanel);
            this.Controls.Add(this.m_horizontalScrollBar);
            this.Controls.Add(this.m_verticalScrollBar);
            this.Name = "MapPanel";
            this.Size = new System.Drawing.Size(318, 238);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar m_verticalScrollBar;
        private System.Windows.Forms.HScrollBar m_horizontalScrollBar;
        private CustomPanel m_innerPanel;
        private System.Windows.Forms.Timer m_animationTimer;
    }
}
