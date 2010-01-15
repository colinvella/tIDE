namespace TileMapEditor.Dialogs
{
    partial class TilePropertiesDialog
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
            System.Windows.Forms.Label m_labelId;
            System.Windows.Forms.Label m_labelBlendMode;
            System.Windows.Forms.Label m_labelTileSheet;
            System.Windows.Forms.Label m_labelTileIndex;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilePropertiesDialog));
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_customTabControl = new TileMapEditor.Controls.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new TileMapEditor.Controls.CustomPropertyGrid();
            this.m_comboBoxBlendMode = new System.Windows.Forms.ComboBox();
            this.m_textBoxTileSheet = new System.Windows.Forms.TextBox();
            this.m_textBoxTileIndex = new System.Windows.Forms.TextBox();
            m_labelId = new System.Windows.Forms.Label();
            m_labelBlendMode = new System.Windows.Forms.Label();
            m_labelTileSheet = new System.Windows.Forms.Label();
            m_labelTileIndex = new System.Windows.Forms.Label();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.m_tabCustomProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Enabled = false;
            this.m_buttonOk.Location = new System.Drawing.Point(335, 377);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 1;
            this.m_buttonOk.Text = "&OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Location = new System.Drawing.Point(497, 377);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 2;
            this.m_buttonCancel.Text = "&Close";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonApply.Enabled = false;
            this.m_buttonApply.Location = new System.Drawing.Point(416, 377);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(75, 23);
            this.m_buttonApply.TabIndex = 4;
            this.m_buttonApply.Text = "&Apply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_customTabControl
            // 
            this.m_customTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_customTabControl.Controls.Add(this.m_tabGeneral);
            this.m_customTabControl.Controls.Add(this.m_tabCustomProperties);
            this.m_customTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.m_customTabControl.Location = new System.Drawing.Point(12, 12);
            this.m_customTabControl.Name = "m_customTabControl";
            this.m_customTabControl.SelectedIndex = 0;
            this.m_customTabControl.Size = new System.Drawing.Size(560, 359);
            this.m_customTabControl.TabIndex = 3;
            // 
            // m_tabGeneral
            // 
            this.m_tabGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.m_tabGeneral.Controls.Add(this.m_textBoxTileIndex);
            this.m_tabGeneral.Controls.Add(m_labelTileIndex);
            this.m_tabGeneral.Controls.Add(m_labelTileSheet);
            this.m_tabGeneral.Controls.Add(this.m_textBoxTileSheet);
            this.m_tabGeneral.Controls.Add(this.m_comboBoxBlendMode);
            this.m_tabGeneral.Controls.Add(m_labelBlendMode);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(m_labelId);
            this.m_tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabGeneral.Size = new System.Drawing.Size(552, 333);
            this.m_tabGeneral.TabIndex = 0;
            this.m_tabGeneral.Text = " General ";
            // 
            // m_textBoxId
            // 
            this.m_textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxId.Location = new System.Drawing.Point(103, 7);
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.Size = new System.Drawing.Size(443, 20);
            this.m_textBoxId.TabIndex = 1;
            this.m_textBoxId.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_labelId
            // 
            m_labelId.AutoSize = true;
            m_labelId.Location = new System.Drawing.Point(6, 10);
            m_labelId.Name = "m_labelId";
            m_labelId.Size = new System.Drawing.Size(18, 13);
            m_labelId.TabIndex = 0;
            m_labelId.Text = "ID";
            // 
            // m_tabCustomProperties
            // 
            this.m_tabCustomProperties.BackColor = System.Drawing.SystemColors.Control;
            this.m_tabCustomProperties.Controls.Add(this.m_customPropertyGrid);
            this.m_tabCustomProperties.Location = new System.Drawing.Point(4, 22);
            this.m_tabCustomProperties.Name = "m_tabCustomProperties";
            this.m_tabCustomProperties.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabCustomProperties.Size = new System.Drawing.Size(552, 333);
            this.m_tabCustomProperties.TabIndex = 1;
            this.m_tabCustomProperties.Text = " Custom Properties ";
            // 
            // m_customPropertyGrid
            // 
            this.m_customPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_customPropertyGrid.Location = new System.Drawing.Point(6, 6);
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.Size = new System.Drawing.Size(540, 321);
            this.m_customPropertyGrid.TabIndex = 0;
            this.m_customPropertyGrid.PropertyChanged += new TileMapEditor.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // m_labelBlendMode
            // 
            m_labelBlendMode.AutoSize = true;
            m_labelBlendMode.Location = new System.Drawing.Point(6, 37);
            m_labelBlendMode.Name = "m_labelBlendMode";
            m_labelBlendMode.Size = new System.Drawing.Size(64, 13);
            m_labelBlendMode.TabIndex = 2;
            m_labelBlendMode.Text = "Blend Mode";
            // 
            // m_comboBoxBlendMode
            // 
            this.m_comboBoxBlendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxBlendMode.FormattingEnabled = true;
            this.m_comboBoxBlendMode.Items.AddRange(new object[] {
            "Alpha",
            "Additive"});
            this.m_comboBoxBlendMode.Location = new System.Drawing.Point(103, 34);
            this.m_comboBoxBlendMode.Name = "m_comboBoxBlendMode";
            this.m_comboBoxBlendMode.Size = new System.Drawing.Size(121, 21);
            this.m_comboBoxBlendMode.TabIndex = 3;
            // 
            // m_textBoxTileSheet
            // 
            this.m_textBoxTileSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxTileSheet.Location = new System.Drawing.Point(103, 277);
            this.m_textBoxTileSheet.Name = "m_textBoxTileSheet";
            this.m_textBoxTileSheet.ReadOnly = true;
            this.m_textBoxTileSheet.Size = new System.Drawing.Size(443, 20);
            this.m_textBoxTileSheet.TabIndex = 4;
            // 
            // m_labelTileSheet
            // 
            m_labelTileSheet.AutoSize = true;
            m_labelTileSheet.Location = new System.Drawing.Point(6, 284);
            m_labelTileSheet.Name = "m_labelTileSheet";
            m_labelTileSheet.Size = new System.Drawing.Size(55, 13);
            m_labelTileSheet.TabIndex = 5;
            m_labelTileSheet.Text = "Tile Sheet";
            // 
            // m_labelTileIndex
            // 
            m_labelTileIndex.AutoSize = true;
            m_labelTileIndex.Location = new System.Drawing.Point(6, 310);
            m_labelTileIndex.Name = "m_labelTileIndex";
            m_labelTileIndex.Size = new System.Drawing.Size(53, 13);
            m_labelTileIndex.TabIndex = 6;
            m_labelTileIndex.Text = "Tile Index";
            // 
            // m_textBoxTileIndex
            // 
            this.m_textBoxTileIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textBoxTileIndex.Location = new System.Drawing.Point(103, 307);
            this.m_textBoxTileIndex.Name = "m_textBoxTileIndex";
            this.m_textBoxTileIndex.ReadOnly = true;
            this.m_textBoxTileIndex.Size = new System.Drawing.Size(443, 20);
            this.m_textBoxTileIndex.TabIndex = 7;
            // 
            // TilePropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "TilePropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tile Properties";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.m_customTabControl.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.m_tabGeneral.PerformLayout();
            this.m_tabCustomProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private TileMapEditor.Controls.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxId;
        private TileMapEditor.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.TextBox m_textBoxTileIndex;
        private System.Windows.Forms.TextBox m_textBoxTileSheet;
        private System.Windows.Forms.ComboBox m_comboBoxBlendMode;
    }
}