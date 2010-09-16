namespace TileMapEditor.Dialogs
{
    partial class PluginInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginInfoDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_panel = new System.Windows.Forms.Panel();
            this.m_labelAuthor = new System.Windows.Forms.Label();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_labelVersion = new System.Windows.Forms.Label();
            this.m_labelName = new System.Windows.Forms.Label();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.m_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.AccessibleDescription = null;
            this.m_okButton.AccessibleName = null;
            resources.ApplyResources(this.m_okButton, "m_okButton");
            this.m_okButton.BackgroundImage = null;
            this.m_okButton.Font = null;
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_panel
            // 
            this.m_panel.AccessibleDescription = null;
            this.m_panel.AccessibleName = null;
            resources.ApplyResources(this.m_panel, "m_panel");
            this.m_panel.BackgroundImage = global::TileMapEditor.Properties.Resources.AboutPluginBackground;
            this.m_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panel.Controls.Add(this.m_okButton);
            this.m_panel.Controls.Add(this.m_labelAuthor);
            this.m_panel.Controls.Add(this.m_textBoxDescription);
            this.m_panel.Controls.Add(this.m_labelVersion);
            this.m_panel.Controls.Add(this.m_labelName);
            this.m_panel.Font = null;
            this.m_panel.Name = "m_panel";
            this.m_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // m_labelAuthor
            // 
            this.m_labelAuthor.AccessibleDescription = null;
            this.m_labelAuthor.AccessibleName = null;
            resources.ApplyResources(this.m_labelAuthor, "m_labelAuthor");
            this.m_labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.m_labelAuthor.Font = null;
            this.m_labelAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelAuthor.Name = "m_labelAuthor";
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.AccessibleDescription = null;
            this.m_textBoxDescription.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxDescription, "m_textBoxDescription");
            this.m_textBoxDescription.BackColor = System.Drawing.SystemColors.Info;
            this.m_textBoxDescription.BackgroundImage = null;
            this.m_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textBoxDescription.Font = null;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.ReadOnly = true;
            this.m_textBoxDescription.TabStop = false;
            // 
            // m_labelVersion
            // 
            this.m_labelVersion.AccessibleDescription = null;
            this.m_labelVersion.AccessibleName = null;
            resources.ApplyResources(this.m_labelVersion, "m_labelVersion");
            this.m_labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.m_labelVersion.Font = null;
            this.m_labelVersion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelVersion.Name = "m_labelVersion";
            // 
            // m_labelName
            // 
            this.m_labelName.AccessibleDescription = null;
            this.m_labelName.AccessibleName = null;
            resources.ApplyResources(this.m_labelName, "m_labelName");
            this.m_labelName.BackColor = System.Drawing.Color.Transparent;
            this.m_labelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelName.Name = "m_labelName";
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Interval = 10;
            this.m_timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // PluginInfoDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_panel);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginInfoDialog";
            this.Opacity = 0;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.OnLoadDialog);
            this.m_panel.ResumeLayout(false);
            this.m_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_labelName;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Label m_labelVersion;
        private System.Windows.Forms.Label m_labelAuthor;
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Panel m_panel;
        private System.Windows.Forms.Timer m_timer;
    }
}