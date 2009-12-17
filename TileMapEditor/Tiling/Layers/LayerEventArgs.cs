using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;

namespace Tiling.Layers
{
    public class LayerEventArgs
    {
        private Layer m_layer;
        private Rectangle m_viewPort;

        public LayerEventArgs(Layer layer, Rectangle viewPort)
        {
            m_layer = layer;
            m_viewPort = viewPort;
        }

        public Layer Layer { get { return m_layer; } }

        public Rectangle ViewPort { get { return m_viewPort; } }
    }
}
