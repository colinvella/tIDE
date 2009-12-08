using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor
{
    public class ClipBoardManager
    {
        private static ClipBoardManager s_clipBoardManager = new ClipBoardManager();

        private TileBrush m_tileBrush;

        private ClipBoardManager()
        {
            m_tileBrush = null;
        }

        public static ClipBoardManager Instance { get { return s_clipBoardManager; } }

        public bool HasTileBrush()
        {
            return m_tileBrush != null;
        }

        public void StoreTileBrush(TileBrush tileBrush)
        {
            m_tileBrush = tileBrush;
        }

        public TileBrush RetrieveTileBrush()
        {
            return m_tileBrush;
        }
    }
}
