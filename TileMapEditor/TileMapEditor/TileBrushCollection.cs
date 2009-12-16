using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor
{
    internal class TileBrushCollection
    {
        private List<TileBrush> m_tileBrushes;

        public TileBrushCollection()
        {
            m_tileBrushes = new List<TileBrush>();
        }

        public List<TileBrush> TileBrushes
        {
            get { return m_tileBrushes; }
        }
    }
}
