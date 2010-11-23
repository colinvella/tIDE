namespace tIDE.Dialogs
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
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_customPropertyGrid = new tIDE.Controls.CustomPropertyGrid();
            this.SuspendLayout();
            // 
            // m_buttonOk
            // 
            this.m_buttonOk.AccessibleDescription = null;
            this.m_buttonOk.AccessibleName = null;
            resources.ApplyResources(this.m_buttonOk, "m_buttonOk");
            this.m_buttonOk.BackgroundImage = null;
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Font = null;
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.AccessibleDescription = null;
            this.m_buttonCancel.AccessibleName = null;
            resources.ApplyResources(this.m_buttonCancel, "m_buttonCancel");
            this.m_buttonCancel.BackgroundImage = null;
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Font = null;
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            this.m_buttonApply.AccessibleDescription = null;
            this.m_buttonApply.AccessibleName = null;
            resources.ApplyResources(this.m_buttonApply, "m_buttonApply");
            this.m_buttonApply.BackgroundImage = null;
            this.m_buttonApply.Font = null;
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_buttonClose
            // 
            this.m_buttonClose.AccessibleDescription = null;
            this.m_buttonClose.AccessibleName = null;
            resources.ApplyResources(this.m_buttonClose, "m_buttonClose");
            this.m_buttonClose.BackgroundImage = null;
            this.m_buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonClose.Font = null;
            this.m_buttonClose.Name = "m_buttonClose";
            this.m_buttonClose.UseVisualStyleBackColor = true;
            // 
            // m_customPropertyGrid
            // 
            this.m_customPropertyGrid.AccessibleDescription = null;
            this.m_customPropertyGrid.AccessibleName = null;
            resources.ApplyResources(this.m_customPropertyGrid, "m_customPropertyGrid");
            this.m_customPropertyGrid.BackgroundImage = null;
            this.m_customPropertyGrid.Font = null;
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.PropertyDeleted += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            this.m_customPropertyGrid.PropertyChanged += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // CustomPropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_buttonCancel;
            this.Controls.Add(this.m_buttonClose);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_customPropertyGrid);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.Font = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPropertiesDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonCancel;
        private tIDE.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonClose;
    }
}