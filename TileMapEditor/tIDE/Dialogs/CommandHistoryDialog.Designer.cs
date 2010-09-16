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
            this.m_undoLabel = new System.Windows.Forms.Label();
            this.m_redoLabel = new System.Windows.Forms.Label();
            this.m_CurrentStateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_commandsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // m_commandsDataGridView
            // 
            this.m_commandsDataGridView.AccessibleDescription = null;
            this.m_commandsDataGridView.AccessibleName = null;
            this.m_commandsDataGridView.AllowUserToAddRows = false;
            this.m_commandsDataGridView.AllowUserToDeleteRows = false;
            this.m_commandsDataGridView.AllowUserToResizeColumns = false;
            this.m_commandsDataGridView.AllowUserToResizeRows = false;
            resources.ApplyResources(this.m_commandsDataGridView, "m_commandsDataGridView");
            this.m_commandsDataGridView.BackgroundImage = null;
            this.m_commandsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.m_commandsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_commandsDataGridView.ColumnHeadersVisible = false;
            this.m_commandsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Action});
            this.m_commandsDataGridView.Font = null;
            this.m_commandsDataGridView.MultiSelect = false;
            this.m_commandsDataGridView.Name = "m_commandsDataGridView";
            this.m_commandsDataGridView.ReadOnly = true;
            this.m_commandsDataGridView.RowHeadersVisible = false;
            this.m_commandsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.m_commandsDataGridView.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // Command
            // 
            this.Command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Command.FillWeight = 80F;
            resources.ApplyResources(this.Command, "Command");
            this.Command.Name = "Command";
            this.Command.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.FillWeight = 20F;
            resources.ApplyResources(this.Action, "Action");
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // m_undoLabel
            // 
            this.m_undoLabel.AccessibleDescription = null;
            this.m_undoLabel.AccessibleName = null;
            resources.ApplyResources(this.m_undoLabel, "m_undoLabel");
            this.m_undoLabel.Font = null;
            this.m_undoLabel.Name = "m_undoLabel";
            // 
            // m_redoLabel
            // 
            this.m_redoLabel.AccessibleDescription = null;
            this.m_redoLabel.AccessibleName = null;
            resources.ApplyResources(this.m_redoLabel, "m_redoLabel");
            this.m_redoLabel.Font = null;
            this.m_redoLabel.Name = "m_redoLabel";
            // 
            // m_CurrentStateLabel
            // 
            this.m_CurrentStateLabel.AccessibleDescription = null;
            this.m_CurrentStateLabel.AccessibleName = null;
            resources.ApplyResources(this.m_CurrentStateLabel, "m_CurrentStateLabel");
            this.m_CurrentStateLabel.Font = null;
            this.m_CurrentStateLabel.Name = "m_CurrentStateLabel";
            // 
            // CommandHistoryDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_CurrentStateLabel);
            this.Controls.Add(this.m_redoLabel);
            this.Controls.Add(this.m_undoLabel);
            this.Controls.Add(this.m_commandsDataGridView);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CommandHistoryDialog";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_commandsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_commandsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Label m_undoLabel;
        private System.Windows.Forms.Label m_redoLabel;
        private System.Windows.Forms.Label m_CurrentStateLabel;
    }
}