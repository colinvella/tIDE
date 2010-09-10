using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using TileMapEditor.AutoTiles;

namespace TileMapEditor.Commands
{
    internal class ToolsTileBlockCommand: Command
    {
        private Layer m_layer; 
        private TileSheet m_tileSheet;
        private int m_tileIndex;
        private Location m_blockLocation;
        private Tile[,] m_oldTiles;
        private Dictionary<Location, Tile> m_oldFringeAssignments;

        public ToolsTileBlockCommand(Layer layer, TileSheet tileSheet,
            int tileIndex, Location blockLocation, Size blockSize)
        {
            m_layer = layer;
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
            m_blockLocation = blockLocation;

            m_oldTiles = new Tile[blockSize.Width, blockSize.Height];

            m_oldFringeAssignments = new Dictionary<Location, Tile>();

            m_description = "Draw a block of tiles \"" + m_tileSheet.Id + ":" + m_tileIndex 
                + "\" at " + m_blockLocation + " of size " + blockSize
                + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            m_oldFringeAssignments.Clear();

            Size blockSize = new Size(m_oldTiles.GetLength(0), m_oldTiles.GetLength(1));
            int tileY = m_blockLocation.Y;
            for (int blockY = 0; blockY < blockSize.Height; blockY++, tileY++)
            {
                int tileX = m_blockLocation.X;
                for (int blockX = 0; blockX < blockSize.Width; blockX++, tileX++)
                {
                    // place block tile (after preserving old tile)
                    m_oldTiles[blockX, blockY] = m_layer.Tiles[tileX, tileY];
                    StaticTile localTile = new StaticTile(m_layer, m_tileSheet, BlendMode.Alpha, m_tileIndex);
                    m_layer.Tiles[tileX, tileY] = localTile;

                    // determine local fringe auto-tiles
                    Dictionary<Location, Tile> localAssignments = AutoTileManager.Instance.DetermineTileAssignments(
                        m_layer, new Location(tileX, tileY), localTile);

                    // place fringe auto-tiles (after preserving previous tiles)
                    foreach (Location locationKey in localAssignments.Keys)
                    {
                        m_oldFringeAssignments[locationKey] = m_layer.Tiles[locationKey];
                        m_layer.Tiles[locationKey] = localAssignments[locationKey];
                    }
                }
            }
        }

        public override void Undo()
        {
            // undo fringe auto-tiles
            foreach (Location locationKey in m_oldFringeAssignments.Keys)
                m_layer.Tiles[locationKey] = m_oldFringeAssignments[locationKey];

            // undo block tiles
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
