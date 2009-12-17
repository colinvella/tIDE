using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Tiles;

namespace Tiling.Display
{
    public interface IDisplayDevice
    {
        void LoadTileSheet(TileSheet tileSheet);

        void DisposeTileSheet(TileSheet tileSheet);

        void BeginScene();

        void SetClippingRegion(Rectangle clippingRegion);

        void DrawTile(Tile tile, Location location);

        void EndScene();
    }
}
