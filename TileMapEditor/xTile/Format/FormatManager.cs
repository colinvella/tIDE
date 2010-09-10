/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Public License (Ms-PL)                            //
//             http://www.opensource.org/licenses/ms-pl.html               //
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
using System.IO;

namespace xTile.Format
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

        /// <summary>
        /// Loads and returns a Map instance using the given file path. The map
        /// format is determined automatically from the file extension and the
        /// map is loaded using the corresponding IMapFormat implementation if
        /// available.
        /// </summary>
        /// <param name="filePath">Path to the map file to load</param>
        /// <returns>a loaded Map instance</returns>
        public Map LoadMap(string filePath)
        {
            try
            {
                if (filePath == null)
                    throw new Exception("A null file path was specified");

                string fileExtension
                    = Path.GetExtension(filePath).Replace(".", "");
                if (fileExtension.Length == 0)
                    throw new Exception("Cannot determine map format without a file extension");

                IMapFormat mapFormat = GetMapFormatByExtension(fileExtension);
                if (mapFormat == null)
                    throw new Exception("No IMapFormat implementation for files with extension '" + fileExtension + "'");

                Stream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                Map map = mapFormat.Load(fileStream);
                fileStream.Close();

                return map;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to load map with file path '" + filePath + "'", exception);
            }
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
