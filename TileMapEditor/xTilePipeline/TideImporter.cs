using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using xTile;
using xTile.Format;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content importer class for tIDE map files
    /// </summary>
    [ContentImporter(".tide", DisplayName = "tIDE Map Importer", DefaultProcessor = "TideProcessor")]
    public class TideImporter : ContentImporter<Map>
    {
        /// <summary>
        /// Loads and returns a new tIDE map instance from the given filename
        /// </summary>
        /// <param name="filename">Filename of the tIDE map</param>
        /// <param name="contentImporterContext">Importer context object</param>
        /// <returns>a loaded tIDE map instance</returns>
        public override Map Import(string filename, ContentImporterContext contentImporterContext)
        {
            return FormatManager.Instance.LoadMap(filename);
        }
    }
}
