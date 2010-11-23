namespace tIDE.Dialogs
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.m_lnkProject = new System.Windows.Forms.LinkLabel();
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
            m_backgroundPanel.Controls.Add(this.m_lnkProject);
            m_backgroundPanel.Controls.Add(this.m_labelCompanyName);
            m_backgroundPanel.Controls.Add(this.m_labelCopyright);
            m_backgroundPanel.Controls.Add(this.m_labelProductName);
            m_backgroundPanel.Controls.Add(this.labelVersion);
            m_backgroundPanel.Controls.Add(this.m_buttonOk);
            m_backgroundPanel.Controls.Add(this.m_textBoxDescription);
            resources.ApplyResources(m_backgroundPanel, "m_backgroundPanel");
            m_backgroundPanel.Name = "m_backgroundPanel";
            // 
            // m_lnkProject
            // 
            resources.ApplyResources(this.m_lnkProject, "m_lnkProject");
            this.m_lnkProject.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkProject.LinkColor = System.Drawing.Color.Maroon;
            this.m_lnkProject.Name = "m_lnkProject";
            this.m_lnkProject.TabStop = true;
            this.m_lnkProject.Tag = "http://tide.codeplex.com";
            this.m_lnkProject.UseCompatibleTextRendering = true;
            this.m_lnkProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnProjectLinkClicked);
            // 
            // m_labelCompanyName
            // 
            resources.ApplyResources(this.m_labelCompanyName, "m_labelCompanyName");
            this.m_labelCompanyName.Name = "m_labelCompanyName";
            // 
            // m_labelCopyright
            // 
            resources.ApplyResources(this.m_labelCopyright, "m_labelCopyright");
            this.m_labelCopyright.Name = "m_labelCopyright";
            // 
            // m_labelProductName
            // 
            resources.ApplyResources(this.m_labelProductName, "m_labelProductName");
            this.m_labelProductName.ForeColor = System.Drawing.Color.White;
            this.m_labelProductName.Name = "m_labelProductName";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            // 
            // m_buttonOk
            // 
            resources.ApplyResources(this.m_buttonOk, "m_buttonOk");
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.BackColor = System.Drawing.SystemColors.Info;
            this.m_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.m_textBoxDescription, "m_textBoxDescription");
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.ReadOnly = true;
            this.m_textBoxDescription.TabStop = false;
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Interval = 10;
            this.m_timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tIDE.Properties.Resources.AboutBackground;
            this.CancelButton = this.m_buttonOk;
            this.Controls.Add(m_backgroundPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.LinkLabel m_lnkProject;
    }
}
