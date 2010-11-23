using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tIDE.Plugin
{
    public struct Version
    {
        private byte m_major;
        private byte m_minor;

        public static bool operator ==(Version version1, Version version2)
        {
            return version1.m_major == version2.m_major
                && version1.m_minor == version2.m_minor;
        }

        public static bool operator !=(Version version1, Version version2)
        {
            return version1.m_major != version2.m_major
                || version1.m_minor != version2.m_minor;
        }

        public Version(byte major, byte minor)
        {
            m_major = major;
            m_minor = minor;
        }

        public byte Major { get { return m_major; } }

        public byte Minor { get { return m_minor; } }

        public override int GetHashCode()
        {
            return m_major << 8 + m_minor; ;
        }

        public override bool Equals(object other)
        {
            if (!(other is Version))
                return false;

            Version version = (Version)other;
            return this == version;
        }

        public override string ToString()
        {
            return m_major + "." + m_minor;
        }
    }
}
