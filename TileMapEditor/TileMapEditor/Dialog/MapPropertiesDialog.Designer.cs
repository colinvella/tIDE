namespace TileMapEditor.Dialog
{
    partial class MapPropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPropertiesDialog));
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_customTabControl = new TileMapEditor.Control.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_labelDescription = new System.Windows.Forms.Label();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_labelId = new System.Windows.Forms.Label();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new TileMapEditor.Control.CustomPropertyGrid();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.m_tabCustomProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Location = new System.Drawing.Point(12, 377);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 1;
            this.m_buttonOk.Text = "OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
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
            this.m_tabGeneral.Controls.Add(this.m_textBoxDescription);
            this.m_tabGeneral.Controls.Add(this.m_labelDescription);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(this.m_labelId);
            this.m_tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabGeneral.Size = new System.Drawing.Size(552, 333);
            this.m_tabGeneral.TabIndex = 0;
            this.m_tabGeneral.Text = " General ";
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.Location = new System.Drawing.Point(103, 33);
            this.m_textBoxDescription.Multiline = true;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.Size = new System.Drawing.Size(443, 294);
            this.m_textBoxDescription.TabIndex = 3;
            // 
            // m_labelDescription
            // 
            this.m_labelDescription.AutoSize = true;
            this.m_labelDescription.Location = new System.Drawing.Point(6, 36);
            this.m_labelDescription.Name = "m_labelDescription";
            this.m_labelDescription.Size = new System.Drawing.Size(60, 13);
            this.m_labelDescription.TabIndex = 2;
            this.m_labelDescription.Text = "Description";
            // 
            // m_textBoxId
            // 
            this.m_textBoxId.Location = new System.Drawing.Point(103, 7);
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.Size = new System.Drawing.Size(100, 20);
            this.m_textBoxId.TabIndex = 1;
            // 
            // m_labelId
            // 
            this.m_labelId.AutoSize = true;
            this.m_labelId.Location = new System.Drawing.Point(6, 10);
            this.m_labelId.Name = "m_labelId";
            this.m_labelId.Size = new System.Drawing.Size(18, 13);
            this.m_labelId.TabIndex = 0;
            this.m_labelId.Text = "ID";
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
            this.m_customPropertyGrid.Location = new System.Drawing.Point(6, 6);
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.Size = new System.Drawing.Size(540, 321);
            this.m_customPropertyGrid.TabIndex = 0;
            // 
            // MapPropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapPropertiesDialog";
            this.Text = "Map Properties";
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
        private TileMapEditor.Control.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Label m_labelDescription;
        private System.Windows.Forms.TextBox m_textBoxId;
        private System.Windows.Forms.Label m_labelId;
        private TileMapEditor.Control.CustomPropertyGrid m_customPropertyGrid;
    }
}