namespace TileMapEditor.Dialog
{
    partial class LayerPropertiesDialog
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
            System.Windows.Forms.Label m_labelDescription;
            System.Windows.Forms.Label m_labelId;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerPropertiesDialog));
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_customTabControl = new TileMapEditor.Control.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_numericTileHeight = new System.Windows.Forms.NumericUpDown();
            this.m_numericTileWidth = new System.Windows.Forms.NumericUpDown();
            this.m_numericLayerHeight = new System.Windows.Forms.NumericUpDown();
            this.m_numericLayerWidth = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new TileMapEditor.Control.CustomPropertyGrid();
            m_labelDescription = new System.Windows.Forms.Label();
            m_labelId = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerWidth)).BeginInit();
            this.m_tabCustomProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelDescription
            // 
            m_labelDescription.AutoSize = true;
            m_labelDescription.Location = new System.Drawing.Point(6, 36);
            m_labelDescription.Name = "m_labelDescription";
            m_labelDescription.Size = new System.Drawing.Size(60, 13);
            m_labelDescription.TabIndex = 2;
            m_labelDescription.Text = "Description";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 283);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 7;
            label1.Text = "Layer Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(169, 283);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(12, 13);
            label2.TabIndex = 9;
            label2.Text = "x";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(253, 283);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(25, 13);
            label3.TabIndex = 11;
            label3.Text = "tiles";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(253, 309);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 16;
            label4.Text = "pixels";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(169, 309);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(12, 13);
            label5.TabIndex = 14;
            label5.Text = "x";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 309);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(47, 13);
            label6.TabIndex = 12;
            label6.Text = "Tile Size";
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Location = new System.Drawing.Point(12, 377);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 1;
            this.m_buttonOk.Text = "OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.m_buttonOk_Click);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Location = new System.Drawing.Point(497, 377);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 2;
            this.m_buttonCancel.Text = "Cancel";
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
            // m_customTabControl
            // 
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
            this.m_tabGeneral.Controls.Add(label4);
            this.m_tabGeneral.Controls.Add(this.m_numericTileHeight);
            this.m_tabGeneral.Controls.Add(label5);
            this.m_tabGeneral.Controls.Add(this.m_numericTileWidth);
            this.m_tabGeneral.Controls.Add(label6);
            this.m_tabGeneral.Controls.Add(label3);
            this.m_tabGeneral.Controls.Add(this.m_numericLayerHeight);
            this.m_tabGeneral.Controls.Add(label2);
            this.m_tabGeneral.Controls.Add(this.m_numericLayerWidth);
            this.m_tabGeneral.Controls.Add(label1);
            this.m_tabGeneral.Controls.Add(this.m_textBoxDescription);
            this.m_tabGeneral.Controls.Add(m_labelDescription);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(m_labelId);
            this.m_tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabGeneral.Size = new System.Drawing.Size(552, 333);
            this.m_tabGeneral.TabIndex = 0;
            this.m_tabGeneral.Text = " General ";
            // 
            // m_numericTileHeight
            // 
            this.m_numericTileHeight.Location = new System.Drawing.Point(187, 307);
            this.m_numericTileHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.m_numericTileHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericTileHeight.Name = "m_numericTileHeight";
            this.m_numericTileHeight.Size = new System.Drawing.Size(60, 20);
            this.m_numericTileHeight.TabIndex = 15;
            this.m_numericTileHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // m_numericTileWidth
            // 
            this.m_numericTileWidth.Location = new System.Drawing.Point(103, 307);
            this.m_numericTileWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.m_numericTileWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericTileWidth.Name = "m_numericTileWidth";
            this.m_numericTileWidth.Size = new System.Drawing.Size(60, 20);
            this.m_numericTileWidth.TabIndex = 13;
            this.m_numericTileWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // m_numericLayerHeight
            // 
            this.m_numericLayerHeight.Location = new System.Drawing.Point(187, 281);
            this.m_numericLayerHeight.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_numericLayerHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericLayerHeight.Name = "m_numericLayerHeight";
            this.m_numericLayerHeight.Size = new System.Drawing.Size(60, 20);
            this.m_numericLayerHeight.TabIndex = 10;
            this.m_numericLayerHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_numericLayerWidth
            // 
            this.m_numericLayerWidth.Location = new System.Drawing.Point(103, 281);
            this.m_numericLayerWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_numericLayerWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericLayerWidth.Name = "m_numericLayerWidth";
            this.m_numericLayerWidth.Size = new System.Drawing.Size(60, 20);
            this.m_numericLayerWidth.TabIndex = 8;
            this.m_numericLayerWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.Location = new System.Drawing.Point(103, 33);
            this.m_textBoxDescription.Multiline = true;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.Size = new System.Drawing.Size(443, 242);
            this.m_textBoxDescription.TabIndex = 3;
            // 
            // m_textBoxId
            // 
            this.m_textBoxId.Location = new System.Drawing.Point(103, 7);
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.Size = new System.Drawing.Size(200, 20);
            this.m_textBoxId.TabIndex = 1;
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
            this.m_customPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_customPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.Size = new System.Drawing.Size(546, 327);
            this.m_customPropertyGrid.TabIndex = 0;
            // 
            // LayerPropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerPropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Properties";
            this.Load += new System.EventHandler(this.LayerPropertiesDialog_Load);
            this.m_customTabControl.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.m_tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerWidth)).EndInit();
            this.m_tabCustomProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private TileMapEditor.Control.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.TextBox m_textBoxId;
        private TileMapEditor.Control.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.NumericUpDown m_numericLayerHeight;
        private System.Windows.Forms.NumericUpDown m_numericLayerWidth;
        private System.Windows.Forms.NumericUpDown m_numericTileHeight;
        private System.Windows.Forms.NumericUpDown m_numericTileWidth;
    }
}