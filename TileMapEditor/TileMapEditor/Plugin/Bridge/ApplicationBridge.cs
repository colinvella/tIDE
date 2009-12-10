using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class ApplicationBridge: ElementBridge, IApplication
    {
        private MenuStripBridge m_menuStripBridge;

        public ApplicationBridge(MenuStrip menuStrip)
            : base(false)
        {
            m_menuStripBridge = new MenuStripBridge(menuStrip);
        }

        public IMenuStrip MenuStrip
        {
            get { return m_menuStripBridge; }
        }
    }
}
