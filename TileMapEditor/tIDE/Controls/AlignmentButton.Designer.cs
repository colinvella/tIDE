namespace TileMapEditor.Controls
{
    partial class AlignmentButton
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
            this.m_btnTopLeft = new System.Windows.Forms.Button();
            this.m_btnTop = new System.Windows.Forms.Button();
            this.m_btnTopRight = new System.Windows.Forms.Button();
            this.m_btnRight = new System.Windows.Forms.Button();
            this.m_btnCentre = new System.Windows.Forms.Button();
            this.m_btnLeft = new System.Windows.Forms.Button();
            this.m_btnBottomRight = new System.Windows.Forms.Button();
            this.m_btnBottom = new System.Windows.Forms.Button();
            this.m_btnBottomLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_btnTopLeft
            // 
            this.m_btnTopLeft.Image = global::TileMapEditor.Properties.Resources.AnchorUpLeft;
            this.m_btnTopLeft.Location = new System.Drawing.Point(2, 2);
            this.m_btnTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnTopLeft.Name = "m_btnTopLeft";
            this.m_btnTopLeft.Size = new System.Drawing.Size(22, 22);
            this.m_btnTopLeft.TabIndex = 0;
            this.m_btnTopLeft.UseVisualStyleBackColor = true;
            this.m_btnTopLeft.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnTop
            // 
            this.m_btnTop.Image = global::TileMapEditor.Properties.Resources.AnchorUp;
            this.m_btnTop.Location = new System.Drawing.Point(24, 2);
            this.m_btnTop.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnTop.Name = "m_btnTop";
            this.m_btnTop.Size = new System.Drawing.Size(22, 22);
            this.m_btnTop.TabIndex = 1;
            this.m_btnTop.UseVisualStyleBackColor = true;
            this.m_btnTop.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnTopRight
            // 
            this.m_btnTopRight.Image = global::TileMapEditor.Properties.Resources.AnchorUpRight;
            this.m_btnTopRight.Location = new System.Drawing.Point(46, 2);
            this.m_btnTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnTopRight.Name = "m_btnTopRight";
            this.m_btnTopRight.Size = new System.Drawing.Size(22, 22);
            this.m_btnTopRight.TabIndex = 2;
            this.m_btnTopRight.UseVisualStyleBackColor = true;
            this.m_btnTopRight.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnRight
            // 
            this.m_btnRight.Image = global::TileMapEditor.Properties.Resources.AnchorRight;
            this.m_btnRight.Location = new System.Drawing.Point(46, 24);
            this.m_btnRight.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnRight.Name = "m_btnRight";
            this.m_btnRight.Size = new System.Drawing.Size(22, 22);
            this.m_btnRight.TabIndex = 5;
            this.m_btnRight.UseVisualStyleBackColor = true;
            this.m_btnRight.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnCentre
            // 
            this.m_btnCentre.Location = new System.Drawing.Point(24, 24);
            this.m_btnCentre.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnCentre.Name = "m_btnCentre";
            this.m_btnCentre.Size = new System.Drawing.Size(22, 22);
            this.m_btnCentre.TabIndex = 4;
            this.m_btnCentre.UseVisualStyleBackColor = true;
            this.m_btnCentre.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnLeft
            // 
            this.m_btnLeft.Image = global::TileMapEditor.Properties.Resources.AnchorLeft;
            this.m_btnLeft.Location = new System.Drawing.Point(2, 24);
            this.m_btnLeft.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnLeft.Name = "m_btnLeft";
            this.m_btnLeft.Size = new System.Drawing.Size(22, 22);
            this.m_btnLeft.TabIndex = 3;
            this.m_btnLeft.UseVisualStyleBackColor = true;
            this.m_btnLeft.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnBottomRight
            // 
            this.m_btnBottomRight.Image = global::TileMapEditor.Properties.Resources.AnchorDownRight;
            this.m_btnBottomRight.Location = new System.Drawing.Point(46, 46);
            this.m_btnBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnBottomRight.Name = "m_btnBottomRight";
            this.m_btnBottomRight.Size = new System.Drawing.Size(22, 22);
            this.m_btnBottomRight.TabIndex = 8;
            this.m_btnBottomRight.UseVisualStyleBackColor = true;
            this.m_btnBottomRight.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnBottom
            // 
            this.m_btnBottom.Image = global::TileMapEditor.Properties.Resources.AnchorDown;
            this.m_btnBottom.Location = new System.Drawing.Point(24, 46);
            this.m_btnBottom.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnBottom.Name = "m_btnBottom";
            this.m_btnBottom.Size = new System.Drawing.Size(22, 22);
            this.m_btnBottom.TabIndex = 7;
            this.m_btnBottom.UseVisualStyleBackColor = true;
            this.m_btnBottom.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // m_btnBottomLeft
            // 
            this.m_btnBottomLeft.Image = global::TileMapEditor.Properties.Resources.AnchorDownLeft;
            this.m_btnBottomLeft.Location = new System.Drawing.Point(2, 46);
            this.m_btnBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.m_btnBottomLeft.Name = "m_btnBottomLeft";
            this.m_btnBottomLeft.Size = new System.Drawing.Size(22, 22);
            this.m_btnBottomLeft.TabIndex = 6;
            this.m_btnBottomLeft.UseVisualStyleBackColor = true;
            this.m_btnBottomLeft.Click += new System.EventHandler(this.OnAnchorButtonClicked);
            // 
            // AnchorButtonGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnBottomRight);
            this.Controls.Add(this.m_btnBottom);
            this.Controls.Add(this.m_btnBottomLeft);
            this.Controls.Add(this.m_btnRight);
            this.Controls.Add(this.m_btnCentre);
            this.Controls.Add(this.m_btnLeft);
            this.Controls.Add(this.m_btnTopRight);
            this.Controls.Add(this.m_btnTop);
            this.Controls.Add(this.m_btnTopLeft);
            this.MaximumSize = new System.Drawing.Size(70, 70);
            this.MinimumSize = new System.Drawing.Size(70, 70);
            this.Name = "AnchorButtonGroup";
            this.Size = new System.Drawing.Size(70, 70);
            this.Load += new System.EventHandler(this.OnLoadControl);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnTopLeft;
        private System.Windows.Forms.Button m_btnTop;
        private System.Windows.Forms.Button m_btnTopRight;
        private System.Windows.Forms.Button m_btnRight;
        private System.Windows.Forms.Button m_btnCentre;
        private System.Windows.Forms.Button m_btnLeft;
        private System.Windows.Forms.Button m_btnBottomRight;
        private System.Windows.Forms.Button m_btnBottom;
        private System.Windows.Forms.Button m_btnBottomLeft;
    }
}
