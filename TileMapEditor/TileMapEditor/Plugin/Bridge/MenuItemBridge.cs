using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class MenuItemBridge: ElementBridge, IMenuItem, IMenuItemCollection
    {
        private ToolStripMenuItem m_toolStripMenuItem;
        private List<IMenuItem> m_subItems;

        public MenuItemBridge(ToolStripMenuItem toolStripMenuItem, bool readOnly)
            : base(readOnly)
        {
            m_toolStripMenuItem = toolStripMenuItem;
            m_subItems = new List<IMenuItem>();

            foreach (ToolStripItem subItem in toolStripMenuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem)
                    m_subItems.Add(new MenuItemBridge((ToolStripMenuItem)subItem, readOnly));
            }
        }

        public IMenuItem AddSubItem(string text)
        {
            VerifyWriteAccess();

            throw new NotImplementedException();
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

        public IMenuItem AddItem(string text)
        {
            ToolStripMenuItem subItem = new ToolStripMenuItem(text);
            m_toolStripMenuItem.DropDownItems.Add(subItem);
            MenuItemBridge subItemBridge = new MenuItemBridge(subItem, false);
            m_subItems.Add(subItemBridge);
            return subItemBridge;
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
            return m_subItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_subItems.GetEnumerator();
        }
    }
}
