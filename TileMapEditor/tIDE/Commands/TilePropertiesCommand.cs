using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Tiles;
using XTile.ObjectModel;

namespace TileMapEditor.Commands
{
    internal class TilePropertiesCommand: Command
    {
        private Tile m_tile;
        private string m_oldId, m_newId;
        private BlendMode m_oldBlendMode, m_newBlendMode;
        private PropertyCollection m_oldProperties, m_newProperties;

        public TilePropertiesCommand(Tile tile, string newId, BlendMode newBlendMode, PropertyCollection newProperties)
        {
            m_tile = tile;

            m_oldId = tile.Id;
            m_oldBlendMode = tile.BlendMode;
            m_oldProperties = new PropertyCollection(tile.Properties);

            m_newId = newId;
            m_newBlendMode = newBlendMode;
            m_newProperties = newProperties;

            m_description = "Change tile properties";
        }

        public override void Do()
        {
            m_tile.Id = m_newId;
            m_tile.BlendMode = m_newBlendMode;
            m_tile.Properties.Clear();
            m_tile.Properties.CopyFrom(m_newProperties);
        }

        public override void Undo()
        {
            m_tile.Id = m_oldId;
            m_tile.BlendMode = m_oldBlendMode;
            m_tile.Properties.Clear();
            m_tile.Properties.CopyFrom(m_oldProperties);
        }
    }
}
