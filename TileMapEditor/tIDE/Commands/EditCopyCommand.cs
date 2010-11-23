using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using tIDE.TileBrushes;

namespace tIDE.Commands
{
    internal class EditCopyCommand : Command
    {
        private Layer m_layer;
        private TileSelection m_tileSelection;
        private TileBrush m_previousClipboardContent;

        public EditCopyCommand(Layer layer, TileSelection tileSelection)
        {
            m_layer = layer;
            m_tileSelection = tileSelection;

            m_description = "Copy selection from layer \"" + m_layer.Id + "\"";
        }

        public override void Do()
        {
            ClipBoardManager clipBoardManager = ClipBoardManager.Instance;
            m_previousClipboardContent = clipBoardManager.RetrieveTileBrush();
            TileBrush tileBrush = new TileBrush(m_layer, m_tileSelection);
            clipBoardManager.StoreTileBrush(tileBrush);
        }

        public override void Undo()
        {
            ClipBoardManager clipBoardManager = ClipBoardManager.Instance;
            clipBoardManager.StoreTileBrush(m_previousClipboardContent);
        }
    }
}
