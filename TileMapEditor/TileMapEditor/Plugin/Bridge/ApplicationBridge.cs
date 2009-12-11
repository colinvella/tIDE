using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class ApplicationBridge: ElementBridge, IApplication, IToolBarCollection
    {
        private MenuStripBridge m_menuStripBridge;
        private List<ToolBarBridge> m_toolBars;

        private void PopulateToolBars(ToolStripPanel toolStripPanel)
        {
            foreach (System.Windows.Forms.Control control in toolStripPanel.Controls)
            {
                if (!(control is ToolStrip))
                    continue;
                m_toolBars.Add(new ToolBarBridge((ToolStrip)control, false));
            }
        }

        public ApplicationBridge(MenuStrip menuStrip, ToolStripContainer toolStripContainer)
            : base(false)
        {
            m_menuStripBridge = new MenuStripBridge(menuStrip);

            m_toolBars = new List<ToolBarBridge>();
            PopulateToolBars(toolStripContainer.TopToolStripPanel);
            PopulateToolBars(toolStripContainer.BottomToolStripPanel);
            PopulateToolBars(toolStripContainer.LeftToolStripPanel);
            PopulateToolBars(toolStripContainer.TopToolStripPanel);
        }

        public IMenuStrip MenuStrip
        {
            get { return m_menuStripBridge; }
        }

        public IToolBarCollection ToolBars
        {
            get { return this; }
        }

        public IToolBar Add(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(IToolBar toolBar)
        {
            throw new NotImplementedException();
        }

        public IToolBar this[string id]
        {
            get { throw new NotImplementedException(); }
        }

        public IToolBar this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
