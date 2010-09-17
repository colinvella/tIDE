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
            m_lblDataFormat.AccessibleDescription = null;
            m_lblDataFormat.AccessibleName = null;
            resources.ApplyResources(m_lblDataFormat, "m_lblDataFormat");
            m_lblDataFormat.Font = null;
            m_lblDataFormat.Name = "m_lblDataFormat";
            // 
            // m_cmbDataFormat
            // 
            this.m_cmbDataFormat.AccessibleDescription = null;
            this.m_cmbDataFormat.AccessibleName = null;
            resources.ApplyResources(this.m_cmbDataFormat, "m_cmbDataFormat");
            this.m_cmbDataFormat.BackgroundImage = null;
            this.m_cmbDataFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbDataFormat.Font = null;
            this.m_cmbDataFormat.FormattingEnabled = true;
            this.m_cmbDataFormat.Items.AddRange(new object[] {
            resources.GetString("m_cmbDataFormat.Items"),
            resources.GetString("m_cmbDataFormat.Items1"),
            resources.GetString("m_cmbDataFormat.Items2"),
            resources.GetString("m_cmbDataFormat.Items3"),
            resources.GetString("m_cmbDataFormat.Items4")});
            this.m_cmbDataFormat.Name = "m_cmbDataFormat";
            this.m_cmbDataFormat.SelectedIndexChanged += new System.EventHandler(this.OnEncodingSelected);
            // 
            // m_btnOk
            // 
            this.m_btnOk.AccessibleDescription = null;
            this.m_btnOk.AccessibleName = null;
            resources.ApplyResources(this.m_btnOk, "m_btnOk");
            this.m_btnOk.BackgroundImage = null;
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Font = null;
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AccessibleDescription = null;
            this.m_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.BackgroundImage = null;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Font = null;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // TiledFormatOptionsDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_cmbDataFormat);
            this.Controls.Add(m_lblDataFormat);
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TiledFormatOptionsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cmbDataFormat;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
    }
}