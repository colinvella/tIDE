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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_topicTreeView = new System.Windows.Forms.TreeView();
            this.m_indexTreeView = new System.Windows.Forms.TreeView();
            this.m_searchListView = new System.Windows.Forms.ListView();
            this.m_contentPanel = new System.Windows.Forms.Panel();
            this.m_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.m_helpContentsButton = new System.Windows.Forms.ToolStripButton();
            this.m_helpIndexButton = new System.Windows.Forms.ToolStripButton();
            this.m_helpSearchButton = new System.Windows.Forms.ToolStripButton();
            this.m_searchTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.m_contentRichTextBox = new TileMapEditor.Controls.CustomRichTextBox();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_contentPanel.SuspendLayout();
            this.m_toolStripContainer.ContentPanel.SuspendLayout();
            this.m_toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.m_toolStripContainer.SuspendLayout();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.AccessibleDescription = null;
            this.m_splitContainer.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer, "m_splitContainer");
            this.m_splitContainer.BackgroundImage = null;
            this.m_splitContainer.Font = null;
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.AccessibleDescription = null;
            this.m_splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer.Panel1, "m_splitContainer.Panel1");
            this.m_splitContainer.Panel1.BackgroundImage = null;
            this.m_splitContainer.Panel1.Controls.Add(this.m_topicTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_indexTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_searchListView);
            this.m_splitContainer.Panel1.Font = null;
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.AccessibleDescription = null;
            this.m_splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.m_splitContainer.Panel2, "m_splitContainer.Panel2");
            this.m_splitContainer.Panel2.BackgroundImage = null;
            this.m_splitContainer.Panel2.Controls.Add(this.m_contentPanel);
            this.m_splitContainer.Panel2.Font = null;
            // 
            // m_topicTreeView
            // 
            this.m_topicTreeView.AccessibleDescription = null;
            this.m_topicTreeView.AccessibleName = null;
            resources.ApplyResources(this.m_topicTreeView, "m_topicTreeView");
            this.m_topicTreeView.BackgroundImage = null;
            this.m_topicTreeView.Font = null;
            this.m_topicTreeView.Name = "m_topicTreeView";
            this.m_topicTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("m_topicTreeView.Nodes")))});
            this.m_topicTreeView.ShowNodeToolTips = true;
            this.m_topicTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTopicSelect);
            // 
            // m_indexTreeView
            // 
            this.m_indexTreeView.AccessibleDescription = null;
            this.m_indexTreeView.AccessibleName = null;
            resources.ApplyResources(this.m_indexTreeView, "m_indexTreeView");
            this.m_indexTreeView.BackgroundImage = null;
            this.m_indexTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_indexTreeView.Font = null;
            this.m_indexTreeView.Name = "m_indexTreeView";
            this.m_indexTreeView.ShowLines = false;
            this.m_indexTreeView.ShowPlusMinus = false;
            this.m_indexTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnIndexSelect);
            // 
            // m_searchListView
            // 
            this.m_searchListView.AccessibleDescription = null;
            this.m_searchListView.AccessibleName = null;
            resources.ApplyResources(this.m_searchListView, "m_searchListView");
            this.m_searchListView.BackgroundImage = null;
            this.m_searchListView.Font = null;
            this.m_searchListView.Name = "m_searchListView";
            this.m_searchListView.UseCompatibleStateImageBehavior = false;
            this.m_searchListView.View = System.Windows.Forms.View.List;
            this.m_searchListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSearchResult);
            // 
            // m_contentPanel
            // 
            this.m_contentPanel.AccessibleDescription = null;
            this.m_contentPanel.AccessibleName = null;
            resources.ApplyResources(this.m_contentPanel, "m_contentPanel");
            this.m_contentPanel.BackColor = System.Drawing.SystemColors.Window;
            this.m_contentPanel.BackgroundImage = null;
            this.m_contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_contentPanel.Controls.Add(this.m_contentRichTextBox);
            this.m_contentPanel.Font = null;
            this.m_contentPanel.Name = "m_contentPanel";
            // 
            // m_toolStripContainer
            // 
            this.m_toolStripContainer.AccessibleDescription = null;
            this.m_toolStripContainer.AccessibleName = null;
            resources.ApplyResources(this.m_toolStripContainer, "m_toolStripContainer");
            // 
            // m_toolStripContainer.BottomToolStripPanel
            // 
            this.m_toolStripContainer.BottomToolStripPanel.AccessibleDescription = null;
            this.m_toolStripContainer.BottomToolStripPanel.AccessibleName = null;
            this.m_toolStripContainer.BottomToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.m_toolStripContainer.BottomToolStripPanel, "m_toolStripContainer.BottomToolStripPanel");
            this.m_toolStripContainer.BottomToolStripPanel.Font = null;
            // 
            // m_toolStripContainer.ContentPanel
            // 
            this.m_toolStripContainer.ContentPanel.AccessibleDescription = null;
            this.m_toolStripContainer.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.m_toolStripContainer.ContentPanel, "m_toolStripContainer.ContentPanel");
            this.m_toolStripContainer.ContentPanel.BackgroundImage = null;
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitContainer);
            this.m_toolStripContainer.ContentPanel.Font = null;
            this.m_toolStripContainer.Font = null;
            // 
            // m_toolStripContainer.LeftToolStripPanel
            // 
            this.m_toolStripContainer.LeftToolStripPanel.AccessibleDescription = null;
            this.m_toolStripContainer.LeftToolStripPanel.AccessibleName = null;
            this.m_toolStripContainer.LeftToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.m_toolStripContainer.LeftToolStripPanel, "m_toolStripContainer.LeftToolStripPanel");
            this.m_toolStripContainer.LeftToolStripPanel.Font = null;
            this.m_toolStripContainer.LeftToolStripPanelVisible = false;
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            // 
            // m_toolStripContainer.RightToolStripPanel
            // 
            this.m_toolStripContainer.RightToolStripPanel.AccessibleDescription = null;
            this.m_toolStripContainer.RightToolStripPanel.AccessibleName = null;
            this.m_toolStripContainer.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.m_toolStripContainer.RightToolStripPanel, "m_toolStripContainer.RightToolStripPanel");
            this.m_toolStripContainer.RightToolStripPanel.Font = null;
            this.m_toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // m_toolStripContainer.TopToolStripPanel
            // 
            this.m_toolStripContainer.TopToolStripPanel.AccessibleDescription = null;
            this.m_toolStripContainer.TopToolStripPanel.AccessibleName = null;
            this.m_toolStripContainer.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.m_toolStripContainer.TopToolStripPanel, "m_toolStripContainer.TopToolStripPanel");
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_toolStrip);
            this.m_toolStripContainer.TopToolStripPanel.Font = null;
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.AccessibleDescription = null;
            this.m_toolStrip.AccessibleName = null;
            resources.ApplyResources(this.m_toolStrip, "m_toolStrip");
            this.m_toolStrip.BackgroundImage = null;
            this.m_toolStrip.Font = null;
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_helpContentsButton,
            this.m_helpIndexButton,
            this.m_helpSearchButton,
            this.m_searchTextbox});
            this.m_toolStrip.Name = "m_toolStrip";
            // 
            // m_helpContentsButton
            // 
            this.m_helpContentsButton.AccessibleDescription = null;
            this.m_helpContentsButton.AccessibleName = null;
            resources.ApplyResources(this.m_helpContentsButton, "m_helpContentsButton");
            this.m_helpContentsButton.BackgroundImage = null;
            this.m_helpContentsButton.Checked = true;
            this.m_helpContentsButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_helpContentsButton.Image = global::TileMapEditor.Properties.Resources.HelpContents;
            this.m_helpContentsButton.Name = "m_helpContentsButton";
            this.m_helpContentsButton.Click += new System.EventHandler(this.OnHelpContents);
            // 
            // m_helpIndexButton
            // 
            this.m_helpIndexButton.AccessibleDescription = null;
            this.m_helpIndexButton.AccessibleName = null;
            resources.ApplyResources(this.m_helpIndexButton, "m_helpIndexButton");
            this.m_helpIndexButton.BackgroundImage = null;
            this.m_helpIndexButton.Image = global::TileMapEditor.Properties.Resources.HelpIndex;
            this.m_helpIndexButton.Name = "m_helpIndexButton";
            this.m_helpIndexButton.Click += new System.EventHandler(this.OnHelpIndex);
            // 
            // m_helpSearchButton
            // 
            this.m_helpSearchButton.AccessibleDescription = null;
            this.m_helpSearchButton.AccessibleName = null;
            resources.ApplyResources(this.m_helpSearchButton, "m_helpSearchButton");
            this.m_helpSearchButton.BackgroundImage = null;
            this.m_helpSearchButton.Image = global::TileMapEditor.Properties.Resources.HelpSearch;
            this.m_helpSearchButton.Name = "m_helpSearchButton";
            this.m_helpSearchButton.Click += new System.EventHandler(this.OnHelpSearch);
            // 
            // m_searchTextbox
            // 
            this.m_searchTextbox.AccessibleDescription = null;
            this.m_searchTextbox.AccessibleName = null;
            resources.ApplyResources(this.m_searchTextbox, "m_searchTextbox");
            this.m_searchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_searchTextbox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_searchTextbox.Name = "m_searchTextbox";
            this.m_searchTextbox.Enter += new System.EventHandler(this.OnEnterSearchTextBox);
            this.m_searchTextbox.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // m_contentRichTextBox
            // 
            this.m_contentRichTextBox.AccessibleDescription = null;
            this.m_contentRichTextBox.AccessibleName = null;
            resources.ApplyResources(this.m_contentRichTextBox, "m_contentRichTextBox");
            this.m_contentRichTextBox.BackColor = System.Drawing.Color.White;
            this.m_contentRichTextBox.BackgroundImage = null;
            this.m_contentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_contentRichTextBox.DetectUrls = true;
            this.m_contentRichTextBox.Font = null;
            this.m_contentRichTextBox.Name = "m_contentRichTextBox";
            this.m_contentRichTextBox.ReadOnly = true;
            this.m_contentRichTextBox.SelectionLink = false;
            this.m_contentRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnHelpLink);
            // 
            // HelpForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_toolStripContainer);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "HelpForm";
            this.Load += new System.EventHandler(this.OnHelpFormLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnHelpClosing);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.m_contentPanel.ResumeLayout(false);
            this.m_toolStripContainer.ContentPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.m_toolStripContainer.TopToolStripPanel.PerformLayout();
            this.m_toolStripContainer.ResumeLayout(false);
            this.m_toolStripContainer.PerformLayout();
            this.m_toolStrip.ResumeLayout(false);
            this.m_toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer m_splitContainer;
        private TileMapEditor.Controls.CustomRichTextBox m_contentRichTextBox;
        private System.Windows.Forms.ToolStripContainer m_toolStripContainer;
        private System.Windows.Forms.Panel m_contentPanel;
        private System.Windows.Forms.TreeView m_topicTreeView;
        private System.Windows.Forms.ToolStrip m_toolStrip;
        private System.Windows.Forms.ToolStripButton m_helpSearchButton;
        private System.Windows.Forms.ToolStripButton m_helpIndexButton;
        private System.Windows.Forms.ToolStripButton m_helpContentsButton;
        private System.Windows.Forms.TreeView m_indexTreeView;
        private System.Windows.Forms.ToolStripTextBox m_searchTextbox;
        private System.Windows.Forms.ListView m_searchListView;
    }
}