namespace TileMapEditor.Dialog
{
    partial class TileBrushDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileBrushDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_applyButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_listView = new System.Windows.Forms.ListView();
            this.m_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_renameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_renameButton = new System.Windows.Forms.Button();
            this.m_deleteButton = new System.Windows.Forms.Button();
            this.m_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_okButton.Enabled = false;
            this.m_okButton.Location = new System.Drawing.Point(335, 377);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 3;
            this.m_okButton.Text = "&OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_applyButton
            // 
            this.m_applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_applyButton.Enabled = false;
            this.m_applyButton.Location = new System.Drawing.Point(416, 377);
            this.m_applyButton.Name = "m_applyButton";
            this.m_applyButton.Size = new System.Drawing.Size(75, 23);
            this.m_applyButton.TabIndex = 4;
            this.m_applyButton.Text = "&Apply";
            this.m_applyButton.UseVisualStyleBackColor = true;
            this.m_applyButton.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(497, 377);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 5;
            this.m_cancelButton.Text = "&Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_listView
            // 
            this.m_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listView.BackgroundImage = global::TileMapEditor.Properties.Resources.ImageBackground;
            this.m_listView.BackgroundImageTiled = true;
            this.m_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listView.ContextMenuStrip = this.m_contextMenuStrip;
            this.m_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_listView.LabelEdit = true;
            this.m_listView.Location = new System.Drawing.Point(12, 12);
            this.m_listView.MultiSelect = false;
            this.m_listView.Name = "m_listView";
            this.m_listView.Size = new System.Drawing.Size(560, 359);
            this.m_listView.TabIndex = 0;
            this.m_listView.UseCompatibleStateImageBehavior = false;
            this.m_listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.OnAfterLabelEdit);
            this.m_listView.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // m_contextMenuStrip
            // 
            this.m_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_renameMenuItem,
            this.m_deleteMenuItem});
            this.m_contextMenuStrip.Name = "m_contextMenuStrip";
            this.m_contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // m_renameMenuItem
            // 
            this.m_renameMenuItem.Name = "m_renameMenuItem";
            this.m_renameMenuItem.Size = new System.Drawing.Size(117, 22);
            this.m_renameMenuItem.Text = "Rename";
            this.m_renameMenuItem.Click += new System.EventHandler(this.OnTileBrushRename);
            // 
            // m_deleteMenuItem
            // 
            this.m_deleteMenuItem.Name = "m_deleteMenuItem";
            this.m_deleteMenuItem.Size = new System.Drawing.Size(117, 22);
            this.m_deleteMenuItem.Text = "Delete";
            this.m_deleteMenuItem.Click += new System.EventHandler(this.OnTileBrushDelete);
            // 
            // m_renameButton
            // 
            this.m_renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_renameButton.Enabled = false;
            this.m_renameButton.Location = new System.Drawing.Point(12, 377);
            this.m_renameButton.Name = "m_renameButton";
            this.m_renameButton.Size = new System.Drawing.Size(75, 23);
            this.m_renameButton.TabIndex = 1;
            this.m_renameButton.Text = "&Rename";
            this.m_renameButton.UseVisualStyleBackColor = true;
            this.m_renameButton.Click += new System.EventHandler(this.OnTileBrushRename);
            // 
            // m_deleteButton
            // 
            this.m_deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_deleteButton.Enabled = false;
            this.m_deleteButton.Location = new System.Drawing.Point(93, 377);
            this.m_deleteButton.Name = "m_deleteButton";
            this.m_deleteButton.Size = new System.Drawing.Size(75, 23);
            this.m_deleteButton.TabIndex = 2;
            this.m_deleteButton.Text = "&Delete";
            this.m_deleteButton.UseVisualStyleBackColor = true;
            this.m_deleteButton.Click += new System.EventHandler(this.OnTileBrushDelete);
            // 
            // TileBrushDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_deleteButton);
            this.Controls.Add(this.m_renameButton);
            this.Controls.Add(this.m_listView);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_applyButton);
            this.Controls.Add(this.m_okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 150);
            this.Name = "TileBrushDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tile Brushes";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.m_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_applyButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.ListView m_listView;
        private System.Windows.Forms.Button m_renameButton;
        private System.Windows.Forms.Button m_deleteButton;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_renameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_deleteMenuItem;
    }
}