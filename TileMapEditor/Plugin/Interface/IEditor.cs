using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;

namespace TileMapEditor.Plugin.Interface
{
    public interface IEditor: IElement
    {
        Map Map { get; }
        Layer Layer { get; }
    }
}
