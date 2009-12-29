using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

namespace TileMapEditor.Commands
{
    internal class PasteCommand: Command
    {
        private Layer m_layer;
        private TileBrush m_tileBrush;
        private Location m_brushLocation;
        private TileSelection m_tileSelection;
        private bool m_fromClipboard;
        private TileBrush m_oldTiles;

        public PasteCommand(Layer layer,
            TileBrush tileBrush, Location brushLocation,
            TileSelection tileSelection, bool fromClipboard)
        {
            m_layer = layer;
            m_tileBrush = tileBrush;
            m_brushLocation = brushLocation;
            m_tileSelection = tileSelection;
            m_fromClipboard = fromClipboard;
            m_oldTiles = null;

            m_description = fromClipboard
                ? "Paste copied tiles" : "Paste tile brush \"" + tileBrush.Id + "\"";
            m_description += " at " + m_brushLocation + " in layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            TileSelection tileSelection = new TileSelection();
            m_tileBrush.GenerateSelection(m_brushLocation, tileSelection);
            m_oldTiles = new TileBrush(m_layer, tileSelection);

            m_tileBrush.ApplyTo(m_layer, m_brushLocation, m_tileSelection);
            if (!m_fromClipboard)
                m_tileSelection.Clear();
        }

        public override void Undo()
        {
            m_oldTiles.ApplyTo(m_layer, m_brushLocation, m_tileSelection);
            
            m_tileSelection.Clear();
        }
    }
}
