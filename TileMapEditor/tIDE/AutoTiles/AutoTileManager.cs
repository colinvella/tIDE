using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

namespace tIDE.AutoTiles
{
    internal class AutoTileManager
    {
        public static AutoTileManager Instance { get { return s_instance; } }

        public void Refresh(Map map)
        {
            m_autoTiles.Clear();
            foreach (TileSheet tileSheet in map.TileSheets)
                Refresh(tileSheet);
        }

        public void Refresh(TileSheet tileSheet)
        {
            // clear only autotiles bound to the givne tile sheet
            for (int index = 0; index < m_autoTiles.Count; )
            {
                if (m_autoTiles[index].TileSheet == tileSheet)
                    m_autoTiles.RemoveAt(index);
                else
                    ++index;
            }

            foreach (string propertyKey in tileSheet.Properties.Keys)
            {
                if (!propertyKey.StartsWith("@AutoTile@"))
                    continue;
                string[] tokens
                    = propertyKey.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != 2)
                    return;
                string autoTileId = tokens[1];
                string autoTileSet = tileSheet.Properties[propertyKey];
                RefreshSet(autoTileId, tileSheet, autoTileSet);
            }

            SortAutoTiles();
        }

        public Dictionary<Location, Tile> DetermineTileAssignments(Layer layer, Location tileLocation, StaticTile staticTile)
        {
            Dictionary<Location, Tile> allAssignments = new Dictionary<Location, Tile>();
            foreach (AutoTile autoTile in m_autoTiles)
            {
                if (autoTile.TileSheet != staticTile.TileSheet)
                    continue;

                Dictionary<Location, Tile> assignments
                    = autoTile.DetermineTileAssignments(layer, tileLocation, staticTile.TileIndex);

                foreach (Location location in assignments.Keys)
                    allAssignments[location] = assignments[location];
            }

            if (m_autoTiles.Count == 0)
                allAssignments[tileLocation] = staticTile.Clone(layer);

            return allAssignments;
        }

        public ReadOnlyCollection<AutoTile> GetAutoTiles(TileSheet tileSheet)
        {
            List<AutoTile> autoTiles = new List<AutoTile>();
            foreach (AutoTile autoTile in m_autoTiles)
                if (autoTile.TileSheet == tileSheet)
                    autoTiles.Add(autoTile);
            return autoTiles.AsReadOnly();
        }

        public ReadOnlyCollection<AutoTile> AutoTiles { get { return m_autoTiles.AsReadOnly(); } }

        private static AutoTileManager s_instance = new AutoTileManager();

        private AutoTileManager()
        {
            m_autoTiles = new List<AutoTile>();
        }

        private void RefreshSet(string id, TileSheet tileSheet, string indexSet)
        {
            // avoid duplicate ids
            foreach (AutoTile autoTile in m_autoTiles)
                if (autoTile.Id == id)
                    return;

            // parse index set using comma delimeter
            string[] tokens = indexSet.Split(new char[] { ',' });
            // ensure exactly 16 tokens
            if (tokens.Length != 16)
                return;

            int[] tileIndices = new int[16];
            for (int index = 0; index < 16; index++)
            {
                int tileIndex;
                if (!int.TryParse(tokens[index], out tileIndex))
                    return;
                tileIndices[index] = tileIndex;
            }

            m_autoTiles.Add(new AutoTile(id, tileSheet, tileIndices)); 
        }

        private void SortAutoTiles()
        {
            m_autoTiles.Sort(
                delegate(AutoTile autoTile1, AutoTile autoTile2)
                {
                    return autoTile1.Id.CompareTo(autoTile2.Id);
                });
        }

        private List<AutoTile> m_autoTiles;
    }
}
