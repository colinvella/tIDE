using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Tiles;

namespace TileMapEditor.Controls
{
    public class TilePickerEventArgs
    {
        private TileSheet m_tileSheet;
        private int m_tileIndex;

        public TilePickerEventArgs(TileSheet tileSheet, int tileIndex)
        {
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
        }

        public TileSheet TileSheet { get { return m_tileSheet; } }

        public int TileIndex { get { return m_tileIndex; } }
    }
}
