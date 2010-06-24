namespace TileMapEditor.Dialogs
{
    partial class CommandHistoryDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandHistoryDialog));
            this.m_commandsDataGridView = new System.Windows.Forms.DataGridView();
            this.Command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_commandsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_commandsDataGridView
            // 
            this.m_commandsDataGridView.AllowUserToAddRows = false;
            this.m_commandsDataGridView.AllowUserToDeleteRows = false;
            this.m_commandsDataGridView.AllowUserToResizeColumns = false;
            this.m_commandsDataGridView.AllowUserToResizeRows = false;
            this.m_commandsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.m_commandsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_commandsDataGridView.ColumnHeadersVisible = false;
            this.m_commandsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Action});
            this.m_commandsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_commandsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_commandsDataGridView.MultiSelect = false;
            this.m_commandsDataGridView.Name = "m_commandsDataGridView";
            this.m_commandsDataGridView.ReadOnly = true;
            this.m_commandsDataGridView.RowHeadersVisible = false;
            this.m_commandsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.m_commandsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_commandsDataGridView.Size = new System.Drawing.Size(304, 206);
            this.m_commandsDataGridView.TabIndex = 0;
            // 
            // Command
            // 
            this.Command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Command.FillWeight = 80F;
            this.Command.HeaderText = "Command";
            this.Command.Name = "Command";
            this.Command.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.FillWeight = 20F;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // CommandHistoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 206);
            this.Controls.Add(this.m_commandsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 120);
            this.Name = "CommandHistoryDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Command History";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_commandsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_commandsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}