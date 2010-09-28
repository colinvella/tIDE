using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TileMapEditor.Controls
{
    [ToolboxBitmapAttribute(typeof(ListView))]
    class CustomListView : ListView
    {
        public CustomListView()
        {
            DoubleBuffered = true;
        }
    }
}
