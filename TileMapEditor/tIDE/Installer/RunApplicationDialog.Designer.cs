namespace TileMapEditor.Installer
{
    partial class RunApplicationDialog
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
            System.Windows.Forms.Button m_yesButton;
            System.Windows.Forms.Button m_noButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunApplicationDialog));
            this.m_promptLabel = new System.Windows.Forms.Label();
            m_yesButton = new System.Windows.Forms.Button();
            m_noButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_yesButton
            // 
            m_yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            m_yesButton.Location = new System.Drawing.Point(12, 77);
            m_yesButton.Name = "m_yesButton";
            m_yesButton.Size = new System.Drawing.Size(75, 23);
            m_yesButton.TabIndex = 1;
            m_yesButton.Text = "&Yes";
            m_yesButton.UseVisualStyleBackColor = true;
            // 
            // m_noButton
            // 
            m_noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            m_noButton.Location = new System.Drawing.Point(197, 77);
            m_noButton.Name = "m_noButton";
            m_noButton.Size = new System.Drawing.Size(75, 23);
            m_noButton.TabIndex = 2;
            m_noButton.Text = "&No";
            m_noButton.UseVisualStyleBackColor = true;
            // 
            // m_promptLabel
            // 
            this.m_promptLabel.AutoSize = true;
            this.m_promptLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_promptLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_promptLabel.Location = new System.Drawing.Point(94, 24);
            this.m_promptLabel.Name = "m_promptLabel";
            this.m_promptLabel.Size = new System.Drawing.Size(93, 13);
            this.m_promptLabel.TabIndex = 0;
            this.m_promptLabel.Text = "Run tIDE now?";
            this.m_promptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunApplicationDialog
            // 
            this.AcceptButton = m_yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TileMapEditor.Properties.Resources.AboutBackground;
            this.CancelButton = m_noButton;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(m_noButton);
            this.Controls.Add(m_yesButton);
            this.Controls.Add(this.m_promptLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunApplicationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tIDE Tile Map Editor";
            this.Deactivate += new System.EventHandler(this.OnDialogDeactivate);
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_promptLabel;
    }
}