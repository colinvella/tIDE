using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Controls
{
    class CustomListView: ListView
    {
        public CustomListView()
        {
            DoubleBuffered = true;
        }
    }
}
