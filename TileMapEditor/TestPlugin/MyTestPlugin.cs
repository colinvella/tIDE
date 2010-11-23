using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;

using tIDE.Plugin;
using tIDE.Plugin.Interface;

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
            m_myDropDownMenu = application.MenuStrip.DropDownMenus.Add("My Custom Menu");
            m_myDropDownMenu.Image = Properties.Resources.Menu;

            m_myMenuItem = application.MenuStrip.DropDownMenus["My Custom Menu"].SubItems.Add("My Menu Item 1");
            m_myMenuItem.Image = Properties.Resources.Action;
            m_myMenuItem.ShortcutKeys = (Keys)(Keys.Control | Keys.Z);
            m_myMenuItem.EventHandler = MyCustomAction;

            m_myToolBar = application.ToolBars.Add("MyToolBar");

            m_myToolBarButton1 = m_myToolBar.Buttons.Add("Button1", Properties.Resources.Action);
            m_myToolBarButton1.ToolTipText = "My ToolStrip Button 1";
            m_myToolBarButton1.Checked = true;
            m_myToolBarButton1.EventHandler = MyCustomAction;

            m_myToolBarButton2 = m_myToolBar.Buttons.Add("Button2", Properties.Resources.Action);
            m_myToolBarButton2.ToolTipText = "My second toolbar button";
            m_myToolBarButton2.Enabled = false;

            application.Editor.MouseDown = OnEditorMouseDown;
        }

        public void Shutdown(IApplication application)
        {
            m_myToolBarButton1 = m_myToolBarButton2 = null;

            application.ToolBars.Remove(m_myToolBar);
            m_myToolBar = null;

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
