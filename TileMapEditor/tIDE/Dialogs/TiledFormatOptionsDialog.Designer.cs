namespace TileMapEditor.Dialogs
{
    partial class TiledFormatOptionsDialog
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
            System.Windows.Forms.Label m_lblDataFormat;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiledFormatOptionsDialog));
            this.m_cmbDataFormat = new System.Windows.Forms.ComboBox();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            m_lblDataFormat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lblDataFormat
            // 
            m_lblDataFormat.AutoSize = true;
            m_lblDataFormat.Location = new System.Drawing.Point(12, 15);
            m_lblDataFormat.Name = "m_lblDataFormat";
            m_lblDataFormat.Size = new System.Drawing.Size(111, 13);
            m_lblDataFormat.TabIndex = 0;
            m_lblDataFormat.Text = "Store tile layer data as";
            // 
            // m_cmbDataFormat
            // 
            this.m_cmbDataFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbDataFormat.FormattingEnabled = true;
            this.m_cmbDataFormat.Items.AddRange(new object[] {
            "XML",
            "Base64 (uncompressed)",
            "Base64 (gzip compressed)",
            "Base64 (zlib compressed)",
            "CSV"});
            this.m_cmbDataFormat.Location = new System.Drawing.Point(129, 12);
            this.m_cmbDataFormat.Name = "m_cmbDataFormat";
            this.m_cmbDataFormat.Size = new System.Drawing.Size(143, 21);
            this.m_cmbDataFormat.TabIndex = 1;
            this.m_cmbDataFormat.SelectedIndexChanged += new System.EventHandler(this.OnEncodingSelected);
            // 
            // m_btnOk
            // 
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Enabled = false;
            this.m_btnOk.Location = new System.Drawing.Point(13, 127);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Text = "&OK";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(196, 127);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 3;
            this.m_btnCancel.Text = "&Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // TiledFormatOptionsDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_cmbDataFormat);
            this.Controls.Add(m_lblDataFormat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "TiledFormatOptionsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiled TMX Format Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cmbDataFormat;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
    }
}