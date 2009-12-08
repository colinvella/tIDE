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
            Rectangle selectionBounds = tileSelection.Bounds;
            m_size = selectionBounds.Size;
            m_tileBrushElements = new List<TileBrushElement>();
            foreach (Location location in tileSelection.Locations)
            {
                Tile tile = layer.Tiles[location];
                Tile tileClone = tile == null ? null : tile.Clone();
                TileBrushElement tileBrushElement = new TileBrushElement(
                    tileClone, location - selectionBounds.Location);
                m_tileBrushElements.Add(tileBrushElement);
            }
        }

        public void ApplyTo(Layer layer, Location brushLocation,
            TileSelection tileSelection)
        {
            Map map = layer.Map;
            Size layerTileSize = layer.TileSize;
            tileSelection.Clear();
            foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
            {
                Location tileLocation = brushLocation + tileBrushElement.Location;
                if (!layer.IsValidTileLocation(tileLocation))
                    continue;

                Tile tile = tileBrushElement.Tile;
                Tile tileClone = null;
                if (tile != null)
                {
                    TileSheet tileSheet = tile.TileSheet;

                    if (tileSheet.TileSize != layerTileSize)
                        break;

                    if (!map.TileSheets.Contains(tile.TileSheet))
                        continue;

                    tileClone = tile.Clone();
                }

                layer.Tiles[tileLocation] = tileClone;
                tileSelection.AddLocation(tileLocation);
            }
        }
    }

}
