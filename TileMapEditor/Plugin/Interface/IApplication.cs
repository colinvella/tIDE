using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;

namespace tIDE.Plugin.Interface
{
    public interface IApplication
    {
        void Execute(ICommand command);

        IMenuStrip MenuStrip { get; }

        IToolBarCollection ToolBars { get; }

        IEditor Editor { get; }
    }
}
