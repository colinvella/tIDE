using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XTile.Tiles;

namespace TileMapEditor.Dialogs
{
    public partial class AutoTileDialog : Form
    {
        public AutoTileDialog(TileSheet tileSheet)
        {
            InitializeComponent();

            m_tileSheet = tileSheet;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_tilePicker.Map = m_tileSheet.Map;
            m_tilePicker.SelectedTileSheet = m_tileSheet;
            m_tilePicker.UpdatePicker();
        }

        private TileSheet m_tileSheet;
    }
}
