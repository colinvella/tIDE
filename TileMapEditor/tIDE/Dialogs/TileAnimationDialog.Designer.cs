namespace TileMapEditor.Dialogs
{
    partial class TileAnimationDialog
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
            System.Windows.Forms.Label m_frameIntervalLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileAnimationDialog));
            System.Windows.Forms.SplitContainer m_splitContainerOuter;
            System.Windows.Forms.SplitContainer m_splitContainerInner;
            System.Windows.Forms.ToolStripSeparator m_menuItemSeparator;
            TileMapEditor.Controls.CustomPanel m_customPanel;
            this.m_tilePicker = new TileMapEditor.Controls.TilePicker();
            this.m_previewPanel = new TileMapEditor.Controls.CustomPanel();
            this.m_animationListView = new TileMapEditor.Controls.CustomListView();
            this.m_frameContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_framePropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_frameDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_imageListAnimation = new System.Windows.Forms.ImageList(this.components);
            this.m_buttonOk = new System.Windows.Forms.Button();
            this.m_buttonApply = new System.Windows.Forms.Button();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_frameIntervalTextbox = new System.Windows.Forms.NumericUpDown();
            this.m_animationTimer = new System.Windows.Forms.Timer(this.components);
            this.m_buttonClose = new System.Windows.Forms.Button();
            this.m_tileSizeMessageBox = new TileMapEditor.Controls.CustomMessageBox(this.components);
            m_frameIntervalLabel = new System.Windows.Forms.Label();
            m_splitContainerOuter = new System.Windows.Forms.SplitContainer();
            m_splitContainerInner = new System.Windows.Forms.SplitContainer();
            m_menuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            m_customPanel = new TileMapEditor.Controls.CustomPanel();
            m_splitContainerOuter.Panel1.SuspendLayout();
            m_splitContainerOuter.Panel2.SuspendLayout();
            m_splitContainerOuter.SuspendLayout();
            m_splitContainerInner.Panel1.SuspendLayout();
            m_splitContainerInner.Panel2.SuspendLayout();
            m_splitContainerInner.SuspendLayout();
            this.m_frameContextMenuStrip.SuspendLayout();
            m_customPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_frameIntervalTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // m_frameIntervalLabel
            // 
            m_frameIntervalLabel.AccessibleDescription = null;
            m_frameIntervalLabel.AccessibleName = null;
            resources.ApplyResources(m_frameIntervalLabel, "m_frameIntervalLabel");
            m_frameIntervalLabel.Font = null;
            m_frameIntervalLabel.Name = "m_frameIntervalLabel";
            // 
            // m_splitContainerOuter
            // 
            m_splitContainerOuter.AccessibleDescription = null;
            m_splitContainerOuter.AccessibleName = null;
            resources.ApplyResources(m_splitContainerOuter, "m_splitContainerOuter");
            m_splitContainerOuter.BackgroundImage = null;
            m_splitContainerOuter.Font = null;
            m_splitContainerOuter.Name = "m_splitContainerOuter";
            // 
            // m_splitContainerOuter.Panel1
            // 
            m_splitContainerOuter.Panel1.AccessibleDescription = null;
            m_splitContainerOuter.Panel1.AccessibleName = null;
            resources.ApplyResources(m_splitContainerOuter.Panel1, "m_splitContainerOuter.Panel1");
            m_splitContainerOuter.Panel1.BackgroundImage = null;
            m_splitContainerOuter.Panel1.Controls.Add(this.m_tilePicker);
            m_splitContainerOuter.Panel1.Font = null;
            // 
            // m_splitContainerOuter.Panel2
            // 
            m_splitContainerOuter.Panel2.AccessibleDescription = null;
            m_splitContainerOuter.Panel2.AccessibleName = null;
            resources.ApplyResources(m_splitContainerOuter.Panel2, "m_splitContainerOuter.Panel2");
            m_splitContainerOuter.Panel2.BackgroundImage = null;
            m_splitContainerOuter.Panel2.Controls.Add(m_splitContainerInner);
            m_splitContainerOuter.Panel2.Font = null;
            // 
            // m_tilePicker
            // 
            this.m_tilePicker.AccessibleDescription = null;
            this.m_tilePicker.AccessibleName = null;
            this.m_tilePicker.AllowDrop = true;
            resources.ApplyResources(this.m_tilePicker, "m_tilePicker");
            this.m_tilePicker.BackgroundImage = null;
            this.m_tilePicker.Font = null;
            this.m_tilePicker.Map = null;
            this.m_tilePicker.Name = "m_tilePicker";
            this.m_tilePicker.SelectedTileSheet = null;
            this.m_tilePicker.TileDrag += new TileMapEditor.Controls.TilePickerEventHandler(this.OnTileDrag);
            // 
            // m_splitContainerInner
            // 
            m_splitContainerInner.AccessibleDescription = null;
            m_splitContainerInner.AccessibleName = null;
            resources.ApplyResources(m_splitContainerInner, "m_splitContainerInner");
            m_splitContainerInner.BackgroundImage = null;
            m_splitContainerInner.Font = null;
            m_splitContainerInner.Name = "m_splitContainerInner";
            // 
            // m_splitContainerInner.Panel1
            // 
            m_splitContainerInner.Panel1.AccessibleDescription = null;
            m_splitContainerInner.Panel1.AccessibleName = null;
            resources.ApplyResources(m_splitContainerInner.Panel1, "m_splitContainerInner.Panel1");
            m_splitContainerInner.Panel1.BackgroundImage = null;
            m_splitContainerInner.Panel1.Controls.Add(this.m_previewPanel);
            m_splitContainerInner.Panel1.Font = null;
            // 
            // m_splitContainerInner.Panel2
            // 
            m_splitContainerInner.Panel2.AccessibleDescription = null;
            m_splitContainerInner.Panel2.AccessibleName = null;
            resources.ApplyResources(m_splitContainerInner.Panel2, "m_splitContainerInner.Panel2");
            m_splitContainerInner.Panel2.BackgroundImage = null;
            m_splitContainerInner.Panel2.Controls.Add(this.m_animationListView);
            m_splitContainerInner.Panel2.Font = null;
            // 
            // m_previewPanel
            // 
            this.m_previewPanel.AccessibleDescription = null;
            this.m_previewPanel.AccessibleName = null;
            this.m_previewPanel.AllowDrop = true;
            resources.ApplyResources(this.m_previewPanel, "m_previewPanel");
            this.m_previewPanel.BackgroundImage = null;
            this.m_previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_previewPanel.Font = null;
            this.m_previewPanel.Name = "m_previewPanel";
            this.m_previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPreviewPaint);
            this.m_previewPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDialogMouseMove);
            // 
            // m_animationListView
            // 
            this.m_animationListView.AccessibleDescription = null;
            this.m_animationListView.AccessibleName = null;
            resources.ApplyResources(this.m_animationListView, "m_animationListView");
            this.m_animationListView.AllowDrop = true;
            this.m_animationListView.BackgroundImage = null;
            this.m_animationListView.ContextMenuStrip = this.m_frameContextMenuStrip;
            this.m_animationListView.Font = null;
            this.m_animationListView.LargeImageList = this.m_imageListAnimation;
            this.m_animationListView.Name = "m_animationListView";
            this.m_animationListView.UseCompatibleStateImageBehavior = false;
            this.m_animationListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTileDragDrop);
            this.m_animationListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTileDragEnter);
            // 
            // m_frameContextMenuStrip
            // 
            this.m_frameContextMenuStrip.AccessibleDescription = null;
            this.m_frameContextMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.m_frameContextMenuStrip, "m_frameContextMenuStrip");
            this.m_frameContextMenuStrip.BackgroundImage = null;
            this.m_frameContextMenuStrip.Font = null;
            this.m_frameContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_framePropertiesMenuItem,
            m_menuItemSeparator,
            this.m_frameDeleteMenuItem});
            this.m_frameContextMenuStrip.Name = "m_frameContextMenuStrip";
            // 
            // m_framePropertiesMenuItem
            // 
            this.m_framePropertiesMenuItem.AccessibleDescription = null;
            this.m_framePropertiesMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_framePropertiesMenuItem, "m_framePropertiesMenuItem");
            this.m_framePropertiesMenuItem.BackgroundImage = null;
            this.m_framePropertiesMenuItem.Image = global::TileMapEditor.Properties.Resources.TileAnimationFrameProperties;
            this.m_framePropertiesMenuItem.Name = "m_framePropertiesMenuItem";
            this.m_framePropertiesMenuItem.ShortcutKeyDisplayString = null;
            this.m_framePropertiesMenuItem.Click += new System.EventHandler(this.OnFrameProperties);
            // 
            // m_menuItemSeparator
            // 
            m_menuItemSeparator.AccessibleDescription = null;
            m_menuItemSeparator.AccessibleName = null;
            resources.ApplyResources(m_menuItemSeparator, "m_menuItemSeparator");
            m_menuItemSeparator.Name = "m_menuItemSeparator";
            // 
            // m_frameDeleteMenuItem
            // 
            this.m_frameDeleteMenuItem.AccessibleDescription = null;
            this.m_frameDeleteMenuItem.AccessibleName = null;
            resources.ApplyResources(this.m_frameDeleteMenuItem, "m_frameDeleteMenuItem");
            this.m_frameDeleteMenuItem.BackgroundImage = null;
            this.m_frameDeleteMenuItem.Image = global::TileMapEditor.Properties.Resources.TileAnimationFrameDelete;
            this.m_frameDeleteMenuItem.Name = "m_frameDeleteMenuItem";
            this.m_frameDeleteMenuItem.ShortcutKeyDisplayString = null;
            this.m_frameDeleteMenuItem.Click += new System.EventHandler(this.OnDeleteFrame);
            // 
            // m_imageListAnimation
            // 
            this.m_imageListAnimation.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.m_imageListAnimation, "m_imageListAnimation");
            this.m_imageListAnimation.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_customPanel
            // 
            m_customPanel.AccessibleDescription = null;
            m_customPanel.AccessibleName = null;
            resources.ApplyResources(m_customPanel, "m_customPanel");
            m_customPanel.BackgroundImage = null;
            m_customPanel.Controls.Add(m_splitContainerOuter);
            m_customPanel.Font = null;
            m_customPanel.Name = "m_customPanel";
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
            this.m_buttonOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDialogMouseMove);
            this.m_buttonOk.Click += new System.EventHandler(this.OnDialogOk);
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
            this.m_buttonApply.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDialogMouseMove);
            this.m_buttonApply.Click += new System.EventHandler(this.OnDialogApply);
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
            this.m_buttonCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDialogMouseMove);
            // 
            // m_frameIntervalTextbox
            // 
            this.m_frameIntervalTextbox.AccessibleDescription = null;
            this.m_frameIntervalTextbox.AccessibleName = null;
            resources.ApplyResources(this.m_frameIntervalTextbox, "m_frameIntervalTextbox");
            this.m_frameIntervalTextbox.Font = null;
            this.m_frameIntervalTextbox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_frameIntervalTextbox.Name = "m_frameIntervalTextbox";
            this.m_frameIntervalTextbox.ValueChanged += new System.EventHandler(this.OnFrameIntervalChanged);
            // 
            // m_animationTimer
            // 
            this.m_animationTimer.Enabled = true;
            this.m_animationTimer.Interval = 1;
            this.m_animationTimer.Tick += new System.EventHandler(this.OnAnimationTimer);
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
            // m_tileSizeMessageBox
            // 
            resources.ApplyResources(this.m_tileSizeMessageBox, "m_tileSizeMessageBox");
            this.m_tileSizeMessageBox.HelpFilePath = null;
            this.m_tileSizeMessageBox.Icon = TileMapEditor.Controls.MessageIcon.Error;
            this.m_tileSizeMessageBox.Owner = this;
            // 
            // TileAnimationDialog
            // 
            this.AcceptButton = this.m_buttonOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.m_buttonCancel;
            this.Controls.Add(this.m_buttonApply);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonClose);
            this.Controls.Add(m_frameIntervalLabel);
            this.Controls.Add(m_customPanel);
            this.Controls.Add(this.m_buttonOk);
            this.Controls.Add(this.m_frameIntervalTextbox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "TileAnimationDialog";
            this.Load += new System.EventHandler(this.OnDialogLoad);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDialogMouseMove);
            m_splitContainerOuter.Panel1.ResumeLayout(false);
            m_splitContainerOuter.Panel2.ResumeLayout(false);
            m_splitContainerOuter.ResumeLayout(false);
            m_splitContainerInner.Panel1.ResumeLayout(false);
            m_splitContainerInner.Panel2.ResumeLayout(false);
            m_splitContainerInner.ResumeLayout(false);
            this.m_frameContextMenuStrip.ResumeLayout(false);
            m_customPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_frameIntervalTextbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_buttonOk;
        private System.Windows.Forms.Button m_buttonApply;
        private System.Windows.Forms.Button m_buttonCancel;
        private TileMapEditor.Controls.TilePicker m_tilePicker;
        private TileMapEditor.Controls.CustomPanel m_previewPanel;
        private TileMapEditor.Controls.CustomListView m_animationListView;
        private System.Windows.Forms.ImageList m_imageListAnimation;
        private System.Windows.Forms.ContextMenuStrip m_frameContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_frameDeleteMenuItem;
        private System.Windows.Forms.NumericUpDown m_frameIntervalTextbox;
        private System.Windows.Forms.Timer m_animationTimer;
        private System.Windows.Forms.ToolStripMenuItem m_framePropertiesMenuItem;
        private System.Windows.Forms.Button m_buttonClose;
        private TileMapEditor.Controls.CustomMessageBox m_tileSizeMessageBox;

    }
}