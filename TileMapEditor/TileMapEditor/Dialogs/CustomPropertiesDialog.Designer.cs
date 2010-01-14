namespace TileMapEditor.Dialogs
{
    partial class CustomPropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPropertiesDialog));
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_customPropertyGrid = new TileMapEditor.Controls.CustomPropertyGrid();
            this.SuspendLayout();
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Enabled = false;
            this.m_buttonOk.Location = new System.Drawing.Point(135, 227);
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.m_buttonOk.TabIndex = 1;
            this.m_buttonOk.Text = "&OK";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Location = new System.Drawing.Point(297, 227);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 2;
            this.m_buttonCancel.Text = "&Close";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonApply.Enabled = false;
            this.m_buttonApply.Location = new System.Drawing.Point(216, 227);
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.Size = new System.Drawing.Size(75, 23);
            this.m_buttonApply.TabIndex = 3;
            this.m_buttonApply.Text = "&Apply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_customPropertyGrid
            // 
            this.m_customPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_customPropertyGrid.Location = new System.Drawing.Point(12, 12);
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.Size = new System.Drawing.Size(360, 209);
            this.m_customPropertyGrid.TabIndex = 0;
            this.m_customPropertyGrid.PropertyDeleted += new TileMapEditor.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            this.m_customPropertyGrid.PropertyChanged += new TileMapEditor.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // CustomPropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_customPropertyGrid);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "CustomPropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Properties";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonCancel;
        private TileMapEditor.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonApply;
    }
}