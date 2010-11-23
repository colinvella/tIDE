namespace tIDE.Dialogs
{
    partial class MapStatisticsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapStatisticsDialog));
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_textBoxStatistics = new tIDE.Controls.CustomRichTextBox();
            this.SuspendLayout();
            // 
            // m_buttonClose
            // 
            this.m_buttonClose.AccessibleDescription = null;
            this.m_buttonClose.AccessibleName = null;
            resources.ApplyResources(this.m_buttonClose, "m_buttonClose");
            this.m_buttonClose.BackgroundImage = null;
            this.m_buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonClose.Font = null;
            this.m_buttonClose.Name = "m_buttonClose";
            this.m_buttonClose.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AccessibleDescription = null;
            this.checkBox1.AccessibleName = null;
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackgroundImage = null;
            this.checkBox1.Font = null;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_textBoxStatistics
            // 
            this.m_textBoxStatistics.AccessibleDescription = null;
            this.m_textBoxStatistics.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxStatistics, "m_textBoxStatistics");
            this.m_textBoxStatistics.BackColor = System.Drawing.SystemColors.Window;
            this.m_textBoxStatistics.BackgroundImage = null;
            this.m_textBoxStatistics.DetectUrls = true;
            this.m_textBoxStatistics.Font = null;
            this.m_textBoxStatistics.Name = "m_textBoxStatistics";
            this.m_textBoxStatistics.ReadOnly = true;
            this.m_textBoxStatistics.SelectionLink = false;
            // 
            // MapStatisticsDialog
            // 
            this.AcceptButton = this.m_buttonClose;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_buttonClose;
            this.Controls.Add(this.m_textBoxStatistics);
            this.Controls.Add(this.m_buttonClose);
            this.Font = null;
            this.MinimizeBox = false;
            this.Name = "MapStatisticsDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private tIDE.Controls.CustomRichTextBox m_textBoxStatistics;
    }
}