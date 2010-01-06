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

            Type resourcesType = typeof(Properties.Resources);

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

            byte[] content = (byte[]) propertyValue;
            try
            {
                m_contentRichTextBox.LoadFile(new MemoryStream(content), RichTextBoxStreamType.RichText);
            }
            catch (Exception exception)
            {
                m_contentRichTextBox.Text = "Error loading content resource \""
                    + resourceName + "\". Reason: " + exception;
            }
        }
    }
}
