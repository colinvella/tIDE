using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IApplication
    {
        IMenuStrip MenuStrip { get; }

        IToolBarCollection ToolBars { get; }
    }
}
