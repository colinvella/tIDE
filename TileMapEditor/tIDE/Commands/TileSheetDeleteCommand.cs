using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Commands
{
    internal class TileSheetDeleteCommand: Command
    {
        private Map m_map;
        private TileSheet m_tileSheet;
        private MapTreeView m_mapTreeView;

        public TileSheetDeleteCommand(Map map, TileSheet tileSheet, MapTreeView mapTreeView)
        {
            m_map = map;
            m_tileSheet = tileSheet;
            m_mapTreeView = mapTreeView;
            m_description = "Delete tile sheet \"" + tileSheet.Id + "\"";
        }

        public override void Do()
        {
            m_map.RemoveTileSheet(m_tileSheet);
            m_mapTreeView.UpdateTree();
        }

        public override void Undo()
        {
            TileImageCache.Instance.Refresh(m_tileSheet);
            m_map.AddTileSheet(m_tileSheet);
            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = m_tileSheet;
        }
    }
}
