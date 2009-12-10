using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin;

namespace TileMapEditor.Dialog
{
    public partial class PluginInfoDialog : Form
    {
        private IPlugin m_plugin;

        public PluginInfoDialog(IPlugin plugin)
        {
            InitializeComponent();

            m_plugin = plugin;
        }

        private void OnLoadDialog(object sender, EventArgs eventArgs)
        {
            m_pictureBoxIcon.Image = m_plugin.Icon;
            m_labelName.Text = m_plugin.Name;
            m_labelVersion.Text = "Version " + m_plugin.Version;
            m_labelAuthor.Text = m_plugin.Author;
            m_textBoxDescription.Text = m_plugin.Description;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
