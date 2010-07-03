using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;

namespace TileMapEditor.History
{
    internal class MapHistoryEntry : HistoryEntry
    {
        private Map map;
        private Map m_oldMap;
        private Map m_newMap;
        private string m_description;

        public MapHistoryEntry(Map oldMap, Map newMap, string description)
        {
            m_oldMap = oldMap;
            m_newMap = newMap;
            m_description = description;
        }

        public override void Undo()
        {
        }

        public override void Redo()
        {
        }

        public override string Description
        {
            get { return m_description; }
        }
    }
}
