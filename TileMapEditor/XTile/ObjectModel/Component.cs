using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTile.ObjectModel
{
    [Serializable]
    public abstract class Component
    {
        private string m_id;
        private PropertyCollection m_propertyCollection;

        public Component()
        {
            m_id = Guid.NewGuid().ToString();
            m_propertyCollection = new PropertyCollection();
        }

        public Component(string id)
        {
            m_id = id;
            m_propertyCollection = new PropertyCollection();
        }

        public override string ToString()
        {
            return "Component: " + m_id;
        }

        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public PropertyCollection Properties { get { return m_propertyCollection; } }
    }
}
