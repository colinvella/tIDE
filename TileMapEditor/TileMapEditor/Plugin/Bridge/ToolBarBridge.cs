using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class ToolBarBridge: ElementBridge, IToolBar, IToolBarButtonCollection
    {
        private ToolStrip m_toolStrip;
        private List<ToolBarButtonBridge> m_toolBarButtons;

        internal ToolStrip ToolStrip { get { return m_toolStrip; } }

        public ToolBarBridge(ToolStrip toolStrip, bool readOnly)
            :base(readOnly)
        {
            m_toolStrip = toolStrip;
            m_toolBarButtons = new List<ToolBarButtonBridge>();

            foreach (ToolStripItem toolStripItem in m_toolStrip.Items)
            {
                if (!(toolStripItem is ToolStripButton))
                    continue;
                m_toolBarButtons.Add(
                    new ToolBarButtonBridge((ToolStripButton) toolStripItem , readOnly));
            }
        }

        public string Id
        {
            get { return m_toolStrip.Name; }
            set
            {
                VerifyWriteAccess();
                m_toolStrip.Name = value;
            }
        }

        public bool Enabled
        {
            get { return m_toolStrip.Enabled; }
            set
            {
                VerifyWriteAccess();
                m_toolStrip.Enabled = value;
            }
        }

        public IToolBarButtonCollection Buttons
        {
            get { return this; }
        }

        public IToolBarButton Add(string id, Image image)
        {
            ToolStripButton toolStripButton = new ToolStripButton(image);
            m_toolStrip.Items.Add(toolStripButton);
            ToolBarButtonBridge toolBarButton = new ToolBarButtonBridge(toolStripButton, false);
            m_toolBarButtons.Add(toolBarButton);
            return toolBarButton;
        }

        public void Remove(IToolBarButton toolBarButton)
        {
            ToolBarButtonBridge toolBarButtonBridge = (ToolBarButtonBridge)toolBarButton;

            if (!m_toolBarButtons.Contains(toolBarButtonBridge))
                throw new Exception(
                    "Cannot remove a toolbar button that is not contained in this toolbar");

            if (toolBarButton.ReadOnly)
                throw new Exception("Cannot remove a built-in toolbar");

            ToolStripButton toolStripButton = toolBarButtonBridge.ToolStripButton;
            toolStripButton.Owner.Items.Remove(toolStripButton);

            m_toolBarButtons.Remove(toolBarButtonBridge);
        }

        public IToolBarButton this[string id]
        {
            get
            {
                foreach (IToolBarButton toolBarButton in m_toolBarButtons)
                    if (toolBarButton.Id == id)
                        return toolBarButton;
                throw new Exception("Undefined toolbar button");
            }
        }

        public IToolBarButton this[int index]
        {
            get { return m_toolBarButtons[index]; }
        }
    }
}
