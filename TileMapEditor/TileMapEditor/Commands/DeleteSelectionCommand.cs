using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class DeleteSelectionCommand: Command
    {
        private Layer m_layer;
        private Location m_selectionLocation;
        private TileSelection m_tileSelection;
        private TileBrush m_tileBrush;

        public DeleteSelectionCommand(Layer layer, TileSelection tileSelection, bool isCut)
        {
            m_layer = layer;
            m_selectionLocation = tileSelection.Bounds.Location;
            m_tileSelection = tileSelection;
            m_tileBrush = new TileBrush(m_layer, m_tileSelection);

            m_description = isCut ? "Cut " : "Erase ";
            m_description += "selection from layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            foreach (TileBrushElement tileBrushElement in m_tileBrush.Elements)
            {
                Location location = m_selectionLocation + tileBrushElement.Location;
                m_layer.Tiles[location] = null;
            }
        }

        public override void Undo()
        {
            m_tileBrush.ApplyTo(m_layer, m_selectionLocation, m_tileSelection);
            foreach (TileBrushElement tileBrushElement in m_tileBrush.Elements)
            {
                Location location = m_selectionLocation + tileBrushElement.Location;
                m_layer.Tiles[location] = tileBrushElement.Tile;
            }
        }
    }
}
