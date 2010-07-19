namespace TileMapEditor.Dialogs
{
    partial class FormatCompatibilityDialog
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
            System.Windows.Forms.Label m_overallCompatibilityLabel;
            System.Windows.Forms.Label m_compatibilityNotesLabel;
            System.Windows.Forms.Label m_overallCompatibilityValue;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatCompatibilityDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CompatibilityLevelIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.CompatiblityLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            m_overallCompatibilityLabel = new System.Windows.Forms.Label();
            m_compatibilityNotesLabel = new System.Windows.Forms.Label();
            m_overallCompatibilityValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_okButton.Location = new System.Drawing.Point(497, 227);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 0;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompatibilityLevelIcon,
            this.CompatiblityLevel,
            this.Remarks});
            this.dataGridView1.Location = new System.Drawing.Point(13, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(559, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // m_overallCompatibilityLabel
            // 
            m_overallCompatibilityLabel.AutoSize = true;
            m_overallCompatibilityLabel.Location = new System.Drawing.Point(13, 13);
            m_overallCompatibilityLabel.Name = "m_overallCompatibilityLabel";
            m_overallCompatibilityLabel.Size = new System.Drawing.Size(101, 13);
            m_overallCompatibilityLabel.TabIndex = 2;
            m_overallCompatibilityLabel.Text = "Overall Compatibility";
            // 
            // m_compatibilityNotesLabel
            // 
            m_compatibilityNotesLabel.AutoSize = true;
            m_compatibilityNotesLabel.Location = new System.Drawing.Point(13, 47);
            m_compatibilityNotesLabel.Name = "m_compatibilityNotesLabel";
            m_compatibilityNotesLabel.Size = new System.Drawing.Size(96, 13);
            m_compatibilityNotesLabel.TabIndex = 3;
            m_compatibilityNotesLabel.Text = "Compatibility Notes";
            // 
            // CompatibilityLevelIcon
            // 
            this.CompatibilityLevelIcon.HeaderText = "";
            this.CompatibilityLevelIcon.MinimumWidth = 18;
            this.CompatibilityLevelIcon.Name = "CompatibilityLevelIcon";
            this.CompatibilityLevelIcon.ReadOnly = true;
            this.CompatibilityLevelIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CompatibilityLevelIcon.Width = 18;
            // 
            // CompatiblityLevel
            // 
            this.CompatiblityLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompatiblityLevel.FillWeight = 30F;
            this.CompatiblityLevel.HeaderText = "Compatiblity Level";
            this.CompatiblityLevel.Name = "CompatiblityLevel";
            this.CompatiblityLevel.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.FillWeight = 70F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // m_overallCompatibilityValue
            // 
            m_overallCompatibilityValue.AutoSize = true;
            m_overallCompatibilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            m_overallCompatibilityValue.Location = new System.Drawing.Point(120, 13);
            m_overallCompatibilityValue.Name = "m_overallCompatibilityValue";
            m_overallCompatibilityValue.Size = new System.Drawing.Size(85, 13);
            m_overallCompatibilityValue.TabIndex = 4;
            m_overallCompatibilityValue.Text = "(compatibility)";
            // 
            // FormatCompatibilityDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_okButton;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(m_overallCompatibilityValue);
            this.Controls.Add(m_compatibilityNotesLabel);
            this.Controls.Add(m_overallCompatibilityLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.m_okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormatCompatibilityDialog";
            this.Text = "Format Compatibility Report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn CompatibilityLevelIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompatiblityLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}