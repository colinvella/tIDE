using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

using xTile;
using xTile.Format;
using xTile.Tiles;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content processor class for tIDE map files
    /// </summary>
    [ContentProcessor(DisplayName = "tIDE Map Processor")]
    public class TideProcessor : ContentProcessor<Map, Map>
    {
        /// <summary>
        /// Process a tIDE map object.
        /// </summary>
        /// <param map="input">Input map object</param>
        /// <param name="contentProcessorContext">Processor context object</param>
        /// <returns></returns>
        public override Map Process(Map map, ContentProcessorContext contentProcessorContext)
        {
            foreach (TileSheet tileSheet in map.TileSheets)
            {
                string imageSource = tileSheet.ImageSource;
                string oldImageSource = imageSource;

                while (imageSource.StartsWith("..\\")
                    || imageSource.StartsWith("../"))
                    imageSource = imageSource.Remove(0, 3);

                string extension = Path.GetExtension(imageSource);
                if (extension != string.Empty)
                    imageSource
                        = imageSource.Remove(imageSource.Length - extension.Length);

                tileSheet.ImageSource = imageSource;

                contentProcessorContext.Logger.LogImportantMessage(
                    "Normalised image source reference from '" + oldImageSource + "' to '" + imageSource + "'");
            }

            return map;
        }
    }
}