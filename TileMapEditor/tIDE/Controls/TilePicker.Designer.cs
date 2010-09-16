namespace TileMapEditor.Controls
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
            System.Windows.Forms.Panel m_panelContent;
            this.m_tileListView = new TileMapEditor.Controls.CustomListView();
            this.m_tileImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_comboBoxTileSheets = new System.Windows.Forms.ComboBox();
            m_labelCaption = new System.Windows.Forms.Label();
            m_panelContent = new System.Windows.Forms.Panel();
            m_panelContent.SuspendLayout();
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
            // m_panelContent
            // 
            m_panelContent.AccessibleDescription = null;
            m_panelContent.AccessibleName = null;
            resources.ApplyResources(m_panelContent, "m_panelContent");
            m_panelContent.BackgroundImage = null;
            m_panelContent.Controls.Add(this.m_tileListView);
            m_panelContent.Controls.Add(this.m_comboBoxTileSheets);
            m_panelContent.Font = null;
            m_panelContent.Name = "m_panelContent";
            // 
            // m_tileListView
            // 
            this.m_tileListView.AccessibleDescription = null;
            this.m_tileListView.AccessibleName = null;
            resources.ApplyResources(this.m_tileListView, "m_tileListView");
            this.m_tileListView.AutoArrange = false;
            this.m_tileListView.BackgroundImage = null;
            this.m_tileListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_tileListView.Font = null;
            this.m_tileListView.LargeImageList = this.m_tileImageList;
            this.m_tileListView.MultiSelect = false;
            this.m_tileListView.Name = "m_tileListView";
            this.m_tileListView.UseCompatibleStateImageBehavior = false;
            this.m_tileListView.VirtualMode = true;
            this.m_tileListView.SelectedIndexChanged += new System.EventHandler(this.OnSelectTile);
            this.m_tileListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.OnRetrieveVirtualItem);
            this.m_tileListView.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.OnDragGiveFeedback);
            this.m_tileListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnItemDrag);
            // 
            // m_tileImageList
            // 
            this.m_tileImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.m_tileImageList, "m_tileImageList");
            this.m_tileImageList.TransparentColor = System.Drawing.Color.Transparent;
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
            // TilePicker
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(m_panelContent);
            this.Controls.Add(m_labelCaption);
            this.Font = null;
            this.Name = "TilePicker";
            m_panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_comboBoxTileSheets;
        private System.Windows.Forms.ImageList m_tileImageList;
        private CustomListView m_tileListView;
    }
}
