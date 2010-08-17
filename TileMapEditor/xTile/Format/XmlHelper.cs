using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XTile.Format
{
    internal class XmlHelper
    {
        private XmlReader m_xmlReader;

        public XmlHelper(XmlReader xmlReader)
        {
            m_xmlReader = xmlReader;
        }

        public XmlNodeType AdvanceNode()
        {
            if (!m_xmlReader.Read())
                throw new Exception("End of XML stream reached");

            return m_xmlReader.NodeType;
        }

        public void AdvanceNode(XmlNodeType xmlNodeType)
        {
            AdvanceNode();

            if (m_xmlReader.NodeType != xmlNodeType)
                throw new Exception("The expected node is " + xmlNodeType);
        }

        public void AdvanceNamedNode(XmlNodeType xmlNodeType, string nodeName)
        {
            AdvanceNode(xmlNodeType);

            if (m_xmlReader.Name != nodeName)
                throw new Exception("Node '" + nodeName + "' of type '"
                    + xmlNodeType + "' expected");
        }

        public void AdvanceDeclaration()
        {
            AdvanceNode(XmlNodeType.XmlDeclaration);
        }

        public void AdvanceStartElement(string elementName)
        {
            AdvanceNamedNode(XmlNodeType.Element, elementName);
        }

        public bool AdvanceStartRepeatedElement(string elementName, string closingContainerName)
        {
            // handle empty container element
            if (m_xmlReader.NodeType == XmlNodeType.Element && m_xmlReader.IsEmptyElement
                && m_xmlReader.Name == closingContainerName)
                return false;

            XmlNodeType xmlNodeType = AdvanceNode();

            if (xmlNodeType == XmlNodeType.EndElement)
            {
                if (m_xmlReader.Name == closingContainerName)
                    return false;
                else
                    throw new Exception("Expected closing element '" + closingContainerName + "'");
            }

            if (xmlNodeType != XmlNodeType.Element
                || (xmlNodeType == XmlNodeType.Element && m_xmlReader.Name != elementName))
                throw new Exception(
                    "Repeated element '" + elementName
                    + "' or closing container element expected");

            return true;
        }

        public void AdvanceEndElement(string elementName)
        {
            if (m_xmlReader.IsEmptyElement && m_xmlReader.Name == elementName)
                return;

            AdvanceNamedNode(XmlNodeType.EndElement, elementName);
        }

        public string GetAttribute(string attributeName)
        {
            if (!m_xmlReader.HasAttributes)
                throw new Exception("Node '" + m_xmlReader.Name + "' of type '"
                    + m_xmlReader.NodeType + "' has no attributes");

            string attributeValue = m_xmlReader.GetAttribute(attributeName);
            if (attributeValue == null)
                throw new Exception(
                    "No attribute '" + attributeName + "' defined");

            return attributeValue;
        }

        public string GetAttribute(string attributeName, string defaultValue)
        {
            string attributeValue = m_xmlReader.GetAttribute(attributeName);

            return attributeValue == null ? defaultValue : attributeValue;
        }

        public int GetIntAttribute(string attributeName)
        {
            string attributeValue = GetAttribute(attributeName);
            try
            {
                // note: TryParse not supported by .NET CF
                return int.Parse(attributeValue);
            }
            catch (Exception exception)
            {
                throw new Exception("Attribute '" + attributeValue + "' is not a valid integer", exception);
            }
        }

        public int GetIntAttribute(string attributeName, int defaultValue)
        {
            string attributeValueString = m_xmlReader.GetAttribute(attributeName);

            if (attributeValueString == null)
                return defaultValue;

            try
            {
                // note: TryParse not supported by .NET CF
                return int.Parse(attributeValueString);
            }
            catch (Exception exception)
            {
                throw new Exception("Attribute '" + attributeValueString + "' is not a valid integer", exception);
            }
        }

        public string GetCData()
        {
            AdvanceNode(XmlNodeType.CDATA);
            return m_xmlReader.Value;
        }

        public XmlReader XmlReader
        {
            get { return m_xmlReader; }
        }
    }
}
