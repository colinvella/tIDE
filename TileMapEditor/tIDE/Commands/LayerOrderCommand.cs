using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Layers;

namespace TileMapEditor.Commands
{
    internal enum LayerOrderCommandType
    {
        BringForward,
        SendBackward
    }

    internal class LayerOrderCommand: Command
    {
        private Layer m_layer;
        private LayerOrderCommandType m_layerOrderCommandType;

        public LayerOrderCommand(Layer layer, LayerOrderCommandType layerOrderCommandType)
        {
            m_layer = layer;
            m_layerOrderCommandType = layerOrderCommandType;
            m_description = layerOrderCommandType == LayerOrderCommandType.BringForward
                ? "Bring layer \"" + layer.Id + "\" forward"
                : "Send layer \"" + layer.Id + "\" backward";
        }

        public override void Do()
        {
            if (m_layerOrderCommandType == LayerOrderCommandType.BringForward)
                m_layer.Map.BringLayerForward(m_layer);
            else
                m_layer.Map.SendLayerBackward(m_layer);
        }

        public override void Undo()
        {
            if (m_layerOrderCommandType == LayerOrderCommandType.BringForward)
                m_layer.Map.SendLayerBackward(m_layer);
            else
                m_layer.Map.BringLayerForward(m_layer);
        }
    }
}
