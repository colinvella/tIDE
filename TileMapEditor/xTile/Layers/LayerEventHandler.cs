using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xTile.Layers
{
    /// <summary>
    /// Delegate for Layer events
    /// </summary>
    /// <param name="sender">Source of layer event</param>
    /// <param name="layerEventArgs">Argument structure for Layer events</param>
    public delegate void LayerEventHandler(object sender, LayerEventArgs layerEventArgs);
}
