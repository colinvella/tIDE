using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface ICommand
    {
        void Do();
        void Undo();

        string Description { get; }
    }
}
