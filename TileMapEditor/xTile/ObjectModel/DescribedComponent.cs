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

namespace xTile.ObjectModel
{
    /// <summary>
    /// Derivation of a Component type with a Description property
    /// </summary>
    public abstract class DescribedComponent : Component
    {
        #region Public Properties

        /// <summary>
        /// Description associated with this Component
        /// </summary>
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a default DescribedComponent. The object is
        /// assigned a GUID-based ID, a blank property collection
        /// and a blank description
        /// </summary>
        public DescribedComponent()
            :base()
        {
            m_description = "";
        }

        /// <summary>
        /// Constructs a DescribedComponent using the given ID. The object is
        /// assigned a blank property collection and a blank description
        /// </summary>
        /// <param name="id">ID to assign to the DescribedComponent</param>
        public DescribedComponent(string id)
            : base(id)
        {
            m_description = "";
        }

        /// <summary>
        /// Constructs a DescribedComponent using the given ID and
        /// description
        /// </summary>
        /// <param name="id">ID to assign to the DescribedComponent</param>
        /// <param name="description">Descriptive text to assign to the component</param>
        public DescribedComponent(string id, string description)
            : base(id)
        {
            m_description = description;
        }

        #endregion


        #region Private Variables

        private string m_description;

        #endregion
    }
}
