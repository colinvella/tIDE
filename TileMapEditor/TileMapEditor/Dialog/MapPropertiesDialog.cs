using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor.Dialog
{
    public partial class MapPropertiesDialog : Form
    {
        private Map m_map;

        public MapPropertiesDialog(Map map)
        {
            InitializeComponent();

            m_map = map;
        }

        private void m_buttonOk_Click(object sender, EventArgs eventArgs)
        {
            m_map.Id = m_textBoxId.Text;

            m_map.Description = m_textBoxDescription.Text;

            m_customPropertyGrid.StoreProperties(m_map);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void MapPropertiesDialog_Load(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_map.Id;
            m_textBoxDescription.Text = m_map.Description;
            m_customPropertyGrid.LoadProperties(m_map);
        }
    }
}
