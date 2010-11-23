using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Tiles;
using tIDE.TileBrushes;

namespace tIDE.Controls
{
    public class TilePickerEventArgs: EventArgs
    {
        private TileSheet m_tileSheet;
        private int m_tileIndex;
        private TileBrush m_tileBrush;

        public TilePickerEventArgs(TileSheet tileSheet, int tileIndex)
        {
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
            m_tileBrush = null;
        }

        public TilePickerEventArgs(TileBrush tileBrush)
        {
            m_tileSheet = null;
            m_tileIndex = -1;
            m_tileBrush = tileBrush;
        }

        public TileSheet TileSheet { get { return m_tileSheet; } }

        public int TileIndex { get { return m_tileIndex; } }

        public TileBrush TileBrush { get { return m_tileBrush; } }
    }
}
