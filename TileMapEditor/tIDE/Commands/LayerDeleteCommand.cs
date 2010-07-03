using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile;
using XTile.Layers;

using TileMapEditor.Controls;

namespace TileMapEditor.Commands
{
    internal class LayerDeleteCommand: Command
    {
        private Map m_map;
        private Layer m_layer;
        private int m_layerIndex;
        private MapTreeView m_mapTreeView;

        public LayerDeleteCommand(Map map, Layer layer, MapTreeView mapTreeView)
        {
            m_map = map;
            m_layer = layer;
            m_layerIndex = map.Layers.IndexOf(layer);
            m_mapTreeView = mapTreeView;
            m_description = "Delete layer \"" + layer.Id + "\"";
        }

        public override void Do()
        {
            m_map.RemoveLayer(m_layer);

            m_mapTreeView.UpdateTree();
        }

        public override void Undo()
        {
            m_map.InsertLayer(m_layer, m_layerIndex);

            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = m_layer;
        }
    }
}
