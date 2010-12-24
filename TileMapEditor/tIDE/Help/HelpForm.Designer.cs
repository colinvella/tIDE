namespace tIDE.Help
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
            this.components = new System.ComponentModel.Container();
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
            this.m_contentRichTextBox = new tIDE.Controls.CustomRichTextBox();
            this.m_noContentMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
            this.m_badContentMessageBox = new tIDE.Controls.CustomMessageBox(this.components);
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
            resources.ApplyResources(this.m_splitContainer, "m_splitContainer");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_topicTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_indexTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_searchListView);
            resources.ApplyResources(this.m_splitContainer.Panel1, "m_splitContainer.Panel1");
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_contentPanel);
            // 
            // m_topicTreeView
            // 
            resources.ApplyResources(this.m_topicTreeView, "m_topicTreeView");
            this.m_topicTreeView.Name = "m_topicTreeView";
            this.m_topicTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("m_topicTreeView.Nodes"))),
            ((System.Windows.Forms.TreeNode)(resources.GetObject("m_topicTreeView.Nodes1")))});
            this.m_topicTreeView.ShowNodeToolTips = true;
            this.m_topicTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTopicSelect);
            // 
            // m_indexTreeView
            // 
            this.m_indexTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.m_indexTreeView, "m_indexTreeView");
            this.m_indexTreeView.Name = "m_indexTreeView";
            this.m_indexTreeView.ShowLines = false;
            this.m_indexTreeView.ShowPlusMinus = false;
            this.m_indexTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnIndexSelect);
            // 
            // m_searchListView
            // 
            resources.ApplyResources(this.m_searchListView, "m_searchListView");
            this.m_searchListView.Name = "m_searchListView";
            this.m_searchListView.UseCompatibleStateImageBehavior = false;
            this.m_searchListView.View = System.Windows.Forms.View.List;
            this.m_searchListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSearchResult);
            // 
            // m_contentPanel
            // 
            resources.ApplyResources(this.m_contentPanel, "m_contentPanel");
            this.m_contentPanel.BackColor = System.Drawing.SystemColors.Window;
            this.m_contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_contentPanel.Controls.Add(this.m_contentRichTextBox);
            this.m_contentPanel.Name = "m_contentPanel";
            // 
            // m_toolStripContainer
            // 
            // 
            // m_toolStripContainer.ContentPanel
            // 
            resources.ApplyResources(this.m_toolStripContainer.ContentPanel, "m_toolStripContainer.ContentPanel");
            this.m_toolStripContainer.ContentPanel.Controls.Add(this.m_splitContainer);
            resources.ApplyResources(this.m_toolStripContainer, "m_toolStripContainer");
            this.m_toolStripContainer.LeftToolStripPanelVisible = false;
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            this.m_toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // m_toolStripContainer.TopToolStripPanel
            // 
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_toolStrip);
            // 
            // m_toolStrip
            // 
            resources.ApplyResources(this.m_toolStrip, "m_toolStrip");
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_helpContentsButton,
            this.m_helpIndexButton,
            this.m_helpSearchButton,
            this.m_searchTextbox});
            this.m_toolStrip.Name = "m_toolStrip";
            // 
            // m_helpContentsButton
            // 
            this.m_helpContentsButton.Checked = true;
            this.m_helpContentsButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_helpContentsButton.Image = global::tIDE.Properties.Resources.HelpContents;
            resources.ApplyResources(this.m_helpContentsButton, "m_helpContentsButton");
            this.m_helpContentsButton.Name = "m_helpContentsButton";
            this.m_helpContentsButton.Click += new System.EventHandler(this.OnHelpContents);
            // 
            // m_helpIndexButton
            // 
            this.m_helpIndexButton.Image = global::tIDE.Properties.Resources.HelpIndex;
            resources.ApplyResources(this.m_helpIndexButton, "m_helpIndexButton");
            this.m_helpIndexButton.Name = "m_helpIndexButton";
            this.m_helpIndexButton.Click += new System.EventHandler(this.OnHelpIndex);
            // 
            // m_helpSearchButton
            // 
            this.m_helpSearchButton.Image = global::tIDE.Properties.Resources.HelpSearch;
            resources.ApplyResources(this.m_helpSearchButton, "m_helpSearchButton");
            this.m_helpSearchButton.Name = "m_helpSearchButton";
            this.m_helpSearchButton.Click += new System.EventHandler(this.OnHelpSearch);
            // 
            // m_searchTextbox
            // 
            this.m_searchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_searchTextbox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_searchTextbox.Name = "m_searchTextbox";
            resources.ApplyResources(this.m_searchTextbox, "m_searchTextbox");
            this.m_searchTextbox.Enter += new System.EventHandler(this.OnEnterSearchTextBox);
            this.m_searchTextbox.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // m_contentRichTextBox
            // 
            this.m_contentRichTextBox.BackColor = System.Drawing.Color.White;
            this.m_contentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_contentRichTextBox.DetectUrls = true;
            resources.ApplyResources(this.m_contentRichTextBox, "m_contentRichTextBox");
            this.m_contentRichTextBox.Name = "m_contentRichTextBox";
            this.m_contentRichTextBox.ReadOnly = true;
            this.m_contentRichTextBox.SelectionLink = false;
            this.m_contentRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnHelpLink);
            // 
            // m_noContentMessageBox
            // 
            resources.ApplyResources(this.m_noContentMessageBox, "m_noContentMessageBox");
            this.m_noContentMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_noContentMessageBox.Owner = this;
            // 
            // m_badContentMessageBox
            // 
            resources.ApplyResources(this.m_badContentMessageBox, "m_badContentMessageBox");
            this.m_badContentMessageBox.Icon = tIDE.Controls.MessageIcon.Error;
            this.m_badContentMessageBox.Owner = this;
            // 
            // HelpForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_toolStripContainer);
            this.DoubleBuffered = true;
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
        private tIDE.Controls.CustomRichTextBox m_contentRichTextBox;
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
        private tIDE.Controls.CustomMessageBox m_noContentMessageBox;
        private tIDE.Controls.CustomMessageBox m_badContentMessageBox;
    }
}