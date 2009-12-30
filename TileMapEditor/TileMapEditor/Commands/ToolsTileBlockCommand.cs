using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class ToolsTileBlockCommand: Command
    {
        private Layer m_layer; 
        private TileSheet m_tileSheet;
        private int m_tileIndex;
        private Location m_blockLocation;
        private Tile[,] m_oldTiles;

        public ToolsTileBlockCommand(Layer layer, TileSheet tileSheet,
            int tileIndex, Location blockLocation, Size blockSize)
        {
            m_layer = layer;
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
            m_blockLocation = blockLocation;

            m_oldTiles = new Tile[blockSize.Width, blockSize.Height];

            m_description = "Draw a block of tiles \"" + m_tileSheet.Id + ":" + m_tileIndex 
                + "\" at " + m_blockLocation + " of size " + blockSize
                + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            Size blockSize = new Size(m_oldTiles.GetLength(0), m_oldTiles.GetLength(1));
            int layerY = m_blockLocation.Y;
            for (int tileY = 0; tileY < blockSize.Height; tileY++, layerY++)
            {
                int layerX = m_blockLocation.X;
                for (int tileX = 0; tileX < blockSize.Width; tileX++, layerX++)
                {
                    m_oldTiles[tileX, tileY] = m_layer.Tiles[layerX, layerY];
                    m_layer.Tiles[layerX, layerY] = new StaticTile(m_layer, m_tileSheet, BlendMode.Alpha, m_tileIndex);
                }
            }
        }

        public override void Undo()
        {
            Size blockSize = new Size(m_oldTiles.GetLength(0), m_oldTiles.GetLength(1));
            int layerY = m_blockLocation.Y;
            for (int tileY = 0; tileY < blockSize.Height; tileY++, layerY++)
            {
                int layerX = m_blockLocation.X;
                for (int tileX = 0; tileX < blockSize.Width; tileX++, layerX++)
                    m_layer.Tiles[layerX, layerY] = m_oldTiles[tileX, tileY];
            }
        }
    }
}
