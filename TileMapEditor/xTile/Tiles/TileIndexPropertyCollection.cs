using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile.Tiles;
using xTile.ObjectModel;

namespace xTile.Tiles
{
    internal class TileIndexPropertyCollection: IPropertyCollection
    {
        internal TileIndexPropertyCollection(TileSheet tileSheet, int tileIndex)
        {
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
        }

        private string IndexKey(string key)
        {
            return "@TileIndex@" + m_tileIndex + "@" + key;
        }

        private string ParseIndexedKey(string indexedKey)
        {
            string[] tokens = indexedKey.Split(new char[]{'@'});
            if (tokens.Length != 4)
                return null;

            if (tokens[0] != "")
                return null;

            if (tokens[1] != "TileIndex")
                return null;

            if (tokens[2] != m_tileIndex.ToString())
                return null;

            string key = tokens[3];
            return key;
        }

        public void CopyFrom(IPropertyCollection propertyCollection)
        {
            Clear();

            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            foreach (string key in propertyCollection.Keys)
                tilesheetProperties[IndexKey(key)] = propertyCollection[key];
        }

        public void Add(string key, PropertyValue propertyValue)
        {
            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            tilesheetProperties[IndexKey(key)] = propertyValue;
        }

        public bool ContainsKey(string key)
        {
            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            return tilesheetProperties.ContainsKey(IndexKey(key));
        }

        public ICollection<string> Keys
        {
            get
            {
                List<string> keys = new List<string>(m_tileSheet.Properties.Keys.Select(x => ParseIndexedKey(x)).Where(x => x != null));
                return keys;
            }
        }

        public bool Remove(string key)
        {
            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            return tilesheetProperties.Remove(IndexKey(key));;
        }

        public bool TryGetValue(string key, out PropertyValue propertyValue)
        {
            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            return tilesheetProperties.TryGetValue(IndexKey(key), out propertyValue);
        }

        public ICollection<PropertyValue> Values
        {
            get
            {
                IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                foreach (KeyValuePair<string, PropertyValue> keyValuePair in tilesheetProperties)
                {
                    string key = ParseIndexedKey(keyValuePair.Key);
                    if (key != null)
                        propertyValues.Add(keyValuePair.Value);
                }

                return propertyValues;
            }
        }

        public PropertyValue this[string key]
        {
            get
            {
                return m_tileSheet.Properties[IndexKey(key)];
            }
            set
            {
                m_tileSheet.Properties[IndexKey(key)] = value;
            }
        }

        public void Add(KeyValuePair<string, PropertyValue> keyValuPair)
        {
            this[keyValuPair.Key] = keyValuPair.Value;
        }

        public void Clear()
        {
            IPropertyCollection tilesheetProperties = m_tileSheet.Properties;
            IEnumerable<string> oldIndexedKeys
                = tilesheetProperties.Keys.Where(x => ParseIndexedKey(x) != null).ToArray();
            foreach (string indexedKey in oldIndexedKeys)
                tilesheetProperties.Remove(indexedKey);
        }

        public bool Contains(KeyValuePair<string, PropertyValue> keyValuePair)
        {
            return m_tileSheet.Properties.Contains(
                new KeyValuePair<string, PropertyValue>(
                    IndexKey(keyValuePair.Key), keyValuePair.Value));
        }

        public void CopyTo(KeyValuePair<string, PropertyValue>[] array, int arrayIndex)
        {
            foreach (string key in Keys)
            {
                PropertyValue propertyValue = this[key];
                array[arrayIndex++] = new KeyValuePair<string,PropertyValue>(key, propertyValue);
            }
        }

        public int Count
        {
            get { return Keys.Count; }
        }

        public bool IsReadOnly
        {
            get { return m_tileSheet.Properties.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<string, PropertyValue> keyValuePair)
        {
            string indexedKey = ParseIndexedKey(keyValuePair.Key);
            if (indexedKey == null)
                return false;

            keyValuePair = new KeyValuePair<string,PropertyValue>(indexedKey, keyValuePair.Value);

            return m_tileSheet.Properties.Remove(keyValuePair);
        }

        public IEnumerator<KeyValuePair<string, PropertyValue>> GetEnumerator()
        {
            List<KeyValuePair<string, PropertyValue>> keyValuePairs
                = new List<KeyValuePair<string, PropertyValue>>();

            foreach (string key in Keys)
            {
                PropertyValue propertyValue = this[key];
                KeyValuePair<string, PropertyValue> keyValuePair
                    = new KeyValuePair<string, PropertyValue>(key, propertyValue);

                keyValuePairs.Add(keyValuePair);
            }

            return keyValuePairs.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private TileSheet m_tileSheet;
        private int m_tileIndex;
    }
}
