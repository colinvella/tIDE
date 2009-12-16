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

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {

        }

        public TileBrushDialog(TileBrushCollection tileBrushCollection)
        {
            InitializeComponent();

            m_tileBrushCollection = tileBrushCollection;
        }

        private void TileBrushDialog_Load(object sender, EventArgs e)
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

                imageList.Images.Add(tileBrush.ImageRepresentation);
            }

            imageList.ImageSize = new Size(previewSize, previewSize);

            listView1.LargeImageList = imageList;

            int imageIndex = 0;
            foreach (TileBrush tileBrush in m_tileBrushCollection.TileBrushes)
            {
                listView1.Items.Add(tileBrush.Id, imageIndex++);
            }
        }
    }
}
