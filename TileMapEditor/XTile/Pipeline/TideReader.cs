using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

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
        protected override Map Read(ContentReader contentReader, Map existingMap)
        {
            // existing map is ignored

            int dataLength = contentReader.ReadInt32();
            byte[] data = contentReader.ReadBytes(dataLength);

            MemoryStream memoryStream = new MemoryStream(data);
            GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);

            Map map = FormatManager.Instance.DefaultFormat.Load(gZipStream);

            return map;
        }
    }
}
