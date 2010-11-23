using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Layers;

namespace tIDE.Commands
{
    internal class ToolsSelectCommand: Command
    {
        private Layer m_layer;
        private TileSelection m_currentTileSelection;
        private TileSelection m_oldTileSelection;
        private TileSelection m_newTileSelection;
        private bool m_replace;

        public ToolsSelectCommand(Layer layer,
            TileSelection currentTileSelection, TileSelection newTileSelection,
            bool replace)
        {
            m_layer = layer;
            m_currentTileSelection = currentTileSelection;
            m_oldTileSelection = new TileSelection(currentTileSelection);
            m_newTileSelection = new TileSelection(newTileSelection);
            m_replace = replace;

            if (m_replace)
                m_description = newTileSelection.IsEmpty() ? "Clear selection" : "Select tiles";
            else
                m_description = "Select more tiles";
        }

        public override void Do()
        {
            if (m_replace)
                m_currentTileSelection.Clear();
            m_currentTileSelection.Merge(m_newTileSelection);
        }

        public override void Undo()
        {
            m_currentTileSelection.Clear();
            m_currentTileSelection.Merge(m_oldTileSelection);
        }
    }
}
