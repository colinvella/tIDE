using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xTile.ObjectModel
{
    /// <summary>
    /// Interface to a custom property collection used by
    /// component objects. This interface extends the .NET Framework
    /// generic Dictionary class
    /// </summary>
    public interface IPropertyCollection : IDictionary<string, PropertyValue>
    {
        /// <summary>
        /// Copies the given property collection into this collection
        /// </summary>
        /// <param name="propertyCollection">Property collection to copy from</param>
        void CopyFrom(IPropertyCollection propertyCollection);
    }
}
