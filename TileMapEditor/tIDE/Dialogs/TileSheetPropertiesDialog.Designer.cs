namespace tIDE.Dialogs
{
    partial class TileSheetPropertiesDialog
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
            System.Windows.Forms.Label m_labelTileSize;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileSheetPropertiesDialog));
            System.Windows.Forms.Label m_labelTileSizeBy;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_customTabControl = new tIDE.Controls.CustomTabControl();
            this.m_tabGeneral = new System.Windows.Forms.TabPage();
            this.m_labelImageSource = new System.Windows.Forms.Label();
            this.m_buttonBrowse = new System.Windows.Forms.Button();
            this.m_textBoxImageSource = new System.Windows.Forms.TextBox();
            this.m_textBoxDescription = new System.Windows.Forms.TextBox();
            this.m_labelDescription = new System.Windows.Forms.Label();
            this.m_textBoxId = new System.Windows.Forms.TextBox();
            this.m_labelId = new System.Windows.Forms.Label();
            this.m_tabAlignment = new System.Windows.Forms.TabPage();
            this.m_buttonDoneSwapping = new System.Windows.Forms.Button();
            this.m_buttonSwapTiles = new System.Windows.Forms.Button();
            this.m_groupBoxCustomSettings = new System.Windows.Forms.GroupBox();
            this.m_textBoxTileWidth = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxTileHeight = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxSpacingY = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxTopMargin = new System.Windows.Forms.NumericUpDown();
            this.m_textBoxSpacingX = new System.Windows.Forms.NumericUpDown();
            this.m_groupBoxQuickSettings = new System.Windows.Forms.GroupBox();
            this.m_comboBoxSpacing = new System.Windows.Forms.ComboBox();
            this.m_comboBoxMargin = new System.Windows.Forms.ComboBox();
            this.m_comboBoxTileSize = new System.Windows.Forms.ComboBox();
            this.m_buttonAutoDetect = new System.Windows.Forms.Button();
            this.m_panelImage = new tIDE.Controls.CustomPanel();
            this.m_trackBarZoom = new System.Windows.Forms.TrackBar();
            this.m_labelZoom = new System.Windows.Forms.Label();
            this.m_tabCustomProperties = new System.Windows.Forms.TabPage();
            this.m_customPropertyGrid = new tIDE.Controls.CustomPropertyGrid();
            this.m_noImageSourceMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_duplicateIdMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_tileSizeFixedMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            m_labelTileSize = new System.Windows.Forms.Label();
            m_labelTileSizeBy = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.m_customTabControl.SuspendLayout();
            this.m_tabGeneral.SuspendLayout();
            this.m_tabAlignment.SuspendLayout();
            this.m_groupBoxCustomSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxSpacingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxSpacingX)).BeginInit();
            this.m_groupBoxQuickSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarZoom)).BeginInit();
            this.m_tabCustomProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelTileSize
            // 
            resources.ApplyResources(m_labelTileSize, "m_labelTileSize");
            m_labelTileSize.Name = "m_labelTileSize";
            // 
            // m_labelTileSizeBy
            // 
            resources.ApplyResources(m_labelTileSizeBy, "m_labelTileSizeBy");
            m_labelTileSizeBy.Name = "m_labelTileSizeBy";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // m_buttonOk
            // 
            resources.ApplyResources(this.m_buttonOk, "m_buttonOk");
            this.m_buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonOk.Name = "m_buttonOk";
            this.m_buttonOk.UseVisualStyleBackColor = true;
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
            // 
            // m_buttonCancel
            // 
            resources.ApplyResources(this.m_buttonCancel, "m_buttonCancel");
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_buttonApply
            // 
            resources.ApplyResources(this.m_buttonApply, "m_buttonApply");
            this.m_buttonApply.Name = "m_buttonApply";
            this.m_buttonApply.UseVisualStyleBackColor = true;
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
            // 
            // m_buttonClose
            // 
            resources.ApplyResources(this.m_buttonClose, "m_buttonClose");
            this.m_buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_buttonClose.Name = "m_buttonClose";
            this.m_buttonClose.UseVisualStyleBackColor = true;
            // 
            // m_tabImageList
            // 
            this.m_tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_tabImageList.ImageStream")));
            this.m_tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_tabImageList.Images.SetKeyName(0, "TileSheet.png");
            this.m_tabImageList.Images.SetKeyName(1, "TileSheetAlignment.png");
            this.m_tabImageList.Images.SetKeyName(2, "CustomProperties.png");
            // 
            // m_customTabControl
            // 
            resources.ApplyResources(this.m_customTabControl, "m_customTabControl");
            this.m_customTabControl.Controls.Add(this.m_tabGeneral);
            this.m_customTabControl.Controls.Add(this.m_tabAlignment);
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
            this.m_customTabControl.HotTrack = true;
            this.m_customTabControl.ImageList = this.m_tabImageList;
            this.m_customTabControl.Name = "m_customTabControl";
            this.m_customTabControl.SelectedIndex = 0;
            this.m_customTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.OnSelectingTab);
            // 
            // m_tabGeneral
            // 
            resources.ApplyResources(this.m_tabGeneral, "m_tabGeneral");
            this.m_tabGeneral.BackColor = System.Drawing.Color.Transparent;
            this.m_tabGeneral.Controls.Add(this.m_labelImageSource);
            this.m_tabGeneral.Controls.Add(this.m_buttonBrowse);
            this.m_tabGeneral.Controls.Add(this.m_textBoxImageSource);
            this.m_tabGeneral.Controls.Add(this.m_textBoxDescription);
            this.m_tabGeneral.Controls.Add(this.m_labelDescription);
            this.m_tabGeneral.Controls.Add(this.m_textBoxId);
            this.m_tabGeneral.Controls.Add(this.m_labelId);
            this.m_tabGeneral.Name = "m_tabGeneral";
            this.m_tabGeneral.UseVisualStyleBackColor = true;
            // 
            // m_labelImageSource
            // 
            resources.ApplyResources(this.m_labelImageSource, "m_labelImageSource");
            this.m_labelImageSource.Name = "m_labelImageSource";
            // 
            // m_buttonBrowse
            // 
            resources.ApplyResources(this.m_buttonBrowse, "m_buttonBrowse");
            this.m_buttonBrowse.Name = "m_buttonBrowse";
            this.m_buttonBrowse.UseVisualStyleBackColor = true;
            this.m_buttonBrowse.Click += new System.EventHandler(this.OnBrowse);
            // 
            // m_textBoxImageSource
            // 
            resources.ApplyResources(this.m_textBoxImageSource, "m_textBoxImageSource");
            this.m_textBoxImageSource.Name = "m_textBoxImageSource";
            this.m_textBoxImageSource.ReadOnly = true;
            this.m_textBoxImageSource.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_textBoxDescription
            // 
            this.m_textBoxDescription.AcceptsReturn = true;
            resources.ApplyResources(this.m_textBoxDescription, "m_textBoxDescription");
            this.m_textBoxDescription.Name = "m_textBoxDescription";
            this.m_textBoxDescription.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_labelDescription
            // 
            resources.ApplyResources(this.m_labelDescription, "m_labelDescription");
            this.m_labelDescription.Name = "m_labelDescription";
            // 
            // m_textBoxId
            // 
            resources.ApplyResources(this.m_textBoxId, "m_textBoxId");
            this.m_textBoxId.Name = "m_textBoxId";
            this.m_textBoxId.TextChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // m_labelId
            // 
            resources.ApplyResources(this.m_labelId, "m_labelId");
            this.m_labelId.Name = "m_labelId";
            // 
            // m_tabAlignment
            // 
            resources.ApplyResources(this.m_tabAlignment, "m_tabAlignment");
            this.m_tabAlignment.BackColor = System.Drawing.Color.Transparent;
            this.m_tabAlignment.Controls.Add(this.m_buttonDoneSwapping);
            this.m_tabAlignment.Controls.Add(this.m_buttonSwapTiles);
            this.m_tabAlignment.Controls.Add(this.m_groupBoxCustomSettings);
            this.m_tabAlignment.Controls.Add(this.m_groupBoxQuickSettings);
            this.m_tabAlignment.Controls.Add(this.m_panelImage);
            this.m_tabAlignment.Controls.Add(this.m_trackBarZoom);
            this.m_tabAlignment.Controls.Add(this.m_labelZoom);
            this.m_tabAlignment.Name = "m_tabAlignment";
            this.m_tabAlignment.UseVisualStyleBackColor = true;
            // 
            // m_buttonDoneSwapping
            // 
            resources.ApplyResources(this.m_buttonDoneSwapping, "m_buttonDoneSwapping");
            this.m_buttonDoneSwapping.Name = "m_buttonDoneSwapping";
            this.m_buttonDoneSwapping.UseVisualStyleBackColor = true;
            this.m_buttonDoneSwapping.Click += new System.EventHandler(this.OnDoneSwapping);
            // 
            // m_buttonSwapTiles
            // 
            resources.ApplyResources(this.m_buttonSwapTiles, "m_buttonSwapTiles");
            this.m_buttonSwapTiles.Name = "m_buttonSwapTiles";
            this.m_buttonSwapTiles.UseVisualStyleBackColor = true;
            this.m_buttonSwapTiles.Click += new System.EventHandler(this.OnSwapTiles);
            // 
            // m_groupBoxCustomSettings
            // 
            resources.ApplyResources(this.m_groupBoxCustomSettings, "m_groupBoxCustomSettings");
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxTileWidth);
            this.m_groupBoxCustomSettings.Controls.Add(m_labelTileSize);
            this.m_groupBoxCustomSettings.Controls.Add(m_labelTileSizeBy);
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxTileHeight);
            this.m_groupBoxCustomSettings.Controls.Add(label2);
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxLeftMargin);
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxSpacingY);
            this.m_groupBoxCustomSettings.Controls.Add(label1);
            this.m_groupBoxCustomSettings.Controls.Add(label3);
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxTopMargin);
            this.m_groupBoxCustomSettings.Controls.Add(this.m_textBoxSpacingX);
            this.m_groupBoxCustomSettings.Controls.Add(label4);
            this.m_groupBoxCustomSettings.Name = "m_groupBoxCustomSettings";
            this.m_groupBoxCustomSettings.TabStop = false;
            // 
            // m_textBoxTileWidth
            // 
            resources.ApplyResources(this.m_textBoxTileWidth, "m_textBoxTileWidth");
            this.m_textBoxTileWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.m_textBoxTileWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_textBoxTileWidth.Name = "m_textBoxTileWidth";
            this.m_textBoxTileWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_textBoxTileWidth.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_textBoxTileHeight
            // 
            resources.ApplyResources(this.m_textBoxTileHeight, "m_textBoxTileHeight");
            this.m_textBoxTileHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.m_textBoxTileHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_textBoxTileHeight.Name = "m_textBoxTileHeight";
            this.m_textBoxTileHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.m_textBoxTileHeight.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_textBoxLeftMargin
            // 
            resources.ApplyResources(this.m_textBoxLeftMargin, "m_textBoxLeftMargin");
            this.m_textBoxLeftMargin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_textBoxLeftMargin.Name = "m_textBoxLeftMargin";
            this.m_textBoxLeftMargin.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_textBoxSpacingY
            // 
            resources.ApplyResources(this.m_textBoxSpacingY, "m_textBoxSpacingY");
            this.m_textBoxSpacingY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_textBoxSpacingY.Name = "m_textBoxSpacingY";
            this.m_textBoxSpacingY.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_textBoxTopMargin
            // 
            resources.ApplyResources(this.m_textBoxTopMargin, "m_textBoxTopMargin");
            this.m_textBoxTopMargin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_textBoxTopMargin.Name = "m_textBoxTopMargin";
            this.m_textBoxTopMargin.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_textBoxSpacingX
            // 
            resources.ApplyResources(this.m_textBoxSpacingX, "m_textBoxSpacingX");
            this.m_textBoxSpacingX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.m_textBoxSpacingX.Name = "m_textBoxSpacingX";
            this.m_textBoxSpacingX.ValueChanged += new System.EventHandler(this.OnUpdateAlignment);
            // 
            // m_groupBoxQuickSettings
            // 
            resources.ApplyResources(this.m_groupBoxQuickSettings, "m_groupBoxQuickSettings");
            this.m_groupBoxQuickSettings.Controls.Add(this.m_comboBoxSpacing);
            this.m_groupBoxQuickSettings.Controls.Add(label7);
            this.m_groupBoxQuickSettings.Controls.Add(this.m_comboBoxMargin);
            this.m_groupBoxQuickSettings.Controls.Add(label6);
            this.m_groupBoxQuickSettings.Controls.Add(this.m_comboBoxTileSize);
            this.m_groupBoxQuickSettings.Controls.Add(label5);
            this.m_groupBoxQuickSettings.Controls.Add(this.m_buttonAutoDetect);
            this.m_groupBoxQuickSettings.Name = "m_groupBoxQuickSettings";
            this.m_groupBoxQuickSettings.TabStop = false;
            // 
            // m_comboBoxSpacing
            // 
            resources.ApplyResources(this.m_comboBoxSpacing, "m_comboBoxSpacing");
            this.m_comboBoxSpacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxSpacing.FormattingEnabled = true;
            this.m_comboBoxSpacing.Items.AddRange(new object[] {
            resources.GetString("m_comboBoxSpacing.Items"),
            resources.GetString("m_comboBoxSpacing.Items1"),
            resources.GetString("m_comboBoxSpacing.Items2"),
            resources.GetString("m_comboBoxSpacing.Items3"),
            resources.GetString("m_comboBoxSpacing.Items4"),
            resources.GetString("m_comboBoxSpacing.Items5")});
            this.m_comboBoxSpacing.Name = "m_comboBoxSpacing";
            this.m_comboBoxSpacing.SelectedIndexChanged += new System.EventHandler(this.OnSpacingCombo);
            // 
            // m_comboBoxMargin
            // 
            resources.ApplyResources(this.m_comboBoxMargin, "m_comboBoxMargin");
            this.m_comboBoxMargin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxMargin.FormattingEnabled = true;
            this.m_comboBoxMargin.Items.AddRange(new object[] {
            resources.GetString("m_comboBoxMargin.Items"),
            resources.GetString("m_comboBoxMargin.Items1"),
            resources.GetString("m_comboBoxMargin.Items2"),
            resources.GetString("m_comboBoxMargin.Items3"),
            resources.GetString("m_comboBoxMargin.Items4"),
            resources.GetString("m_comboBoxMargin.Items5")});
            this.m_comboBoxMargin.Name = "m_comboBoxMargin";
            this.m_comboBoxMargin.SelectedIndexChanged += new System.EventHandler(this.OnMarginCombo);
            // 
            // m_comboBoxTileSize
            // 
            resources.ApplyResources(this.m_comboBoxTileSize, "m_comboBoxTileSize");
            this.m_comboBoxTileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTileSize.FormattingEnabled = true;
            this.m_comboBoxTileSize.Items.AddRange(new object[] {
            resources.GetString("m_comboBoxTileSize.Items"),
            resources.GetString("m_comboBoxTileSize.Items1"),
            resources.GetString("m_comboBoxTileSize.Items2"),
            resources.GetString("m_comboBoxTileSize.Items3"),
            resources.GetString("m_comboBoxTileSize.Items4"),
            resources.GetString("m_comboBoxTileSize.Items5"),
            resources.GetString("m_comboBoxTileSize.Items6"),
            resources.GetString("m_comboBoxTileSize.Items7")});
            this.m_comboBoxTileSize.Name = "m_comboBoxTileSize";
            this.m_comboBoxTileSize.SelectedIndexChanged += new System.EventHandler(this.OnTileSizeCombo);
            // 
            // m_buttonAutoDetect
            // 
            resources.ApplyResources(this.m_buttonAutoDetect, "m_buttonAutoDetect");
            this.m_buttonAutoDetect.Name = "m_buttonAutoDetect";
            this.m_buttonAutoDetect.UseVisualStyleBackColor = true;
            this.m_buttonAutoDetect.Click += new System.EventHandler(this.OnAutoDetect);
            // 
            // m_panelImage
            // 
            resources.ApplyResources(this.m_panelImage, "m_panelImage");
            this.m_panelImage.BackgroundImage = global::tIDE.Properties.Resources.ImageBackground;
            this.m_panelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_panelImage.Name = "m_panelImage";
            this.m_panelImage.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPreviewPaint);
            this.m_panelImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPreviewMouseDown);
            this.m_panelImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPreviewMouseMove);
            this.m_panelImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnPreviewMouseUp);
            // 
            // m_trackBarZoom
            // 
            resources.ApplyResources(this.m_trackBarZoom, "m_trackBarZoom");
            this.m_trackBarZoom.Minimum = 1;
            this.m_trackBarZoom.Name = "m_trackBarZoom";
            this.m_trackBarZoom.Value = 1;
            this.m_trackBarZoom.Scroll += new System.EventHandler(this.OnZoom);
            // 
            // m_labelZoom
            // 
            resources.ApplyResources(this.m_labelZoom, "m_labelZoom");
            this.m_labelZoom.Name = "m_labelZoom";
            // 
            // m_tabCustomProperties
            // 
            resources.ApplyResources(this.m_tabCustomProperties, "m_tabCustomProperties");
            this.m_tabCustomProperties.BackColor = System.Drawing.Color.Transparent;
            this.m_tabCustomProperties.Controls.Add(this.m_customPropertyGrid);
            this.m_tabCustomProperties.Name = "m_tabCustomProperties";
            this.m_tabCustomProperties.UseVisualStyleBackColor = true;
            // 
            // m_customPropertyGrid
            // 
            resources.ApplyResources(this.m_customPropertyGrid, "m_customPropertyGrid");
            this.m_customPropertyGrid.Name = "m_customPropertyGrid";
            this.m_customPropertyGrid.PropertyChanged += new tIDE.Controls.CustomPropertyEventHandler(this.OnPropertyChangedOrDeleted);
            // 
            // m_noImageSourceMessageBox
            // 
            resources.ApplyResources(this.m_noImageSourceMessageBox, "m_noImageSourceMessageBox");
            this.m_noImageSourceMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_noImageSourceMessageBox.Owner = this;
            // 
            // m_duplicateIdMessageBox
            // 
            resources.ApplyResources(this.m_duplicateIdMessageBox, "m_duplicateIdMessageBox");
            this.m_duplicateIdMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_duplicateIdMessageBox.Owner = this;
            // 
            // m_tileSizeFixedMessageBox
            // 
            resources.ApplyResources(this.m_tileSizeFixedMessageBox, "m_tileSizeFixedMessageBox");
            this.m_tileSizeFixedMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_tileSizeFixedMessageBox.Owner = this;
            // 
            // TileSheetPropertiesDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.Controls.Add(this.m_buttonClose);
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_customTabControl);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonOk);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "TileSheetPropertiesDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.m_customTabControl.ResumeLayout(false);
            this.m_tabGeneral.ResumeLayout(false);
            this.m_tabGeneral.PerformLayout();
            this.m_tabAlignment.ResumeLayout(false);
            this.m_tabAlignment.PerformLayout();
            this.m_groupBoxCustomSettings.ResumeLayout(false);
            this.m_groupBoxCustomSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxSpacingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_textBoxSpacingX)).EndInit();
            this.m_groupBoxQuickSettings.ResumeLayout(false);
            this.m_groupBoxQuickSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBarZoom)).EndInit();
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
        private System.Windows.Forms.TabPage m_tabAlignment;
        private System.Windows.Forms.Label m_labelImageSource;
        private System.Windows.Forms.Button m_buttonBrowse;
        private System.Windows.Forms.NumericUpDown m_textBoxTileHeight;
        private System.Windows.Forms.NumericUpDown m_textBoxTileWidth;
        private System.Windows.Forms.NumericUpDown m_textBoxSpacingY;
        private System.Windows.Forms.NumericUpDown m_textBoxSpacingX;
        private System.Windows.Forms.NumericUpDown m_textBoxTopMargin;
        private System.Windows.Forms.NumericUpDown m_textBoxLeftMargin;
        private tIDE.Controls.CustomPanel m_panelImage;
        private System.Windows.Forms.TextBox m_textBoxImageSource;
        private System.Windows.Forms.Label m_labelZoom;
        private System.Windows.Forms.TrackBar m_trackBarZoom;
        private tIDE.Controls.CustomPropertyGrid m_customPropertyGrid;
        private System.Windows.Forms.Button m_buttonAutoDetect;
        private System.Windows.Forms.GroupBox m_groupBoxCustomSettings;
        private System.Windows.Forms.GroupBox m_groupBoxQuickSettings;
        private System.Windows.Forms.ComboBox m_comboBoxMargin;
        private System.Windows.Forms.ComboBox m_comboBoxTileSize;
        private System.Windows.Forms.ComboBox m_comboBoxSpacing;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonSwapTiles;
        private System.Windows.Forms.Button m_buttonClose;
        private System.Windows.Forms.Button m_buttonDoneSwapping;
        private tIDE.Controls.CustomMessageBox m_noImageSourceMessageBox;
        private tIDE.Controls.CustomMessageBox m_duplicateIdMessageBox;
        private tIDE.Controls.CustomMessageBox m_tileSizeFixedMessageBox;
        private System.Windows.Forms.ImageList m_tabImageList;
    }
}