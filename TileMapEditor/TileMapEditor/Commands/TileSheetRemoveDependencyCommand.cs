using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile;
using XTile.Dimensions;
using XTile.Layers;
using XTile.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Commands
{
    internal struct TileSheetDependency
    {
        private Layer m_layer;
        private Location m_location;
        private Tile m_tile;

        internal TileSheetDependency(Layer layer, Location location, Tile tile)
        {
            m_layer = layer;
            m_location = location;
            m_tile = tile;
        }

        internal Layer Layer { get { return m_layer; } }

        internal Location Location { get { return m_location; } }

        internal Tile Tile { get { return m_tile; } }

        internal void Break()
        {
            m_layer.Tiles[m_location] = null;
        }

        internal void Restore()
        {
            m_layer.Tiles[m_location] = m_tile;
        }
    }

    internal class TileSheetRemoveDependencyCommand: Command
    {
        private Map m_map;
        private TileSheet m_tileSheet;
        private List<TileSheetDependency> m_tileSheetDependencies;

        public TileSheetRemoveDependencyCommand(Map map, TileSheet tileSheet)
        {
            m_map = map;
            m_tileSheet = tileSheet;
            m_description = "Remove dependencies on tile sheet \"" + tileSheet.Id + "\"";

            m_tileSheetDependencies = new List<TileSheetDependency>();
            foreach (Layer layer in m_map.Layers)
            {
                Size layerSize = layer.LayerSize;
                Location location;
                for (location.Y = 0; location.Y < layerSize.Height; location.Y++)
                    for (location.X = 0; location.X < layerSize.Width; location.X++)
                    {
                        Tile tile = layer.Tiles[location];
                        if (tile != null && tile.DependsOnTileSheet(m_tileSheet))
                            m_tileSheetDependencies.Add(new TileSheetDependency(layer, location, tile));
                    }
            }
        }

        public override void Do()
        {
            foreach (TileSheetDependency tileSheetDependency in m_tileSheetDependencies)
                tileSheetDependency.Break();
        }

        public override void Undo()
        {
            foreach (TileSheetDependency tileSheetDependency in m_tileSheetDependencies)
                tileSheetDependency.Restore();
        }
    }
}
