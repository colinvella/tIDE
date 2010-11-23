namespace tIDE.Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunApplicationDialog));
            System.Windows.Forms.Button m_noButton;
            this.m_promptLabel = new System.Windows.Forms.Label();
            m_yesButton = new System.Windows.Forms.Button();
            m_noButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_yesButton
            // 
            m_yesButton.AccessibleDescription = null;
            m_yesButton.AccessibleName = null;
            resources.ApplyResources(m_yesButton, "m_yesButton");
            m_yesButton.BackgroundImage = null;
            m_yesButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            m_yesButton.Font = null;
            m_yesButton.Name = "m_yesButton";
            m_yesButton.UseVisualStyleBackColor = true;
            // 
            // m_noButton
            // 
            m_noButton.AccessibleDescription = null;
            m_noButton.AccessibleName = null;
            resources.ApplyResources(m_noButton, "m_noButton");
            m_noButton.BackgroundImage = null;
            m_noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            m_noButton.Font = null;
            m_noButton.Name = "m_noButton";
            m_noButton.UseVisualStyleBackColor = true;
            // 
            // m_promptLabel
            // 
            this.m_promptLabel.AccessibleDescription = null;
            this.m_promptLabel.AccessibleName = null;
            resources.ApplyResources(this.m_promptLabel, "m_promptLabel");
            this.m_promptLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_promptLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_promptLabel.Name = "m_promptLabel";
            // 
            // RunApplicationDialog
            // 
            this.AcceptButton = m_yesButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tIDE.Properties.Resources.AboutBackground;
            this.CancelButton = m_noButton;
            this.Controls.Add(m_noButton);
            this.Controls.Add(m_yesButton);
            this.Controls.Add(this.m_promptLabel);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunApplicationDialog";
            this.Deactivate += new System.EventHandler(this.OnDialogDeactivate);
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_promptLabel;
    }
}