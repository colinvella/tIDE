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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatCompatibilityDialog));
            this.m_overallCompatibilityValue = new System.Windows.Forms.Label();
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_notesDataGridView = new System.Windows.Forms.DataGridView();
            this.CompatibilityLevelIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.CompatiblityLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            m_overallCompatibilityLabel = new System.Windows.Forms.Label();
            m_compatibilityNotesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_notesDataGridView)).BeginInit();
            this.SuspendLayout();
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
            // m_overallCompatibilityValue
            // 
            this.m_overallCompatibilityValue.AutoSize = true;
            this.m_overallCompatibilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_overallCompatibilityValue.Location = new System.Drawing.Point(120, 13);
            this.m_overallCompatibilityValue.Name = "m_overallCompatibilityValue";
            this.m_overallCompatibilityValue.Size = new System.Drawing.Size(85, 13);
            this.m_overallCompatibilityValue.TabIndex = 4;
            this.m_overallCompatibilityValue.Text = "(compatibility)";
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
            // m_notesDataGridView
            // 
            this.m_notesDataGridView.AllowUserToAddRows = false;
            this.m_notesDataGridView.AllowUserToDeleteRows = false;
            this.m_notesDataGridView.AllowUserToResizeColumns = false;
            this.m_notesDataGridView.AllowUserToResizeRows = false;
            this.m_notesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_notesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_notesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompatibilityLevelIcon,
            this.CompatiblityLevel,
            this.Remarks});
            this.m_notesDataGridView.Location = new System.Drawing.Point(13, 63);
            this.m_notesDataGridView.MultiSelect = false;
            this.m_notesDataGridView.Name = "m_notesDataGridView";
            this.m_notesDataGridView.ReadOnly = true;
            this.m_notesDataGridView.RowHeadersVisible = false;
            this.m_notesDataGridView.ShowEditingIcon = false;
            this.m_notesDataGridView.ShowRowErrors = false;
            this.m_notesDataGridView.Size = new System.Drawing.Size(559, 150);
            this.m_notesDataGridView.TabIndex = 1;
            this.m_notesDataGridView.TabStop = false;
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
            // FormatCompatibilityDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_okButton;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.m_overallCompatibilityValue);
            this.Controls.Add(m_compatibilityNotesLabel);
            this.Controls.Add(m_overallCompatibilityLabel);
            this.Controls.Add(this.m_notesDataGridView);
            this.Controls.Add(this.m_okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatCompatibilityDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Format Compatibility Report";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_notesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.DataGridView m_notesDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn CompatibilityLevelIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompatiblityLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label m_overallCompatibilityValue;
    }
}