using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using tIDE.AutoTiles;

namespace tIDE.Commands
{
    internal class ToolsFloodFillCommand: Command
    {
        private Layer m_layer; 
        private Location m_startLocation;
        private TileSheet m_tileSheet;
        private int m_tileIndex;
        private Dictionary<Location, Tile> m_oldTiles;

        public ToolsFloodFillCommand(Layer layer, Location startLocation,
            TileSheet tileSheet, int tileIndex)
        {
            m_layer = layer;
            m_startLocation = startLocation;
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;

            m_oldTiles = new Dictionary<Location, Tile>();

            m_description = "Flood fill with tile \"" + m_tileSheet.Id + ":" + m_tileIndex 
                + "\" at " + m_startLocation + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            m_oldTiles.Clear();

            if (!m_layer.IsValidTileLocation(m_startLocation))
                return;

            Tile targetTile = m_layer.Tiles[m_startLocation];

            Queue<Location> locationQueue = new Queue<Location>();

            locationQueue.Enqueue(m_startLocation);

            while (locationQueue.Count > 0)
            {
                Location location = locationQueue.Dequeue();
                Tile currentTile = m_layer.Tiles[location];

                Location spanLeft = location;
                while (spanLeft.X > 0 && TilesMatch(targetTile, m_layer.Tiles[spanLeft.Left]))
                    --spanLeft.X;

                Location spanRight = location;
                while (spanRight.X < m_layer.LayerWidth && TilesMatch(targetTile, m_layer.Tiles[spanRight]))
                    ++spanRight.X;

                for (location.X = spanLeft.X; location.X < spanRight.X; location.X++)
                {
                    m_oldTiles[location] = m_layer.Tiles[location];
                    m_layer.Tiles[location] = new StaticTile(m_layer, m_tileSheet, BlendMode.Alpha, m_tileIndex);

                    Location above = location.Above;
                    if (location.Y > 0 && TilesMatch(targetTile, m_layer.Tiles[above]))
                        locationQueue.Enqueue(above);

                    Location below = location.Below;
                    if (location.Y < m_layer.LayerHeight - 1 && TilesMatch(targetTile, m_layer.Tiles[below]))
                        locationQueue.Enqueue(below);
                }
            }

        }

        public override void Undo()
        {
            // undo flood fill
            foreach (Location locationKey in m_oldTiles.Keys)
                m_layer.Tiles[locationKey] = m_oldTiles[locationKey];
        }

        private bool TilesMatch(Tile tile1, Tile tile2)
        {
            // match of both null or they match in sheet and index

            if (tile1 == null)
                return tile2 == null;

            if (tile2 == null)
                return false;

            return tile1.TileSheet == tile2.TileSheet && tile1.TileIndex == tile2.TileIndex;
        }
    }
}
