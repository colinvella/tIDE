namespace tIDE.Dialogs
{
    partial class OptonsDialog
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
            System.Windows.Forms.Label m_recentFileCountLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptonsDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_tabControl = new tIDE.Controls.CustomTabControl();
            this.m_recentFilesTabPage = new System.Windows.Forms.TabPage();
            this.m_clearHistoryButton = new System.Windows.Forms.Button();
            this.m_recentFileCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_languageTabPage = new System.Windows.Forms.TabPage();
            this.m_languageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            m_recentFileCountLabel = new System.Windows.Forms.Label();
            this.m_tabControl.SuspendLayout();
            this.m_recentFilesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_recentFileCountUpDown)).BeginInit();
            this.m_languageTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_recentFileCountLabel
            // 
            m_recentFileCountLabel.AccessibleDescription = null;
            m_recentFileCountLabel.AccessibleName = null;
            resources.ApplyResources(m_recentFileCountLabel, "m_recentFileCountLabel");
            m_recentFileCountLabel.Font = null;
            m_recentFileCountLabel.Name = "m_recentFileCountLabel";
            // 
            // m_okButton
            // 
            this.m_okButton.AccessibleDescription = null;
            this.m_okButton.AccessibleName = null;
            resources.ApplyResources(this.m_okButton, "m_okButton");
            this.m_okButton.BackgroundImage = null;
            this.m_okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_okButton.Font = null;
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.AccessibleDescription = null;
            this.m_cancelButton.AccessibleName = null;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.BackgroundImage = null;
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Font = null;
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_tabImageList
            // 
            this.m_tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tabImageList.ImageStream")));
            this.m_tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tabImageList.Images.SetKeyName(0, "FileOpenRecent.png");
            this.m_tabImageList.Images.SetKeyName(1, "OptionsLanguage.png");
            // 
            // m_tabControl
            // 
            this.m_tabControl.AccessibleDescription = null;
            this.m_tabControl.AccessibleName = null;
            resources.ApplyResources(this.m_tabControl, "m_tabControl");
            this.m_tabControl.BackgroundImage = null;
            this.m_tabControl.Controls.Add(this.m_recentFilesTabPage);
            this.m_tabControl.Controls.Add(this.m_languageTabPage);
            this.m_tabControl.DisplayStyle = tIDE.Controls.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.m_tabControl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.m_tabControl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.m_tabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.m_tabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.m_tabControl.DisplayStyleProvider.FocusTrack = false;
            this.m_tabControl.DisplayStyleProvider.HotTrack = true;
            this.m_tabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_tabControl.DisplayStyleProvider.Opacity = 1F;
            this.m_tabControl.DisplayStyleProvider.Overlap = 7;
            this.m_tabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.m_tabControl.DisplayStyleProvider.ShowTabCloser = false;
            this.m_tabControl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.m_tabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.m_tabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.m_tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.m_tabControl.Font = null;
            this.m_tabControl.HotTrack = true;
            this.m_tabControl.ImageList = this.m_tabImageList;
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            // 
            // m_recentFilesTabPage
            // 
            this.m_recentFilesTabPage.AccessibleDescription = null;
            this.m_recentFilesTabPage.AccessibleName = null;
            resources.ApplyResources(this.m_recentFilesTabPage, "m_recentFilesTabPage");
            this.m_recentFilesTabPage.BackColor = System.Drawing.Color.Transparent;
            this.m_recentFilesTabPage.BackgroundImage = null;
            this.m_recentFilesTabPage.Controls.Add(this.m_clearHistoryButton);
            this.m_recentFilesTabPage.Controls.Add(m_recentFileCountLabel);
            this.m_recentFilesTabPage.Controls.Add(this.m_recentFileCountUpDown);
            this.m_recentFilesTabPage.Font = null;
            this.m_recentFilesTabPage.Name = "m_recentFilesTabPage";
            this.m_recentFilesTabPage.UseVisualStyleBackColor = true;
            // 
            // m_clearHistoryButton
            // 
            this.m_clearHistoryButton.AccessibleDescription = null;
            this.m_clearHistoryButton.AccessibleName = null;
            resources.ApplyResources(this.m_clearHistoryButton, "m_clearHistoryButton");
            this.m_clearHistoryButton.BackgroundImage = null;
            this.m_clearHistoryButton.Font = null;
            this.m_clearHistoryButton.Name = "m_clearHistoryButton";
            this.m_clearHistoryButton.UseVisualStyleBackColor = true;
            this.m_clearHistoryButton.Click += new System.EventHandler(this.OnClearHistory);
            // 
            // m_recentFileCountUpDown
            // 
            this.m_recentFileCountUpDown.AccessibleDescription = null;
            this.m_recentFileCountUpDown.AccessibleName = null;
            resources.ApplyResources(this.m_recentFileCountUpDown, "m_recentFileCountUpDown");
            this.m_recentFileCountUpDown.Font = null;
            this.m_recentFileCountUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_recentFileCountUpDown.Name = "m_recentFileCountUpDown";
            // 
            // m_languageTabPage
            // 
            this.m_languageTabPage.AccessibleDescription = null;
            this.m_languageTabPage.AccessibleName = null;
            resources.ApplyResources(this.m_languageTabPage, "m_languageTabPage");
            this.m_languageTabPage.BackColor = System.Drawing.Color.Transparent;
            this.m_languageTabPage.BackgroundImage = null;
            this.m_languageTabPage.Controls.Add(this.m_languageComboBox);
            this.m_languageTabPage.Controls.Add(this.label1);
            this.m_languageTabPage.Font = null;
            this.m_languageTabPage.Name = "m_languageTabPage";
            this.m_languageTabPage.UseVisualStyleBackColor = true;
            // 
            // m_languageComboBox
            // 
            this.m_languageComboBox.AccessibleDescription = null;
            this.m_languageComboBox.AccessibleName = null;
            resources.ApplyResources(this.m_languageComboBox, "m_languageComboBox");
            this.m_languageComboBox.BackgroundImage = null;
            this.m_languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_languageComboBox.Font = null;
            this.m_languageComboBox.FormattingEnabled = true;
            this.m_languageComboBox.Name = "m_languageComboBox";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // OptonsDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_cancelButton;
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_tabControl);
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptonsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.m_tabControl.ResumeLayout(false);
            this.m_recentFilesTabPage.ResumeLayout(false);
            this.m_recentFilesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_recentFileCountUpDown)).EndInit();
            this.m_languageTabPage.ResumeLayout(false);
            this.m_languageTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private tIDE.Controls.CustomTabControl m_tabControl;
        private System.Windows.Forms.TabPage m_recentFilesTabPage;
        private System.Windows.Forms.TabPage m_languageTabPage;
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Button m_clearHistoryButton;
        private System.Windows.Forms.NumericUpDown m_recentFileCountUpDown;
        private System.Windows.Forms.ComboBox m_languageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList m_tabImageList;
    }
}