using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Commands
{
    internal class TileSheetNewCommand: Command
    {
        private Map m_map;
        private TileSheet m_newTileSheet;
        private MapTreeView m_mapTreeView;

        public TileSheetNewCommand(Map map, TileSheet newTileSheet, MapTreeView mapTreeView)
        {
            m_map = map;
            m_newTileSheet = newTileSheet;
            m_mapTreeView = mapTreeView;
            m_description = "Add new tile sheet \"" + newTileSheet.Id + "\"";
        }

        public override void Do()
        {
            TileImageCache.Instance.Refresh(m_newTileSheet);
            m_map.AddTileSheet(m_newTileSheet);
            m_mapTreeView.UpdateTree();
            m_mapTreeView.SelectedComponent = m_newTileSheet;
        }

        public override void Undo()
        {
            m_map.RemoveTileSheet(m_newTileSheet);
            m_mapTreeView.UpdateTree();
        }
    }
}
