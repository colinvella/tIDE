using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile.Format;
using xTile;
using System.IO;
using xTile.Layers;
using xTile.Tiles;
using xTile.ObjectModel;
using System.Xml;
using System.Collections.ObjectModel;
using xTile.Dimensions;
using tIDE.Dialogs;
using System.Windows.Forms;

namespace tIDE.Format
{
    internal class FlixelLayerFormat: IMapFormat
    {
        #region Public Methods

        public CompatibilityReport DetermineCompatibility(Map map)
        {
            List<CompatibilityNote> compatibilityNotes = new List<CompatibilityNote>();

            if (map.Layers.Count != 1)
            {
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.None,
                    "The map must contain exactly one layer"));
            }

            bool mixedTileSheets = false;
            bool nullTiles = false;
            bool animationTiles = false;
            foreach (Layer layer in map.Layers)
            {
                for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
                {
                    for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                    {
                        Tile tile = layer.Tiles[tileX, tileY];
                        if (tile == null)
                            nullTiles = true;
                        else if (tile is AnimatedTile)
                            animationTiles = true;

                        // no need to test further?
                        if (mixedTileSheets && nullTiles && animationTiles)
                            goto CompatibilityTestEnd;
                    }
                }
            }
            CompatibilityTestEnd: // label to shorten compatibility test

            if (mixedTileSheets)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.None, "Cannot have multiple tile sheets per layer"));

            if (nullTiles)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.Partial, "Null tiles will be converted to the zero tile index"));

            if (animationTiles)
                compatibilityNotes.Add(new CompatibilityNote(CompatibilityLevel.Partial, "Animated tiles will be converted to static tiles"));

            CompatibilityReport compatibilityReport = new CompatibilityReport(compatibilityNotes);
            return compatibilityReport;
        }

        public Map Load(Stream stream)
        {
            Map map = new Map("Flixel Map");

            TileSheet tilesheet = new TileSheet("Flixel Tile Sheet", map, "", new Size(10, 10), new Size(16, 15));
            TileSheetPropertiesDialog tileSheetPropertiesDialog = new TileSheetPropertiesDialog(tilesheet, true, null);
            if (tileSheetPropertiesDialog.ShowDialog() == DialogResult.Cancel)
                throw new Exception("No tile sheet configured");

            TextReader layerTextReader = new StreamReader(stream);

            List<List<int>> tileIndices = new List<List<int>>();

            char[] commas = new char[] { ',' };
            Size layerSize = new Size();

            while (true)
            {
                string layerLine = layerTextReader.ReadLine();
                if (layerLine == null)
                    break;

                List<int> indexRow = new List<int>();
                tileIndices.Add(indexRow);

                string[] tokens = layerLine.Split(commas);

                layerSize.Width = Math.Max(layerSize.Width, tokens.Length);

                foreach (string token in tokens)
                {
                    int tileIndex = int.Parse(token.Trim());
                    indexRow.Add(tileIndex);
                }

                layerSize.Height++;
            }

            Layer layer = new Layer("Flixel Layer", map, layerSize, tilesheet.TileSize);
            map.AddLayer(layer);

            for (int tileY = 0; tileY < tileIndices.Count; tileY++)
            {
                List<int> indexRow = tileIndices[tileY];
                for (int tileX = 0; tileX < indexRow.Count; tileX++)
                    layer.Tiles[tileX, tileY] = new StaticTile(layer, tilesheet, BlendMode.Alpha, indexRow[tileX]); 
            }

            return map;
        }

        public void Store(Map map, Stream stream)
        {
            Layer layer = map.Layers[0];

            TextWriter layerTextWriter = new StreamWriter(stream);
            for (int tileY = 0; tileY < layer.LayerHeight; tileY++)
            {
                for (int tileX = 0; tileX < layer.LayerWidth; tileX++)
                {
                    if (tileX > 0)
                        layerTextWriter.Write(",");

                    Tile tile = layer.Tiles[tileX, tileY];
                    if (tile == null)
                        layerTextWriter.Write("0");
                    else
                        layerTextWriter.Write(tile.TileIndex);
                }
                layerTextWriter.WriteLine();
            }
            layerTextWriter.Flush();
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get { return "Flixel Layer Text Format"; }
        }

        public string FileExtensionDescriptor
        {
            get { return "Flixel Layer Text Files (*.txt)"; }
        }

        public string FileExtension
        {
            get { return "txt"; }
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
