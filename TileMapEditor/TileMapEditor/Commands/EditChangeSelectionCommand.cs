using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Layers;

namespace TileMapEditor.Commands
{
    internal enum ChangeSelectionType
    {
        SelectAll,
        Clear,
        Invert
    }

    internal class EditChangeSelectionCommand: Command
    {
        private Layer m_layer;
        private TileSelection m_currentTileSelection;
        private TileSelection m_oldTileSelection;
        private ChangeSelectionType m_changeSelectionType;

        public EditChangeSelectionCommand(Layer layer,
            TileSelection currentTileSelection,
            ChangeSelectionType changeSelectionType)
        {
            m_layer = layer;
            m_currentTileSelection = currentTileSelection;
            m_oldTileSelection = new TileSelection(currentTileSelection);
            m_changeSelectionType = changeSelectionType;

            switch (m_changeSelectionType)
            {
                case ChangeSelectionType.SelectAll:
                    m_description = "Select all tiles";
                    break;
                case ChangeSelectionType.Clear:
                    m_description = "Clear tile selection";
                    break;
                case ChangeSelectionType.Invert:
                    m_description = "Invert tile selection"; 
                    break;
            }
        }

        public override void Do()
        {
            Rectangle selectionContext
                = new Rectangle(Location.Origin, m_layer.LayerSize);

            switch (m_changeSelectionType)
            {
                case ChangeSelectionType.SelectAll:
                    m_currentTileSelection.SelectAll(selectionContext);
                    break;
                case ChangeSelectionType.Clear:
                    m_currentTileSelection.Clear();
                    break;
                case ChangeSelectionType.Invert:
                    m_currentTileSelection.Invert(selectionContext);
                    break;
            }
        }

        public override void Undo()
        {
            m_currentTileSelection.Clear();
            m_currentTileSelection.Merge(m_oldTileSelection);
        }
    }
}
