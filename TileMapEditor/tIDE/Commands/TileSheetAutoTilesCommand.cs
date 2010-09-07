using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.ObjectModel;
using XTile.Tiles;

using TileMapEditor.AutoTiles;

namespace TileMapEditor.Commands
{
    internal class TileSheetAutoTilesCommand: Command
    {
        private TileSheet m_tileSheet;
        private List<AutoTile> m_autoTiles;
        private Dictionary<string, PropertyValue> m_oldAutoTiles;

        public TileSheetAutoTilesCommand(
            TileSheet tileSheet,
            IEnumerable<AutoTile> autoTiles)
        {
            m_tileSheet = tileSheet;
            m_autoTiles = new List<AutoTile>(autoTiles);
            m_oldAutoTiles = new Dictionary<string, PropertyValue>();

            m_description = "Update auto tile definitions for tile sheet \"" + tileSheet.Id + "\"";
        }

        public override void Do()
        {
            foreach (string propertyKey in m_tileSheet.Properties.Keys)
            {
                if (propertyKey.StartsWith("@AutoTile@"))
                    m_oldAutoTiles[propertyKey] = m_tileSheet.Properties[propertyKey];
            }
            foreach (string propertyKey in m_oldAutoTiles.Keys)
                m_tileSheet.Properties.Remove(propertyKey);

            foreach (AutoTile autoTile in m_autoTiles)
            {
                string propertyKey = "@AutoTile@" + autoTile.Id;
                StringBuilder propertyValue = new StringBuilder();
                foreach (int setIndex in autoTile.IndexSet)
                {
                    if (propertyValue.Length > 0)
                        propertyValue.Append(',');
                    propertyValue.Append(setIndex);
                }
                m_tileSheet.Properties[propertyKey] = propertyValue.ToString();
            }

            AutoTileManager.Instance.Refresh(m_tileSheet);
        }

        public override void Undo()
        {
            foreach (AutoTile autoTile in m_autoTiles)
            {
                string propertyKey = "@AutoTile@" + autoTile.Id;
                m_tileSheet.Properties.Remove(propertyKey);
            }

            foreach (string propertyKey in m_oldAutoTiles.Keys)
                m_tileSheet.Properties[propertyKey] = m_oldAutoTiles[propertyKey];

            AutoTileManager.Instance.Refresh(m_tileSheet);
        }
    }
}
