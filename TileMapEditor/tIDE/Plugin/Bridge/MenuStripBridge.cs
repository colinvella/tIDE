using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    internal class MenuStripBridge:
        ElementBridge, IMenuStrip, IMenuItemCollection
    {
        private MenuStrip m_menuStrip;
        private List<MenuItemBridge> m_dropDownMenus;

        public MenuStripBridge(MenuStrip menuStrip)
            : base(false)
        {
            m_menuStrip = menuStrip;
            m_dropDownMenus = new List<MenuItemBridge>();

            foreach (ToolStripMenuItem dropDownMenu in m_menuStrip.Items)
                m_dropDownMenus.Add(new MenuItemBridge(dropDownMenu, true));
        }

        public IMenuItemCollection DropDownMenus
        {
            get { return this; }
        }

        public IMenuItem Add(string text)
        {
            ToolStripMenuItem dropDownMenu = new ToolStripMenuItem(text);
            m_menuStrip.Items.Add(dropDownMenu);
            MenuItemBridge dropDownMenuBridge = new MenuItemBridge(dropDownMenu, false);
            m_dropDownMenus.Add(dropDownMenuBridge);
            return dropDownMenuBridge;
        }

        public void Remove(IMenuItem menuItem)
        {
            MenuItemBridge subItemBridge = (MenuItemBridge)menuItem;

            if (!m_dropDownMenus.Contains(subItemBridge))
                throw new Exception(
                    "Cannot remove a drop-down menu that is not contained in this menu strip");

            if (menuItem.ReadOnly)
                throw new Exception("Cannot remove a built-in drop-down menu");

            ToolStripMenuItem subItem = subItemBridge.ToolStripMenuItem;
            subItem.Owner.Items.Remove(subItem);

            m_dropDownMenus.Remove(subItemBridge);
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
            return m_dropDownMenus.Cast<IMenuItem>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_dropDownMenus.GetEnumerator();
        }
    }
}
