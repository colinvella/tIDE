namespace TileMapEditor.Controls
{
    partial class CustomPropertyGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPropertyGrid));
            this.m_dataGridView = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_noNameMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            this.m_duplicateNameMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridView
            // 
            this.m_dataGridView.AccessibleDescription = null;
            this.m_dataGridView.AccessibleName = null;
            this.m_dataGridView.AllowUserToOrderColumns = true;
            this.m_dataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.m_dataGridView, "m_dataGridView");
            this.m_dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dataGridView.BackgroundImage = null;
            this.m_dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyValue});
            this.m_dataGridView.Font = null;
            this.m_dataGridView.MultiSelect = false;
            this.m_dataGridView.Name = "m_dataGridView";
            this.m_dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.OnCellBeginEdit);
            this.m_dataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValidated);
            this.m_dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.OnUserDeletedRow);
            this.m_dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.OnCellValidating);
            // 
            // PropertyName
            // 
            this.PropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.PropertyName, "PropertyName");
            this.PropertyName.Name = "PropertyName";
            // 
            // PropertyValue
            // 
            this.PropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.PropertyValue, "PropertyValue");
            this.PropertyValue.Name = "PropertyValue";
            // 
            // m_noNameMessageBox
            // 
            resources.ApplyResources(this.m_noNameMessageBox, "m_noNameMessageBox");
            this.m_noNameMessageBox.HelpFilePath = null;
            this.m_noNameMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Error;
            this.m_noNameMessageBox.Owner = this;
            // 
            // m_duplicateNameMessageBox
            // 
            resources.ApplyResources(this.m_duplicateNameMessageBox, "m_duplicateNameMessageBox");
            this.m_duplicateNameMessageBox.HelpFilePath = null;
            this.m_duplicateNameMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Error;
            this.m_duplicateNameMessageBox.Owner = this;
            // 
            // CustomPropertyGrid
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_dataGridView);
            this.Font = null;
            this.Name = "CustomPropertyGrid";
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue;
        private CustomMessageBox m_noNameMessageBox;
        private CustomMessageBox m_duplicateNameMessageBox;
    }
}
