using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Tiles;
using Tiling.ObjectModel;

namespace TileMapEditor.Commands
{
    internal class TilePropertiesCommand: Command
    {
        private Tile m_tile;
        private string m_oldId, m_newId;
        private PropertyCollection m_oldProperties, m_newProperties;

        public TilePropertiesCommand(Tile tile, string newId, PropertyCollection newProperties)
        {
            m_tile = tile;

            m_oldId = tile.Id;
            m_oldProperties = new PropertyCollection(tile.Properties);

            m_newId = newId;
            m_newProperties = newProperties;

            m_description = "Change tile properties";
        }

        public override void Do()
        {
            m_tile.Id = m_newId;
            m_tile.Properties.Clear();
            m_tile.Properties.CopyFrom(m_newProperties);
        }

        public override void Undo()
        {
            m_tile.Id = m_oldId;
            m_tile.Properties.Clear();
            m_tile.Properties.CopyFrom(m_oldProperties);
        }
    }
}
