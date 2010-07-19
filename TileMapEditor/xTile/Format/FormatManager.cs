using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    public class FormatManager
    {
        private static FormatManager s_formatManager = new FormatManager();

        private Dictionary<string, IMapFormat> m_mapFormats;
        private TideFormat m_defaultFormat;

        private FormatManager()
        {
            m_mapFormats = new Dictionary<string, IMapFormat>();

            // register default format
            m_defaultFormat = new TideFormat();
            m_mapFormats[m_defaultFormat.Name] = m_defaultFormat;

            // register other supported formats

            // Tiled Format
            TiledTmxFormat tiledTmxFormat = new TiledTmxFormat();
            m_mapFormats[tiledTmxFormat.Name] = tiledTmxFormat;
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

        public IMapFormat GetMapFormatByExtension(string fileExtension)
        {
            foreach (IMapFormat mapFormat in m_mapFormats.Values)
                if (mapFormat.FileExtension.Equals(fileExtension,
                    StringComparison.InvariantCultureIgnoreCase))
                    return mapFormat;
            return null;
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

        public IMapFormat DefaultFormat
        {
            get { return m_defaultFormat; }
        }

        public ReadOnlyCollection<IMapFormat> MapFormats
        {
            get { return new List<IMapFormat>(m_mapFormats.Values).AsReadOnly(); }
        }
    }
}
