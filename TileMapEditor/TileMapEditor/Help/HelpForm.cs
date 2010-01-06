using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Help
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            byte[] content = Properties.Resources.HelpGettingStarted;
            m_contentRichTextBox.LoadFile(new MemoryStream(content), RichTextBoxStreamType.RichText);
        }
    }
}
