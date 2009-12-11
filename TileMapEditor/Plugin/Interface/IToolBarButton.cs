using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace TileMapEditor.Plugin.Interface
{
    public interface IToolBarButton: IElement
    {
        string Id { get; set; }

        Image Image { get; set; }

        string ToolTipText { get; set; }

        bool Enabled { get; set; }

        bool Checked { get; set; }

        object Tag { get; set; }

        EventHandler EventHandler { set; }
    }
}
