using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xTile.Pipeline
{
    /// <summary>
    /// Tile storage marker constants used by the XNA content writers
    /// </summary>
    public class TileMarker
    {
        public const byte Null = 0;
        public const byte TileSheet = 1;
        public const byte StaticTile = 2;
        public const byte AnimatedTile = 3;
        public const byte TileFrame = 4;

        public const byte BlendAlpha = 0;
        public const byte BlendAdditive = 1;
    }
}