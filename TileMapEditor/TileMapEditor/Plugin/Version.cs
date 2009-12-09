using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileMapEditor.Plugin
{
    public struct Version
    {
        private byte m_major;
        private byte m_minor;

        public Version(byte major, byte minor)
        {
            m_major = major;
            m_minor = minor;
        }

        public byte Major { get { return m_major; } }

        public byte Minor { get { return m_minor; } }

        public override string ToString()
        {
            return m_major + "." + m_minor;
        }
    }
}
