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
            System.Windows.Forms.Label m_labelCaption;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilePicker));
            System.Windows.Forms.ToolStripLabel m_lblIdx;
            this.m_comboBoxTileSheets = new System.Windows.Forms.ComboBox();
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
            this.m_tilePanel.SuspendLayout();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.AccessibleDescription = null;
            m_labelCaption.AccessibleName = null;
            resources.ApplyResources(m_labelCaption, "m_labelCaption");
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_labelCaption.Font = null;
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Name = "m_labelCaption";
            // 
            // m_lblIdx
            // 
            m_lblIdx.AccessibleDescription = null;
            m_lblIdx.AccessibleName = null;
            resources.ApplyResources(m_lblIdx, "m_lblIdx");
            m_lblIdx.BackgroundImage = null;
            m_lblIdx.Name = "m_lblIdx";
            // 
            // m_comboBoxTileSheets
            // 
            this.m_comboBoxTileSheets.AccessibleDescription = null;
            this.m_comboBoxTileSheets.AccessibleName = null;
            resources.ApplyResources(this.m_comboBoxTileSheets, "m_comboBoxTileSheets");
            this.m_comboBoxTileSheets.BackgroundImage = null;
            this.m_comboBoxTileSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTileSheets.Font = null;
            this.m_comboBoxTileSheets.FormattingEnabled = true;
            this.m_comboBoxTileSheets.Name = "m_comboBoxTileSheets";
            this.m_comboBoxTileSheets.SelectedIndexChanged += new System.EventHandler(this.OnSelectTileSheet);
            // 
            // m_tilePanel
            // 
            this.m_tilePanel.AccessibleDescription = null;
            this.m_tilePanel.AccessibleName = null;
            resources.ApplyResources(this.m_tilePanel, "m_tilePanel");
            this.m_tilePanel.BackgroundImage = global::tIDE.Properties.Resources.ImageBackground;
            this.m_tilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_tilePanel.Controls.Add(this.m_horizontalScrollBar);
            this.m_tilePanel.Controls.Add(this.m_verticalScrollBar);
            this.m_tilePanel.Controls.Add(this.m_toolStrip);
            this.m_tilePanel.Font = null;
            this.m_tilePanel.Name = "m_tilePanel";
            this.m_tilePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnTilePanelPaint);
            this.m_tilePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseMove);
            this.m_tilePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseDown);
            this.m_tilePanel.Resize += new System.EventHandler(this.OnTilePanelResize);
            this.m_tilePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTilePanelMouseUp);
            this.m_tilePanel.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.OnDragGiveFeedback);
            // 
            // m_horizontalScrollBar
            // 
            this.m_horizontalScrollBar.AccessibleDescription = null;
            this.m_horizontalScrollBar.AccessibleName = null;
            resources.ApplyResources(this.m_horizontalScrollBar, "m_horizontalScrollBar");
            this.m_horizontalScrollBar.BackgroundImage = null;
            this.m_horizontalScrollBar.Font = null;
            this.m_horizontalScrollBar.Name = "m_horizontalScrollBar";
            this.m_horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnHorizontalScroll);
            // 
            // m_verticalScrollBar
            // 
            this.m_verticalScrollBar.AccessibleDescription = null;
            this.m_verticalScrollBar.AccessibleName = null;
            resources.ApplyResources(this.m_verticalScrollBar, "m_verticalScrollBar");
            this.m_verticalScrollBar.BackgroundImage = null;
            this.m_verticalScrollBar.Font = null;
            this.m_verticalScrollBar.Name = "m_verticalScrollBar";
            this.m_verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVerticalScroll);
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.AccessibleDescription = null;
            this.m_toolStrip.AccessibleName = null;
            resources.ApplyResources(this.m_toolStrip, "m_toolStrip");
            this.m_toolStrip.BackgroundImage = null;
            this.m_toolStrip.Font = null;
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
            this.m_indexOrderButton.AccessibleDescription = null;
            this.m_indexOrderButton.AccessibleName = null;
            resources.ApplyResources(this.m_indexOrderButton, "m_indexOrderButton");
            this.m_indexOrderButton.BackgroundImage = null;
            this.m_indexOrderButton.Checked = true;
            this.m_indexOrderButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_indexOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_indexOrderButton.Image = global::tIDE.Properties.Resources.TileOrderIndexed;
            this.m_indexOrderButton.Name = "m_indexOrderButton";
            this.m_indexOrderButton.Click += new System.EventHandler(this.OnOrderIndexed);
            // 
            // m_mruOrderButton
            // 
            this.m_mruOrderButton.AccessibleDescription = null;
            this.m_mruOrderButton.AccessibleName = null;
            resources.ApplyResources(this.m_mruOrderButton, "m_mruOrderButton");
            this.m_mruOrderButton.BackgroundImage = null;
            this.m_mruOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_mruOrderButton.Image = global::tIDE.Properties.Resources.TileOrderMru;
            this.m_mruOrderButton.Name = "m_mruOrderButton";
            this.m_mruOrderButton.Click += new System.EventHandler(this.OnOrderMru);
            // 
            // m_imageOrderButton
            // 
            this.m_imageOrderButton.AccessibleDescription = null;
            this.m_imageOrderButton.AccessibleName = null;
            resources.ApplyResources(this.m_imageOrderButton, "m_imageOrderButton");
            this.m_imageOrderButton.BackgroundImage = null;
            this.m_imageOrderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_imageOrderButton.Image = global::tIDE.Properties.Resources.TileOrderImage;
            this.m_imageOrderButton.Name = "m_imageOrderButton";
            this.m_imageOrderButton.Click += new System.EventHandler(this.OnOrderImage);
            // 
            // m_lblIdxValue
            // 
            this.m_lblIdxValue.AccessibleDescription = null;
            this.m_lblIdxValue.AccessibleName = null;
            resources.ApplyResources(this.m_lblIdxValue, "m_lblIdxValue");
            this.m_lblIdxValue.BackgroundImage = null;
            this.m_lblIdxValue.Name = "m_lblIdxValue";
            // 
            // TilePickerNew
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_tilePanel);
            this.Controls.Add(this.m_comboBoxTileSheets);
            this.Controls.Add(m_labelCaption);
            this.Font = null;
            this.Name = "TilePickerNew";
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
    }
}
