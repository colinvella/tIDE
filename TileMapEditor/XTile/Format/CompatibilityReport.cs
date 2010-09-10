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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace xTile.Format
{
    /// <summary>
    /// Represents a report on the compatibility of a map in a given format
    /// </summary>
    [Serializable]
    public class CompatibilityReport
    {
        #region Public Methods

        /// <summary>
        /// Constructs a compatibility report using the given compatibility notes
        /// </summary>
        /// <param name="compatibilityNotes">Compatibility notes to populate report with</param>
        public CompatibilityReport(IEnumerable<CompatibilityNote> compatibilityNotes)
        {
            m_compatibilityNotes = new List<CompatibilityNote>(compatibilityNotes);
        }

        /// <summary>
        /// Creats a blank compatibility report. A report with no notes is assumed
        /// to represent a format compliant map
        /// </summary>
        public CompatibilityReport()
        {
            m_compatibilityNotes = new List<CompatibilityNote>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Overall compatibility level. This is computed from the worst case
        /// note within the report. If no notes are present, Full compatibility
        /// is assumed
        /// </summary>
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

        /// <summary>
        /// Collection of compatibility notes
        /// </summary>
        public ReadOnlyCollection<CompatibilityNote> CompatibilityNotes
        {
            get { return m_compatibilityNotes.AsReadOnly(); }
        }

        #endregion

        #region Private Variables

        private List<CompatibilityNote> m_compatibilityNotes;

        #endregion
    }
}
