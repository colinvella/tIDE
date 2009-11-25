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

        public TileSheetPropertiesDialog(TileSheet tileSheet)
        {
            InitializeComponent();

            m_tileSheet = tileSheet;
        }

        private void m_buttonOk_Click(object sender, EventArgs eventArgs)
        {
            m_tileSheet.Id = m_textBoxId.Text;

            m_tileSheet.Description = m_textBoxDescription.Text;

            m_customPropertyGrid.StoreProperties(m_tileSheet);

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
            graphics.SmoothingMode = SmoothingMode.HighSpeed;

            Matrix matrix = new Matrix();
            matrix.Scale(m_trackBar.Value, m_trackBar.Value);
            graphics.Transform = matrix;

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
                graphics.DrawImage(m_bitmapImageSource, 0, 0);
            }
        }

        private void m_trackBar_Scroll(object sender, EventArgs eventArgs)
        {
            m_panelImage.Invalidate();
        }
    }
}
