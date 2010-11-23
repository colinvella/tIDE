using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace tIDE.Controls
{
    [ToolboxBitmapAttribute(typeof(Panel))]
    class CustomPanel : Panel
    {
        public CustomPanel()
        {
            DoubleBuffered = true;
        }
    }
}
