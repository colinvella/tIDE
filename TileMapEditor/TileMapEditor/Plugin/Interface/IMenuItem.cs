using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Plugin.Interface
{
    public interface IMenuItem: IElement
    {
        IMenuItem AddSubItem(string text);

        string Text { get; set; }
        Image Image { get; set; }
        Keys ShortcutKeys { get; set; }
        ReadOnlyCollection<IMenuItem> SubItems { get; }
        EventHandler EventHandler { set; }
    }
}
