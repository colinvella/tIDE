using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Layers;
using xTile.Dimensions;
using xTile.ObjectModel;
using xTile.Tiles;

namespace TileMapEditor.Commands
{
    internal class LayerOffsetCommand: Command
    {
        private Layer m_layer;
        private Location m_offset;
        private bool m_wrapHorizontally;
        private bool m_wrapVertically;
        private Tile[,] m_tiles;

        public LayerOffsetCommand(Layer layer, Location offset,
            bool wrapHorizontally, bool wrapVertically)
        {
            m_layer = layer;
            m_offset = offset;
            m_wrapHorizontally = wrapHorizontally;
            m_wrapVertically = wrapVertically;
            m_tiles = null;

            m_description = "Offset layer \"" + m_layer.Id + "\" by " + m_offset + " tiles ";
            if (m_wrapHorizontally && m_wrapVertically)
                m_description += "with horizontal and vertical wrapping";
            else if (m_wrapHorizontally)
                m_description += "with horizontal wrapping only";
            else if (m_wrapVertically)
                m_description += "with vertical wrapping only";
            else
                m_description += "without wrapping";

        }

        public override void Do()
        {
            if (m_offset == Location.Origin)
                return;

            int layerWidth = m_layer.LayerSize.Width;
            int layerHeight = m_layer.LayerSize.Height;

            // backup tiles
            m_tiles = new Tile[layerWidth, layerHeight];
            for (int tileY = 0; tileY < layerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layerWidth; tileX++)
                {
                    m_tiles[tileX, tileY] = m_layer.Tiles[tileX, tileY];
                }
            }

            for (int destY = 0; destY < layerHeight; destY++)
            {
                int sourceY = destY - m_offset.Y;
                if (m_wrapVertically)
                {
                    while (sourceY < 0)
                        sourceY += layerHeight;
                    while (sourceY > layerHeight)
                        sourceY -= layerHeight;
                }

                for (int destX = 0; destX < layerWidth; destX++)
                {
                    int sourceX = destX - m_offset.X;
                    if (m_wrapHorizontally)
                    {
                        while (sourceX < 0)
                            sourceX += layerWidth;
                        while (sourceX > layerWidth)
                            sourceX -= layerWidth;
                    }

                    if (m_layer.IsValidTileLocation(sourceX, sourceY))
                        m_layer.Tiles[destX, destY] = m_tiles[sourceX, sourceY];
                    else
                        m_layer.Tiles[destX, destY] = null;
                }
            }
        }

        public override void Undo()
        {
            if (m_offset == Location.Origin)
                return;

            int layerWidth = m_layer.LayerSize.Width;
            int layerHeight = m_layer.LayerSize.Height;

            // restore tiles
            for (int tileY = 0; tileY < layerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layerWidth; tileX++)
                {
                    m_layer.Tiles[tileX, tileY] = m_tiles[tileX, tileY];
                }
            }
            m_tiles = null;
        }
    }
}
