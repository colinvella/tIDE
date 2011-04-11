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
using System.Linq;
using System.Text;

namespace xTile.ObjectModel
{
    /// <summary>
    /// Implementation of a custom property collection used by
    /// component objects. This class extends the .NET Framework
    /// generic Dictionary class
    /// </summary>
    public class PropertyCollection : Dictionary<string, PropertyValue>
    {
        /// <summary>
        /// Constucts an empty property collection
        /// </summary>
        public PropertyCollection()
            : base()
        {
        }

        /// <summary>
        /// Constucts a property collection by cloning the given
        /// collection
        /// </summary>
        /// <param name="propertyCollection">Property collection to clone</param>
        public PropertyCollection(PropertyCollection propertyCollection)
            : base(propertyCollection.Count)
        {
            CopyFrom(propertyCollection);
        }

        /// <summary>
        /// Copies the given property collection into this collection
        /// </summary>
        /// <param name="propertyCollection">Property collection to copy from</param>
        public void CopyFrom(PropertyCollection propertyCollection)
        {
            foreach (KeyValuePair<string, PropertyValue> keyValuePair in propertyCollection)
                this[keyValuePair.Key] = new PropertyValue(keyValuePair.Value);
        }
    }
}
