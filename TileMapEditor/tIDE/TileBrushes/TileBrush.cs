using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.TileBrushes
{
    [Serializable]
    public class TileBrush
    {
        #region Internal Methods

        internal TileBrush(Layer layer, TileSelection tileSelection)
            : this("Clipboard", layer, tileSelection)
        {
        }

        internal TileBrush(string id, Layer layer, TileSelection tileSelection)
        {
            m_id = id;
            xTile.Dimensions.Rectangle selectionBounds = tileSelection.Bounds;

            m_brushSize = selectionBounds.Size;
            m_tileSize = layer.TileSize;
            m_displaySize = new xTile.Dimensions.Size(
                m_brushSize.Width * m_tileSize.Width,
                m_brushSize.Height * m_tileSize.Height);

            m_tileBrushElements = new List<TileBrushElement>();
            foreach (Location location in tileSelection.Locations)
            {
                if (!layer.IsValidTileLocation(location))
                    continue;

                Tile tile = layer.Tiles[location];
                Tile tileClone = tile == null ? null : tile.Clone(layer);
                TileBrushElement tileBrushElement = new TileBrushElement(
                    tileClone, location - selectionBounds.Location);
                m_tileBrushElements.Add(tileBrushElement);
            }
        }

        internal TileBrush(TileBrush tileBrush)
        {
            m_id = tileBrush.m_id;
            m_brushSize = tileBrush.m_brushSize;
            m_tileSize = tileBrush.m_tileSize;
            m_displaySize = tileBrush.m_displaySize;
            m_tileBrushElements = new List<TileBrushElement>(tileBrush.m_tileBrushElements);
            m_imageRepresentation = tileBrush.m_imageRepresentation;
        }

        internal TileBrush(string id, List<TileBrushElement> tileBrushElements)
        {
            m_id = id;

            m_brushSize = new xTile.Dimensions.Size();
            m_tileSize = new xTile.Dimensions.Size();
            foreach (TileBrushElement tileBrushElement in tileBrushElements)
            {
                m_brushSize.Width = Math.Max(m_brushSize.Width, tileBrushElement.Location.X + 1);
                m_brushSize.Height = Math.Max(m_brushSize.Width, tileBrushElement.Location.Y + 1);
                if (tileBrushElement.Tile != null)
                    m_tileSize = tileBrushElement.Tile.TileSheet.TileSize;
            }

            m_displaySize = new xTile.Dimensions.Size(
                m_brushSize.Width * m_tileSize.Width,
                m_brushSize.Height * m_tileSize.Height);

            m_tileBrushElements = new List<TileBrushElement>(tileBrushElements);
        }

        internal void ApplyTo(Layer layer, Location brushLocation,
            TileSelection tileSelection)
        {
            Map map = layer.Map;
            xTile.Dimensions.Size layerTileSize = layer.TileSize;

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

                    tileClone = tile.Clone(layer);
                }

                layer.Tiles[tileLocation] = tileClone;
                tileSelection.AddLocation(tileLocation);
            }
        }

        internal void GenerateSelection(Location brushLocation,
            TileSelection tileSelection)
        {
            tileSelection.Clear();
            foreach (TileBrushElement tileBrushElement in m_tileBrushElements)
                tileSelection.AddLocation(brushLocation + tileBrushElement.Location);
        }

        internal void StoreInMap(Map map)
        {
            if (m_tileBrushElements.Count == 0)
                return;

            string propertyKey = "@TileBrush@" + m_id + "@";

            List<TileBrushElement> tileBrushElements = new List<TileBrushElement>(m_tileBrushElements);
            Layer layer = null;

            // group by tile sheet id for compactness
            tileBrushElements.Sort(
                delegate(TileBrushElement tileBrushElement1, TileBrushElement tileBrushElement2)
                {
                    Tile tile1 = tileBrushElement1.Tile;
                    Tile tile2 = tileBrushElement2.Tile;
                    if (tile1 == null)
                    {
                        if (tile2 == null)
                        {
                            // both null
                            return 0;
                        }
                        else
                        {
                            // only #1 null
                            return -1;
                        }
                    }
                    else
                    {
                        if (tile2 == null)
                        {
                            // only #2 null
                            return 1;
                        }
                        else
                        {
                            // both non-null - compare tile sheet id's
                            return tile1.TileSheet.Id.CompareTo(tile2.TileSheet.Id);
                        }
                    }
                }
                );

            // build property value
            StringBuilder stringBuilder = new StringBuilder();
            string lastTileSheetId = null;
            foreach (TileBrushElement tileBrushElement in tileBrushElements)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append('|');
                stringBuilder.Append(tileBrushElement.Location.X);
                stringBuilder.Append(',');
                stringBuilder.Append(tileBrushElement.Location.Y);
                stringBuilder.Append(',');

                Tile tile = tileBrushElement.Tile;
                if (tile == null)
                    stringBuilder.Append(",");
                else
                {
                    layer = tile.Layer;
                    string tileSheetId = tile.TileSheet.Id;
                    if (tileSheetId != lastTileSheetId)
                    {
                        stringBuilder.Append(tileSheetId);
                        lastTileSheetId = tileSheetId;
                    }
                    stringBuilder.Append(',');
                    stringBuilder.Append(tile.TileIndex);
                }
            }

            string propertyValue = layer.Id + "|" + stringBuilder;

            map.Properties[propertyKey] = propertyValue;
        }

        #endregion

        #region Internal Properties

        internal string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        internal Image ImageRepresentation
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

        internal xTile.Dimensions.Size BrushSize { get { return m_brushSize; } }

        internal xTile.Dimensions.Size TileSize { get { return m_tileSize; } }

        internal xTile.Dimensions.Size DisplaySize { get { return m_displaySize; } }

        internal ReadOnlyCollection<TileBrushElement> Elements
        {
            get { return m_tileBrushElements.AsReadOnly(); }
        }

        #endregion

        #region Private Variables

        private string m_id;
        private xTile.Dimensions.Size m_brushSize;
        private xTile.Dimensions.Size m_tileSize;
        private xTile.Dimensions.Size m_displaySize;
        private List<TileBrushElement> m_tileBrushElements;
        private Image m_imageRepresentation;

        #endregion
    }
}
