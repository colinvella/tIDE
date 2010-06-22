using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile;
using XTile.ObjectModel;

namespace TileMapEditor.Commands
{
    internal class MapPropertiesCommand: Command
    {
        private Map m_map;
        private string m_oldId, m_newId;
        private string m_oldDescription, m_newDescription;
        private PropertyCollection m_oldProperties, m_newProperties;

        public MapPropertiesCommand(Map map, string newId, string newDescription,
            PropertyCollection newProperties)
        {
            m_map = map;

            m_oldId = map.Id;
            m_oldDescription = map.Description;
            m_oldProperties = new PropertyCollection(map.Properties);

            m_newId = newId;
            m_newDescription = newDescription;
            m_newProperties = newProperties;

            m_description = "Change map properties";
        }

        public override void Do()
        {
            m_map.Id = m_newId;
            m_map.Description = m_newDescription;
            m_map.Properties.Clear();
            m_map.Properties.CopyFrom(m_newProperties);
        }

        public override void Undo()
        {
            m_map.Id = m_oldId;
            m_map.Description = m_oldDescription;
            m_map.Properties.Clear();
            m_map.Properties.CopyFrom(m_oldProperties);
        }
    }
}
