using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IToolBar: IElement
    {
        string Id { get; set; }

        bool Enabled { get; set; }

        IToolBarButtonCollection Buttons { get; }
    }
}
