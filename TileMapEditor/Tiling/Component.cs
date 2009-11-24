using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public abstract class Component
    {
        private string m_id;
        private Dictionary<string, PropertyValue> m_properties;

        public Component()
        {
            m_id = Guid.NewGuid().ToString();
            m_properties = new Dictionary<string, PropertyValue>();
        }

        public Component(string id)
        {
            m_id = id;
            m_properties = new Dictionary<string, PropertyValue>();
        }

        public override string ToString()
        {
            return "Component: " + m_id;
        }

        public string Id { get { return m_id; } }

        public Dictionary<string, PropertyValue> Properties { get { return m_properties; } }
    }
}
