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

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_commandsDataGridView.Rows.Clear();
            foreach (Command command in CommandHistory.Instance.History)
            {
                m_commandsDataGridView.Rows.Add(new object[] {command.Description, null });
            }
        }
    }
}
