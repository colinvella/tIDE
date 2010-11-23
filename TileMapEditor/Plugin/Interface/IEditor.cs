using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;
using xTile.Layers;

namespace tIDE.Plugin.Interface
{
    public interface IEditor: IElement
    {
        Map Map { get; }
        Layer Layer { get; }

        EditorHandler MouseDown { set; }
        EditorHandler MouseMove { set; }
        EditorHandler MouseUp { set; }
    }

    public delegate void EditorHandler(MouseEventArgs mouseEventArgs, Location tileLocation);
}
