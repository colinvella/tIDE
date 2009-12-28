using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.History
{
    internal class LayerHistoryEntry : HistoryEntry
    {
        private Map m_map;
        private int m_layerIndex;
        private Layer m_oldLayer;
        private Layer m_newLayer;
        private string m_description;

        public LayerHistoryEntry(Map map, int layerIndex,
            Layer oldLayer, Layer newLayer, string description)
        {
            m_map = map;
            m_layerIndex = layerIndex;
            m_oldLayer = oldLayer;
            m_newLayer = newLayer;
            m_description = description;
        }

        public override void Undo()
        {
            m_map.RemoveLayer(m_newLayer);
            m_map.InsertLayer(m_oldLayer, m_layerIndex);
        }

        public override void Redo()
        {
            m_map.RemoveLayer(m_oldLayer);
            m_map.InsertLayer(m_newLayer, m_layerIndex);
        }

        public override string Description
        {
            get { return m_description; }
        }
    }
}
