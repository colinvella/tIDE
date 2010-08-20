/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Reciprocal License (Ms-RL)                        //
//             http://www.opensource.org/licenses/ms-rl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    /// <summary>
    /// A singleton manager of registered file map formats. Direct access is provided
    /// to the default tIDE map format (.tide). Other formats are querable by extension
    /// </summary>
    public class FormatManager
    {
        #region Public Static Properties

        /// <summary>
        /// Reference to the singleton manager instance
        /// </summary>
        public static FormatManager Instance { get { return s_formatManager; } }

        #endregion

        #region Public Properties

        /// <summary>
        /// String-based indexer for map formap implementations
        /// </summary>
        /// <param name="mapFormatName">Format name to query</param>
        /// <returns></returns>
        public IMapFormat this[string mapFormatName]
        {
            get
            {
                if (!m_mapFormats.ContainsKey(mapFormatName))
                    throw new Exception("Map format '" + mapFormatName + "' is is not registered");

                return m_mapFormats[mapFormatName];
            }
        }

        /// <summary>
        /// Returns the default tIDE format
        /// </summary>
        public IMapFormat DefaultFormat
        {
            get { return m_defaultFormat; }
        }

        /// <summary>
        /// Returns a collection of registered map formats
        /// </summary>
        public ReadOnlyCollection<IMapFormat> MapFormats
        {
            get { return new List<IMapFormat>(m_mapFormats.Values).AsReadOnly(); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers the given map format
        /// </summary>
        /// <param name="mapFormat">Map format implementation to register</param>
        public void RegisterMapFormat(IMapFormat mapFormat)
        {
            if (m_mapFormats.ContainsKey(mapFormat.Name))
                throw new Exception("Map format '" + mapFormat.Name+ "' is already registered");

            m_mapFormats[mapFormat.Name] = mapFormat;
        }

        /// <summary>
        /// Unregisters the given map format
        /// </summary>
        /// <param name="mapFormat">Map format implementation to unregister</param>
        public void UnregisterMapFormat(IMapFormat mapFormat)
        {
            if (!m_mapFormats.ContainsKey(mapFormat.Name))
                throw new Exception("Map format '" + mapFormat.Name + "' is is not registered");

            m_mapFormats.Remove(mapFormat.Name);
        }

        /// <summary>
        /// Returns the map format implementation for the given file extension
        /// or Null if not matched
        /// </summary>
        /// <param name="fileExtension">File extension to query</param>
        /// <returns></returns>
        public IMapFormat GetMapFormatByExtension(string fileExtension)
        {
            foreach (IMapFormat mapFormat in m_mapFormats.Values)
                if (mapFormat.FileExtension.Equals(fileExtension,
                    StringComparison.InvariantCultureIgnoreCase))
                    return mapFormat;
            return null;
        }

        #endregion

        #region Private Methods

        private FormatManager()
        {
            m_mapFormats = new Dictionary<string, IMapFormat>();

            // register default format
            m_defaultFormat = new TideFormat();
            m_mapFormats[m_defaultFormat.Name] = m_defaultFormat;
        }

        #endregion

        #region Private Static Variables

        private static FormatManager s_formatManager = new FormatManager();

        #endregion

        #region Private Variables

        private Dictionary<string, IMapFormat> m_mapFormats;
        private TideFormat m_defaultFormat;

        #endregion
    }
}
