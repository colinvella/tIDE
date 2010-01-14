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

namespace TileMapEditor.Dialogs
{
    public partial class CustomPropertiesDialog : Form
    {
        private Tiling.ObjectModel.Component m_component;

        public CustomPropertiesDialog(string dialogTitle, Tiling.ObjectModel.Component component)
        {
            InitializeComponent();

            this.Text = dialogTitle;
            m_component = component;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_customPropertyGrid.LoadProperties(m_component);
        }

        private void OnPropertyChangedOrDeleted(object sender,
            TileMapEditor.Controls.CustomPropertyEventArgs customPropertyEventArgs)
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = true;
            m_buttonCancel.Text = "&Cancel";
            m_buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            Command command = new CustomPropertiesCommand(m_component, m_customPropertyGrid.NewProperties);
            CommandHistory.Instance.Do(command);
            m_buttonOk.Enabled = m_buttonApply.Enabled = false;
            m_buttonCancel.Text = "&Close";
            m_buttonCancel.DialogResult = DialogResult.OK;
        }
    }
}
