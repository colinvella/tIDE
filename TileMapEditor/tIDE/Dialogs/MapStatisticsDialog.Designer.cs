namespace TileMapEditor.Dialogs
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
            this.m_textBoxStatistics = new TileMapEditor.Controls.CustomRichTextBox();
            this.SuspendLayout();
            // 
            // m_buttonClose
            // 
            this.m_buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonClose.Location = new System.Drawing.Point(497, 377);
            this.m_buttonClose.Name = "m_buttonClose";
            this.m_buttonClose.Size = new System.Drawing.Size(75, 23);
            this.m_buttonClose.TabIndex = 2;
            this.m_buttonClose.Text = "&Close";
            this.m_buttonClose.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_textBoxStatistics
            // 
            this.m_textBoxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxStatistics.BackColor = System.Drawing.SystemColors.Window;
            this.m_textBoxStatistics.DetectUrls = true;
            this.m_textBoxStatistics.Location = new System.Drawing.Point(12, 12);
            this.m_textBoxStatistics.Name = "m_textBoxStatistics";
            this.m_textBoxStatistics.ReadOnly = true;
            this.m_textBoxStatistics.SelectionLink = false;
            this.m_textBoxStatistics.Size = new System.Drawing.Size(560, 359);
            this.m_textBoxStatistics.TabIndex = 3;
            this.m_textBoxStatistics.Text = "";
            // 
            // MapStatisticsDialog
            // 
            this.AcceptButton = this.m_buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonClose;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_textBoxStatistics);
            this.Controls.Add(this.m_buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MapStatisticsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Statistics";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private TileMapEditor.Controls.CustomRichTextBox m_textBoxStatistics;
    }
}