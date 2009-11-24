namespace TileMapEditor
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
            this.m_dataGridView = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGridView
            // 
            this.m_dataGridView.AllowUserToOrderColumns = true;
            this.m_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyValue});
            this.m_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_dataGridView.Name = "m_dataGridView";
            this.m_dataGridView.Size = new System.Drawing.Size(440, 150);
            this.m_dataGridView.TabIndex = 0;
            this.m_dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.m_dataGridView_CellBeginEdit);
            this.m_dataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dataGridView_CellValidated);
            this.m_dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.m_dataGridView_UserDeletedRow);
            this.m_dataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.m_dataGridView_CellValidating);
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "Name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.Width = 200;
            // 
            // PropertyValue
            // 
            this.PropertyValue.HeaderText = "Value";
            this.PropertyValue.Name = "PropertyValue";
            this.PropertyValue.Width = 200;
            // 
            // CustomPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_dataGridView);
            this.Name = "CustomPropertyGrid";
            this.Size = new System.Drawing.Size(440, 150);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue;
    }
}
