namespace TileMapEditor.Dialogs
{
    partial class AutoTileDialog
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
            System.Windows.Forms.Label m_lblId;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTileDialog));
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_tilePicker = new TileMapEditor.Controls.TilePicker();
            this.m_panelTemplate = new TileMapEditor.Controls.CustomPanel();
            this.m_btnNew = new System.Windows.Forms.Button();
            this.m_cmbId = new System.Windows.Forms.ComboBox();
            this.m_btnDelete = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.m_btnRename = new System.Windows.Forms.Button();
            this.m_txtNewId = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            m_lblId = new System.Windows.Forms.Label();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblId
            // 
            m_lblId.AccessibleDescription = null;
            m_lblId.AccessibleName = null;
            resources.ApplyResources(m_lblId, "m_lblId");
            m_lblId.Font = null;
            m_lblId.Name = "m_lblId";
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.AccessibleDescription = null;
            this.m_splitContainer.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer, "m_splitContainer");
            this.m_splitContainer.BackgroundImage = null;
            this.m_splitContainer.Font = null;
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.AccessibleDescription = null;
            this.m_splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer.Panel1, "m_splitContainer.Panel1");
            this.m_splitContainer.Panel1.BackgroundImage = null;
            this.m_splitContainer.Panel1.Controls.Add(this.m_tilePicker);
            this.m_splitContainer.Panel1.Font = null;
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.AccessibleDescription = null;
            this.m_splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer.Panel2, "m_splitContainer.Panel2");
            this.m_splitContainer.Panel2.BackgroundImage = null;
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelTemplate);
            this.m_splitContainer.Panel2.Font = null;
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.AccessibleDescription = null;
            this.m_tilePicker.AccessibleName = null;
            this.m_tilePicker.AllowDrop = true;
            resources.ApplyResources(this.m_tilePicker, "m_tilePicker");
            this.m_tilePicker.BackgroundImage = null;
            this.m_tilePicker.Font = null;
            this.m_tilePicker.LockTileSheet = true;
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.TileDrag += new TileMapEditor.Controls.TilePickerEventHandler(this.OnTileDrag);
            // 
            // m_panelTemplate
            // 
            this.m_panelTemplate.AccessibleDescription = null;
            this.m_panelTemplate.AccessibleName = null;
            this.m_panelTemplate.AllowDrop = true;
            resources.ApplyResources(this.m_panelTemplate, "m_panelTemplate");
            this.m_panelTemplate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.m_panelTemplate.BackgroundImage = global::TileMapEditor.Properties.Resources.AutoTileTemplate;
            this.m_panelTemplate.Font = null;
            this.m_panelTemplate.Name = "m_panelTemplate";
            this.m_panelTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTemplatePaint);
            this.m_panelTemplate.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTileDragDrop);
            this.m_panelTemplate.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTileDragEnter);
            // 
            // m_btnNew
            // 
            this.m_btnNew.AccessibleDescription = null;
            this.m_btnNew.AccessibleName = null;
            resources.ApplyResources(this.m_btnNew, "m_btnNew");
            this.m_btnNew.BackgroundImage = null;
            this.m_btnNew.Font = null;
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.UseVisualStyleBackColor = true;
            this.m_btnNew.Click += new System.EventHandler(this.OnNewAutoTile);
            // 
            // m_cmbId
            // 
            this.m_cmbId.AccessibleDescription = null;
            this.m_cmbId.AccessibleName = null;
            resources.ApplyResources(this.m_cmbId, "m_cmbId");
            this.m_cmbId.BackgroundImage = null;
            this.m_cmbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbId.Font = null;
            this.m_cmbId.FormattingEnabled = true;
            this.m_cmbId.Name = "m_cmbId";
            this.m_cmbId.SelectedIndexChanged += new System.EventHandler(this.OnAutoTileSelected);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.AccessibleDescription = null;
            this.m_btnDelete.AccessibleName = null;
            resources.ApplyResources(this.m_btnDelete, "m_btnDelete");
            this.m_btnDelete.BackgroundImage = null;
            this.m_btnDelete.Font = null;
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.UseVisualStyleBackColor = true;
            this.m_btnDelete.Click += new System.EventHandler(this.OnDeleteAutoTile);
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
            this.m_btnOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_btnApply
            // 
            this.m_btnApply.AccessibleDescription = null;
            this.m_btnApply.AccessibleName = null;
            resources.ApplyResources(this.m_btnApply, "m_btnApply");
            this.m_btnApply.BackgroundImage = null;
            this.m_btnApply.Font = null;
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_btnClose
            // 
            this.m_btnClose.AccessibleDescription = null;
            this.m_btnClose.AccessibleName = null;
            resources.ApplyResources(this.m_btnClose, "m_btnClose");
            this.m_btnClose.BackgroundImage = null;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnClose.Font = null;
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.UseVisualStyleBackColor = true;
            // 
            // m_btnRename
            // 
            this.m_btnRename.AccessibleDescription = null;
            this.m_btnRename.AccessibleName = null;
            resources.ApplyResources(this.m_btnRename, "m_btnRename");
            this.m_btnRename.BackgroundImage = null;
            this.m_btnRename.Font = null;
            this.m_btnRename.Name = "m_btnRename";
            this.m_btnRename.UseVisualStyleBackColor = true;
            this.m_btnRename.Click += new System.EventHandler(this.OnRenameAutoTile);
            // 
            // m_txtNewId
            // 
            this.m_txtNewId.AccessibleDescription = null;
            this.m_txtNewId.AccessibleName = null;
            resources.ApplyResources(this.m_txtNewId, "m_txtNewId");
            this.m_txtNewId.BackgroundImage = null;
            this.m_txtNewId.Font = null;
            this.m_txtNewId.Name = "m_txtNewId";
            this.m_txtNewId.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnNewIdPreviewKeyDown);
            this.m_txtNewId.Leave += new System.EventHandler(this.OnLeaveNewId);
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
            // AutoTileDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnClose;
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnRename);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnDelete);
            this.Controls.Add(this.m_cmbId);
            this.Controls.Add(m_lblId);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.m_btnNew);
            this.Controls.Add(this.m_txtNewId);
            this.Font = null;
            this.Name = "AutoTileDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnNew;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private TileMapEditor.Controls.TilePicker m_tilePicker;
        private TileMapEditor.Controls.CustomPanel m_panelTemplate;
        private System.Windows.Forms.ComboBox m_cmbId;
        private System.Windows.Forms.Button m_btnDelete;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnApply;
        private System.Windows.Forms.Button m_btnClose;
        private System.Windows.Forms.Button m_btnRename;
        private System.Windows.Forms.TextBox m_txtNewId;
        private System.Windows.Forms.Button m_btnCancel;


    }
}