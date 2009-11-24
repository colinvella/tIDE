using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class PropertyValue
    {
        private object m_value;

        public static implicit operator PropertyValue(bool value)
        {
            return new PropertyValue(value);
        }

        public static implicit operator PropertyValue(int value)
        {
            return new PropertyValue(value);
        }

        public static implicit operator PropertyValue(float value)
        {
            return new PropertyValue(value);
        }

        public static implicit operator PropertyValue(string value)
        {
            return new PropertyValue(value);
        }

        public static implicit operator bool(PropertyValue propertyValue)
        {
            if (!(propertyValue.m_value is bool))
                throw new Exception("Cannot cast to a boolean value");
            return (bool)propertyValue.m_value;
        }

        public static implicit operator int(PropertyValue propertyValue)
        {
            if (!(propertyValue.m_value is int))
                throw new Exception("Cannot cast to an integer value");
            return (int)propertyValue.m_value;
        }

        public static implicit operator float(PropertyValue propertyValue)
        {
            if (propertyValue.m_value is int)
                return (float)(int)propertyValue.m_value;
            else if (propertyValue.m_value is float)
                return (float)propertyValue.m_value;
            else
                throw new Exception("Cannot cast to a float value");
        }

        public static implicit operator string(PropertyValue propertyValue)
        {
            return propertyValue.m_value.ToString();
        }

        public PropertyValue(bool value)
        {
            m_value = value;
        }

        public PropertyValue(int value)
        {
            m_value = value;
        }

        public PropertyValue(float value)
        {
            m_value = value;
        }

        public PropertyValue(string value)
        {
            m_value = value;
        }

        public Type Type { get { return m_value.GetType(); } }

        public override string ToString()
        {
            return m_value.ToString();
        }
    }
}
