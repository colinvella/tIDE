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
            this.m_verticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.m_horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.m_innerPanel = new TileMapEditor.Control.CustomPanel();
            this.SuspendLayout();
            // 
            // m_verticalScrollBar
            // 
            this.m_verticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_verticalScrollBar.Location = new System.Drawing.Point(303, 0);
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Size = new System.Drawing.Size(17, 240);
            this.m_verticalScrollBar.TabIndex = 0;
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_verticalScrollBar_Scroll);
            // 
            // m_horizontalScrollBar
            // 
            this.m_horizontalScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_horizontalScrollBar.Location = new System.Drawing.Point(0, 223);
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Size = new System.Drawing.Size(303, 17);
            this.m_horizontalScrollBar.TabIndex = 1;
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_horizontalScrollBar_Scroll);
            // 
            // m_innerPanel
            // 
            this.m_innerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_innerPanel.Location = new System.Drawing.Point(0, 0);
            this.m_innerPanel.Name = "m_innerPanel";
            this.m_innerPanel.Size = new System.Drawing.Size(303, 223);
            this.m_innerPanel.TabIndex = 2;
            this.m_innerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.m_innerPanel_Paint);
            this.m_innerPanel.Resize += new System.EventHandler(this.m_innerPanel_Resize);
            // 
            // MapPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_innerPanel);
            this.Controls.Add(this.m_horizontalScrollBar);
            this.Controls.Add(this.m_verticalScrollBar);
            this.Name = "MapPanel";
            this.Size = new System.Drawing.Size(320, 240);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar m_verticalScrollBar;
        private System.Windows.Forms.HScrollBar m_horizontalScrollBar;
        private CustomPanel m_innerPanel;
    }
}
