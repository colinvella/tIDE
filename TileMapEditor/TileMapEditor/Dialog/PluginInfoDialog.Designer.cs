namespace TileMapEditor.Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginInfoDialog));
            this.m_labelName = new System.Windows.Forms.Label();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_labelVersion = new System.Windows.Forms.Label();
            this.m_labelAuthor = new System.Windows.Forms.Label();
            this.m_pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.m_buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // m_labelName
            // 
            this.m_labelName.AutoSize = true;
            this.m_labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelName.Location = new System.Drawing.Point(82, 12);
            this.m_labelName.Name = "m_labelName";
            this.m_labelName.Size = new System.Drawing.Size(59, 17);
            this.m_labelName.TabIndex = 1;
            this.m_labelName.Text = "(name)";
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_textBoxDescription.Location = new System.Drawing.Point(12, 82);
            this.m_textBoxDescription.Multiline = true;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.ReadOnly = true;
            this.m_textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_textBoxDescription.Size = new System.Drawing.Size(360, 128);
            this.m_textBoxDescription.TabIndex = 2;
            this.m_textBoxDescription.TabStop = false;
            // 
            // m_labelVersion
            // 
            this.m_labelVersion.AutoSize = true;
            this.m_labelVersion.Location = new System.Drawing.Point(82, 39);
            this.m_labelVersion.Name = "m_labelVersion";
            this.m_labelVersion.Size = new System.Drawing.Size(47, 13);
            this.m_labelVersion.TabIndex = 3;
            this.m_labelVersion.Text = "(version)";
            // 
            // m_labelAuthor
            // 
            this.m_labelAuthor.AutoSize = true;
            this.m_labelAuthor.Location = new System.Drawing.Point(82, 63);
            this.m_labelAuthor.Name = "m_labelAuthor";
            this.m_labelAuthor.Size = new System.Drawing.Size(43, 13);
            this.m_labelAuthor.TabIndex = 4;
            this.m_labelAuthor.Text = "(author)";
            // 
            // m_pictureBoxIcon
            // 
            this.m_pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
            this.m_pictureBoxIcon.Name = "m_pictureBoxIcon";
            this.m_pictureBoxIcon.Size = new System.Drawing.Size(64, 64);
            this.m_pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureBoxIcon.TabIndex = 0;
            this.m_pictureBoxIcon.TabStop = false;
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonOk.Location = new System.Drawing.Point(297, 227);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 5;
            this.m_buttonOk.Text = "&OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // PluginInfoDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonOk;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.m_buttonOk);
            this.Controls.Add(this.m_labelAuthor);
            this.Controls.Add(this.m_labelVersion);
            this.Controls.Add(this.m_textBoxDescription);
            this.Controls.Add(this.m_labelName);
            this.Controls.Add(this.m_pictureBoxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginInfoDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plugin Information";
            this.Load += new System.EventHandler(this.OnLoadDialog);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_pictureBoxIcon;
        private System.Windows.Forms.Label m_labelName;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Label m_labelVersion;
        private System.Windows.Forms.Label m_labelAuthor;
        private System.Windows.Forms.Button m_buttonOk;
    }
}