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
            this.components = new System.ComponentModel.Container();
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
            this.m_noIdMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            this.m_duplicateIdMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            this.m_deleteMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            m_lblId = new System.Windows.Forms.Label();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblId
            // 
            resources.ApplyResources(m_lblId, "m_lblId");
            m_lblId.Name = "m_lblId";
            // 
            // m_splitContainer
            // 
            resources.ApplyResources(this.m_splitContainer, "m_splitContainer");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_tilePicker);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelTemplate);
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.AllowDrop = true;
            resources.ApplyResources(this.m_tilePicker, "m_tilePicker");
            this.m_tilePicker.LockTileSheet = true;
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.TileDrag += new TileMapEditor.Controls.TilePickerEventHandler(this.OnTileDrag);
            // 
            // m_panelTemplate
            // 
            this.m_panelTemplate.AllowDrop = true;
            this.m_panelTemplate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.m_panelTemplate.BackgroundImage = global::TileMapEditor.Properties.Resources.AutoTileTemplate;
            resources.ApplyResources(this.m_panelTemplate, "m_panelTemplate");
            this.m_panelTemplate.Name = "m_panelTemplate";
            this.m_panelTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTemplatePaint);
            this.m_panelTemplate.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTileDragDrop);
            this.m_panelTemplate.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTileDragEnter);
            // 
            // m_btnNew
            // 
            resources.ApplyResources(this.m_btnNew, "m_btnNew");
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.UseVisualStyleBackColor = true;
            this.m_btnNew.Click += new System.EventHandler(this.OnNewAutoTile);
            // 
            // m_cmbId
            // 
            this.m_cmbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbId.FormattingEnabled = true;
            resources.ApplyResources(this.m_cmbId, "m_cmbId");
            this.m_cmbId.Name = "m_cmbId";
            this.m_cmbId.SelectedIndexChanged += new System.EventHandler(this.OnAutoTileSelected);
            // 
            // m_btnDelete
            // 
            resources.ApplyResources(this.m_btnDelete, "m_btnDelete");
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.UseVisualStyleBackColor = true;
            this.m_btnDelete.Click += new System.EventHandler(this.OnDeleteAutoTile);
            // 
            // m_btnOk
            // 
            resources.ApplyResources(this.m_btnOk, "m_btnOk");
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_btnApply
            // 
            resources.ApplyResources(this.m_btnApply, "m_btnApply");
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            this.m_btnApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_btnClose
            // 
            resources.ApplyResources(this.m_btnClose, "m_btnClose");
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.UseVisualStyleBackColor = true;
            // 
            // m_btnRename
            // 
            resources.ApplyResources(this.m_btnRename, "m_btnRename");
            this.m_btnRename.Name = "m_btnRename";
            this.m_btnRename.UseVisualStyleBackColor = true;
            this.m_btnRename.Click += new System.EventHandler(this.OnRenameAutoTile);
            // 
            // m_txtNewId
            // 
            resources.ApplyResources(this.m_txtNewId, "m_txtNewId");
            this.m_txtNewId.Name = "m_txtNewId";
            this.m_txtNewId.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnNewIdPreviewKeyDown);
            this.m_txtNewId.Leave += new System.EventHandler(this.OnLeaveNewId);
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_noIdMessageBox
            // 
            resources.ApplyResources(this.m_noIdMessageBox, "m_noIdMessageBox");
            this.m_noIdMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Error;
            this.m_noIdMessageBox.Owner = this;
            // 
            // m_duplicateIdMessageBox
            // 
            resources.ApplyResources(this.m_duplicateIdMessageBox, "m_duplicateIdMessageBox");
            this.m_duplicateIdMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Error;
            this.m_duplicateIdMessageBox.Owner = this;
            // 
            // m_deleteMessageBox
            // 
            this.m_deleteMessageBox.Buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
            resources.ApplyResources(this.m_deleteMessageBox, "m_deleteMessageBox");
            this.m_deleteMessageBox.DefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button2;
            this.m_deleteMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Question;
            this.m_deleteMessageBox.Owner = this;
            // 
            // AutoTileDialog
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private TileMapEditor.Controls.CustomMessageBox m_noIdMessageBox;
        private TileMapEditor.Controls.CustomMessageBox m_duplicateIdMessageBox;
        private TileMapEditor.Controls.CustomMessageBox m_deleteMessageBox;


    }
}