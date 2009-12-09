using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    internal class MenuItemBridge: ElementBridge, IMenuItem
    {
        private ToolStripMenuItem m_toolStripMenuItem;
        private List<IMenuItem> m_subItems;

        public MenuItemBridge(ToolStripMenuItem toolStripMenuItem, bool readOnly)
            : base(readOnly)
        {
            m_toolStripMenuItem = toolStripMenuItem;
            m_subItems = new List<IMenuItem>();
            foreach (ToolStripMenuItem subItem in toolStripMenuItem.DropDownItems)
            {
                MenuItemBridge subItemBridge = new MenuItemBridge(subItem, readOnly);
                subItemBridge.Image = subItem.Image;
                subItemBridge.ShortcutKeys = subItem.ShortcutKeys;
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

        public ReadOnlyCollection<IMenuItem> SubItems
        {
            get { return m_subItems.AsReadOnly(); }
        }

        public EventHandler EventHandler
        {
            set
            {
                VerifyWriteAccess();
                m_toolStripMenuItem.Click += value;
            }
        }
    }
}
