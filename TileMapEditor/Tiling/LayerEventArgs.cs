using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class LayerEventArgs
    {
        private Map m_map;
        private Rectangle m_viewPort;

        public LayerEventArgs(Map map, Rectangle viewPort)
        {
            m_map = map;
            m_viewPort = viewPort;
        }

        public Map Map { get { return m_map; } }

        public Rectangle ViewPort { get { return m_viewPort; } }
    }
}
