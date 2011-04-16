namespace tIDE.Controls
{
    partial class TilePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label m_labelCaption;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilePicker));
            System.Windows.Forms.ToolStripLabel m_lblIdx;
            this.m_comboBoxTileSheets = new System.Windows.Forms.ComboBox();
            this.m_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tilePickerTileIndexPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tilePanel = new tIDE.Controls.CustomPanel();
            this.m_horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.m_verticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.m_indexOrderButton = new System.Windows.Forms.ToolStripButton();
            this.m_mruOrderButton = new System.Windows.Forms.ToolStripButton();
            this.m_imageOrderButton = new System.Windows.Forms.ToolStripButton();
            this.m_lblIdxValue = new System.Windows.Forms.ToolStripLabel();
            m_labelCaption = new System.Windows.Forms.Label();
            m_lblIdx = new System.Windows.Forms.ToolStripLabel();
            this.m_contextMenuStrip.SuspendLayout();
            this.m_tilePanel.SuspendLayout();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(m_labelCaption, "m_labelCaption");
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Name = "m_labelCaption";
            // 
            // m_lblIdx
            // 
            m_lblIdx.Name = "m_lblIdx";
            resources.ApplyResources(m_lblIdx, "m_lblIdx");
            // 
            // m_comboBoxTileSheets
            // 
            resources.ApplyResources(this.m_comboBoxTileSheets, "m_comboBoxTileSheets");
            this.m_comboBoxTileSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTileSheets.FormattingEnabled = true;
            this.m_comboBoxTileSheets.Name = "m_comboBoxTileSheets";
            this.m_comboBoxTileSheets.SelectedIndexChanged += new System.EventHandler(this.OnSelectTileSheet);
            // 
            // m_contextMenuStrip
            // 
            this.m_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tilePickerTileIndexPropertiesMenuItem});
            this.m_contextMenuStrip.Name = "m_ctxTilePicker";
            resources.ApplyResources(this.m_contextMenuStrip, "m_contextMenuStrip");
            this.m_contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnTilePickerMenuOpening);
            // 
            // m_tilePickerTileIndexPropertiesMenuItem
            // 
            this.m_tilePickerTileIndexPropertiesMenuItem.Image = global::tIDE.Properties.Resources.TileProperties;
            this.m_tilePickerTileIndexPropertiesMenuItem.Name = "m_tilePickerTileIndexPropertiesMenuItem";
            resources.ApplyResources(this.m_tilePickerTileIndexPropertiesMenuItem, "m_tilePickerTileIndexPropertiesMenuItem");
            this.m_tilePickerTileIndexPropertiesMenuItem.Click += new System.EventHandler(this.OnTileIndexProperties);
            // 
            // m_tilePanel
            // 
            resources.ApplyResources(this.m_tilePanel, "m_tilePanel");
            this.m_tilePanel.BackgroundImage = global::tIDE.Properties.Resources.ImageBackground;
            this.m_tilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_tilePanel.ContextMenuStrip = this.m_contextMenuStrip;
            this.m_tilePanel.Controls.Add(this.m_horizontalScrollBar);
            this.m_tilePanel.Controls.Add(this.m_verticalScrollBar);
            this.m_tilePanel.Controls.Add(this.m_toolStrip);
            this.m_tilePanel.Name = "m_tilePanel";
            this.m_tilePanel.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.OnDragGiveFeedback);
            this.m_tilePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTilePanelPaint);
            this.m_tilePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseDown);
            this.m_tilePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseMove);
            this.m_tilePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseUp);
            this.m_tilePanel.Resize += new System.EventHandler(this.OnTilePanelResize);
            // 
            // m_horizontalScrollBar
            // 
            resources.ApplyResources(this.m_horizontalScrollBar, "m_horizontalScrollBar");
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnHorizontalScroll);
            // 
            // m_verticalScrollBar
            // 
            resources.ApplyResources(this.m_verticalScrollBar, "m_verticalScrollBar");
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVerticalScroll);
            // 
            // m_toolStrip
            // 
            resources.ApplyResources(this.m_toolStrip, "m_toolStrip");
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_indexOrderButton,
            this.m_mruOrderButton,
            this.m_imageOrderButton,
            m_lblIdx,
            this.m_lblIdxValue});
            this.m_toolStrip.Name = "m_toolStrip";
            // 
            // m_indexOrderButton
            // 
            this.m_indexOrderButton.Checked = true;
            this.m_indexOrderButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_indexOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_indexOrderButton.Image = global::tIDE.Properties.Resources.TileOrderIndexed;
            resources.ApplyResources(this.m_indexOrderButton, "m_indexOrderButton");
            this.m_indexOrderButton.Name = "m_indexOrderButton";
            this.m_indexOrderButton.Click += new System.EventHandler(this.OnOrderIndexed);
            // 
            // m_mruOrderButton
            // 
            this.m_mruOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_mruOrderButton.Image = global::tIDE.Properties.Resources.TileOrderMru;
            resources.ApplyResources(this.m_mruOrderButton, "m_mruOrderButton");
            this.m_mruOrderButton.Name = "m_mruOrderButton";
            this.m_mruOrderButton.Click += new System.EventHandler(this.OnOrderMru);
            // 
            // m_imageOrderButton
            // 
            this.m_imageOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_imageOrderButton.Image = global::tIDE.Properties.Resources.TileOrderImage;
            resources.ApplyResources(this.m_imageOrderButton, "m_imageOrderButton");
            this.m_imageOrderButton.Name = "m_imageOrderButton";
            this.m_imageOrderButton.Click += new System.EventHandler(this.OnOrderImage);
            // 
            // m_lblIdxValue
            // 
            this.m_lblIdxValue.Name = "m_lblIdxValue";
            resources.ApplyResources(this.m_lblIdxValue, "m_lblIdxValue");
            // 
            // TilePicker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tilePanel);
            this.Controls.Add(this.m_comboBoxTileSheets);
            this.Controls.Add(m_labelCaption);
            this.Name = "TilePicker";
            this.m_contextMenuStrip.ResumeLayout(false);
            this.m_tilePanel.ResumeLayout(false);
            this.m_tilePanel.PerformLayout();
            this.m_toolStrip.ResumeLayout(false);
            this.m_toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_comboBoxTileSheets;
        private CustomPanel m_tilePanel;
        private System.Windows.Forms.ToolStrip m_toolStrip;
        private System.Windows.Forms.ToolStripButton m_indexOrderButton;
        private System.Windows.Forms.ToolStripButton m_mruOrderButton;
        private System.Windows.Forms.ToolStripButton m_imageOrderButton;
        private System.Windows.Forms.VScrollBar m_verticalScrollBar;
        private System.Windows.Forms.HScrollBar m_horizontalScrollBar;
        private System.Windows.Forms.ToolStripLabel m_lblIdxValue;
        private System.Windows.Forms.ContextMenuStrip m_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_tilePickerTileIndexPropertiesMenuItem;
    }
}
