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
        private Dictionary<string, List<string>> m_contentIndex;
        private char[] m_delimeters;

        public HelpForm()
        {
            InitializeComponent();
        }

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
                m_contentRichTextBox.SelectedText = " ";
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
            }
            catch (Exception exception)
            {
                m_contentRichTextBox.Text = "Error loading content resource \""
                    + resourceName + "\". Reason: " + exception;
            }
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
            while (true)
            {
                pos = m_contentRichTextBox.Find(keyword, pos + 1, RichTextBoxFinds.WholeWord);
                if (pos == -1)
                    break;
                m_contentRichTextBox.Select(pos, keyword.Length);
                m_contentRichTextBox.SelectionBackColor = Color.Yellow;
            }
        }

        private void OnHelpFormLoad(object sender, EventArgs eventArgs)
        {
            m_contentIndex = new Dictionary<string, List<string>>();

            List<char> delimeters = new List<char>();
            for (char ch = '\0'; ch < (char)255; ch++)
                if (!char.IsLetterOrDigit(ch))
                    delimeters.Add(ch);
            m_delimeters = delimeters.ToArray();
        }

        private void OnHelpIndex(object sender, EventArgs eventArgs)
        {
            if (m_contentIndex.Count == 0)
            {
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
                        string nodeName = "";
                        foreach (char ch in resourceName)
                        {
                            if (char.IsUpper(ch))
                                nodeName += " ";
                            nodeName += ch;
                        }
                        if (nodeName.StartsWith(" Help "))
                            nodeName = nodeName.Substring(6);

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
            }

            m_topicTreeView.Visible = false;
            m_indexTreeView.Visible = true;

            m_helpContentsButton.Checked = false;
            m_helpIndexButton.Checked = true;
        }

        private void OnHelpContents(object sender, EventArgs eventArgs)
        {
            m_topicTreeView.Visible = true;
            m_indexTreeView.Visible = false;

            m_helpContentsButton.Checked = true;
            m_helpIndexButton.Checked = false;
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
        }

        private void OnHelpLink(object sender, LinkClickedEventArgs linkClickedEventArgs)
        {
            string resourceName = linkClickedEventArgs.LinkText;

            if (resourceName.Contains('#'))
            {
                resourceName = resourceName.Split('#')[1];
                ShowHelpContent(resourceName);
                m_topicTreeView.SelectedNode = null;
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
    }
}
