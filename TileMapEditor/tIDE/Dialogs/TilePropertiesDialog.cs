using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class TilePropertiesDialog : Form
    {
        private Tile m_tile;

        private void MarkAsModified()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = m_buttonCancel.Visible = true;
            m_buttonClose.Visible = false;
        }

        private void MarkAsApplied()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = m_buttonCancel.Visible = false;
            m_buttonClose.Visible = true;
        }

        private void OnFieldChanged(object sender, EventArgs eventArgs)
        {
            MarkAsModified();
        }

        private void OnPropertyChangedOrDeleted(object sender,
            CustomPropertyEventArgs customPropertyEventArgs)
        {
            MarkAsModified();
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(this, eventArgs);
        }

        private void OnDialogApply(object sender, EventArgs e)
        {
            Command command = new TilePropertiesCommand(m_tile, m_textBoxId.Text,
                (BlendMode) m_comboBoxBlendMode.SelectedIndex,
                m_customPropertyGrid.NewProperties);
            CommandHistory.Instance.Do(command);

            MarkAsApplied();
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_tile.Id;
            m_comboBoxBlendMode.SelectedIndex = (int)m_tile.BlendMode;
            m_textBoxTileSheet.Text = m_tile.TileSheet.Id;
            m_textBoxTileIndex.Text = m_tile.TileIndex.ToString();
            m_customPropertyGrid.LoadProperties(m_tile);

            MarkAsApplied();
        }

        public TilePropertiesDialog(Tile tile)
        {
            InitializeComponent();

            m_tile = tile;
        }
    }
}
