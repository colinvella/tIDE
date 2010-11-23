using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tIDE.Commands;

namespace tIDE.Dialogs
{
    public partial class CommandHistoryDialog : Form
    {
        public CommandHistoryDialog()
        {
            InitializeComponent();
        }

        public void UpdateHistory()
        {
            m_commandsDataGridView.Rows.Clear();

            IEnumerable<Command> commandHistory = CommandHistory.Instance.History;
            if (commandHistory.Count<Command>()== 0)
                return;

            Command lastCommand = CommandHistory.Instance.LastCommand;
            string buttonText = lastCommand == null ? m_redoLabel.Text : m_undoLabel.Text;

            if (lastCommand == null)
            {
                m_commandsDataGridView.Rows.Insert(0, new object[] { m_CurrentStateLabel.Text, null });
                m_commandsDataGridView.Rows[0].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
            }

            foreach (Command command in commandHistory)
            {
                m_commandsDataGridView.Rows.Insert(0, new object[] { command.Description, buttonText });
                m_commandsDataGridView.Rows[0].Tag = command;

                if (command == lastCommand)
                {
                    m_commandsDataGridView.Rows.Insert(0, new object[] { m_CurrentStateLabel.Text, null });
                    m_commandsDataGridView.Rows[0].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
                    buttonText = "Redo";
                }
            }

            m_commandsDataGridView.CellContentClick +=new DataGridViewCellEventHandler(OnCellContentClick);
        }

        public event HistoryChangedHandler HistoryChanged;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            UpdateHistory();
        }

        private void OnCellContentClick(object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs)
        {
            // ensure action column
            if (dataGridViewCellEventArgs.ColumnIndex != 1)
                return;

            int rowIndex = dataGridViewCellEventArgs.RowIndex;

            // ignore clicks on current state button
            if (m_commandsDataGridView.Rows[rowIndex].Tag == null)
                return;

            // get corresponding command and undo/redo
            Command command = (Command) m_commandsDataGridView.Rows[rowIndex].Tag;
            CommandHistory.Instance.UndoOrRedo(command);

            // refresh
            UpdateHistory();

            // fire events
            if (HistoryChanged != null)
                HistoryChanged(this, EventArgs.Empty);
        }

        private void OnSelectionChanged(object sender, EventArgs eventArgs)
        {
            m_commandsDataGridView.SelectionChanged -= OnSelectionChanged;
            m_commandsDataGridView.ClearSelection();
            m_commandsDataGridView.SelectionChanged +=new EventHandler(OnSelectionChanged);
        }
    }

    public delegate void HistoryChangedHandler(object sender, EventArgs eventArgs);

}
