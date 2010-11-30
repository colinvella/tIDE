using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xTile.Layers;
using tIDE.Commands;
using xTile.Dimensions;

namespace tIDE.Dialogs
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

            int horizontalExtent = m_layer.LayerWidth - 1;
            m_nudOffsetHorizontal.Minimum = -horizontalExtent;
            m_nudOffsetHorizontal.Maximum = horizontalExtent;

            int verticalExtent = m_layer.LayerHeight - 1;
            m_nudOffsetVertical.Minimum = -verticalExtent;
            m_nudOffsetVertical.Maximum = verticalExtent;
        }

        private void OnParametersChanged(object sender, EventArgs eventArgs)
        {
            m_btnOk.Enabled = m_nudOffsetHorizontal.Value != 0 || m_nudOffsetVertical.Value != 0;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            Command command = new LayerOffsetCommand(m_layer,
                new Location((int)m_nudOffsetHorizontal.Value, (int)m_nudOffsetVertical.Value),
                m_chkWrapHorizontal.Checked, m_chkWrapVertical.Checked);
            CommandHistory.Instance.Do(command);
        }

        private Layer m_layer;
    }
}
