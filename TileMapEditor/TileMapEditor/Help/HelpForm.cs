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
        public HelpForm()
        {
            InitializeComponent();
        }

        private void LoadHelpContent(string resourceName)
        {
            Type resourcesType = typeof(Properties.Resources);

            m_contentRichTextBox.Clear();

            PropertyInfo propertyInfo = resourcesType.GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic);
            if (propertyInfo == null)
            {
                m_contentRichTextBox.Text = "Content resource \"" + resourceName + "\" is not defined";
                return;
            }

            MethodInfo propertyAccessor = propertyInfo.GetGetMethod(true);
            object propertyValue = propertyAccessor.Invoke(this, new object[0]);

            if (!(propertyValue is byte[]))
            {
                m_contentRichTextBox.Text = "Content resource \"" + resourceName + "\" is in the wrong format";
            }

            byte[] content = (byte[])propertyValue;

            string rtf = new System.Text.ASCIIEncoding().GetString(content);
            m_contentRichTextBox.Rtf = rtf;

            try
            {
                m_contentRichTextBox.LoadFile(new MemoryStream(content), RichTextBoxStreamType.RichText);

                int textPos = -1;
                //string rtf = m_contentRichTextBox.Rtf;
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
                    m_contentRichTextBox.InsertLink(linkText, linkUrl, start);
                }
            }
            catch (Exception exception)
            {
                m_contentRichTextBox.Text = "Error loading content resource \""
                    + resourceName + "\". Reason: " + exception;
            }
        }

        private void OnHelpFormLoad(object sender, EventArgs eventArgs)
        {
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

            LoadHelpContent(resourceName);
        }

        private void OnHelpLink(object sender, LinkClickedEventArgs linkClickedEventArgs)
        {
            string resourceName = linkClickedEventArgs.LinkText.Replace("http://", "");
            LoadHelpContent(resourceName);
        }
    }
}
