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
    /// Base class for all xTile map components. Can be assigned an ID and
    /// optionally one or more custom properties
    /// </summary>
    [Serializable]
    public abstract class Component
    {
        #region Public Properties

        /// <summary>
        /// Identifier string for this Component
        /// </summary>
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// Custom Property collection associated with this Component
        /// </summary>
        public PropertyCollection Properties { get { return m_propertyCollection; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a Component with an automatically-assigned GUID
        /// </summary>
        public Component()
        {
            m_id = Guid.NewGuid().ToString();
            m_propertyCollection = new PropertyCollection();
        }

        /// <summary>
        /// Constructs a Component with the given ID
        /// </summary>
        /// <param name="id">ID to assign to the Component</param>
        public Component(string id)
        {
            m_id = id;
            m_propertyCollection = new PropertyCollection();
        }

        /// <summary>
        /// Returns a string representation of this Component
        /// </summary>
        /// <returns>string representation of this Component</returns>
        public override string ToString()
        {
            return "Component: " + m_id;
        }

        #endregion

        #region Private Variables

        private string m_id;
        private PropertyCollection m_propertyCollection;

        #endregion
    }
}
