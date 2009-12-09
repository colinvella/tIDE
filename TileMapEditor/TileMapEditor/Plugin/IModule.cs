using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin
{
    interface IModule
    {
        string Name { get; }
        Version Version { get; }
        string Manufacturer { get; }
        string Description { get; }
        Bitmap Icon { get; }

        void Load(IApplication application);
        void Unload(IApplication application);
    }
}
