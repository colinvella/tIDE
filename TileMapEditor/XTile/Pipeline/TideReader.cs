using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using xTile;

namespace xTile.Pipeline
{
    /// <summary>
    /// Content reader class for tIDE map files
    /// </summary>
    public class TideReader : ContentTypeReader<Map>
    {
        protected override Map Read(ContentReader input, Map map)
        {
            // TODO: read a value from the input ContentReader.
            throw new NotImplementedException();
        }
    }
}
