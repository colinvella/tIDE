using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor.Dialog
{
    public partial class TileSheetPropertiesDialog : Form
    {
        private TileSheet m_tileSheet;
        private Bitmap m_bitmapImageSource;
        private string m_imageSourceErrorMessge;
        private int m_cycle;

        public TileSheetPropertiesDialog(TileSheet tileSheet)
        {
            InitializeComponent();

            m_tileSheet = tileSheet;
        }

        private void m_buttonOk_Click(object sender, EventArgs eventArgs)
        {
            string newId = m_textBoxId.Text;

            foreach (TileSheet tileSheet in m_tileSheet.Map.TileSheets)
            {
                if (tileSheet == m_tileSheet)
                    continue;
                if (newId == m_tileSheet.Id)
                {
                    MessageBox.Show(this, "The specified Id is already used by another tile sheet",
                        "Tile Sheet Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            m_tileSheet.Id = newId;

            m_tileSheet.Description = m_textBoxDescription.Text;

            m_customPropertyGrid.StoreProperties(m_tileSheet);

            if (m_bitmapImageSource != null)
                m_bitmapImageSource.Dispose();

            DialogResult = DialogResult.OK;

            Close();
        }

        private void TileSheetPropertiesDialog_Load(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_tileSheet.Id;
            m_textBoxDescription.Text = m_tileSheet.Description;
            m_customPropertyGrid.LoadProperties(m_tileSheet);
            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;
            m_cycle = 0;
        }

        private void m_buttonBrowse_Click(object sender, EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Browse for a Tile Set image";
            openFileDialog.Filter = "PNG|*.png|Bitmap|*.bmp|JPG|*.jpg|GIF|*.gif";

            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            m_textBoxImageSource.Text = openFileDialog.FileName;

            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;

            try
            {
                m_bitmapImageSource = new Bitmap(openFileDialog.FileName);
            }
            catch (Exception exception)
            {
                m_imageSourceErrorMessge = exception.Message;
            }
        }

        private void m_panelImage_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            Graphics graphics = paintEventArgs.Graphics;
            //graphics.ScaleTransform(m_trackBar.Value, m_trackBar.Value);

            if (m_bitmapImageSource == null && m_imageSourceErrorMessge == null)
            {
                graphics.DrawString("No image source selected", this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
                return;
            }
            else if (m_bitmapImageSource == null)
            {
                graphics.DrawString("Error loading image source:" + m_imageSourceErrorMessge, this.Font, SystemBrushes.ControlText, 0.0f, 0.0f);
            }
            else
            {
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.ScaleTransform(m_trackBar.Value, m_trackBar.Value);
                //System.Drawing.Rectangle rectangleSource = new System.Drawing.Rectangle(0, 0, m_bitmapImageSource.Width, m_bitmapImageSource.Height);
                System.Drawing.Rectangle rectangleDestination = new System.Drawing.Rectangle(0, 0, m_bitmapImageSource.Width * m_trackBar.Value, m_bitmapImageSource.Height * m_trackBar.Value);
                //graphics.DrawImage(m_bitmapImageSource, rectangleDestination, rectangleSource, GraphicsUnit.Pixel);
                graphics.DrawImage(m_bitmapImageSource, 0, 0);

                byte intensity = m_cycle < 10 ? (byte)(255 * m_cycle / 10 ) : (byte)(255 * (20 - m_cycle) / 10);
                Pen pen = new Pen(Color.FromArgb(128, intensity, intensity, intensity));

                int imageWidth = m_bitmapImageSource.Width;
                int imageHeight = m_bitmapImageSource.Height;
                int marginLeft = (int)m_textBoxLeftMargin.Value;
                int marginTop = (int)m_textBoxTopMargin.Value;
                int tileWidth = (int)m_textBoxTileWidth.Value;
                int tileHeight = (int)m_textBoxTileHeight.Value;
                int tilePaddingX = (int)m_textBoxPaddingX.Value;
                int tilePaddingY = (int)m_textBoxPaddingY.Value;

                for (int posY = marginTop; posY + tileHeight < imageHeight; posY += tileHeight + tilePaddingY)
                    for (int posX = marginLeft; posX + tileWidth < imageWidth; posX += tileWidth + tilePaddingX)
                        graphics.DrawRectangle(pen, posX, posY, tileWidth - 1, tileHeight - 1);
            }

        }

        private void m_trackBar_Scroll(object sender, EventArgs eventArgs)
        {
            if (m_trackBar.Value == 1)
                m_labelZoom.Text = "Zoom";
            else
                m_labelZoom.Text = "Zoom (x " + m_trackBar.Value + ")";
            m_panelImage.Invalidate();
        }

        private void OnUpdateAlignment(object sender, EventArgs eventArgs)
        {
            m_panelImage.Invalidate();
        }

        private void m_timer_Tick(object sender, EventArgs e)
        {
            m_cycle = (m_cycle + 1) % 20;
            m_panelImage.Invalidate();
        }
    }
}
