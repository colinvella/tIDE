using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class ToolBarBridge: ElementBridge, IToolBar
    {
        private ToolStrip m_toolStrip;
        private List<ToolBarButtonBridge> m_toolBarButtons;

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

        public IToolBarButton Add(string id, Image image)
        {
            ToolStripButton toolStripButton = new ToolStripButton(id, image);
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
