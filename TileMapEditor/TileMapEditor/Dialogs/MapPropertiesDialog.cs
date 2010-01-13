using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

using TileMapEditor.Commands;

namespace TileMapEditor.Dialogs
{
    public partial class MapPropertiesDialog : Form
    {
        private Map m_map;

        public MapPropertiesDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
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
        }

        private void MapPropertiesDialog_Load(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_map.Id;
            m_textBoxDescription.Text = m_map.Description;
            m_customPropertyGrid.LoadProperties(m_map);
        }
    }
}
