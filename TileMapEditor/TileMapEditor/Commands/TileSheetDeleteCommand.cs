using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class TileSheetDeleteCommand: Command
    {
        private Map m_map;
        private TileSheet m_tileSheet;

        public TileSheetDeleteCommand(Map map, TileSheet tileSheet)
        {
            m_map = map;
            m_tileSheet = tileSheet;
            m_description = "Delete tile sheet \"" + tileSheet.Id + "\"";
        }

        public override void Do()
        {
            m_map.RemoveTileSheet(m_tileSheet);
        }

        public override void Undo()
        {
            TileImageCache.Instance.Refresh(m_tileSheet);
            m_map.AddTileSheet(m_tileSheet);
        }
    }
}
