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
        private double m_fadeDirection;

        private void OnLoadDialog(object sender, EventArgs eventArgs)
        {
            m_labelName.Text = m_plugin.Name;
            m_labelVersion.Text = "Version " + m_plugin.Version;
            m_labelAuthor.Text = m_plugin.Author;
            m_textBoxDescription.Text = m_plugin.Description;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            m_fadeDirection = -0.05;
            m_timer.Enabled = true;
        }

        private void OnPaint(object sender, PaintEventArgs paintEventArgse)
        {
            Graphics graphics = paintEventArgse.Graphics;
            graphics.DrawImage(m_plugin.LargeIcon, 14, 14);
        }

        private void OnTimer(object sender, EventArgs eventArgs)
        {
            Opacity += m_fadeDirection;
            if (Opacity >= 1.0)
                m_timer.Enabled = false;
            else if (Opacity <= 0.0)
                Close();
        }

        public PluginInfoDialog(IPlugin plugin)
        {
            InitializeComponent();

            m_plugin = plugin;
            m_fadeDirection = 0.05;
        }
    }
}
