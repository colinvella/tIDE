namespace TileMapEditor.Dialogs
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
            System.Windows.Forms.Label m_recentFileCountLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptonsDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_tabControl = new TileMapEditor.Controls.CustomTabControl();
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
            m_recentFileCountLabel.AutoSize = true;
            m_recentFileCountLabel.Location = new System.Drawing.Point(62, 8);
            m_recentFileCountLabel.Name = "m_recentFileCountLabel";
            m_recentFileCountLabel.Size = new System.Drawing.Size(153, 13);
            m_recentFileCountLabel.TabIndex = 1;
            m_recentFileCountLabel.Text = "files shown in recent files menu";
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_okButton.Location = new System.Drawing.Point(12, 129);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 1;
            this.m_okButton.Text = "&OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(197, 129);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 2;
            this.m_cancelButton.Text = "&Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.Controls.Add(this.m_recentFilesTabPage);
            this.m_tabControl.Controls.Add(this.m_languageTabPage);
            this.m_tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.m_tabControl.Location = new System.Drawing.Point(12, 12);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(260, 111);
            this.m_tabControl.TabIndex = 0;
            // 
            // m_recentFilesTabPage
            // 
            this.m_recentFilesTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.m_recentFilesTabPage.Controls.Add(this.m_clearHistoryButton);
            this.m_recentFilesTabPage.Controls.Add(m_recentFileCountLabel);
            this.m_recentFilesTabPage.Controls.Add(this.m_recentFileCountUpDown);
            this.m_recentFilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.m_recentFilesTabPage.Name = "m_recentFilesTabPage";
            this.m_recentFilesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.m_recentFilesTabPage.Size = new System.Drawing.Size(252, 85);
            this.m_recentFilesTabPage.TabIndex = 0;
            this.m_recentFilesTabPage.Text = "Recent Files";
            // 
            // m_clearHistoryButton
            // 
            this.m_clearHistoryButton.Location = new System.Drawing.Point(7, 33);
            this.m_clearHistoryButton.Name = "m_clearHistoryButton";
            this.m_clearHistoryButton.Size = new System.Drawing.Size(75, 23);
            this.m_clearHistoryButton.TabIndex = 2;
            this.m_clearHistoryButton.Text = "Clear &History";
            this.m_clearHistoryButton.UseVisualStyleBackColor = true;
            // 
            // m_recentFileCountUpDown
            // 
            this.m_recentFileCountUpDown.Location = new System.Drawing.Point(6, 6);
            this.m_recentFileCountUpDown.Name = "m_recentFileCountUpDown";
            this.m_recentFileCountUpDown.Size = new System.Drawing.Size(50, 20);
            this.m_recentFileCountUpDown.TabIndex = 0;
            // 
            // m_languageTabPage
            // 
            this.m_languageTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.m_languageTabPage.Controls.Add(this.m_languageComboBox);
            this.m_languageTabPage.Controls.Add(this.label1);
            this.m_languageTabPage.Location = new System.Drawing.Point(4, 22);
            this.m_languageTabPage.Name = "m_languageTabPage";
            this.m_languageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.m_languageTabPage.Size = new System.Drawing.Size(252, 85);
            this.m_languageTabPage.TabIndex = 1;
            this.m_languageTabPage.Text = "Language";
            // 
            // m_languageComboBox
            // 
            this.m_languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_languageComboBox.FormattingEnabled = true;
            this.m_languageComboBox.Location = new System.Drawing.Point(7, 24);
            this.m_languageComboBox.Name = "m_languageComboBox";
            this.m_languageComboBox.Size = new System.Drawing.Size(239, 21);
            this.m_languageComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User interface language:";
            // 
            // OptonsDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "OptonsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Optons";
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

        private TileMapEditor.Controls.CustomTabControl m_tabControl;
        private System.Windows.Forms.TabPage m_recentFilesTabPage;
        private System.Windows.Forms.TabPage m_languageTabPage;
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Button m_clearHistoryButton;
        private System.Windows.Forms.NumericUpDown m_recentFileCountUpDown;
        private System.Windows.Forms.ComboBox m_languageComboBox;
        private System.Windows.Forms.Label label1;
    }
}