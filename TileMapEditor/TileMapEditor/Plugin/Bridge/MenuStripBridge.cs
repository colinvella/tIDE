using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class MenuStripBridge:
        ElementBridge, IMenuStrip, IMenuItemCollection
    {
        private MenuStrip m_menuStrip;
        private List<IMenuItem> m_dropDownMenus;

        public MenuStripBridge(MenuStrip menuStrip)
            : base(false)
        {
            m_menuStrip = menuStrip;
            m_dropDownMenus = new List<IMenuItem>();

            foreach (ToolStripMenuItem dropDownMenu in m_menuStrip.Items)
                m_dropDownMenus.Add(new MenuItemBridge(dropDownMenu, true));
        }

        public IMenuItemCollection DropDownMenus
        {
            get { return this; }
        }

        public IMenuItem AddItem(string text)
        {
            ToolStripMenuItem dropDownMenu = new ToolStripMenuItem(text);
            m_menuStrip.Items.Add(dropDownMenu);
            IMenuItem dropDownMenuBridge = new MenuItemBridge(dropDownMenu, false);
            m_dropDownMenus.Add(dropDownMenuBridge);
            return dropDownMenuBridge;
        }

        public IMenuItem this[string text]
        {
            get
            {
                foreach (IMenuItem dropDownMenu in m_dropDownMenus)
                    if (dropDownMenu.Text == text)
                        return dropDownMenu;
                throw new Exception("Undefined drop-down menu");
            }
        }

        public IMenuItem this[int index]
        {
            get { return m_dropDownMenus[index]; }
        }

        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return m_dropDownMenus.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_dropDownMenus.GetEnumerator();
        }
    }
}
