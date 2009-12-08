using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using TileMapEditor.Control;

namespace TileMapEditor
{
    [Serializable]
    public struct TileBrushElement
    {
        private Tile m_tile;
        private Location m_location;

        public TileBrushElement(Tile tile, Location location)
        {
            m_tile = tile;
            m_location = location;
        }

        public Tile Tile { get { return m_tile; } }

        public Location Location { get { return m_location; } }
    }

    [Serializable]
    public class TileBrush
    {
        private Size m_size;
        private List<TileBrushElement> m_tileBrushElements;

        public TileBrush(Layer layer, TileSelection tileSelection)
        {
            m_size = tileSelection.Bounds.Size;
            m_tileBrushElements = new List<TileBrushElement>();
            foreach (Location location in tileSelection.Locations)
            {
                Tile tile = layer.Tiles[location];
                TileBrushElement tileBrushElement = new TileBrushElement(
                    tile.Clone(), location);
                m_tileBrushElements.Add(tileBrushElement);
            }
        }

        public void ApplyTo(Layer layer, Location brushLocation)
        {
            Map map = layer.Map;
            foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
            {
                Location tileLocation = brushLocation + tileBrushElement.Location;
                if (!layer.IsValidTileLocation(tileLocation))
                    continue;

                Tile tile = tileBrushElement.Tile;
                if (!map.TileSheets.Contains(tile.TileSheet))
                    continue;

                layer.Tiles[tileLocation] = tileBrushElement.Tile.Clone();
            }
        }
    }

}
