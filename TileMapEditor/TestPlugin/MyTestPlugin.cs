using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using TileMapEditor.Plugin;
using TileMapEditor.Plugin.Interface;

namespace TestPlugin
{
    public class MyTestPlugin : IPlugin
    {
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

        public System.Drawing.Bitmap Icon
        {
            get
            {
                Bitmap bitmap = new Bitmap(16, 16);
                bitmap.SetPixel(0, 0, Color.Red);
                return bitmap;
            }
        }

        public void Initialise(IApplication application)
        {
            application.MenuStrip.DropDownMenus.AddItem("My dropdown menu!");
        }

        public void Shutdown(IApplication application)
        {
            
        }

        #endregion
    }
}
