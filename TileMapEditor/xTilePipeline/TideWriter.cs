using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.ObjectModel;
using xTile.Pipeline;
using xTile.Tiles;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content writer class for tIDE map files
    /// </summary>
    [ContentTypeWriter]
    public class TideWriter : ContentTypeWriter<Map>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "xTile.Pipeline.TideReader, xTile.Pipeline";
        }

        protected override void Write(ContentWriter contentWriter, Map map)
        {
            contentWriter.Write(map.Id);
            contentWriter.Write(map.Description);
            WriteProperties(contentWriter, map.Properties);
            WriteTileSheets(contentWriter, map.TileSheets);
            WriteLayers(contentWriter, map.Layers);
        }

        private void WriteProperties(ContentWriter contentWriter, PropertyCollection propertyCollection)
        {
            contentWriter.Write(propertyCollection.Count);
            foreach (string propertyKey in propertyCollection.Keys)
            {
                contentWriter.Write(propertyKey);
                PropertyValue propertyValue = propertyCollection[propertyKey];
                contentWriter.Write(propertyValue.Type.Name);
                if (propertyValue.Type == typeof(bool))
                    contentWriter.Write((bool)propertyValue);
                else if (propertyValue.Type == typeof(int))
                    contentWriter.Write((int)propertyValue);
                else if (propertyValue.Type == typeof(float))
                    contentWriter.Write((float)propertyValue);
                else
                    contentWriter.Write((string)propertyValue);
            }
        }

        private void WriteTileSheets(ContentWriter contentWriter, ReadOnlyCollection<TileSheet> tileSheets)
        {
            contentWriter.Write(tileSheets.Count);
            foreach (TileSheet tileSheet in tileSheets)
                WriteTileSheet(contentWriter, tileSheet);
        }

        private void WriteTileSheet(ContentWriter contentWriter, TileSheet tileSheet)
        {
            contentWriter.Write(tileSheet.Id);
            contentWriter.Write(tileSheet.Description);
            contentWriter.Write(tileSheet.ImageSource);
            WriteSize(contentWriter, tileSheet.SheetSize);
            WriteSize(contentWriter, tileSheet.TileSize);
            WriteSize(contentWriter, tileSheet.Margin);
            WriteSize(contentWriter, tileSheet.Spacing);
            WriteProperties(contentWriter, tileSheet.Properties);
        }

        private void WriteLayers(ContentWriter contentWriter, ReadOnlyCollection<Layer> layers)
        {
            contentWriter.Write(layers.Count);
            foreach (Layer layer in layers)
                WriteLayer(contentWriter, layer);
        }

        private void WriteLayer(ContentWriter contentWriter, Layer layer)
        {
            contentWriter.Write(layer.Id);
            contentWriter.Write(layer.Description);
            WriteProperties(contentWriter, layer.Properties);
            WriteSize(contentWriter, layer.LayerSize);
            WriteSize(contentWriter, layer.TileSize);
            contentWriter.Write(layer.Visible);
            WriteProperties(contentWriter, layer.Properties);

            TileSheet tileSheet = null;
            for (int tileY = 0; tileY < layer.LayerSize.Height; tileY++)
            {
                // reset null tile count for every row
                int nullCount = 0;
                for (int tileX = 0; tileX < layer.LayerSize.Width; tileX++)
                {
                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        ++nullCount;
                    else
                    {
                        // handle previous null tiles if any
                        if (nullCount > 0)
                        {
                            contentWriter.Write(TileMarker.Null);
                            contentWriter.Write(nullCount);
                            nullCount = 0;
                        }

                        if (tile is StaticTile)
                        {
                            // handle change in tilesheet if needed
                            if (tile.TileSheet != tileSheet)
                            {
                                tileSheet = tile.TileSheet;
                                contentWriter.Write(TileMarker.TileSheet);
                                contentWriter.Write(tileSheet.Id);
                            }

                            // write static tile
                            contentWriter.Write(TileMarker.StaticTile);
                            contentWriter.Write(tile.TileIndex);
                            WriteBlendMode(contentWriter, tile.BlendMode);
                        }
                        else if (tile is AnimatedTile)
                        {
                            AnimatedTile animatedTile = (AnimatedTile) tile;
                            contentWriter.Write(TileMarker.AnimatedTile);
                            contentWriter.Write(animatedTile.FrameInterval);

                            // write frame count and frames
                            contentWriter.Write(animatedTile.TileFrames.Length);
                            foreach (StaticTile tileFrame in animatedTile.TileFrames)
                            {
                                // handle change in tilesheet if needed
                                if (tileFrame.TileSheet != tileSheet)
                                {
                                    tileSheet = tileFrame.TileSheet;
                                    contentWriter.Write(TileMarker.TileSheet);
                                    contentWriter.Write(tileSheet.Id);
                                }

                                // write tile frame
                                contentWriter.Write(TileMarker.TileFrame);
                                contentWriter.Write(tileFrame.TileIndex);
                                WriteBlendMode(contentWriter, tileFrame.BlendMode);
                                WriteProperties(contentWriter, tileFrame.Properties);
                            }
                        }

                        // write static / animated tile properties
                        WriteProperties(contentWriter, tile.Properties);
                    }
                }

                // handle any pending last null counts in row
                if (nullCount > 0)
                {
                    contentWriter.Write(TileMarker.Null);
                    contentWriter.Write(nullCount);
                }
            }
        }

        private void WriteSize(ContentWriter contentWriter, Size size)
        {
            contentWriter.Write(size.Width);
            contentWriter.Write(size.Height);
        }

        private void WriteBlendMode(ContentWriter contentWriter, BlendMode blendMode)
        {
            contentWriter.Write(blendMode == BlendMode.Alpha
                ? TileMarker.BlendAlpha
                : TileMarker.BlendAdditive);
        }
    }
}
