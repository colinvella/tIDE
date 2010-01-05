using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor
{
    [Serializable]
    public class TileBrush
    {
        private string m_id;
        private Tiling.Dimensions.Size m_brushSize;
        private Tiling.Dimensions.Size m_tileSize;
        private Tiling.Dimensions.Size m_displaySize;
        private List<TileBrushElement> m_tileBrushElements;
        private Image m_imageRepresentation;

        public TileBrush(Layer layer, TileSelection tileSelection)
            : this("Clipboard", layer, tileSelection)
        {
        }

        public TileBrush(string id, Layer layer, TileSelection tileSelection)
        {
            m_id = id;
            Tiling.Dimensions.Rectangle selectionBounds = tileSelection.Bounds;

            m_brushSize = selectionBounds.Size;
            m_tileSize = layer.TileSize;
            m_displaySize = new Tiling.Dimensions.Size(
                m_brushSize.Width * m_tileSize.Width,
                m_brushSize.Height * m_tileSize.Height);

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

        public TileBrush(TileBrush tileBrush)
        {
            m_id = tileBrush.m_id;
            m_brushSize = tileBrush.m_brushSize;
            m_tileSize = tileBrush.m_tileSize;
            m_displaySize = tileBrush.m_displaySize;
            m_tileBrushElements = new List<TileBrushElement>(tileBrush.m_tileBrushElements);
            m_imageRepresentation = tileBrush.m_imageRepresentation;
        }

        public void ApplyTo(Layer layer, Location brushLocation,
            TileSelection tileSelection)
        {
            Map map = layer.Map;
            Tiling.Dimensions.Size layerTileSize = layer.TileSize;

            if (layerTileSize != m_tileSize)
                return;

            
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

                    if (!map.TileSheets.Contains(tile.TileSheet))
                        continue;

                    tileClone = tile.Clone();
                }

                layer.Tiles[tileLocation] = tileClone;
                tileSelection.AddLocation(tileLocation);
            }
        }

        public void GenerateSelection(Location brushLocation,
            TileSelection tileSelection)
        {
            tileSelection.Clear();
            foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
                tileSelection.AddLocation(brushLocation + tileBrushElement.Location);
        }

        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public Image ImageRepresentation
        {
            get
            {
                if (m_imageRepresentation == null)
                {
                    if (m_tileBrushElements.Count == 0)
                        return null;

                    Bitmap bitmap = new Bitmap(
                        m_brushSize.Width * m_tileSize.Width, m_brushSize.Height * m_tileSize.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);

                    TileImageCache tileImageCache = TileImageCache.Instance;

                    foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
                    {
                        Tile tile = tileBrushElement.Tile;
                        if (tile == null)
                            continue;
                        Image tileImage = tileImageCache.GetTileBitmap(tile.TileSheet, tile.TileIndex);
                        Location location = tileBrushElement.Location;
                        graphics.DrawImage(tileImage,
                            location.X * m_tileSize.Width, location.Y * m_tileSize.Height);
                    }

                    m_imageRepresentation = bitmap;
                }

                return m_imageRepresentation;
            }
        }

        public Tiling.Dimensions.Size BrushSize { get { return m_brushSize; } }

        public Tiling.Dimensions.Size TileSize { get { return m_tileSize; } }

        public Tiling.Dimensions.Size DisplaySize { get { return m_displaySize; } }

        public ReadOnlyCollection<TileBrushElement> Elements
        {
            get { return m_tileBrushElements.AsReadOnly(); }
        }
    }
}
