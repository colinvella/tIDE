using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Commands
{
    internal abstract class Command
    {
        public abstract void Do();
        public abstract void Undo();

        public abstract string Description { get; }
    }
}
