using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tIDE.Dialogs
{
    internal struct IconInfo
    {
        public bool Icon;
        public int HotSpotX;
        public int HotSpotY;
        public IntPtr BitMaskHandle;
        public IntPtr PixelData;
    }
}
