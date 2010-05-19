namespace TileMapEditor.Dialogs
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.Windows.Forms.Panel m_backgroundPanel;
            this.m_labelCompanyName = new System.Windows.Forms.Label();
            this.m_labelCopyright = new System.Windows.Forms.Label();
            this.m_labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            m_backgroundPanel = new System.Windows.Forms.Panel();
            m_backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_backgroundPanel
            // 
            m_backgroundPanel.BackColor = System.Drawing.Color.Transparent;
            m_backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_backgroundPanel.Controls.Add(this.m_labelCompanyName);
            m_backgroundPanel.Controls.Add(this.m_labelCopyright);
            m_backgroundPanel.Controls.Add(this.m_labelProductName);
            m_backgroundPanel.Controls.Add(this.labelVersion);
            m_backgroundPanel.Controls.Add(this.m_buttonOk);
            m_backgroundPanel.Controls.Add(this.m_textBoxDescription);
            m_backgroundPanel.Location = new System.Drawing.Point(0, 0);
            m_backgroundPanel.Margin = new System.Windows.Forms.Padding(0);
            m_backgroundPanel.Name = "m_backgroundPanel";
            m_backgroundPanel.Size = new System.Drawing.Size(400, 300);
            m_backgroundPanel.TabIndex = 1;
            // 
            // m_labelCompanyName
            // 
            this.m_labelCompanyName.AutoSize = true;
            this.m_labelCompanyName.Location = new System.Drawing.Point(11, 104);
            this.m_labelCompanyName.Name = "m_labelCompanyName";
            this.m_labelCompanyName.Size = new System.Drawing.Size(82, 13);
            this.m_labelCompanyName.TabIndex = 4;
            this.m_labelCompanyName.Text = "Company Name";
            // 
            // m_labelCopyright
            // 
            this.m_labelCopyright.AutoSize = true;
            this.m_labelCopyright.Location = new System.Drawing.Point(11, 87);
            this.m_labelCopyright.Name = "m_labelCopyright";
            this.m_labelCopyright.Size = new System.Drawing.Size(51, 13);
            this.m_labelCopyright.TabIndex = 3;
            this.m_labelCopyright.Text = "Copyright";
            // 
            // m_labelProductName
            // 
            this.m_labelProductName.AutoSize = true;
            this.m_labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelProductName.ForeColor = System.Drawing.Color.White;
            this.m_labelProductName.Location = new System.Drawing.Point(64, 16);
            this.m_labelProductName.Name = "m_labelProductName";
            this.m_labelProductName.Size = new System.Drawing.Size(160, 25);
            this.m_labelProductName.TabIndex = 2;
            this.m_labelProductName.Text = "Product Name";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(66, 42);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonOk.Location = new System.Drawing.Point(312, 265);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 22);
            this.m_buttonOk.TabIndex = 6;
            this.m_buttonOk.Text = "&OK";
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.BackColor = System.Drawing.SystemColors.Info;
            this.m_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textBoxDescription.Location = new System.Drawing.Point(14, 126);
            this.m_textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.m_textBoxDescription.Multiline = true;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.ReadOnly = true;
            this.m_textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_textBoxDescription.Size = new System.Drawing.Size(373, 133);
            this.m_textBoxDescription.TabIndex = 5;
            this.m_textBoxDescription.TabStop = false;
            this.m_textBoxDescription.Text = "Description";
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Interval = 10;
            this.m_timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TileMapEditor.Properties.Resources.AboutBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(m_backgroundPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Opacity = 0;
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About tIDE";
            m_backgroundPanel.ResumeLayout(false);
            m_backgroundPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Label m_labelProductName;
        private System.Windows.Forms.Label m_labelCopyright;
        private System.Windows.Forms.Label m_labelCompanyName;
        private System.Windows.Forms.Timer m_timer;
    }
}
