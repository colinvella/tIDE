using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using tIDE.Plugin.Interface;

namespace tIDE.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        Version Version { get; }
        string Author { get; }
        string Description { get; }
        Bitmap SmallIcon { get; }
        Bitmap LargeIcon { get; }

        void Initialise(IApplication application);
        void Shutdown(IApplication application);
    }
}
