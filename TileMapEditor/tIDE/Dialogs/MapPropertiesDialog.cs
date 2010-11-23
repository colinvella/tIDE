using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;

using tIDE.Commands;
using tIDE.Controls;
using tIDE.Localisation;

namespace tIDE.Dialogs
{
    public partial class MapPropertiesDialog : Form
    {
        #region Private Variables

        private Map m_map;
        private bool m_isNewMap;

        #endregion

        #region Private Methods

        private void MarkAsModified()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = true;
            m_buttonCancel.Visible = true;
            m_buttonClose.Visible = false;
        }

        private void MarkAsApplied()
        {
            m_buttonApply.Enabled = m_buttonOk.Enabled = false;
            m_buttonCancel.Visible = false;
            m_buttonClose.Visible = true;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_map.Id;
            m_textBoxDescription.Text = m_map.Description;
            m_customPropertyGrid.LoadProperties(m_map);

            if (m_isNewMap)
                MarkAsModified();
            else
                MarkAsApplied();
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
            Command command = new MapPropertiesCommand(m_map, m_textBoxId.Text, m_textBoxDescription.Text,
                m_customPropertyGrid.NewProperties);
            CommandHistory.Instance.Do(command);

            MarkAsApplied();
        }

        #endregion

        #region Public Methods

        public MapPropertiesDialog(Map map, bool isNewMap)
        {
            InitializeComponent();

            m_map = map;
            m_isNewMap = isNewMap;
        }

        #endregion
    }
}
