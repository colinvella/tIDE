using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IToolBar
    {
        IToolBarButton Add(string text);
        void Remove(IToolBarButton toolBarButton);

        IToolBarButton this[string id] { get; }
        IToolBarButton this[int index] { get; }
    }
}
