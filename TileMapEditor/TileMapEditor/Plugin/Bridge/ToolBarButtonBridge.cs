using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class ToolBarButtonBridge: ElementBridge, IToolBarButton
    {
        private ToolStripButton m_toolStripButton;

        internal ToolStripButton ToolStripButton
        {
            get { return m_toolStripButton; }
        }

        public ToolBarButtonBridge(ToolStripButton toolStripButton, bool readOnly)
            : base(readOnly)
        {
            m_toolStripButton = toolStripButton;
        }

        public string Id
        {
            get { return m_toolStripButton.Text; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Text = value;
            }
        }

        public System.Drawing.Image Image
        {
            get { return m_toolStripButton.Image; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Image = value;
            }
        }

        public string ToolTipText
        {
            get { return m_toolStripButton.ToolTipText; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.ToolTipText = value;
            }
        }

        public bool Enabled
        {
            get { return m_toolStripButton.Enabled; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Enabled = value;
            }
        }

        public bool Checked
        {
            get { return m_toolStripButton.Checked; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Checked = value;
            }
        }

        public object Tag
        {
            get { return m_toolStripButton.Tag; }
            set
            {
                VerifyWriteAccess();
                m_toolStripButton.Tag = value;
            }
        }

        public EventHandler EventHandler
        {
            set { m_toolStripButton.Click += value; }
        }
    }
}
