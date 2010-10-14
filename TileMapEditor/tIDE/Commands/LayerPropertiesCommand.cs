using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Layers;
using xTile.Dimensions;
using xTile.ObjectModel;
using xTile.Tiles;
using TileMapEditor.Controls;

namespace TileMapEditor.Commands
{
    internal class LayerPropertiesCommand: Command
    {
        private Layer m_layer;
        private string m_oldId, m_newId;
        private string m_oldDescription, m_newDescription;
        private Size m_oldLayerSize, m_newLayerSize;
        private Size m_oldTileSize, m_newTileSize;
        private bool m_oldVisibility, m_newVisibility;
        private PropertyCollection m_oldProperties, m_newProperties;
        private LayerOffsetCommand m_layerOffsetCommand;
        private Alignment m_layerAlignment;

        public LayerPropertiesCommand(Layer layer, string newId, string newDescription,
            Size newLayerSize, Size newTileSize, bool newVisibility, PropertyCollection newProperties,
            Alignment layerAlignment)
        {
            m_layer = layer;

            m_oldId = layer.Id;
            m_oldDescription = layer.Description;
            m_oldLayerSize = layer.LayerSize;
            m_oldTileSize = layer.TileSize;
            m_oldVisibility = layer.Visible;
            m_oldProperties = new PropertyCollection(layer.Properties);

            m_newId = newId;
            m_newDescription = newDescription;
            m_newLayerSize = newLayerSize;
            m_newTileSize = newTileSize;
            m_newVisibility = newVisibility;
            m_newProperties = newProperties;

            m_layerAlignment = layerAlignment;
        }

        public override void Do()
        {
            m_layer.Id = m_newId;
            m_layer.Description = m_newDescription;
            m_layer.LayerSize = m_newLayerSize;
            m_layer.TileSize = m_newTileSize;
            m_layer.Visible = m_newVisibility;
            m_layer.Properties.Clear();
            m_layer.Properties.CopyFrom(m_newProperties);

            if (m_layerAlignment != Alignment.TopLeft)
            {
                Location offset = Location.Origin;
                switch (m_layerAlignment)
                {
                    case Alignment.Top:
                        offset.X = (m_newLayerSize.Width - m_layer.LayerSize.Width) / 2;
                        break;
                    case Alignment.TopRight:
                        offset.X = m_newLayerSize.Width - m_layer.LayerSize.Width;
                        break;
                    case Alignment.Left:
                        offset.Y = (m_newLayerSize.Height - m_layer.LayerSize.Height) / 2;
                        break;
                    case Alignment.Centre:
                        offset.X = (m_newLayerSize.Width - m_layer.LayerSize.Width) / 2;
                        offset.Y = (m_newLayerSize.Height - m_layer.LayerSize.Height) / 2;
                        break;
                    case Alignment.Right:
                        offset.X = m_newLayerSize.Width - m_layer.LayerSize.Width;
                        offset.Y = (m_newLayerSize.Height - m_layer.LayerSize.Height) / 2;
                        break;
                    case Alignment.BottomLeft:
                        offset.Y = m_newLayerSize.Height - m_layer.LayerSize.Height;
                        break;
                    case Alignment.Bottom:
                        offset.X = (m_newLayerSize.Width - m_layer.LayerSize.Width) / 2;
                        offset.Y = m_newLayerSize.Height - m_layer.LayerSize.Height;
                        break;
                    case Alignment.BottomRight:
                        offset.X = m_newLayerSize.Width - m_layer.LayerSize.Width;
                        offset.Y = m_newLayerSize.Height - m_layer.LayerSize.Height;
                        break;
                }
                m_layerOffsetCommand = new LayerOffsetCommand(m_layer, offset, false, false);
                m_layerOffsetCommand.Do();
            }

            m_description = "Change properties for layer \"" + m_newId + "\"";
        }

        public override void Undo()
        {
            if (m_layerOffsetCommand != null)
                m_layerOffsetCommand.Undo();

            m_layer.Id = m_oldId;
            m_layer.Description = m_oldDescription;
            m_layer.LayerSize = m_oldLayerSize;
            m_layer.TileSize = m_oldTileSize;
            m_layer.Visible = m_oldVisibility;
            m_layer.Properties.Clear();
            m_layer.Properties.CopyFrom(m_oldProperties);

            m_description = "Change properties for layer \"" + m_oldId + "\"";
        }
    }
}
