using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor.Dialog
{
    internal partial class TileBrushDialog : Form
    {
        private TileBrushCollection m_tileBrushCollection;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            int previewSize = 0;
            ImageList imageList = new ImageList();
            foreach (TileBrush tileBrush in m_tileBrushCollection.TileBrushes)
            {
                Image image = tileBrush.ImageRepresentation;

                int size = Math.Max(image.Width, image.Height);
                if (image.Width != image.Height)
                {
                    Bitmap bitmap = new Bitmap(size, size);
                    int destX = (size - image.Width) / 2;
                    int destY = (size - image.Height) / 2;
                    Graphics.FromImage(bitmap).DrawImage(image, destX, destY);
                    image = bitmap;
                }

                previewSize = Math.Max(previewSize, size);

                imageList.Images.Add(image);
            }

            imageList.ImageSize = new Size(previewSize, previewSize);

            m_listView.LargeImageList = imageList;

            int imageIndex = 0;
            foreach (TileBrush tileBrush in m_tileBrushCollection.TileBrushes)
                m_listView.Items.Add(tileBrush.Id, imageIndex++);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            bool selected = m_listView.SelectedIndices.Count > 0;
            m_renameButton.Enabled = m_deleteButton.Enabled = selected;
        }

        private void OnAfterLabelEdit(object sender, LabelEditEventArgs labelEditEventArgs)
        {
            string newLabel = labelEditEventArgs.Label;
            for (int index = 0; index < m_tileBrushCollection.TileBrushes.Count; index++)
            {
                if (index == labelEditEventArgs.Item)
                    continue;
                if (newLabel == m_tileBrushCollection.TileBrushes[index].Id)
                {
                    labelEditEventArgs.CancelEdit = true;
                    MessageBox.Show(this, 
                        "The tile brush ID '" + newLabel + "' is already in use.",
                        "Tile Brush Dialog",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            m_tileBrushCollection.TileBrushes[labelEditEventArgs.Item].Id = newLabel;
        }

        private void OnTileBrushRename(object sender, EventArgs eventArgs)
        {
            if (m_listView.SelectedIndices.Count == 0)
                return;

            int index = m_listView.SelectedIndices[0];

            m_listView.Items[index].BeginEdit();
        }

        private void OnTileBrushDelete(object sender, EventArgs eventArgs)
        {
            if (m_listView.SelectedIndices.Count == 0)
                return;

            int index = m_listView.SelectedIndices[0];

            m_listView.Items.RemoveAt(index);
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            m_listView.Items[0].BeginEdit();
        }

        public TileBrushDialog(TileBrushCollection tileBrushCollection)
        {
            InitializeComponent();

            m_tileBrushCollection = tileBrushCollection;
        }

        private void m_listView_MouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_contextMenuStrip.SetBounds(mouseEventArgs.X, mouseEventArgs.Y, m_contextMenuStrip.Bounds.Width, m_contextMenuStrip.Bounds.Height);
            m_contextMenuStrip.Visible = true;
        }
    }
}
