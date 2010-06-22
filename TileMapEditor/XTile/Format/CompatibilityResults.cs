using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    [Serializable]
    public enum CompatibilityLevel
    {
        Full,
        Partial,
        None
    }

    [Serializable]
    public class CompatibilityResults
    {
        private CompatibilityLevel m_compatibilityLevel;
        private List<string> m_remarks;

        public CompatibilityResults(CompatibilityLevel compatibilityLevel, List<string> remarks)
        {
            m_compatibilityLevel = compatibilityLevel;
            m_remarks = new List<string>(remarks);
        }

        public CompatibilityResults(CompatibilityLevel compatibilityLevel)
        {
            m_compatibilityLevel = compatibilityLevel;
            m_remarks = new List<string>();
        }

        public CompatibilityLevel CompatibilityLevel
        {
            get { return m_compatibilityLevel; }
        }

        public ReadOnlyCollection<string> Remarks
        {
            get { return m_remarks.AsReadOnly(); }
        }
    }
}
