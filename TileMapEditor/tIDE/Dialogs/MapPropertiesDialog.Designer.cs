namespace tIDE.Dialogs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPropertiesDialog));
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_customTabControl = new tIDE.Controls.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_labelDescription = new System.Windows.Forms.Label();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_labelId = new System.Windows.Forms.Label();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new tIDE.Controls.CustomPropertyGrid();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.m_tabCustomProperties.SuspendLayout();
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
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
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
            // m_tabImageList
            // 
            this.m_tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tabImageList.ImageStream")));
            this.m_tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tabImageList.Images.SetKeyName(0, "Map.png");
            this.m_tabImageList.Images.SetKeyName(1, "CustomProperties.png");
            // 
            // m_customTabControl
            // 
            this.m_customTabControl.AccessibleDescription = null;
            this.m_customTabControl.AccessibleName = null;
            resources.ApplyResources(this.m_customTabControl, "m_customTabControl");
            this.m_customTabControl.BackgroundImage = null;
            this.m_customTabControl.Controls.Add(this.m_tabGeneral);
            this.m_customTabControl.Controls.Add(this.m_tabCustomProperties);
            this.m_customTabControl.DisplayStyle = tIDE.Controls.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.m_customTabControl.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.m_customTabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.m_customTabControl.DisplayStyleProvider.FocusTrack = false;
            this.m_customTabControl.DisplayStyleProvider.HotTrack = true;
            this.m_customTabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_customTabControl.DisplayStyleProvider.Opacity = 1F;
            this.m_customTabControl.DisplayStyleProvider.Overlap = 7;
            this.m_customTabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.m_customTabControl.DisplayStyleProvider.ShowTabCloser = false;
            this.m_customTabControl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.m_customTabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.m_customTabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.m_customTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.m_customTabControl.Font = null;
            this.m_customTabControl.HotTrack = true;
            this.m_customTabControl.ImageList = this.m_tabImageList;
            this.m_customTabControl.Name = "m_customTabControl";
            this.m_customTabControl.SelectedIndex = 0;
            // 
            // m_tabGeneral
            // 
            this.m_tabGeneral.AccessibleDescription = null;
            this.m_tabGeneral.AccessibleName = null;
            resources.ApplyResources(this.m_tabGeneral, "m_tabGeneral");
            this.m_tabGeneral.BackColor = System.Drawing.Color.Transparent;
            this.m_tabGeneral.BackgroundImage = null;
            this.m_tabGeneral.Controls.Add(this.m_textBoxDescription);
            this.m_tabGeneral.Controls.Add(this.m_labelDescription);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(this.m_labelId);
            this.m_tabGeneral.Font = null;
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.UseVisualStyleBackColor = true;
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.AcceptsReturn = true;
            this.m_textBoxDescription.AccessibleDescription = null;
            this.m_textBoxDescription.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxDescription, "m_textBoxDescription");
            this.m_textBoxDescription.BackgroundImage = null;
            this.m_textBoxDescription.Font = null;
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_labelDescription
            // 
            this.m_labelDescription.AccessibleDescription = null;
            this.m_labelDescription.AccessibleName = null;
            resources.ApplyResources(this.m_labelDescription, "m_labelDescription");
            this.m_labelDescription.Font = null;
            this.m_labelDescription.Name = "m_labelDescription";
            // 
            // m_textBoxId
            // 
            this.m_textBoxId.AccessibleDescription = null;
            this.m_textBoxId.AccessibleName = null;
            resources.ApplyResources(this.m_textBoxId, "m_textBoxId");
            this.m_textBoxId.BackgroundImage = null;
            this.m_textBoxId.Font = null;
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_labelId
            // 
            this.m_labelId.AccessibleDescription = null;
            this.m_labelId.AccessibleName = null;
            resources.ApplyResources(this.m_labelId, "m_labelId");
            this.m_labelId.Font = null;
            this.m_labelId.Name = "m_labelId";
            // 
            // m_tabCustomProperties
            // 
            this.m_tabCustomProperties.AccessibleDescription = null;
            this.m_tabCustomProperties.AccessibleName = null;
            resources.ApplyResources(this.m_tabCustomProperties, "m_tabCustomProperties");
            this.m_tabCustomProperties.BackColor = System.Drawing.Color.Transparent;
            this.m_tabCustomProperties.BackgroundImage = null;
            this.m_tabCustomProperties.Controls.Add(this.m_customPropertyGrid);
            this.m_tabCustomProperties.Font = null;
            this.m_tabCustomProperties.Name = "m_tabCustomProperties";
            this.m_tabCustomProperties.UseVisualStyleBackColor = true;
            // 
            // m_customPropertyGrid
            // 
            this.m_customPropertyGrid.AccessibleDescription = null;
            this.m_customPropertyGrid.AccessibleName = null;
            resources.ApplyResources(this.m_customPropertyGrid, "m_customPropertyGrid");
            this.m_customPropertyGrid.BackgroundImage = null;
            this.m_customPropertyGrid.Font = null;
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.PropertyChanged += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // MapPropertiesDialog
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
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.Font = null;
            this.MinimizeBox = false;
            this.Name = "MapPropertiesDialog";
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
        private tIDE.Controls.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.Label m_labelDescription;
        private System.Windows.Forms.TextBox m_textBoxId;
        private System.Windows.Forms.Label m_labelId;
        private tIDE.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonClose;
        private System.Windows.Forms.ImageList m_tabImageList;
    }
}