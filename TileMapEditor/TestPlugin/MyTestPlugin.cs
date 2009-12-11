using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Plugin;
using TileMapEditor.Plugin.Interface;

namespace TestPlugin
{
    public class MyTestPlugin : IPlugin
    {
        private IMenuItem m_myDropDownMenu;
        private IMenuItem m_myMenuItem;

        #region IPlugin Members

        public string Name
        {
            get { return "My Test Plugin"; }
        }

        public Version Version
        {
            get { return new Version(1, 0); }
        }

        public string Author
        {
            get { return "Colin Vella"; }
        }

        public string Description
        {
            get {return "This is a description for the plugin"; }
        }

        public System.Drawing.Bitmap SmallIcon
        {
            get
            {
                return Properties.Resources.SmallIcon;
            }
        }

        public System.Drawing.Bitmap LargeIcon
        {
            get
            {
                return Properties.Resources.LargeIcon;
            }
        }

        public void Initialise(IApplication application)
        {
            m_myDropDownMenu = application.MenuStrip.DropDownMenus.AddItem("My Custom Drop-Down Menu!");
            m_myDropDownMenu.Image = Properties.Resources.SmallIcon;

            m_myMenuItem = application.MenuStrip.DropDownMenus["&File"].SubItems.AddItem("My custom menu item!");
            m_myMenuItem.Image = Properties.Resources.SmallIcon;
            m_myMenuItem.ShortcutKeys = (Keys)(Keys.Control | Keys.Z);
            m_myMenuItem.EventHandler = MyCustomAction;
        }

        public void Shutdown(IApplication application)
        {
            application.MenuStrip.DropDownMenus["&File"].SubItems.RemoveItem(m_myMenuItem);
            m_myMenuItem = null;

            application.MenuStrip.DropDownMenus.RemoveItem(m_myDropDownMenu);
            m_myDropDownMenu = null;
        }

        public void MyCustomAction(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("My custom action!");
        }

        #endregion
    }
}
