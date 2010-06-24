using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TileMapEditor.Commands;

namespace TileMapEditor.Dialogs
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
            string buttonText = lastCommand == null ? "Redo" : "Undo";

            if (lastCommand == null)
            {
                m_commandsDataGridView.Rows.Insert(0, new object[] { "Current State", null });
            }

            foreach (Command command in commandHistory)
            {
                m_commandsDataGridView.Rows.Insert(0, new object[] { command.Description, buttonText });
                m_commandsDataGridView.Rows[0].Tag = command;

                if (command == lastCommand)
                {
                    m_commandsDataGridView.Rows.Insert(0, new object[] { "Current State", null });
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
    }

    public delegate void HistoryChangedHandler(object sender, EventArgs eventArgs);

}
