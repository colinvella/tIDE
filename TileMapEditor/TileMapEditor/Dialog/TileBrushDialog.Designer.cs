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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileBrushDialog));
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_applyButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.Location = new System.Drawing.Point(335, 377);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(75, 23);
            this.m_okButton.TabIndex = 1;
            this.m_okButton.Text = "&OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_applyButton
            // 
            this.m_applyButton.Location = new System.Drawing.Point(416, 377);
            this.m_applyButton.Name = "m_applyButton";
            this.m_applyButton.Size = new System.Drawing.Size(75, 23);
            this.m_applyButton.TabIndex = 2;
            this.m_applyButton.Text = "&Apply";
            this.m_applyButton.UseVisualStyleBackColor = true;
            this.m_applyButton.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(497, 377);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(75, 23);
            this.m_cancelButton.TabIndex = 3;
            this.m_cancelButton.Text = "&Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(12, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(560, 358);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // TileBrushDialog
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_applyButton);
            this.Controls.Add(this.m_okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileBrushDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Tile Brushes";
            this.Load += new System.EventHandler(this.TileBrushDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_applyButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.ListView listView1;
    }
}