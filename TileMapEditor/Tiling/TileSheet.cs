using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class TileSheet: DescribedComponent
    {
        private Map m_map;
        private string m_imageSource;
        private Size m_sheetSize;
        private Size m_tileSize;
        private Size m_margin;
        private Size m_spacing;

        public TileSheet(Map map, string imageSource, Size sheetSize, Size tileSize)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        public TileSheet(string id, Map map, string imageSource, Size sheetSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        public Map Map { get { return m_map; } }

        public string ImageSource { get { return m_imageSource; } }

        public Size TileSize { get { return m_tileSize; } }

        public Size Margin { get { return m_margin; } }

        public Size Spacing { get { return m_spacing; } }

        public int TileCount
        {
            get
            {
                int tileRows = (m_sheetSize.Height - m_margin.Height) / (m_tileSize.Height + m_spacing.Height);
                int tileColumns = (m_sheetSize.Width - m_margin.Width) / (m_tileSize.Width + m_spacing.Width);
                return tileRows * tileColumns;
            }
        }
    }
}
