namespace tIDE.Dialogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatCompatibilityDialog));
            System.Windows.Forms.Label m_compatibilityNotesLabel;
            this.m_overallCompatibilityValue = new System.Windows.Forms.Label();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_notesDataGridView = new System.Windows.Forms.DataGridView();
            this.m_okButton = new System.Windows.Forms.Button();
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
            m_overallCompatibilityLabel.AccessibleDescription = null;
            m_overallCompatibilityLabel.AccessibleName = null;
            resources.ApplyResources(m_overallCompatibilityLabel, "m_overallCompatibilityLabel");
            m_overallCompatibilityLabel.Font = null;
            m_overallCompatibilityLabel.Name = "m_overallCompatibilityLabel";
            // 
            // m_compatibilityNotesLabel
            // 
            m_compatibilityNotesLabel.AccessibleDescription = null;
            m_compatibilityNotesLabel.AccessibleName = null;
            resources.ApplyResources(m_compatibilityNotesLabel, "m_compatibilityNotesLabel");
            m_compatibilityNotesLabel.Font = null;
            m_compatibilityNotesLabel.Name = "m_compatibilityNotesLabel";
            // 
            // m_overallCompatibilityValue
            // 
            this.m_overallCompatibilityValue.AccessibleDescription = null;
            this.m_overallCompatibilityValue.AccessibleName = null;
            resources.ApplyResources(this.m_overallCompatibilityValue, "m_overallCompatibilityValue");
            this.m_overallCompatibilityValue.Name = "m_overallCompatibilityValue";
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
            // m_notesDataGridView
            // 
            this.m_notesDataGridView.AccessibleDescription = null;
            this.m_notesDataGridView.AccessibleName = null;
            this.m_notesDataGridView.AllowUserToAddRows = false;
            this.m_notesDataGridView.AllowUserToDeleteRows = false;
            this.m_notesDataGridView.AllowUserToResizeColumns = false;
            this.m_notesDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.m_notesDataGridView, "m_notesDataGridView");
            this.m_notesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_notesDataGridView.BackgroundImage = null;
            this.m_notesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.m_notesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_notesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompatibilityLevelIcon,
            this.CompatiblityLevel,
            this.Remarks});
            this.m_notesDataGridView.Font = null;
            this.m_notesDataGridView.MultiSelect = false;
            this.m_notesDataGridView.Name = "m_notesDataGridView";
            this.m_notesDataGridView.ReadOnly = true;
            this.m_notesDataGridView.RowHeadersVisible = false;
            this.m_notesDataGridView.ShowEditingIcon = false;
            this.m_notesDataGridView.ShowRowErrors = false;
            this.m_notesDataGridView.TabStop = false;
            this.m_notesDataGridView.SelectionChanged += new System.EventHandler(this.OnNoteSelectionChanged);
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
            // 
            // CompatibilityLevelIcon
            // 
            resources.ApplyResources(this.CompatibilityLevelIcon, "CompatibilityLevelIcon");
            this.CompatibilityLevelIcon.Name = "CompatibilityLevelIcon";
            this.CompatibilityLevelIcon.ReadOnly = true;
            this.CompatibilityLevelIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CompatiblityLevel
            // 
            this.CompatiblityLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompatiblityLevel.FillWeight = 30F;
            resources.ApplyResources(this.CompatiblityLevel, "CompatiblityLevel");
            this.CompatiblityLevel.Name = "CompatiblityLevel";
            this.CompatiblityLevel.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.FillWeight = 70F;
            resources.ApplyResources(this.Remarks, "Remarks");
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // FormatCompatibilityDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_cancelButton;
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_overallCompatibilityValue);
            this.Controls.Add(m_compatibilityNotesLabel);
            this.Controls.Add(m_overallCompatibilityLabel);
            this.Controls.Add(this.m_notesDataGridView);
            this.Controls.Add(this.m_cancelButton);
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatCompatibilityDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_notesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.DataGridView m_notesDataGridView;
        private System.Windows.Forms.Label m_overallCompatibilityValue;
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.DataGridViewImageColumn CompatibilityLevelIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompatiblityLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}