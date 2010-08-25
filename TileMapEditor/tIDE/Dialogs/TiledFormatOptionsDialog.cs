using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Format;

namespace TileMapEditor.Dialogs
{
    public partial class TiledFormatOptionsDialog : Form
    {
        public TiledFormatOptionsDialog()
        {
            InitializeComponent();
        }

        public TmxEncoding TmxEncoding
        {
            get
            {
                return (TmxEncoding)m_cmbDataFormat.SelectedIndex;
            }
        }

        private void OnEncodingSelected(object sender, EventArgs eventArgs)
        {
            m_btnOk.Enabled = m_cmbDataFormat.SelectedIndex >= 0;
        }
    }
}
