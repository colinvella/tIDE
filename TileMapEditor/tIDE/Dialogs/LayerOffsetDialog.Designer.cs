namespace TileMapEditor.Dialogs
{
    partial class LayerOffsetDialog
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label m_lblLayerId;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label m_lblLayerSize;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerOffsetDialog));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_chkWrapHorizontal = new System.Windows.Forms.CheckBox();
            this.m_chkWrapVertical = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            m_lblLayerId = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            m_lblLayerSize = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 0;
            label1.Text = "Layer ID";
            // 
            // m_lblLayerId
            // 
            m_lblLayerId.AutoSize = true;
            m_lblLayerId.Location = new System.Drawing.Point(65, 14);
            m_lblLayerId.Name = "m_lblLayerId";
            m_lblLayerId.Size = new System.Drawing.Size(46, 13);
            m_lblLayerId.TabIndex = 1;
            m_lblLayerId.Text = "(layer id)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 13);
            label2.TabIndex = 2;
            label2.Text = "Size";
            // 
            // m_lblLayerSize
            // 
            m_lblLayerSize.AutoSize = true;
            m_lblLayerSize.Location = new System.Drawing.Point(65, 40);
            m_lblLayerSize.Name = "m_lblLayerSize";
            m_lblLayerSize.Size = new System.Drawing.Size(56, 13);
            m_lblLayerSize.TabIndex = 3;
            m_lblLayerSize.Text = "(layer size)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 67);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 13);
            label3.TabIndex = 4;
            label3.Text = "Horizontal Offset";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 93);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 13);
            label4.TabIndex = 6;
            label4.Text = "Vertical Offset";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(148, 65);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(148, 91);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_btnOk
            // 
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Enabled = false;
            this.m_btnOk.Location = new System.Drawing.Point(12, 183);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 8;
            this.m_btnOk.Text = "&OK";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(153, 183);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 9;
            this.m_btnCancel.Text = "&Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_chkWrapHorizontal
            // 
            this.m_chkWrapHorizontal.AutoSize = true;
            this.m_chkWrapHorizontal.Location = new System.Drawing.Point(12, 118);
            this.m_chkWrapHorizontal.Name = "m_chkWrapHorizontal";
            this.m_chkWrapHorizontal.Size = new System.Drawing.Size(132, 17);
            this.m_chkWrapHorizontal.TabIndex = 10;
            this.m_chkWrapHorizontal.Text = "Wrap layer horizontally";
            this.m_chkWrapHorizontal.UseVisualStyleBackColor = true;
            // 
            // m_chkWrapVertical
            // 
            this.m_chkWrapVertical.AutoSize = true;
            this.m_chkWrapVertical.Location = new System.Drawing.Point(12, 141);
            this.m_chkWrapVertical.Name = "m_chkWrapVertical";
            this.m_chkWrapVertical.Size = new System.Drawing.Size(121, 17);
            this.m_chkWrapVertical.TabIndex = 11;
            this.m_chkWrapVertical.Text = "Wrap layer vertically";
            this.m_chkWrapVertical.UseVisualStyleBackColor = true;
            // 
            // LayerOffsetDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 218);
            this.Controls.Add(this.m_chkWrapVertical);
            this.Controls.Add(this.m_chkWrapHorizontal);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(label3);
            this.Controls.Add(m_lblLayerSize);
            this.Controls.Add(label2);
            this.Controls.Add(m_lblLayerId);
            this.Controls.Add(label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(256, 256);
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "LayerOffsetDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Offsetting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.CheckBox m_chkWrapHorizontal;
        private System.Windows.Forms.CheckBox m_chkWrapVertical;
    }
}