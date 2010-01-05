namespace TileMapEditor.Control
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
            System.Windows.Forms.Panel m_panelContent;
            this.m_tileListView = new TileMapEditor.Control.CustomListView();
            this.m_tileImageList = new System.Windows.Forms.ImageList(this.components);
            this.m_comboBoxTileSheets = new System.Windows.Forms.ComboBox();
            m_labelCaption = new System.Windows.Forms.Label();
            m_panelContent = new System.Windows.Forms.Panel();
            m_panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            m_labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            m_labelCaption.Location = new System.Drawing.Point(0, 0);
            m_labelCaption.Name = "m_labelCaption";
            m_labelCaption.Padding = new System.Windows.Forms.Padding(2);
            m_labelCaption.Size = new System.Drawing.Size(150, 20);
            m_labelCaption.TabIndex = 0;
            m_labelCaption.Text = "Tile Picker";
            m_labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelContent
            // 
            m_panelContent.Controls.Add(this.m_tileListView);
            m_panelContent.Controls.Add(this.m_comboBoxTileSheets);
            m_panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            m_panelContent.Location = new System.Drawing.Point(0, 20);
            m_panelContent.Name = "m_panelContent";
            m_panelContent.Size = new System.Drawing.Size(150, 130);
            m_panelContent.TabIndex = 1;
            // 
            // m_tileListView
            // 
            this.m_tileListView.AutoArrange = false;
            this.m_tileListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_tileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tileListView.LargeImageList = this.m_tileImageList;
            this.m_tileListView.Location = new System.Drawing.Point(0, 21);
            this.m_tileListView.MultiSelect = false;
            this.m_tileListView.Name = "m_tileListView";
            this.m_tileListView.Size = new System.Drawing.Size(150, 109);
            this.m_tileListView.TabIndex = 1;
            this.m_tileListView.UseCompatibleStateImageBehavior = false;
            this.m_tileListView.VirtualMode = true;
            this.m_tileListView.SelectedIndexChanged += new System.EventHandler(this.OnSelectTile);
            this.m_tileListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.OnRetrieveVirtualItem);
            // 
            // m_tileImageList
            // 
            this.m_tileImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.m_tileImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.m_tileImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_comboBoxTileSheets
            // 
            this.m_comboBoxTileSheets.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_comboBoxTileSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTileSheets.FormattingEnabled = true;
            this.m_comboBoxTileSheets.Location = new System.Drawing.Point(0, 0);
            this.m_comboBoxTileSheets.Name = "m_comboBoxTileSheets";
            this.m_comboBoxTileSheets.Size = new System.Drawing.Size(150, 21);
            this.m_comboBoxTileSheets.TabIndex = 0;
            this.m_comboBoxTileSheets.SelectedIndexChanged += new System.EventHandler(this.OnSelectTileSheet);
            // 
            // TilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(m_panelContent);
            this.Controls.Add(m_labelCaption);
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
