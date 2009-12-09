using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin.Interface
{
    public interface IMenuStrip
    {
        IMenuItem AddDropDownMenu(string text);

        ReadOnlyCollection<IMenuItem> DropDownMenus { get; }
    }
}
