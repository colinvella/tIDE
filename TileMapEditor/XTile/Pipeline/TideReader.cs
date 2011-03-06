using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using xTile;
using xTile.Format;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content reader class for tIDE map files
    /// </summary>
    public class TideReader : ContentTypeReader<Map>
    {
        /// <summary>
        /// Reads a map from the current stream
        /// </summary>
        /// <param name="contentReader">The ContentReader used to read the object</param>
        /// <param name="existingMap">An existing object to read into</param>
        /// <returns>A loaded map instance</returns>
        protected override Map Read(ContentReader contentReader, Map existingMap)
        {
            // existing map is ignored

            int dataLength = contentReader.ReadInt32();
            byte[] data = contentReader.ReadBytes(dataLength);

            MemoryStream memoryStream = new MemoryStream(data);
            Map map = FormatManager.Instance.BinaryFormat.Load(memoryStream);

            return map;
        }
    }
}
