using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.History
{
    internal abstract class HistoryEntry
    {
        public abstract void Undo();

        public abstract void Redo();

        public abstract string Description { get; }
    }
}
