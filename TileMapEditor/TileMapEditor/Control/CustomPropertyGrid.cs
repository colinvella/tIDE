using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling.ObjectModel;

namespace TileMapEditor.Control
{
    public partial class CustomPropertyGrid : UserControl
    {
        #region Private Variables

        private Tiling.ObjectModel.PropertyCollection m_newProperties;
        private string m_previousPropertyName = null;

        #endregion

        #region Private Methods

        private void m_dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs dataGridViewCellCancelEventArgs)
        {
            int rowIndex = dataGridViewCellCancelEventArgs.RowIndex;
            int columnIndex = dataGridViewCellCancelEventArgs.ColumnIndex;

            if (columnIndex == 0)
            {
                object cellValue = m_dataGridView[columnIndex, rowIndex].Value;
                m_previousPropertyName = cellValue == null ? null : cellValue.ToString();
            }
        }

        private void m_dataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs dataGridViewCellValidatingEventArgs)
        {
            int rowIndex = dataGridViewCellValidatingEventArgs.RowIndex;
            int columnIndex = dataGridViewCellValidatingEventArgs.ColumnIndex;

            // do nothing if leaving last row without typing anything
            if (rowIndex == m_dataGridView.Rows.Count - 1)
                return;

            string formattedValue = dataGridViewCellValidatingEventArgs.FormattedValue.ToString().Trim();

            if (columnIndex == 0)
            {
                if (formattedValue.Length == 0)
                {
                    dataGridViewCellValidatingEventArgs.Cancel = true;
                    MessageBox.Show(this, "No property name specified", "Property Name",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int otherRowIdex = 0; otherRowIdex < m_dataGridView.Rows.Count - 1; otherRowIdex++)
                {
                    if (otherRowIdex == rowIndex)
                        continue;

                    if (formattedValue.Equals(m_dataGridView[0, otherRowIdex].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))            
                    {
                        dataGridViewCellValidatingEventArgs.Cancel = true;
                        MessageBox.Show(this, "Another property with the same name is already defined", "Property Name",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void m_dataGridView_CellValidated(object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs)
        {
            int rowIndex = dataGridViewCellEventArgs.RowIndex;
            int columnIndex = dataGridViewCellEventArgs.ColumnIndex;

            if (rowIndex == m_dataGridView.Rows.Count - 1)
                return;

            object cellValue =  m_dataGridView[columnIndex, rowIndex].Value;

            DataGridViewCell cell = m_dataGridView[columnIndex, rowIndex];

            if (columnIndex == 0)
            {
                string propertyName = cellValue.ToString().Trim();

                if (m_previousPropertyName != null && m_previousPropertyName != propertyName)
                {
                    PropertyValue previousPropertyValue = m_newProperties[m_previousPropertyName];
                    m_newProperties.Remove(m_previousPropertyName);
                    m_newProperties[propertyName] = previousPropertyValue;
                    m_previousPropertyName = null;
                }

                cell.Value = propertyName;
            }
            else if (columnIndex == 1)
            {
                string propertyName = m_dataGridView[0, rowIndex].Value.ToString();

                if (cellValue == null)
                {
                    m_newProperties[propertyName] = null;
                    return;
                }

                string propertyValue = cellValue.ToString();
                int propertyValueInt = 0;
                float propertyValueFloat = 0.0f;

                cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                if (propertyValue.Trim().Equals(bool.TrueString, StringComparison.CurrentCultureIgnoreCase))
                    cell.Value = m_newProperties[propertyName] = true;
                else if (propertyValue.Trim().Equals(bool.FalseString, StringComparison.CurrentCultureIgnoreCase))
                    cell.Value = m_newProperties[propertyName] = false;
                else if (int.TryParse(propertyValue.Trim(), out propertyValueInt))
                {
                    cell.Value = m_newProperties[propertyName] = propertyValueInt;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (float.TryParse(propertyValue.Trim(), out propertyValueFloat))
                {
                    cell.Value = m_newProperties[propertyName] = propertyValueFloat;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                    cell.Value = m_newProperties[propertyName] = propertyValue;
            }
        }

        private void m_dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs dataGridViewRowEventArgs)
        {
            string propertyName = dataGridViewRowEventArgs.Row.Cells[0].Value.ToString();
            m_newProperties.Remove(propertyName);
        }

        #endregion

        #region Public Methods

        public CustomPropertyGrid()
        {
            InitializeComponent();

            m_newProperties = new Tiling.ObjectModel.PropertyCollection();
        }

        public void LoadProperties(Tiling.ObjectModel.Component component)
        {
            m_dataGridView.Rows.Clear();

            m_newProperties.Clear();
            foreach (KeyValuePair<string, PropertyValue> keyValuePair
                in component.Properties)
            {
                m_newProperties.Add(keyValuePair.Key, keyValuePair.Value);

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = keyValuePair.Key;
                DataGridViewTextBoxCell valueCell = new DataGridViewTextBoxCell();
                valueCell.Value = keyValuePair.Value.ToString();

                if (keyValuePair.Value.Type == typeof(float)
                    || keyValuePair.Value.Type == typeof(int))
                    valueCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                row.Cells.Add(nameCell);
                row.Cells.Add(valueCell);
                m_dataGridView.Rows.Add(row);
            }
        }

        public void StoreProperties(Tiling.ObjectModel.Component component)
        {
            component.Properties.Clear();
            component.Properties.CopyFrom(m_newProperties);
        }

        #endregion

        #region Public Properties

        public Tiling.ObjectModel.PropertyCollection NewProperties
        {
            get { return m_newProperties; }
        }

        #endregion
    }
}
