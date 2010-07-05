using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Tiles;

namespace XTile.Display
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
