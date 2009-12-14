using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Tiling;
using TileMapEditor.Control;

namespace TileMapEditor
{
    [Serializable]
    public class TileBrush
    {
        private Tiling.Size m_size;
        private List<TileBrushElement> m_tileBrushElements;
        private Image m_imageRepresentation;

        public TileBrush(Layer layer, TileSelection tileSelection)
        {
            Tiling.Rectangle selectionBounds = tileSelection.Bounds;
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
            Tiling.Size layerTileSize = layer.TileSize;
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

        public Image ImageRepresentation
        {
            get
            {
                if (m_imageRepresentation == null)
                {
                    if (m_tileBrushElements.Count == 0)
                        return null;

                    Tiling.Size tileSize
                        = m_tileBrushElements[0].Tile.TileSheet.TileSize;

                    Bitmap bitmap = new Bitmap(
                        m_size.Width * tileSize.Width, m_size.Height * tileSize.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);

                    TileImageCache tileImageCache = TileImageCache.Instance;

                    foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
                    {
                        Tile tile = tileBrushElement.Tile;
                        Image tileImage = tileImageCache.GetTileBitmap(tile.TileSheet, tile.TileIndex);
                        Location location = tileBrushElement.Location;
                        graphics.DrawImage(tileImage,
                            location.X * tileSize.Width, location.Y * tileSize.Height);
                    }

                    m_imageRepresentation = bitmap;
                }

                return m_imageRepresentation;
            }
        }
    }
}
