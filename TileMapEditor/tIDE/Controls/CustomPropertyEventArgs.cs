using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile.ObjectModel;

namespace tIDE.Controls
{
    public class CustomPropertyEventArgs: EventArgs
    {
        private string m_newPropertyName;
        private string m_oldPropertyName;
        private PropertyValue m_oldPropertyValue;
        private PropertyValue m_newPropertyValue;

        public CustomPropertyEventArgs(
            string newPropertyName, string oldPropertyName,
            PropertyValue oldPropertyValue, PropertyValue newPropertyValue)
        {
            m_newPropertyName = newPropertyName;
            m_oldPropertyName = oldPropertyName;
            m_oldPropertyValue = oldPropertyValue;
            m_newPropertyValue = newPropertyValue;
        }

        public string NewPropertyName { get { return m_newPropertyName; } }

        public string OldPropertyName { get { return m_oldPropertyName; } }

        public PropertyValue OldPropertyValue { get { return m_oldPropertyValue; } }

        public PropertyValue NewPropertyValue { get { return m_newPropertyValue; } }
    }

    public delegate void CustomPropertyEventHandler(object sender,
        CustomPropertyEventArgs customPropertyEventArgs);
}
