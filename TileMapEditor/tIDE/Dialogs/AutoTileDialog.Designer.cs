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
            this.m_btnNew = new System.Windows.Forms.Button();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_cmbId = new System.Windows.Forms.ComboBox();
            this.m_btnDelete = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnApply = new System.Windows.Forms.Button();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.m_tilePicker = new TileMapEditor.Controls.TilePicker();
            this.m_panelTemplate = new TileMapEditor.Controls.CustomPanel();
            m_lblId = new System.Windows.Forms.Label();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblId
            // 
            m_lblId.AutoSize = true;
            m_lblId.Location = new System.Drawing.Point(12, 15);
            m_lblId.Name = "m_lblId";
            m_lblId.Size = new System.Drawing.Size(18, 13);
            m_lblId.TabIndex = 3;
            m_lblId.Text = "ID";
            // 
            // m_btnNew
            // 
            this.m_btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnNew.Location = new System.Drawing.Point(12, 379);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Size = new System.Drawing.Size(75, 23);
            this.m_btnNew.TabIndex = 1;
            this.m_btnNew.Text = "&New...";
            this.m_btnNew.UseVisualStyleBackColor = true;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer.Location = new System.Drawing.Point(12, 43);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_tilePicker);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelTemplate);
            this.m_splitContainer.Size = new System.Drawing.Size(560, 330);
            this.m_splitContainer.SplitterDistance = 186;
            this.m_splitContainer.TabIndex = 2;
            // 
            // m_cmbId
            // 
            this.m_cmbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbId.FormattingEnabled = true;
            this.m_cmbId.Location = new System.Drawing.Point(36, 12);
            this.m_cmbId.Name = "m_cmbId";
            this.m_cmbId.Size = new System.Drawing.Size(121, 21);
            this.m_cmbId.TabIndex = 4;
            this.m_cmbId.SelectedIndexChanged += new System.EventHandler(this.OnAutoTileSelected);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnDelete.Enabled = false;
            this.m_btnDelete.Location = new System.Drawing.Point(93, 379);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(75, 23);
            this.m_btnDelete.TabIndex = 5;
            this.m_btnDelete.Text = "&Delete";
            this.m_btnDelete.UseVisualStyleBackColor = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Enabled = false;
            this.m_btnOk.Location = new System.Drawing.Point(335, 379);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.Text = "&OK";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_btnApply
            // 
            this.m_btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnApply.Enabled = false;
            this.m_btnApply.Location = new System.Drawing.Point(416, 379);
            this.m_btnApply.Name = "m_btnApply";
            this.m_btnApply.Size = new System.Drawing.Size(75, 23);
            this.m_btnApply.TabIndex = 7;
            this.m_btnApply.Text = "&Apply";
            this.m_btnApply.UseVisualStyleBackColor = true;
            // 
            // m_btnClose
            // 
            this.m_btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClose.Location = new System.Drawing.Point(497, 379);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(75, 23);
            this.m_btnClose.TabIndex = 8;
            this.m_btnClose.Text = "&Close";
            this.m_btnClose.UseVisualStyleBackColor = true;
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.AllowDrop = true;
            this.m_tilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tilePicker.Location = new System.Drawing.Point(0, 0);
            this.m_tilePicker.LockTileSheet = true;
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.Size = new System.Drawing.Size(186, 330);
            this.m_tilePicker.TabIndex = 0;
            this.m_tilePicker.TileDrag += new TileMapEditor.Controls.TilePickerEventHandler(this.OnTileDrag);
            // 
            // m_panelTemplate
            // 
            this.m_panelTemplate.AllowDrop = true;
            this.m_panelTemplate.BackgroundImage = global::TileMapEditor.Properties.Resources.AutoTileTemplate;
            this.m_panelTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_panelTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTemplate.Location = new System.Drawing.Point(0, 0);
            this.m_panelTemplate.Name = "m_panelTemplate";
            this.m_panelTemplate.Size = new System.Drawing.Size(370, 330);
            this.m_panelTemplate.TabIndex = 0;
            this.m_panelTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTemplatePaint);
            this.m_panelTemplate.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTileDragDrop);
            this.m_panelTemplate.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTileDragEnter);
            // 
            // AutoTileDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.m_btnClose;
            this.ClientSize = new System.Drawing.Size(584, 414);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnApply);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnDelete);
            this.Controls.Add(this.m_cmbId);
            this.Controls.Add(m_lblId);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.m_btnNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "AutoTileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Tiles";
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


    }
}