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
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class TilePropertiesDialog : Form
    {
        private Tile m_tile;

        private void MarkAsModified()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = true;
            m_buttonCancel.Text = "&Cancel";
            m_buttonCancel.DialogResult = DialogResult.Cancel;
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

            m_buttonApply.Enabled = m_buttonOk.Enabled = false;
            m_buttonCancel.Text = "&Close";
            m_buttonCancel.DialogResult = DialogResult.OK;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_tile.Id;
            m_comboBoxBlendMode.SelectedIndex = (int)m_tile.BlendMode;
            m_customPropertyGrid.LoadProperties(m_tile);

            m_buttonApply.Enabled = m_buttonOk.Enabled = false;
            m_buttonCancel.Text = "&Close";
            m_buttonCancel.DialogResult = DialogResult.OK;
        }

        public TilePropertiesDialog(Tile tile)
        {
            InitializeComponent();

            m_tile = tile;
        }
    }
}
