namespace tIDE.Dialogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerOffsetDialog));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.m_lblLayerId = new System.Windows.Forms.Label();
            this.m_lblLayerSize = new System.Windows.Forms.Label();
            this.m_nudOffsetHorizontal = new System.Windows.Forms.NumericUpDown();
            this.m_nudOffsetVertical = new System.Windows.Forms.NumericUpDown();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_chkWrapHorizontal = new System.Windows.Forms.CheckBox();
            this.m_chkWrapVertical = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudOffsetHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudOffsetVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Font = null;
            label1.Name = "label1";
            // 
            // label2
            // 
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.Font = null;
            label2.Name = "label2";
            // 
            // label3
            // 
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Font = null;
            label3.Name = "label3";
            // 
            // label4
            // 
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.Font = null;
            label4.Name = "label4";
            // 
            // m_lblLayerId
            // 
            this.m_lblLayerId.AccessibleDescription = null;
            this.m_lblLayerId.AccessibleName = null;
            resources.ApplyResources(this.m_lblLayerId, "m_lblLayerId");
            this.m_lblLayerId.Font = null;
            this.m_lblLayerId.Name = "m_lblLayerId";
            // 
            // m_lblLayerSize
            // 
            this.m_lblLayerSize.AccessibleDescription = null;
            this.m_lblLayerSize.AccessibleName = null;
            resources.ApplyResources(this.m_lblLayerSize, "m_lblLayerSize");
            this.m_lblLayerSize.Font = null;
            this.m_lblLayerSize.Name = "m_lblLayerSize";
            // 
            // m_nudOffsetHorizontal
            // 
            this.m_nudOffsetHorizontal.AccessibleDescription = null;
            this.m_nudOffsetHorizontal.AccessibleName = null;
            resources.ApplyResources(this.m_nudOffsetHorizontal, "m_nudOffsetHorizontal");
            this.m_nudOffsetHorizontal.Font = null;
            this.m_nudOffsetHorizontal.Name = "m_nudOffsetHorizontal";
            this.m_nudOffsetHorizontal.ValueChanged += new System.EventHandler(this.OnParametersChanged);
            // 
            // m_nudOffsetVertical
            // 
            this.m_nudOffsetVertical.AccessibleDescription = null;
            this.m_nudOffsetVertical.AccessibleName = null;
            resources.ApplyResources(this.m_nudOffsetVertical, "m_nudOffsetVertical");
            this.m_nudOffsetVertical.Font = null;
            this.m_nudOffsetVertical.Name = "m_nudOffsetVertical";
            this.m_nudOffsetVertical.ValueChanged += new System.EventHandler(this.OnParametersChanged);
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
            // m_chkWrapHorizontal
            // 
            this.m_chkWrapHorizontal.AccessibleDescription = null;
            this.m_chkWrapHorizontal.AccessibleName = null;
            resources.ApplyResources(this.m_chkWrapHorizontal, "m_chkWrapHorizontal");
            this.m_chkWrapHorizontal.BackgroundImage = null;
            this.m_chkWrapHorizontal.Font = null;
            this.m_chkWrapHorizontal.Name = "m_chkWrapHorizontal";
            this.m_chkWrapHorizontal.UseVisualStyleBackColor = true;
            this.m_chkWrapHorizontal.CheckedChanged += new System.EventHandler(this.OnParametersChanged);
            // 
            // m_chkWrapVertical
            // 
            this.m_chkWrapVertical.AccessibleDescription = null;
            this.m_chkWrapVertical.AccessibleName = null;
            resources.ApplyResources(this.m_chkWrapVertical, "m_chkWrapVertical");
            this.m_chkWrapVertical.BackgroundImage = null;
            this.m_chkWrapVertical.Font = null;
            this.m_chkWrapVertical.Name = "m_chkWrapVertical";
            this.m_chkWrapVertical.UseVisualStyleBackColor = true;
            this.m_chkWrapVertical.CheckedChanged += new System.EventHandler(this.OnParametersChanged);
            // 
            // LayerOffsetDialog
            // 
            this.AcceptButton = this.m_btnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_btnCancel;
            this.Controls.Add(this.m_chkWrapVertical);
            this.Controls.Add(this.m_chkWrapHorizontal);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_nudOffsetVertical);
            this.Controls.Add(label4);
            this.Controls.Add(this.m_nudOffsetHorizontal);
            this.Controls.Add(label3);
            this.Controls.Add(this.m_lblLayerSize);
            this.Controls.Add(label2);
            this.Controls.Add(this.m_lblLayerId);
            this.Controls.Add(label1);
            this.Font = null;
            this.Name = "LayerOffsetDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.OnDialogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_nudOffsetHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudOffsetVertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown m_nudOffsetHorizontal;
        private System.Windows.Forms.NumericUpDown m_nudOffsetVertical;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.CheckBox m_chkWrapHorizontal;
        private System.Windows.Forms.CheckBox m_chkWrapVertical;
        private System.Windows.Forms.Label m_lblLayerId;
        private System.Windows.Forms.Label m_lblLayerSize;
    }
}