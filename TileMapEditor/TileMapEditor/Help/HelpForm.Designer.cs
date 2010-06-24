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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Features");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Getting Started");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("File Command Reference");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Edit Command Reference");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("View Command Reference");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Map Command Reference");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Layer Command Reference");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Tile Sheet Command Reference");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Plugin Command Reference");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Help Command Reference");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Command Reference", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Tile Selection Tool");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tile Placement Tool");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Tile Block Tool");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Tile Eraser Tool");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Tile Picking Tool");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Tile Brush Tool");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Editing Toolbox", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Map Properties Dialog");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Map Statistics Dialog");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Command History Dialog");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Layer Properties Dialog");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Tile Sheet Properties Dialog");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Tile Properties Dialog");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Tile Animation Dialog");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Tile Brush Dialog");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Plugin Info Dialog");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("About Dialog");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Dialog Box Reference", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("tIDE Help Topics", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode11,
            treeNode18,
            treeNode29});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_topicTreeView = new System.Windows.Forms.TreeView();
            this.m_indexTreeView = new System.Windows.Forms.TreeView();
            this.m_searchListView = new System.Windows.Forms.ListView();
            this.m_contentPanel = new System.Windows.Forms.Panel();
            this.m_contentRichTextBox = new TileMapEditor.Controls.CustomRichTextBox();
            this.m_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.m_helpContentsButton = new System.Windows.Forms.ToolStripButton();
            this.m_helpIndexButton = new System.Windows.Forms.ToolStripButton();
            this.m_helpSearchButton = new System.Windows.Forms.ToolStripButton();
            this.m_searchTextbox = new System.Windows.Forms.ToolStripTextBox();
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
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_topicTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_indexTreeView);
            this.m_splitContainer.Panel1.Controls.Add(this.m_searchListView);
            this.m_splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 0, 4);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_contentPanel);
            this.m_splitContainer.Size = new System.Drawing.Size(584, 387);
            this.m_splitContainer.SplitterDistance = 194;
            this.m_splitContainer.TabIndex = 0;
            // 
            // m_topicTreeView
            // 
            this.m_topicTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_topicTreeView.Location = new System.Drawing.Point(4, 4);
            this.m_topicTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.m_topicTreeView.Name = "m_topicTreeView";
            treeNode1.Name = "Features";
            treeNode1.Tag = "HelpFeatures";
            treeNode1.Text = "Features";
            treeNode1.ToolTipText = "Features of this application";
            treeNode2.Name = "GettingStarted";
            treeNode2.Tag = "HelpGettingStarted";
            treeNode2.Text = "Getting Started";
            treeNode2.ToolTipText = "Tips to quickly start using tIDE";
            treeNode3.Name = "FileCommandReference";
            treeNode3.Tag = "HelpFileCommandReference";
            treeNode3.Text = "File Command Reference";
            treeNode4.Name = "EditCommandReference";
            treeNode4.Tag = "HelpEditCommandReference";
            treeNode4.Text = "Edit Command Reference";
            treeNode5.Name = "ViewCommandReference";
            treeNode5.Tag = "HelpViewCommandReference";
            treeNode5.Text = "View Command Reference";
            treeNode6.Name = "MapCommandReference";
            treeNode6.Tag = "HelpMapCommandReference";
            treeNode6.Text = "Map Command Reference";
            treeNode7.Name = "LayerCommandReference";
            treeNode7.Tag = "HelpLayerCommandReference";
            treeNode7.Text = "Layer Command Reference";
            treeNode8.Name = "TileSheetCommandReference";
            treeNode8.Tag = "HelpTileSheetCommandReference";
            treeNode8.Text = "Tile Sheet Command Reference";
            treeNode9.Name = "PluginCommandReference";
            treeNode9.Tag = "HelpPluginCommandReference";
            treeNode9.Text = "Plugin Command Reference";
            treeNode10.Name = "HelpCommandReference";
            treeNode10.Tag = "HelpHelpCommandReference";
            treeNode10.Text = "Help Command Reference";
            treeNode11.Name = "CommandReference";
            treeNode11.Tag = "HelpCommandReference";
            treeNode11.Text = "Command Reference";
            treeNode11.ToolTipText = "A reference for all menu and toolbar commands";
            treeNode12.Name = "TileSelectionTool";
            treeNode12.Tag = "HelpTileSelectionTool";
            treeNode12.Text = "Tile Selection Tool";
            treeNode12.ToolTipText = "Tile selection tool";
            treeNode13.Name = "TilePlacementTool";
            treeNode13.Tag = "HelpTilePlacementTool";
            treeNode13.Text = "Tile Placement Tool";
            treeNode13.ToolTipText = "Tile placement tool";
            treeNode14.Name = "TileBlockTool";
            treeNode14.Tag = "HelpTileBlockTool";
            treeNode14.Text = "Tile Block Tool";
            treeNode15.Name = "TileEraserTool";
            treeNode15.Tag = "HelpTileEraserTool";
            treeNode15.Text = "Tile Eraser Tool";
            treeNode15.ToolTipText = "Tile eraser tool";
            treeNode16.Name = "TilePickingTool";
            treeNode16.Tag = "HelpTilePickingTool";
            treeNode16.Text = "Tile Picking Tool";
            treeNode16.ToolTipText = "Tile picking tool";
            treeNode17.Name = "TileBrushTool";
            treeNode17.Tag = "HelpTileBrushTool";
            treeNode17.Text = "Tile Brush Tool";
            treeNode17.ToolTipText = "Tile brush editing tool";
            treeNode18.Name = "EditingToolbox";
            treeNode18.Tag = "HelpEditingToolbox";
            treeNode18.Text = "Editing Toolbox";
            treeNode18.ToolTipText = "Reference for map editing tools";
            treeNode19.Name = "MapPropertiesDialog";
            treeNode19.Tag = "HelpMapPropertiesDialog";
            treeNode19.Text = "Map Properties Dialog";
            treeNode19.ToolTipText = "Map Properties dialog box";
            treeNode20.Name = "MapStatisticsDialog";
            treeNode20.Tag = "HelpMapStatisticsDialog";
            treeNode20.Text = "Map Statistics Dialog";
            treeNode20.ToolTipText = "Map statistics dialog box";
            treeNode21.Name = "CommandHistoryDialog";
            treeNode21.Tag = "HelpCommandHistoryDialog";
            treeNode21.Text = "Command History Dialog";
            treeNode21.ToolTipText = "Command history navigation dialog";
            treeNode22.Name = "LayerPropertiesDialog";
            treeNode22.Tag = "HelpLayerPropertiesDialog";
            treeNode22.Text = "Layer Properties Dialog";
            treeNode22.ToolTipText = "Layer properties dialog box";
            treeNode23.Name = "TileSheetPropertiesDialog";
            treeNode23.Tag = "HelpTileSheetPropertiesDialog";
            treeNode23.Text = "Tile Sheet Properties Dialog";
            treeNode23.ToolTipText = "Tile sheet properties dialog box";
            treeNode24.Name = "TilePropertiesDialog";
            treeNode24.Tag = "HelpTilePropertiesDialog";
            treeNode24.Text = "Tile Properties Dialog";
            treeNode24.ToolTipText = "Tile properties dialog box";
            treeNode25.Name = "TileAnimationDialog";
            treeNode25.Tag = "HelpTileAnimationDialog";
            treeNode25.Text = "Tile Animation Dialog";
            treeNode25.ToolTipText = "Tile animation dialog box";
            treeNode26.Name = "TileBrushDialog";
            treeNode26.Tag = "HelpTileBrushDialog";
            treeNode26.Text = "Tile Brush Dialog";
            treeNode26.ToolTipText = "Tile brush management dialog box";
            treeNode27.Name = "PluginInfoDialog";
            treeNode27.Tag = "HelpPluginInfoDialog";
            treeNode27.Text = "Plugin Info Dialog";
            treeNode27.ToolTipText = "Plugin information dialog box";
            treeNode28.Name = "AboutDialog";
            treeNode28.Tag = "HelpAboutDialog";
            treeNode28.Text = "About Dialog";
            treeNode28.ToolTipText = "About dialog box";
            treeNode29.Name = "DialogBoxReference";
            treeNode29.Tag = "HelpDialogBoxReference";
            treeNode29.Text = "Dialog Box Reference";
            treeNode29.ToolTipText = "A reference for all dialog boxes";
            treeNode30.Name = "tIDE";
            treeNode30.Tag = "HelptIDE";
            treeNode30.Text = "tIDE Help Topics";
            treeNode30.ToolTipText = "Overview of all the help topics";
            this.m_topicTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30});
            this.m_topicTreeView.ShowNodeToolTips = true;
            this.m_topicTreeView.Size = new System.Drawing.Size(190, 379);
            this.m_topicTreeView.TabIndex = 0;
            this.m_topicTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTopicSelect);
            // 
            // m_indexTreeView
            // 
            this.m_indexTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_indexTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_indexTreeView.Location = new System.Drawing.Point(4, 4);
            this.m_indexTreeView.Name = "m_indexTreeView";
            this.m_indexTreeView.ShowLines = false;
            this.m_indexTreeView.ShowPlusMinus = false;
            this.m_indexTreeView.Size = new System.Drawing.Size(190, 379);
            this.m_indexTreeView.TabIndex = 1;
            this.m_indexTreeView.Visible = false;
            this.m_indexTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnIndexSelect);
            // 
            // m_searchListView
            // 
            this.m_searchListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_searchListView.Location = new System.Drawing.Point(4, 4);
            this.m_searchListView.Name = "m_searchListView";
            this.m_searchListView.Size = new System.Drawing.Size(190, 379);
            this.m_searchListView.TabIndex = 2;
            this.m_searchListView.UseCompatibleStateImageBehavior = false;
            this.m_searchListView.View = System.Windows.Forms.View.List;
            this.m_searchListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnSearchResult);
            // 
            // m_contentPanel
            // 
            this.m_contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_contentPanel.BackColor = System.Drawing.SystemColors.Window;
            this.m_contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_contentPanel.Controls.Add(this.m_contentRichTextBox);
            this.m_contentPanel.Location = new System.Drawing.Point(0, 4);
            this.m_contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.m_contentPanel.Name = "m_contentPanel";
            this.m_contentPanel.Padding = new System.Windows.Forms.Padding(4);
            this.m_contentPanel.Size = new System.Drawing.Size(382, 379);
            this.m_contentPanel.TabIndex = 1;
            // 
            // m_contentRichTextBox
            // 
            this.m_contentRichTextBox.BackColor = System.Drawing.Color.White;
            this.m_contentRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_contentRichTextBox.DetectUrls = true;
            this.m_contentRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_contentRichTextBox.Location = new System.Drawing.Point(4, 4);
            this.m_contentRichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.m_contentRichTextBox.Name = "m_contentRichTextBox";
            this.m_contentRichTextBox.ReadOnly = true;
            this.m_contentRichTextBox.SelectionLink = false;
            this.m_contentRichTextBox.Size = new System.Drawing.Size(372, 369);
            this.m_contentRichTextBox.TabIndex = 0;
            this.m_contentRichTextBox.Text = "Content Pane";
            this.m_contentRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnHelpLink);
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
            this.m_toolStripContainer.LeftToolStripPanelVisible = false;
            this.m_toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.m_toolStripContainer.Name = "m_toolStripContainer";
            this.m_toolStripContainer.RightToolStripPanelVisible = false;
            this.m_toolStripContainer.Size = new System.Drawing.Size(584, 412);
            this.m_toolStripContainer.TabIndex = 1;
            // 
            // m_toolStripContainer.TopToolStripPanel
            // 
            this.m_toolStripContainer.TopToolStripPanel.Controls.Add(this.m_toolStrip);
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_helpContentsButton,
            this.m_helpIndexButton,
            this.m_helpSearchButton,
            this.m_searchTextbox});
            this.m_toolStrip.Location = new System.Drawing.Point(3, 0);
            this.m_toolStrip.Name = "m_toolStrip";
            this.m_toolStrip.Size = new System.Drawing.Size(204, 25);
            this.m_toolStrip.TabIndex = 0;
            // 
            // m_helpContentsButton
            // 
            this.m_helpContentsButton.Checked = true;
            this.m_helpContentsButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_helpContentsButton.Image = global::TileMapEditor.Properties.Resources.HelpContents;
            this.m_helpContentsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_helpContentsButton.Name = "m_helpContentsButton";
            this.m_helpContentsButton.Size = new System.Drawing.Size(75, 22);
            this.m_helpContentsButton.Text = "Contents";
            this.m_helpContentsButton.Click += new System.EventHandler(this.OnHelpContents);
            // 
            // m_helpIndexButton
            // 
            this.m_helpIndexButton.Image = global::TileMapEditor.Properties.Resources.HelpIndex;
            this.m_helpIndexButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_helpIndexButton.Name = "m_helpIndexButton";
            this.m_helpIndexButton.Size = new System.Drawing.Size(55, 22);
            this.m_helpIndexButton.Text = "Index";
            this.m_helpIndexButton.Click += new System.EventHandler(this.OnHelpIndex);
            // 
            // m_helpSearchButton
            // 
            this.m_helpSearchButton.Image = global::TileMapEditor.Properties.Resources.HelpSearch;
            this.m_helpSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_helpSearchButton.Name = "m_helpSearchButton";
            this.m_helpSearchButton.Size = new System.Drawing.Size(62, 22);
            this.m_helpSearchButton.Text = "Search";
            this.m_helpSearchButton.Click += new System.EventHandler(this.OnHelpSearch);
            // 
            // m_searchTextbox
            // 
            this.m_searchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_searchTextbox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_searchTextbox.Name = "m_searchTextbox";
            this.m_searchTextbox.Size = new System.Drawing.Size(200, 25);
            this.m_searchTextbox.Text = "enter search criteria here";
            this.m_searchTextbox.ToolTipText = "Enter search criteria here";
            this.m_searchTextbox.Visible = false;
            this.m_searchTextbox.Enter += new System.EventHandler(this.OnEnterSearchTextBox);
            this.m_searchTextbox.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.m_toolStripContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tIDE Help";
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