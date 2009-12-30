using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class TileSheetNewCommand: Command
    {
        private Map m_map;
        private TileSheet m_newTileSheet;

        public TileSheetNewCommand(Map map, TileSheet newTileSheet)
        {
            m_map = map;
            m_newTileSheet = newTileSheet;
            m_description = "Add new tile sheet \"" + newTileSheet.Id + "\"";
        }

        public override void Do()
        {
            TileImageCache.Instance.Refresh(m_newTileSheet);
            m_map.AddTileSheet(m_newTileSheet);
        }

        public override void Undo()
        {
            m_map.RemoveTileSheet(m_newTileSheet);
        }
    }
}
