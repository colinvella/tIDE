using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTile.ObjectModel
{
    public class PropertyCollection: Dictionary<string, PropertyValue>
    {
        public PropertyCollection()
            : base()
        {
        }

        public PropertyCollection(PropertyCollection propertyCollection)
            : base(propertyCollection.Count)
        {
            CopyFrom(propertyCollection);
        }

        public void CopyFrom(PropertyCollection propertyCollection)
        {
            foreach (KeyValuePair<string, PropertyValue> keyValuePair in propertyCollection)
                this[keyValuePair.Key] = new PropertyValue(keyValuePair.Value);
        }
    }
}
