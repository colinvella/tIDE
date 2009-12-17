using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;

namespace TileMapEditor.Dialog
{
    public partial class LayerPropertiesDialog : Form
    {
        #region Private Variables

        private Layer m_layer;

        #endregion

        #region Private Methods

        private void LayerPropertiesDialog_Load(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_layer.Id;
            m_textBoxDescription.Text = m_layer.Description;

            m_numericLayerWidth.Value = m_layer.LayerSize.Width;
            m_numericLayerHeight.Value = m_layer.LayerSize.Height;
            m_numericTileWidth.Value = m_layer.TileSize.Width;
            m_numericTileHeight.Value = m_layer.TileSize.Height;

            m_checkBoxVisible.Checked = m_layer.Visible;

            m_customPropertyGrid.LoadProperties(m_layer);
        }

        private void m_buttonOk_Click(object sender, EventArgs eventArgs)
        {
            string newId = m_textBoxId.Text;

            foreach (Layer layer in m_layer.Map.Layers)
            {
                if (layer == m_layer)
                    continue;
                if (newId == layer.Id)
                {
                    MessageBox.Show(this, "The specified Id is already used by another Layer",
                        "Layer Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            m_layer.Id = newId;
            m_layer.Description = m_textBoxDescription.Text;

            m_layer.LayerSize = new Size((int)m_numericLayerWidth.Value, (int)m_numericLayerHeight.Value);
            m_layer.TileSize = new Size((int)m_numericTileWidth.Value, (int)m_numericTileHeight.Value);

            m_layer.Visible = m_checkBoxVisible.Checked;

            m_customPropertyGrid.StoreProperties(m_layer);

            DialogResult = DialogResult.OK;

            Close();
        }

        #endregion

        #region Public Methods

        public LayerPropertiesDialog(Layer layer)
        {
            InitializeComponent();

            m_layer = layer;
        }

        #endregion
    }
}
