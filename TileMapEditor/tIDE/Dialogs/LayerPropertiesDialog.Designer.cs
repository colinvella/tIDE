namespace tIDE.Dialogs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerPropertiesDialog));
            System.Windows.Forms.Label m_labelDescription;
            System.Windows.Forms.Label m_labelId;
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_customTabControl = new tIDE.Controls.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_alignmentButton = new tIDE.Controls.AlignmentButton();
            this.m_lblAlignment = new System.Windows.Forms.Label();
            this.m_checkBoxVisible = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_numericTileHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.m_numericTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_numericLayerHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.m_numericLayerWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new tIDE.Controls.CustomPropertyGrid();
            this.m_duplicateIdMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            m_labelDescription = new System.Windows.Forms.Label();
            m_labelId = new System.Windows.Forms.Label();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericLayerWidth)).BeginInit();
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
            this.m_tabImageList.Images.SetKeyName(0, "Layer.png");
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
            this.m_tabGeneral.Controls.Add(this.m_alignmentButton);
            this.m_tabGeneral.Controls.Add(this.m_lblAlignment);
            this.m_tabGeneral.Controls.Add(this.m_checkBoxVisible);
            this.m_tabGeneral.Controls.Add(this.label4);
            this.m_tabGeneral.Controls.Add(this.m_numericTileHeight);
            this.m_tabGeneral.Controls.Add(this.label5);
            this.m_tabGeneral.Controls.Add(this.m_numericTileWidth);
            this.m_tabGeneral.Controls.Add(this.label6);
            this.m_tabGeneral.Controls.Add(this.label3);
            this.m_tabGeneral.Controls.Add(this.m_numericLayerHeight);
            this.m_tabGeneral.Controls.Add(this.label2);
            this.m_tabGeneral.Controls.Add(this.m_numericLayerWidth);
            this.m_tabGeneral.Controls.Add(this.label1);
            this.m_tabGeneral.Controls.Add(this.m_textBoxDescription);
            this.m_tabGeneral.Controls.Add(m_labelDescription);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(m_labelId);
            this.m_tabGeneral.Font = null;
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.UseVisualStyleBackColor = true;
            // 
            // m_alignmentButton
            // 
            this.m_alignmentButton.AccessibleDescription = null;
            this.m_alignmentButton.AccessibleName = null;
            this.m_alignmentButton.Alignment = tIDE.Controls.Alignment.Centre;
            resources.ApplyResources(this.m_alignmentButton, "m_alignmentButton");
            this.m_alignmentButton.BackgroundImage = null;
            this.m_alignmentButton.Font = null;
            this.m_alignmentButton.Image = global::tIDE.Properties.Resources.Layer;
            this.m_alignmentButton.MaximumSize = new System.Drawing.Size(66, 66);
            this.m_alignmentButton.MinimumSize = new System.Drawing.Size(66, 66);
            this.m_alignmentButton.Name = "m_alignmentButton";
            // 
            // m_lblAlignment
            // 
            this.m_lblAlignment.AccessibleDescription = null;
            this.m_lblAlignment.AccessibleName = null;
            resources.ApplyResources(this.m_lblAlignment, "m_lblAlignment");
            this.m_lblAlignment.Font = null;
            this.m_lblAlignment.Name = "m_lblAlignment";
            // 
            // m_checkBoxVisible
            // 
            this.m_checkBoxVisible.AccessibleDescription = null;
            this.m_checkBoxVisible.AccessibleName = null;
            resources.ApplyResources(this.m_checkBoxVisible, "m_checkBoxVisible");
            this.m_checkBoxVisible.BackgroundImage = null;
            this.m_checkBoxVisible.Font = null;
            this.m_checkBoxVisible.Name = "m_checkBoxVisible";
            this.m_checkBoxVisible.UseVisualStyleBackColor = true;
            this.m_checkBoxVisible.CheckedChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // m_numericTileHeight
            // 
            this.m_numericTileHeight.AccessibleDescription = null;
            this.m_numericTileHeight.AccessibleName = null;
            resources.ApplyResources(this.m_numericTileHeight, "m_numericTileHeight");
            this.m_numericTileHeight.Font = null;
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
            this.m_numericTileHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericTileHeight.ValueChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // m_numericTileWidth
            // 
            this.m_numericTileWidth.AccessibleDescription = null;
            this.m_numericTileWidth.AccessibleName = null;
            resources.ApplyResources(this.m_numericTileWidth, "m_numericTileWidth");
            this.m_numericTileWidth.Font = null;
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
            this.m_numericTileWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_numericTileWidth.ValueChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // m_numericLayerHeight
            // 
            this.m_numericLayerHeight.AccessibleDescription = null;
            this.m_numericLayerHeight.AccessibleName = null;
            resources.ApplyResources(this.m_numericLayerHeight, "m_numericLayerHeight");
            this.m_numericLayerHeight.Font = null;
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
            this.m_numericLayerHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericLayerHeight.ValueChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // m_numericLayerWidth
            // 
            this.m_numericLayerWidth.AccessibleDescription = null;
            this.m_numericLayerWidth.AccessibleName = null;
            resources.ApplyResources(this.m_numericLayerWidth, "m_numericLayerWidth");
            this.m_numericLayerWidth.Font = null;
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
            this.m_numericLayerWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numericLayerWidth.ValueChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
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
            m_labelDescription.AccessibleDescription = null;
            m_labelDescription.AccessibleName = null;
            resources.ApplyResources(m_labelDescription, "m_labelDescription");
            m_labelDescription.Font = null;
            m_labelDescription.Name = "m_labelDescription";
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
            m_labelId.AccessibleDescription = null;
            m_labelId.AccessibleName = null;
            resources.ApplyResources(m_labelId, "m_labelId");
            m_labelId.Font = null;
            m_labelId.Name = "m_labelId";
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
            this.m_customPropertyGrid.PropertyDeleted += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            this.m_customPropertyGrid.PropertyChanged += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // m_duplicateIdMessageBox
            // 
            resources.ApplyResources(this.m_duplicateIdMessageBox, "m_duplicateIdMessageBox");
            this.m_duplicateIdMessageBox.HelpFilePath = null;
            this.m_duplicateIdMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_duplicateIdMessageBox.Owner = this;
            // 
            // LayerPropertiesDialog
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
            this.DoubleBuffered = true;
            this.Font = null;
            this.MinimizeBox = false;
            this.Name = "LayerPropertiesDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
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
        private tIDE.Controls.CustomTabControl m_customTabControl;
        private System.Windows.Forms.TabPage m_tabGeneral;
        private System.Windows.Forms.TabPage m_tabCustomProperties;
        private System.Windows.Forms.TextBox m_textBoxDescription;
        private System.Windows.Forms.TextBox m_textBoxId;
        private tIDE.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.NumericUpDown m_numericLayerHeight;
        private System.Windows.Forms.NumericUpDown m_numericLayerWidth;
        private System.Windows.Forms.NumericUpDown m_numericTileHeight;
        private System.Windows.Forms.NumericUpDown m_numericTileWidth;
        private System.Windows.Forms.CheckBox m_checkBoxVisible;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonClose;
        private tIDE.Controls.CustomMessageBox m_duplicateIdMessageBox;
        private System.Windows.Forms.ImageList m_tabImageList;
        private System.Windows.Forms.Label m_lblAlignment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private tIDE.Controls.AlignmentButton m_alignmentButton;
    }
}