using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTile.Format
{
    /// <summary>
    /// Enumeration for the compatiblity level of a given format
    /// </summary>
    [Serializable]
    public enum CompatibilityLevel
    {
        /// <summary>
        /// This feature or configuration is fully supported
        /// </summary>
        Full,

        /// <summary>
        /// This feature or configuration is only partially supported
        /// </summary>
        Partial,

        /// <summary>
        /// This feature or configuration is not supported at all
        /// </summary>
        None
    }

    /// <summary>
    /// Represents the level of compatibility and associated remarks
    /// for a given format feature or data configuration
    /// </summary>
    [Serializable]
    public class CompatibilityNote
    {
        /// <summary>
        /// Constructs a compatiblity note with the given level and
        /// remarks
        /// </summary>
        /// <param name="compatibilityLevel">Level of compatiblity</param>
        /// <param name="remarks">Any applicable remarks</param>
        public CompatibilityNote(
            CompatibilityLevel compatibilityLevel, string remarks)
        {
            m_compatibilityLevel = compatibilityLevel;
            m_remarks = remarks;
        }

        /// <summary>
        /// The compatbility level of this note
        /// </summary>
        public CompatibilityLevel CompatibilityLevel
        {
            get { return m_compatibilityLevel; }
        }

        /// <summary>
        /// The remarks associated with this note
        /// </summary>
        public string Remarks
        {
            get { return m_remarks; }
        }

        private CompatibilityLevel m_compatibilityLevel;
        private string m_remarks;
    }
}