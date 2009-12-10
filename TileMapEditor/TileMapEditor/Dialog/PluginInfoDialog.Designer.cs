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
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelAuthor = new System.Windows.Forms.Label();
            this.m_labelVersion = new System.Windows.Forms.Label();
            this.m_labelName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.BackColor = System.Drawing.SystemColors.Info;
            this.m_textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textBoxDescription.Location = new System.Drawing.Point(54, 101);
            this.m_textBoxDescription.Multiline = true;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.ReadOnly = true;
            this.m_textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_textBoxDescription.Size = new System.Drawing.Size(318, 120);
            this.m_textBoxDescription.TabIndex = 2;
            this.m_textBoxDescription.TabStop = false;
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonOk.Location = new System.Drawing.Point(297, 227);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 5;
            this.m_buttonOk.Text = "OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::TileMapEditor.Properties.Resources.AboutBackground;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_labelAuthor);
            this.panel1.Controls.Add(this.m_labelVersion);
            this.panel1.Controls.Add(this.m_labelName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 262);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // m_labelAuthor
            // 
            this.m_labelAuthor.AutoSize = true;
            this.m_labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.m_labelAuthor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelAuthor.Location = new System.Drawing.Point(328, 30);
            this.m_labelAuthor.Name = "m_labelAuthor";
            this.m_labelAuthor.Size = new System.Drawing.Size(43, 13);
            this.m_labelAuthor.TabIndex = 4;
            this.m_labelAuthor.Text = "(author)";
            this.m_labelAuthor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_labelVersion
            // 
            this.m_labelVersion.AutoSize = true;
            this.m_labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.m_labelVersion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelVersion.Location = new System.Drawing.Point(50, 30);
            this.m_labelVersion.Name = "m_labelVersion";
            this.m_labelVersion.Size = new System.Drawing.Size(47, 13);
            this.m_labelVersion.TabIndex = 3;
            this.m_labelVersion.Text = "(version)";
            // 
            // m_labelName
            // 
            this.m_labelName.AutoSize = true;
            this.m_labelName.BackColor = System.Drawing.Color.Transparent;
            this.m_labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_labelName.Location = new System.Drawing.Point(50, 11);
            this.m_labelName.Name = "m_labelName";
            this.m_labelName.Size = new System.Drawing.Size(59, 17);
            this.m_labelName.TabIndex = 1;
            this.m_labelName.Text = "(name)";
            // 
            // PluginInfoDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonOk;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.m_buttonOk);
            this.Controls.Add(this.m_textBoxDescription);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginInfoDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plugin Information";
            this.Load += new System.EventHandler(this.OnLoadDialog);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_labelName;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Label m_labelVersion;
        private System.Windows.Forms.Label m_labelAuthor;
        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Panel panel1;
    }
}