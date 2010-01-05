using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling.Tiles;

using TileMapEditor.Commands;

namespace TileMapEditor.Dialog
{
    public partial class TilePropertiesDialog : Form
    {
        private Tile m_tile;

        public TilePropertiesDialog(Tile tile)
        {
            InitializeComponent();

            m_tile = tile;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            Command command = new TilePropertiesCommand(m_tile, m_textBoxId.Text,
                m_customPropertyGrid.NewProperties);
            CommandHistory.Instance.Do(command);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_tile.Id;
            m_customPropertyGrid.LoadProperties(m_tile);
        }
    }
}
