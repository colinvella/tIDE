using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tiling.Format
{
    public class FormatManager
    {
        private static FormatManager s_formatManager = new FormatManager();

        private Dictionary<string, IMapFormat> m_mapFormats;
        private StandardFormat m_standardFormat;

        private FormatManager()
        {
            m_mapFormats = new Dictionary<string, IMapFormat>();

            m_standardFormat = new StandardFormat();
            m_mapFormats[m_standardFormat.Name] = m_standardFormat;
        }

        public static FormatManager Instance { get { return s_formatManager; } }

        public void RegisterMapFormat(IMapFormat mapFormat)
        {
            if (m_mapFormats.ContainsKey(mapFormat.Name))
                throw new Exception("Map format '" + mapFormat.Name+ "' is already registered");

            m_mapFormats[mapFormat.Name] = mapFormat;
        }

        public void UnregisterMapFormat(IMapFormat mapFormat)
        {
            if (!m_mapFormats.ContainsKey(mapFormat.Name))
                throw new Exception("Map format '" + mapFormat.Name + "' is is not registered");

            m_mapFormats.Remove(mapFormat.Name);
        }

        public IMapFormat this[string mapFormatName]
        {
            get
            {
                if (!m_mapFormats.ContainsKey(mapFormatName))
                    throw new Exception("Map format '" + mapFormatName + "' is is not registered");

                return m_mapFormats[mapFormatName];
            }
        }

        public IMapFormat StandardFormat
        {
            get { return m_standardFormat; }
        }

        public ReadOnlyCollection<IMapFormat> MapFormats
        {
            get { return new List<IMapFormat>(m_mapFormats.Values).AsReadOnly(); }
        }
    }
}
