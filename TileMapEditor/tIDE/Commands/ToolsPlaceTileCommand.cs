using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using tIDE.AutoTiles;

namespace tIDE.Commands
{
    internal class ToolsPlaceTileCommand: Command
    {
        private Layer m_layer; 
        private Dictionary<Location, Tile> m_newAssignments, m_oldAssignments;

        public ToolsPlaceTileCommand(Layer layer, Tile newTile, Location tileLocation)
        {
            m_layer = layer;

            if (newTile is StaticTile)
            {
                m_newAssignments = AutoTileManager.Instance.DetermineTileAssignments(
                    m_layer, tileLocation, (StaticTile) newTile);
            }
            else
            {
                m_newAssignments = new Dictionary<Location, Tile>();
                m_newAssignments[tileLocation] = newTile;
            }

            m_oldAssignments = new Dictionary<Location, Tile>();
            foreach (Location assignedLocation in m_newAssignments.Keys)
                m_oldAssignments[assignedLocation] = layer.Tiles[assignedLocation];

            m_description = "Place tile \"" + newTile.TileSheet.Id + ":" + newTile.TileIndex 
                + "\" at " + tileLocation + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            foreach (Location assignedLocation in m_newAssignments.Keys)
                m_layer.Tiles[assignedLocation] = m_newAssignments[assignedLocation];
        }

        public override void Undo()
        {
            foreach (Location assignedLocation in m_oldAssignments.Keys)
                m_layer.Tiles[assignedLocation] = m_oldAssignments[assignedLocation];
        }
    }
}
