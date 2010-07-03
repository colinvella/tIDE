using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TileMapEditor.Help
{
    public partial class HelpForm : Form
    {
        private HelpMode m_helpMode;
        private Dictionary<string, List<string>> m_contentIndex;
        private char[] m_delimeters;
        private Dictionary<string, byte> m_keywordBlacklist;

        private void ProcessHelpLinks()
        {
            int textPos = -1;
            while (true)
            {
                ++textPos;
                textPos = m_contentRichTextBox.Find("[", textPos, RichTextBoxFinds.None);
                if (textPos == -1)
                    break;

                int start = textPos;
                int textStart = start + 1;

                ++textPos;
                textPos = m_contentRichTextBox.Find("#", textPos, RichTextBoxFinds.None);
                if (textPos == -1)
                    break;

                int hash = textPos;

                ++textPos;
                textPos = m_contentRichTextBox.Find("]", textPos, RichTextBoxFinds.None);
                if (textPos == -1)
                    break;

                int end = textPos;

                string linkText = m_contentRichTextBox.Text.Substring(textStart, hash - textStart);

                int urlStart = hash + 1;
                string linkUrl = m_contentRichTextBox.Text.Substring(urlStart, end - urlStart);

                m_contentRichTextBox.Select(start, end - start + 1);
                m_contentRichTextBox.InsertLink(linkText, linkUrl);
            }
        }

        private byte[] LoadHelpContent(string resourceName)
        {
            Type resourcesType = typeof(Properties.Resources);

            m_contentRichTextBox.Clear();

            PropertyInfo propertyInfo = resourcesType.GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic);
            if (propertyInfo == null)
            {
                MessageBox.Show(this,
                    "Content resource \"" + resourceName + "\" is not defined",
                    "Load Help Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            MethodInfo propertyAccessor = propertyInfo.GetGetMethod(true);
            object propertyValue = propertyAccessor.Invoke(this, new object[0]);

            if (!(propertyValue is byte[]))
            {
                MessageBox.Show(this, "Content resource \"" + resourceName + "\" is in the wrong format",
                    "Load Help Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte[] content = (byte[])propertyValue;
            return content;
        }

        private void ShowHelpContent(string resourceName)
        {
            byte[] content = LoadHelpContent(resourceName);
            if (content == null)
            {
                m_contentRichTextBox.Text
                    = "Error loading content resource \"" + resourceName + "\".";
                return;
            }

            try
            {
                m_contentRichTextBox.LoadFile(new MemoryStream(content), RichTextBoxStreamType.RichText);
                ProcessHelpLinks();
                m_contentRichTextBox.SelectionStart = 0;
            }
            catch (Exception exception)
            {
                m_contentRichTextBox.Text = "Error loading content resource \""
                    + resourceName + "\". Reason: " + exception;
            }
        }

        private void SelectContentNode(string resourceName)
        {
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            foreach (TreeNode treeNode in m_topicTreeView.Nodes)
                nodeStack.Push(treeNode);

            while (nodeStack.Count > 0)
            {
                TreeNode treeNode = nodeStack.Pop();
                if (treeNode.Tag != null && (string)treeNode.Tag == resourceName)
                {
                    m_topicTreeView.SelectedNode = treeNode;
                    treeNode.EnsureVisible();
                    m_topicTreeView.Select();
                    return;
                }
                else
                {
                    foreach (TreeNode childNode in treeNode.Nodes)
                        nodeStack.Push(childNode);
                }
            }

            m_topicTreeView.SelectedNode = null;
        }

        private void BuildIndex(string resourceName, byte[] resourceContent)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.LoadFile(new MemoryStream(resourceContent), RichTextBoxStreamType.RichText);
            string plainText = richTextBox.Text;

            string[] words = plainText.ToLower().Split(
                m_delimeters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                // filter out links
                if (word.Contains('#'))
                    continue;

                // filter out blacklisted words
                if (m_keywordBlacklist.ContainsKey(word))
                    continue;

                // filter out numbers
                int dummyInteger;
                if (int.TryParse(word, out dummyInteger))
                    continue;
                float dummyFloat;
                if (float.TryParse(word, out dummyFloat))
                    continue;
                double dummyDouble;
                if (double.TryParse(word, out dummyDouble))
                    continue;

                List<string> resourceNames = null;
                if (m_contentIndex.ContainsKey(word))
                    resourceNames = m_contentIndex[word];
                else
                {
                    resourceNames = new List<string>();
                    m_contentIndex[word] = resourceNames;
                }

                if (!resourceNames.Contains(resourceName))
                    resourceNames.Add(resourceName);
            }
        }

        private void BuildIndex(TreeNode topicNode)
        {
            if (topicNode.Tag != null)
            {
                string resourceName = topicNode.Tag.ToString();
                byte[] resourceContent = LoadHelpContent(resourceName);
                if (resourceContent != null)
                    BuildIndex(resourceName, resourceContent);
            }
            foreach (TreeNode subTopicNode in topicNode.Nodes)
                BuildIndex(subTopicNode);
        }

        private void BuildIndex()
        {
            foreach (TreeNode topicNode in m_topicTreeView.Nodes)
                BuildIndex(topicNode);
        }

        private void HighlightKeywords(string keyword)
        {
            int pos = -1;
            int firstSelection = -1;
            while (true)
            {
                pos = m_contentRichTextBox.Find(keyword, pos + 1, RichTextBoxFinds.WholeWord);
                if (pos == -1)
                    break;

                if (firstSelection == -1)
                    firstSelection = pos;

                m_contentRichTextBox.Select(pos, keyword.Length);
                m_contentRichTextBox.SelectionBackColor = Color.Yellow;
            }
            if (firstSelection > -1)
            {
                m_contentRichTextBox.Select(firstSelection, 0);
                m_contentRichTextBox.ScrollToCaret();
            }
        }

        private string BuildFriendlyResourceName(string resourceName)
        {
            string nodeName = "";
            foreach (char ch in resourceName)
            {
                if (char.IsUpper(ch))
                    nodeName += " ";
                nodeName += ch;
            }
            if (nodeName.StartsWith(" Help "))
                nodeName = nodeName.Substring(6);
            return nodeName;
        }

        private void OnHelpFormLoad(object sender, EventArgs eventArgs)
        {
            m_contentIndex = new Dictionary<string, List<string>>();

            // build delimeter list for keyword tokenization
            List<char> delimeters = new List<char>();
            for (char ch = '\0'; ch < char.MaxValue; ch++)
                if (!char.IsLetterOrDigit(ch) && ch != '#')
                    delimeters.Add(ch);
            m_delimeters = delimeters.ToArray();

            // get keyword blacklist
            m_keywordBlacklist = new Dictionary<string, byte>();
            string[] blacklistedKeywords = Properties.Resources.HelpKeywordBlacklist.Split(
                new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            byte by = byte.MaxValue;
            foreach (string blacklistedKeyword in blacklistedKeywords)
                m_keywordBlacklist[blacklistedKeyword] = by;
        }

        private void OnHelpClosing(object sender, FormClosingEventArgs formClosingEventArgs)
        {
            Hide();
            formClosingEventArgs.Cancel = true;
        }

        private void OnHelpContents(object sender, EventArgs eventArgs)
        {
            m_topicTreeView.Visible = true;
            m_indexTreeView.Visible = false;
            m_searchTextbox.Visible = false;
            m_searchListView.Visible = false;

            m_helpContentsButton.Checked = true;
            m_helpIndexButton.Checked = false;
            m_helpSearchButton.Checked = false;
        }

        private void OnHelpIndex(object sender, EventArgs eventArgs)
        {
            if (m_contentIndex.Count == 0)
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                BuildIndex();

                m_indexTreeView.Nodes.Clear();

                Font fontWord = this.Font;
                Font fontResource = new Font(this.Font, FontStyle.Italic);

                TreeNode rootNode = new TreeNode("Index (" + m_contentIndex.Count + " entries)");
                m_indexTreeView.Nodes.Add(rootNode);
                foreach (KeyValuePair<string, List<string>> keyValuePair in m_contentIndex)
                {
                    TreeNode wordNode = new TreeNode(keyValuePair.Key + " (" + keyValuePair.Value.Count + " topics)");
                    wordNode.NodeFont = fontWord;
                    wordNode.Tag = keyValuePair.Key;
                    foreach (string resourceName in keyValuePair.Value)
                    {
                        string nodeName = BuildFriendlyResourceName(resourceName);

                        TreeNode resourceNode = new TreeNode(nodeName);
                        resourceNode.NodeFont = fontResource;
                        resourceNode.ForeColor = Color.Gray;
                        resourceNode.Tag = resourceName;
                        wordNode.Nodes.Add(resourceNode);
                    }
                    rootNode.Nodes.Add(wordNode);
                }
                m_indexTreeView.Sort();
                m_indexTreeView.ExpandAll();

                Application.DoEvents();
                Cursor = Cursors.Default;
            }

            m_topicTreeView.Visible = false;
            m_indexTreeView.Visible = true;
            m_searchTextbox.Visible = false;
            m_searchListView.Visible = false;

            m_helpContentsButton.Checked = false;
            m_helpIndexButton.Checked = true;
            m_helpSearchButton.Checked = false;
        }

        private void OnHelpSearch(object sender, EventArgs eventArgs)
        {
            if (m_contentIndex.Count == 0)
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                BuildIndex();

                Cursor = Cursors.Default;
            }

            m_topicTreeView.Visible = false;
            m_indexTreeView.Visible = false;
            m_searchTextbox.Visible = true;
            m_searchListView.Visible = true;

            m_helpContentsButton.Checked = false;
            m_helpIndexButton.Checked = false;
            m_helpSearchButton.Checked = true;

            m_searchTextbox.Focus();
        }

        private void OnTopicSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            TreeNode treeNode = treeViewEventArgs.Node;

            m_contentRichTextBox.Clear();

            if (treeNode.Tag == null)
            {
                m_contentRichTextBox.Text = "No content associated with this node";
                return;
            }

            string resourceName = treeNode.Tag.ToString();
            ShowHelpContent(resourceName);

            m_indexTreeView.SelectedNode = null;
            m_searchListView.SelectedIndices.Clear();
        }

        private void OnIndexSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            TreeNode treeNode = treeViewEventArgs.Node;

            m_contentRichTextBox.Clear();

            if (treeNode.Level == 0)
                return;

            if (treeNode.Level == 1)
                treeNode = treeNode.Nodes[0];

            if (treeNode.Tag == null)
            {
                m_contentRichTextBox.Text = "No content associated with this node";
                return;
            }

            string resourceName = treeNode.Tag.ToString();
            ShowHelpContent(resourceName);

            HighlightKeywords(treeNode.Parent.Tag.ToString());

            m_topicTreeView.SelectedNode = null;
            m_searchListView.SelectedIndices.Clear();
        }

        private void OnEnterSearchTextBox(object sender, EventArgs eventArgs)
        {
            if (m_searchTextbox.ForeColor != SystemColors.ControlText)
            {
                m_searchTextbox.Clear();
                m_searchTextbox.ForeColor = SystemColors.ControlText;
            }
        }

        private void OnSearchTextChanged(object sender, EventArgs eventArgs)
        {
            string[] keywords = m_searchTextbox.Text.Split(new char[] { ' ' });

            Dictionary<string, byte> searchResults = new Dictionary<string,byte>();
            foreach (string keyword in keywords)
            {
                if (!m_contentIndex.ContainsKey(keyword))
                    continue;

                List<string> resourceNames = m_contentIndex[keyword];
                foreach (string resourceName in resourceNames)
                    searchResults[resourceName] = byte.MaxValue;
            }

            m_searchListView.Clear();
            foreach (string resourceName in searchResults.Keys)
            {
                string nodeName = BuildFriendlyResourceName(resourceName);
                ListViewItem listViewItem = new ListViewItem(nodeName);
                listViewItem.Tag = resourceName;
                m_searchListView.Items.Add(listViewItem);
            }

            m_topicTreeView.SelectedNode = null;
            m_indexTreeView.SelectedNode = null;
        }

        private void OnSearchResult(object sender, ListViewItemSelectionChangedEventArgs listViewItemSelectionChangedEventArgs)
        {
            if (listViewItemSelectionChangedEventArgs.ItemIndex == -1)
                return;

            ListViewItem listViewItem = listViewItemSelectionChangedEventArgs.Item;

            m_contentRichTextBox.Clear();

            if (listViewItem.Tag == null)
            {
                m_contentRichTextBox.Text = "No content associated with this node";
                return;
            }

            string resourceName = listViewItem.Tag.ToString();

            ShowHelpContent(resourceName);

            string[] keywords = m_searchTextbox.Text.Split(new char[] { ' ' });
            foreach (string keyword in keywords)
                HighlightKeywords(keyword);

            m_topicTreeView.SelectedNode = null;
            m_indexTreeView.SelectedNode = null;
        }

        private void OnHelpLink(object sender, LinkClickedEventArgs linkClickedEventArgs)
        {
            string resourceName = linkClickedEventArgs.LinkText;

            if (resourceName.Contains('#'))
            {
                resourceName = resourceName.Split('#')[1];
                ShowHelpContent(resourceName);
                SelectContentNode(resourceName);
                m_indexTreeView.SelectedNode = null;
            }
            else if (resourceName.StartsWith("http://"))
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "iexplore";
                proc.StartInfo.Arguments = resourceName;
                proc.Start();
            }
        }

        internal HelpForm()
        {
            InitializeComponent();

            m_helpMode = HelpMode.Contents;
        }

        internal HelpMode HelpMode
        {
            get { return m_helpMode; }
            set
            {
                m_helpMode = value;
                switch (m_helpMode)
                {
                    case HelpMode.Contents: OnHelpContents(this, EventArgs.Empty); break;
                    case HelpMode.Index: OnHelpIndex(this, EventArgs.Empty); break;
                    case HelpMode.Search: OnHelpSearch(this, EventArgs.Empty); break;
                }
            }
        }
    }

    internal enum HelpMode
    {
        Contents,
        Index,
        Search
    }
}
