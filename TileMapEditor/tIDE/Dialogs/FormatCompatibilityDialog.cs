using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XTile.Format;

namespace TileMapEditor.Dialogs
{
    public partial class FormatCompatibilityDialog : Form
    {
        public FormatCompatibilityDialog(CompatibilityReport compatibilityReport)
        {
            InitializeComponent();

            m_compatibilityReport = compatibilityReport;
        }

        private CompatibilityReport m_compatibilityReport;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_overallCompatibilityValue.Text = m_compatibilityReport.CompatibilityLevel.ToString();

            foreach (CompatibilityNote compatibilityNote in m_compatibilityReport.CompatibilityNotes)
            {
                Image image = null;
                switch (compatibilityNote.CompatibilityLevel)
                {
                    case CompatibilityLevel.Full: image = Properties.Resources.MapCompatibilityFull; break;
                    case CompatibilityLevel.Partial: image = Properties.Resources.MapCompatibilityPartial; break;
                    case CompatibilityLevel.None: image = Properties.Resources.MapCompatibilityNone; break;
                }
                m_notesDataGridView.Rows.Add(
                    new object[] { image, compatibilityNote.CompatibilityLevel, compatibilityNote.Remarks });
            }
        }
    }
}
