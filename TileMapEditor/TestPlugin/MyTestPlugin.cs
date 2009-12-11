using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

using TileMapEditor.Plugin;
using TileMapEditor.Plugin.Interface;

namespace TestPlugin
{
    public class MyTestPlugin : IPlugin
    {
        private IMenuItem m_myDropDownMenu;
        private IMenuItem m_myMenuItem;
        private IToolBar m_myToolBar;
        private IToolBarButton m_myToolBarButton1, m_myToolBarButton2;

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
            m_myDropDownMenu = application.MenuStrip.DropDownMenus.Add("My Custom Drop-Down Menu!");
            m_myDropDownMenu.Image = Properties.Resources.SmallIcon;

            m_myMenuItem = application.MenuStrip.DropDownMenus["&File"].SubItems.Add("My custom menu item!");
            m_myMenuItem.Image = Properties.Resources.SmallIcon;
            m_myMenuItem.ShortcutKeys = (Keys)(Keys.Control | Keys.Z);
            m_myMenuItem.EventHandler = MyCustomAction;

            m_myToolBar = application.ToolBars.Add("MyToolBar");

            m_myToolBarButton1 = m_myToolBar.Buttons.Add("Button1", Properties.Resources.SmallIcon);
            m_myToolBarButton1.ToolTipText = "My first toolbar button";
            m_myToolBarButton1.Checked = true;
            m_myToolBarButton1.EventHandler = MyCustomAction;

            m_myToolBarButton2 = m_myToolBar.Buttons.Add("Button2", Properties.Resources.SmallIcon);
            m_myToolBarButton2.ToolTipText = "My second toolbar button";
            m_myToolBarButton2.Enabled = false;

            application.Editor.MouseDown = OnEditorMouseDown;
        }

        public void Shutdown(IApplication application)
        {
            application.ToolBars.Remove(m_myToolBar);
            m_myToolBar = null;
            m_myToolBarButton1 = m_myToolBarButton2 = null;

            application.MenuStrip.DropDownMenus["&File"].SubItems.Remove(m_myMenuItem);
            m_myMenuItem = null;

            application.MenuStrip.DropDownMenus.Remove(m_myDropDownMenu);
            m_myDropDownMenu = null;
        }

        public void MyCustomAction(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("My custom action!");
        }

        public void OnEditorMouseDown(MouseEventArgs mouseEventArgs, Location tileLocation)
        {
            //MessageBox.Show("Tile location = " + tileLocation);
        }

        #endregion
    }
}
