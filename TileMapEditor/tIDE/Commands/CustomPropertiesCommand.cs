using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.ObjectModel;

namespace TileMapEditor.Commands
{
    internal class CustomPropertiesCommand: Command
    {
        private Component m_component;
        private PropertyCollection m_oldProperties, m_newProperties;

        public CustomPropertiesCommand(Component component, PropertyCollection newProperties)
        {
            m_component = component;

            m_oldProperties = new PropertyCollection(component.Properties);

            m_newProperties = newProperties;

            m_description = "Change custom properties";
        }

        public override void Do()
        {
            m_component.Properties.Clear();
            m_component.Properties.CopyFrom(m_newProperties);
        }

        public override void Undo()
        {
            m_component.Properties.Clear();
            m_component.Properties.CopyFrom(m_oldProperties);
        }
    }
}
