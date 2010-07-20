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
using System.IO;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    /// <summary>
    /// Abstract interface to a map format implementation
    /// </summary>
    public interface IMapFormat
    {
        #region Public Properties

        /// <summary>
        /// Name of this map format
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Descriptive text for this map format
        /// </summary>
        string FileExtensionDescriptor { get; }

        /// <summary>
        /// File extension associated with this map format
        /// </summary>
        string FileExtension { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a compatibility report for the given map
        /// according to this format
        /// </summary>
        /// <param name="map">Map to analyse</param>
        /// <returns>Format compatibility report</returns>
        CompatibilityReport DetermineCompatibility(Map map);

        /// <summary>
        /// Loads a map from the given stream according to this format
        /// </summary>
        /// <param name="stream">Stream from which to load the map</param>
        /// <returns>Map instance loaded from the given stream</returns>
        Map Load(Stream stream);

        /// <summary>
        /// Stores the given map in the given stream according to this format
        /// </summary>
        /// <param name="map">Map to store</param>
        /// <param name="stream">Output stream on which to store the map</param>
        void Store(Map map, Stream stream);

        #endregion
    }
}
