using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.TileBrushes
{
    internal class TileBrushCollection
    {
        private List<TileBrush> m_tileBrushes;

        public TileBrushCollection()
        {
            m_tileBrushes = new List<TileBrush>();
        }

        public TileBrushCollection(TileBrushCollection tileBrushCollection)
        {
            m_tileBrushes = new List<TileBrush>();
            foreach (TileBrush tileBrush in tileBrushCollection.TileBrushes)
                m_tileBrushes.Add(new TileBrush(tileBrush));
        }

        public string GenerateId()
        {
            List<string> currentIds = new List<string>();
            foreach (TileBrush tileBrush in m_tileBrushes)
                currentIds.Add(tileBrush.Id);

            int newIdIndex = 1;
            string newId = "Tile Brush " + newIdIndex;
            while (currentIds.Contains(newId))
            {
                ++newIdIndex;
                newId = "Tile Brush " + newIdIndex;
            }

            return newId;
        }

        public List<TileBrush> TileBrushes
        {
            get { return m_tileBrushes; }
        }
    }
}
