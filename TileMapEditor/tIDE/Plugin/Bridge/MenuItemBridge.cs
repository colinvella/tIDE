using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tIDE.Plugin.Interface;

namespace tIDE.Plugin.Bridge
{
    internal class MenuItemBridge: ElementBridge, IMenuItem, IMenuItemCollection
    {
        private ToolStripMenuItem m_toolStripMenuItem;
        private List<MenuItemBridge> m_subItems;

        internal ToolStripMenuItem ToolStripMenuItem
        {
            get { return m_toolStripMenuItem; }
        }

        public MenuItemBridge(ToolStripMenuItem toolStripMenuItem, bool readOnly)
            : base(readOnly)
        {
            m_toolStripMenuItem = toolStripMenuItem;
            m_subItems = new List<MenuItemBridge>();

            foreach (ToolStripItem subItem in toolStripMenuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem)
                    m_subItems.Add(new MenuItemBridge((ToolStripMenuItem)subItem, readOnly));
            }
        }

        public string Text
        {
            get { return m_toolStripMenuItem.Text; }
            set
            {
                VerifyWriteAccess();
                m_toolStripMenuItem.Text = value;
            }
        }

        public System.Drawing.Image Image
        {
            get { return m_toolStripMenuItem.Image; }
            set
            {
                VerifyWriteAccess();
                m_toolStripMenuItem.Image = value;
            }
        }

        public System.Windows.Forms.Keys ShortcutKeys
        {
            get { return m_toolStripMenuItem.ShortcutKeys; }
            set
            {
                VerifyWriteAccess();
                m_toolStripMenuItem.ShortcutKeys = value;
            }
        }

        public bool Enabled
        {
            get { return m_toolStripMenuItem.Enabled; }
            set { m_toolStripMenuItem.Enabled = value; }
        }

        public bool Visible
        {
            get { return m_toolStripMenuItem.Visible; }
            set { m_toolStripMenuItem.Visible = value; }
        }

        public object Tag
        {
            get { return m_toolStripMenuItem.Tag; }
            set { m_toolStripMenuItem.Tag = value; }
        }

        public IMenuItemCollection SubItems
        {
            get { return this; }
        }

        public EventHandler EventHandler
        {
            set
            {
                VerifyWriteAccess();
                m_toolStripMenuItem.Click += value;
            }
        }

        public IMenuItem Add(string text)
        {
            ToolStripMenuItem subItem = new ToolStripMenuItem(text);
            m_toolStripMenuItem.DropDownItems.Add(subItem);
            MenuItemBridge subItemBridge = new MenuItemBridge(subItem, false);
            m_subItems.Add(subItemBridge);
            return subItemBridge;
        }

        public void Remove(IMenuItem menuItem)
        {
            MenuItemBridge subItemBridge = (MenuItemBridge)menuItem;

            if (!m_subItems.Contains(subItemBridge))
                throw new Exception(
                    "Cannot remove a menu item that is not contained in this drop-down menu");

            if (menuItem.ReadOnly)
                throw new Exception("Cannot remove a built-in menu item");

            ToolStripMenuItem subItem = subItemBridge.m_toolStripMenuItem;
            subItem.Owner.Items.Remove(subItem);

            m_subItems.Remove(subItemBridge);
        }

        public IMenuItem this[string text]
        {
            get
            {
                foreach (IMenuItem subItem in m_subItems)
                    if (subItem.Text == text)
                        return subItem;
                throw new Exception("Undefined sub-item");
            }
        }

        public IMenuItem this[int index]
        {
            get { return m_subItems[index]; }
        }


        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return m_subItems.Cast<IMenuItem>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_subItems.GetEnumerator();
        }
    }
}
