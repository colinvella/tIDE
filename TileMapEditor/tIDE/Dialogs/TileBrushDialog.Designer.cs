namespace TileMapEditor.Dialogs
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
            this.m_closeButton = new System.Windows.Forms.Button();
            this.m_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            resources.ApplyResources(this.m_okButton, "m_okButton");
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_applyButton
            // 
            resources.ApplyResources(this.m_applyButton, "m_applyButton");
            this.m_applyButton.Name = "m_applyButton";
            this.m_applyButton.UseVisualStyleBackColor = true;
            this.m_applyButton.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_cancelButton
            // 
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Click += new System.EventHandler(this.OnDialogCancel);
            // 
            // m_listView
            // 
            resources.ApplyResources(this.m_listView, "m_listView");
            this.m_listView.BackgroundImage = global::TileMapEditor.Properties.Resources.ImageBackground;
            this.m_listView.BackgroundImageTiled = true;
            this.m_listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listView.ContextMenuStrip = this.m_contextMenuStrip;
            this.m_listView.LabelEdit = true;
            this.m_listView.MultiSelect = false;
            this.m_listView.Name = "m_listView";
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
            resources.ApplyResources(this.m_contextMenuStrip, "m_contextMenuStrip");
            // 
            // m_renameMenuItem
            // 
            this.m_renameMenuItem.Name = "m_renameMenuItem";
            resources.ApplyResources(this.m_renameMenuItem, "m_renameMenuItem");
            this.m_renameMenuItem.Click += new System.EventHandler(this.OnTileBrushRename);
            // 
            // m_deleteMenuItem
            // 
            this.m_deleteMenuItem.Name = "m_deleteMenuItem";
            resources.ApplyResources(this.m_deleteMenuItem, "m_deleteMenuItem");
            this.m_deleteMenuItem.Click += new System.EventHandler(this.OnTileBrushDelete);
            // 
            // m_renameButton
            // 
            resources.ApplyResources(this.m_renameButton, "m_renameButton");
            this.m_renameButton.Name = "m_renameButton";
            this.m_renameButton.UseVisualStyleBackColor = true;
            this.m_renameButton.Click += new System.EventHandler(this.OnTileBrushRename);
            // 
            // m_deleteButton
            // 
            resources.ApplyResources(this.m_deleteButton, "m_deleteButton");
            this.m_deleteButton.Name = "m_deleteButton";
            this.m_deleteButton.UseVisualStyleBackColor = true;
            this.m_deleteButton.Click += new System.EventHandler(this.OnTileBrushDelete);
            // 
            // m_closeButton
            // 
            resources.ApplyResources(this.m_closeButton, "m_closeButton");
            this.m_closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_closeButton.Name = "m_closeButton";
            this.m_closeButton.UseVisualStyleBackColor = true;
            // 
            // TileBrushDialog
            // 
            this.AcceptButton = this.m_okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.Controls.Add(this.m_deleteButton);
            this.Controls.Add(this.m_renameButton);
            this.Controls.Add(this.m_closeButton);
            this.Controls.Add(this.m_listView);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_applyButton);
            this.Controls.Add(this.m_okButton);
            this.MinimizeBox = false;
            this.Name = "TileBrushDialog";
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
        private System.Windows.Forms.Button m_closeButton;
    }
}