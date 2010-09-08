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

namespace XTile.ObjectModel
{
    /// <summary>
    /// Represents the value of a property within a property collection
    /// </summary>
    [Serializable]
    public class PropertyValue
    {
        #region Public Properties

        /// <summary>
        /// Property type
        /// </summary>
        public Type Type { get { return m_value.GetType(); } }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Implicit constructor from a boolean value
        /// </summary>
        /// <param name="value">boolean value to assign</param>
        /// <returns>Boolean property value instance</returns>
        public static implicit operator PropertyValue(bool value)
        {
            return new PropertyValue(value);
        }

        /// <summary>
        /// Implicit constructor from an integer value
        /// </summary>
        /// <param name="value">integer value to assign</param>
        /// <returns>Integer property value instance</returns>
        public static implicit operator PropertyValue(int value)
        {
            return new PropertyValue(value);
        }

        /// <summary>
        /// Implicit constructor from a floating point value
        /// </summary>
        /// <param name="value">float value to assign</param>
        /// <returns>Float property value instance</returns>
        public static implicit operator PropertyValue(float value)
        {
            return new PropertyValue(value);
        }

        /// <summary>
        /// Implicit constructor from a string value
        /// </summary>
        /// <param name="value">string value to assign</param>
        /// <returns>String property value instance</returns>
        public static implicit operator PropertyValue(string value)
        {
            return new PropertyValue(value);
        }

        /// <summary>
        /// Implicit cast operator to a boolean value
        /// </summary>
        /// <param name="propertyValue">property value to cast</param>
        /// <returns>Boolean value</returns>
        public static implicit operator bool(PropertyValue propertyValue)
        {
            if (!(propertyValue.m_value is bool))
                throw new Exception("Cannot cast to a boolean value");
            return (bool)propertyValue.m_value;
        }

        /// <summary>
        /// Implicit cast operator to an integer value
        /// </summary>
        /// <param name="propertyValue">property value to cast</param>
        /// <returns>Integer value</returns>
        public static implicit operator int(PropertyValue propertyValue)
        {
            if (!(propertyValue.m_value is int))
                throw new Exception("Cannot cast to an integer value");
            return (int)propertyValue.m_value;
        }

        /// <summary>
        /// Implicit cast operator to a floating point value
        /// </summary>
        /// <param name="propertyValue">property value to cast</param>
        /// <returns>Float value</returns>
        public static implicit operator float(PropertyValue propertyValue)
        {
            if (propertyValue.m_value is int)
                return (float)(int)propertyValue.m_value;
            else if (propertyValue.m_value is float)
                return (float)propertyValue.m_value;
            else
                throw new Exception("Cannot cast to a float value");
        }

        /// <summary>
        /// Implicit cast operator to a string value
        /// </summary>
        /// <param name="propertyValue">property value to cast</param>
        /// <returns>String value</returns>
        public static implicit operator string(PropertyValue propertyValue)
        {
            return propertyValue.m_value.ToString();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a property value from a boolean
        /// </summary>
        /// <param name="value">Boolean value to assign</param>
        public PropertyValue(bool value)
        {
            m_value = value;
        }

        /// <summary>
        /// Constructs a property value from an integer
        /// </summary>
        /// <param name="value">Integer value to assign</param>
        public PropertyValue(int value)
        {
            m_value = value;
        }

        /// <summary>
        /// Constructs a property value from a floating point value
        /// </summary>
        /// <param name="value">Float value to assign</param>
        public PropertyValue(float value)
        {
            m_value = value;
        }

        /// <summary>
        /// Constructs a property value from a string
        /// </summary>
        /// <param name="value">String value to assign</param>
        public PropertyValue(string value)
        {
            m_value = value;
        }

        /// <summary>
        /// Constructs a property value from another
        /// </summary>
        /// <param name="propertyValue">Property value to clone</param>
        public PropertyValue(PropertyValue propertyValue)
        {
            m_value = propertyValue.m_value;
        }

        /// <summary>
        /// Returns a string representation of the property value
        /// </summary>
        /// <returns>String representation of the property value</returns>
        public override string ToString()
        {
            return m_value.ToString();

        }

        #endregion

        #region Pprivate Variables

        private object m_value;

        #endregion
    }
}
