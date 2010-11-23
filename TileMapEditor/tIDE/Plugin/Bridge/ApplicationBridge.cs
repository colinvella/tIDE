using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tIDE.Commands;
using tIDE.Controls;
using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    internal class ApplicationBridge: ElementBridge, IApplication, IToolBarCollection
    {
        private CommandHistory m_commandHistory;
        private MenuStripBridge m_menuStripBridge;
        private ToolStripContainer m_toolStripContainer;
        private List<ToolBarBridge> m_toolBars;

        private EditorBridge m_editorBridge;

        private void PopulateToolBars(ToolStripPanel toolStripPanel)
        {
            foreach (System.Windows.Forms.Control control in toolStripPanel.Controls)
            {
                if (!(control is ToolStrip))
                    continue;
                m_toolBars.Add(new ToolBarBridge((ToolStrip)control, false));
            }
        }

        public ApplicationBridge(MenuStrip menuStrip,
            ToolStripContainer toolStripContainer, MapPanel mapPanel)
            : base(false)
        {
            m_commandHistory = CommandHistory.Instance;

            m_menuStripBridge = new MenuStripBridge(menuStrip);

            m_toolStripContainer = toolStripContainer;
            m_toolBars = new List<ToolBarBridge>();
            PopulateToolBars(toolStripContainer.TopToolStripPanel);
            PopulateToolBars(toolStripContainer.BottomToolStripPanel);
            PopulateToolBars(toolStripContainer.LeftToolStripPanel);
            PopulateToolBars(toolStripContainer.RightToolStripPanel);

            m_editorBridge = new EditorBridge(mapPanel);
        }

        public void Execute(ICommand command)
        {
            m_commandHistory.Do(new CommandBridge(command));
        }

        public IMenuStrip MenuStrip
        {
            get { return m_menuStripBridge; }
        }

        public IToolBarCollection ToolBars
        {
            get { return this; }
        }

        public IEditor Editor
        {
            get { return m_editorBridge; }
        }

        public IToolBar Add(string id)
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Text = id;

            ToolStripPanel toolStripPanel = m_toolStripContainer.TopToolStripPanel;

            toolStripPanel.Controls.Add(toolStrip);

            ToolBarBridge toolBarBridge = new ToolBarBridge(toolStrip, false);

            m_toolBars.Add(toolBarBridge);
            return toolBarBridge;
        }

        public void Remove(IToolBar toolBar)
        {
            ToolBarBridge toolBarBridge = (ToolBarBridge)toolBar;

            if (!m_toolBars.Contains(toolBarBridge))
                throw new Exception(
                    "Cannot remove a toolbar that is not in the tool strip container");

            if (toolBar.ReadOnly)
                throw new Exception("Cannot remove a built-in toolbar");

            ToolStrip toolStrip = toolBarBridge.ToolStrip;
            toolStrip.Parent.Controls.Remove(toolStrip);

            m_toolBars.Remove(toolBarBridge);
        }

        public IToolBar this[string id]
        {
            get
            {
                foreach (IToolBar toolBar in m_toolBars)
                    if (toolBar.Id == id)
                        return toolBar;
                throw new Exception("Undefined toolbar");
            }
        }

        public IToolBar this[int index]
        {
            get { return m_toolBars[index]; }
        }
    }
}
