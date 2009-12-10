using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin
{
    interface IPlugin
    {
        string Name { get; }
        Version Version { get; }
        string Author { get; }
        string Description { get; }
        Bitmap Icon { get; }

        void Initialise(IApplication application);
        void Shutdown(IApplication application);
    }
}
