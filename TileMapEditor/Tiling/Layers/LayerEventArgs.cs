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
        private Rectangle m_viewport;

        public LayerEventArgs(Layer layer, Rectangle viewport)
        {
            m_layer = layer;
            m_viewport = viewport;
        }

        public Layer Layer { get { return m_layer; } }

        public Rectangle Viewport { get { return m_viewport; } }
    }
}
