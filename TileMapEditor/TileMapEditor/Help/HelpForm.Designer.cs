namespace TileMapEditor.Help
{
    partial class HelpForm
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
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_contentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.m_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_toolStripContainer.ContentPanel.SuspendLayout();
            this.m_toolStripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_contentRichTextBox);
            this.m_splitContainer.Size = new System.Drawing.Size(584, 387);
            this.m_splitContainer.SplitterDistance = 194;
            this.m_splitContainer.TabIndex = 0;
            // 
            // m_contentRichTextBox
            // 
            this.m_contentRichTextBox.BackColor = System.Drawing.Color.White;
            this.m_contentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_contentRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_contentRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.m_contentRichTextBox.Name = "m_contentRichTextBox";
            this.m_contentRichTextBox.ReadOnly = true;
            this.m_contentRichTextBox.Size = new System.Drawing.Size(386, 387);
            this.m_contentRichTextBox.TabIndex = 0;
            this.m_contentRichTextBox.Text = "Content Pane";
            // 
            // m_toolStripContainer
            // 
            // 
            // m_toolStripContainer.ContentPanel
            // 
            this.m_toolStripContainer.ContentPanel.AutoScroll = true;
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitContainer);
            this.m_toolStripContainer.ContentPanel.Size = new System.Drawing.Size(584, 387);
            this.m_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            this.m_toolStripContainer.Size = new System.Drawing.Size(584, 412);
            this.m_toolStripContainer.TabIndex = 1;
            this.m_toolStripContainer.Text = "toolStripContainer1";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_toolStripContainer);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.m_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainer.ResumeLayout(false);
            this.m_toolStripContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer m_splitContainer;
        private System.Windows.Forms.RichTextBox m_contentRichTextBox;
        private System.Windows.Forms.ToolStripContainer m_toolStripContainer;
    }
}