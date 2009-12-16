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
            {
                m_listView.Items.Add(tileBrush.Id, imageIndex++);
            }
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
                    return;
                }
            }

            m_tileBrushCollection.TileBrushes[labelEditEventArgs.Item].Id = newLabel;
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

    }
}
