using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IToolBar
    {
        IToolBarButton Add(string id, Image image);
        void Remove(IToolBarButton toolBarButton);

        IToolBarButton this[string id] { get; }
        IToolBarButton this[int index] { get; }
    }
}
