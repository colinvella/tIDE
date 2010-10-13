using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xTile.Layers;

namespace TileMapEditor.Dialogs
{
    public partial class LayerOffsetDialog : Form
    {
        public LayerOffsetDialog(Layer layer)
        {
            InitializeComponent();

            m_layer = layer;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_lblLayerId.Text = m_layer.Id;
            m_lblLayerSize.Text = m_layer.LayerSize.ToString();

            int horizontalExtent = m_layer.LayerSize.Width - 1;
            m_nudOffsetHorizontal.Minimum = -horizontalExtent;
            m_nudOffsetHorizontal.Maximum = horizontalExtent;

            int verticalExtent = m_layer.LayerSize.Height - 1;
            m_nudOffsetVertical.Minimum = -verticalExtent;
            m_nudOffsetVertical.Maximum = verticalExtent;
        }

        private Layer m_layer;
    }
}
