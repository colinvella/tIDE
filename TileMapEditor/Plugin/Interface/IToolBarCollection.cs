using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IToolBarCollection
    {
        IToolBar Add(string id);
        void Remove(IToolBar toolBar);

        IToolBar this[string id] { get; }
        IToolBar this[int index] { get; }
    }
}
