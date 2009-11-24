using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor
{
    public partial class MainForm : Form
    {
        private Map m_map;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_map = new Map("Untitled map");
            m_mapTreeView.Map = m_map;

            m_map.Properties.Add("hello", "world");
            m_map.Properties.Add("yo", true);
            customPropertyGrid1.LoadProperties(m_map);
        }
    }
}
