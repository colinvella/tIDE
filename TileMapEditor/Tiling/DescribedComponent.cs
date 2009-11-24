using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public abstract class DescribedComponent: Component
    {
        #region Private Variables

        private string m_description;

        #endregion

        #region Public Methods

        public DescribedComponent()
            :base()
        {
            m_description = "";
        }

        public DescribedComponent(string id)
            : base(id)
        {
            m_description = "";
        }

        public DescribedComponent(string id, string description)
            : base(id)
        {
            m_description = description;
        }

        #endregion

        #region Public Properties

        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        #endregion
    }
}
