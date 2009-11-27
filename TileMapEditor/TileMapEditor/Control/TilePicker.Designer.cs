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
            System.Windows.Forms.Panel m_panelContent;
            this.m_labelCaption = new System.Windows.Forms.Label();
            this.m_comboBoxTileSheets = new System.Windows.Forms.ComboBox();
            m_panelContent = new System.Windows.Forms.Panel();
            m_panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelCaption
            // 
            this.m_labelCaption.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.m_labelCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_labelCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_labelCaption.Location = new System.Drawing.Point(0, 0);
            this.m_labelCaption.Name = "m_labelCaption";
            this.m_labelCaption.Padding = new System.Windows.Forms.Padding(2);
            this.m_labelCaption.Size = new System.Drawing.Size(148, 20);
            this.m_labelCaption.TabIndex = 0;
            this.m_labelCaption.Text = "Tile Picker";
            this.m_labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelContent
            // 
            m_panelContent.Controls.Add(this.m_comboBoxTileSheets);
            m_panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            m_panelContent.Location = new System.Drawing.Point(0, 20);
            m_panelContent.Name = "m_panelContent";
            m_panelContent.Size = new System.Drawing.Size(148, 128);
            m_panelContent.TabIndex = 1;
            // 
            // m_comboBoxTileSheets
            // 
            this.m_comboBoxTileSheets.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_comboBoxTileSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboBoxTileSheets.FormattingEnabled = true;
            this.m_comboBoxTileSheets.Location = new System.Drawing.Point(0, 0);
            this.m_comboBoxTileSheets.Name = "m_comboBoxTileSheets";
            this.m_comboBoxTileSheets.Size = new System.Drawing.Size(148, 21);
            this.m_comboBoxTileSheets.TabIndex = 0;
            // 
            // TilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(m_panelContent);
            this.Controls.Add(this.m_labelCaption);
            this.Name = "TilePicker";
            this.Size = new System.Drawing.Size(148, 148);
            m_panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_labelCaption;
        private System.Windows.Forms.ComboBox m_comboBoxTileSheets;
    }
}
