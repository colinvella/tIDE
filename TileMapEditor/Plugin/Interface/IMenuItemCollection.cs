using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tIDE.Plugin.Interface
{
    public interface IMenuItemCollection: IEnumerable<IMenuItem>
    {
        IMenuItem Add(string text);
        void Remove(IMenuItem menuItem);

        IMenuItem this[string text] { get; }
        IMenuItem this[int index] { get; }
    }
}
