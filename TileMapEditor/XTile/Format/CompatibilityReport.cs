using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    [Serializable]
    public class CompatibilityReport
    {
        public CompatibilityReport(List<CompatibilityNote> compatibilityNotes)
        {
            m_compatibilityNotes = new List<CompatibilityNote>(compatibilityNotes);
        }

        public CompatibilityReport()
        {
            m_compatibilityNotes = new List<CompatibilityNote>();
        }

        public CompatibilityLevel CompatibilityLevel
        {
            get
            {
                CompatibilityLevel compatibilityLevel = CompatibilityLevel.Full;

                foreach (CompatibilityNote compatibilityNote in m_compatibilityNotes)
                {
                    switch (compatibilityNote.CompatibilityLevel)
                    {
                        case CompatibilityLevel.None:
                            return CompatibilityLevel.None;
                        case CompatibilityLevel.Partial:
                            compatibilityLevel = CompatibilityLevel.Partial;
                            break;
                    }
                }

                return compatibilityLevel;
            }
        }

        public ReadOnlyCollection<CompatibilityNote> CompatibilityNotes
        {
            get { return m_compatibilityNotes.AsReadOnly(); }
        }

        private List<CompatibilityNote> m_compatibilityNotes;
    }
}
