using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using xTile;
using xTile.Dimensions;
using xTile.Format;
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
            return "xTile.Pipeline.TideReader, xTile";
        }

        protected override void Write(ContentWriter contentWriter, Map map)
        {
            MemoryStream memoryStream = new MemoryStream();
            FormatManager.Instance.DefaultFormat.Store(map, memoryStream);
            byte[] data = memoryStream.ToArray();
            contentWriter.Write(data.Length);
            contentWriter.Write(data);
        }
    }
}
