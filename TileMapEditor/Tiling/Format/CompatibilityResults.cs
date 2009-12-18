using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tiling.Format
{
    [Serializable]
    public class CompatibilityResults
    {
        private bool m_compatible;
        private List<string> m_incompatiblities;

        public CompatibilityResults(bool compatible, List<string> incompatiblities)
        {
            m_compatible = compatible;
            m_incompatiblities = new List<string>(incompatiblities);
        }

        public bool Compatible
        {
            get { return m_compatible; }
        }

        public ReadOnlyCollection<string> Incompatiblities
        {
            get { return m_incompatiblities.AsReadOnly(); }
        }
    }
}
