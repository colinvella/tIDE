using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class EditDeleteCommand: Command
    {
        private Layer m_layer;
        private Location m_selectionLocation;
        private TileSelection m_tileSelection;
        private TileBrush m_tileBrush;

        public EditDeleteCommand(Layer layer, TileSelection tileSelection, bool isCut)
        {
            m_layer = layer;
            m_selectionLocation = tileSelection.Bounds.Location;
            m_tileSelection = tileSelection;
            m_tileBrush = null;

            m_description = isCut ? "Cut " : "Erase ";
            m_description += "selection from layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            m_tileBrush = new TileBrush(m_layer, m_tileSelection);
            m_tileSelection.EraseTiles(m_layer);
        }

        public override void Undo()
        {
            m_tileBrush.ApplyTo(m_layer, m_selectionLocation, m_tileSelection);
        }
    }
}
