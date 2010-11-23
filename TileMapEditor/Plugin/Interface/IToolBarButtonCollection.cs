using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace tIDE.Plugin.Interface
{
    public interface IToolBarButtonCollection
    {
        IToolBarButton Add(string id, Image image);
        void Remove(IToolBarButton toolBarButton);

        IToolBarButton this[string id] { get; }
        IToolBarButton this[int index] { get; }
    }
}
