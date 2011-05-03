using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile.Tiles;

using tIDE.Commands;

namespace tIDE.Dialogs
{
    public partial class CustomPropertiesDialog : Form
    {
        private xTile.ObjectModel.Component m_component;

        public CustomPropertiesDialog(string dialogTitle, xTile.ObjectModel.Component component)
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
            tIDE.Controls.CustomPropertyEventArgs customPropertyEventArgs)
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = true;
            m_buttonCancel.Visible = true;
            m_buttonClose.Visible = false;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            Command command = new CustomPropertiesCommand(m_component, m_customPropertyGrid.NewProperties);
            CommandHistory.Instance.Do(command);
            m_buttonOk.Enabled = m_buttonApply.Enabled = false;
            m_buttonCancel.Visible = false;
            m_buttonClose.Visible = true;
            m_buttonClose.DialogResult = DialogResult.OK;
        }

        private void OnDialogClose(object sender, EventArgs eventArgs)
        {
            Close();
        }

    }
}
