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
using Tiling.Dimensions;
using Tiling.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Control;

namespace TileMapEditor.Dialog
{
    public partial class TileSheetPropertiesDialog : Form
    {
        #region Private Variables

        private TileSheet m_tileSheet;
        private bool m_isNewTileSheet;
        private MapTreeView m_mapTreeView;
        private Bitmap m_bitmapImageSource;
        private string m_imageSourceErrorMessge;

        bool m_previewMouseDown;
        private PointF m_previewOffset;
        private Location m_previewGrip;

        #endregion

        #region Private Methods

        private void UpdateComboBoxes()
        {
            m_comboBoxTileSize.SelectedIndex = 0;
            if (m_textBoxTileWidth.Value == m_textBoxTileHeight.Value)
            {
                switch ((int)m_textBoxTileWidth.Value)
                {
                    case 8: m_comboBoxTileSize.SelectedIndex = 1; break;
                    case 16: m_comboBoxTileSize.SelectedIndex = 2; break;
                    case 32: m_comboBoxTileSize.SelectedIndex = 3; break;
                    case 64: m_comboBoxTileSize.SelectedIndex = 4; break;
                    case 128: m_comboBoxTileSize.SelectedIndex = 5; break;
                    case 256: m_comboBoxTileSize.SelectedIndex = 6; break;
                    case 512: m_comboBoxTileSize.SelectedIndex = 7; break;
                }
            }

            m_comboBoxMargin.SelectedIndex = 0;
            if (m_textBoxTopMargin.Value == m_textBoxLeftMargin.Value)
            {
                switch ((int)m_textBoxTopMargin.Value)
                {
                    case 0: m_comboBoxMargin.SelectedIndex = 1; break;
                    case 1: m_comboBoxMargin.SelectedIndex = 2; break;
                    case 2: m_comboBoxMargin.SelectedIndex = 3; break;
                    case 3: m_comboBoxMargin.SelectedIndex = 4; break;
                    case 4: m_comboBoxMargin.SelectedIndex = 5; break;
                }
            }

            m_comboBoxSpacing.SelectedIndex = 0;
            if (m_textBoxSpacingX.Value == m_textBoxSpacingY.Value)
            {
                switch ((int)m_textBoxSpacingX.Value)
                {
                    case 0: m_comboBoxSpacing.SelectedIndex = 1; break;
                    case 1: m_comboBoxSpacing.SelectedIndex = 2; break;
                    case 2: m_comboBoxSpacing.SelectedIndex = 3; break;
                    case 3: m_comboBoxSpacing.SelectedIndex = 4; break;
                    case 4: m_comboBoxSpacing.SelectedIndex = 5; break;
                }
            }
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_textBoxId.Text = m_tileSheet.Id;
            m_textBoxDescription.Text = m_tileSheet.Description;
            m_textBoxImageSource.Text = m_tileSheet.ImageSource;

            m_textBoxTileWidth.Value = m_tileSheet.TileSize.Width;
            m_textBoxTileHeight.Value = m_tileSheet.TileSize.Height;
            m_textBoxLeftMargin.Value = m_tileSheet.Margin.Width;
            m_textBoxTopMargin.Value = m_tileSheet.Margin.Height;
            m_textBoxSpacingX.Value = m_tileSheet.Spacing.Width;
            m_textBoxSpacingY.Value = m_tileSheet.Spacing.Height;

            UpdateComboBoxes();

            m_customPropertyGrid.LoadProperties(m_tileSheet);

            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;

            m_bitmapImageSource = null;
            m_imageSourceErrorMessge = null;
            try
            {
                m_bitmapImageSource = new Bitmap(m_tileSheet.ImageSource);
            }
            catch (Exception exception)
            {
                m_imageSourceErrorMessge = exception.Message;
            }

            m_previewMouseDown = false;
            m_previewOffset = PointF.Empty;
            m_previewGrip = Tiling.Dimensions.Location.Origin;
        }

        private void OnTileSizeCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxTileSize.SelectedIndex == 0)
                return;
            int size = 4 * 1 << m_comboBoxTileSize.SelectedIndex;
            m_textBoxTileWidth.Value = m_textBoxTileHeight.Value = size;
        }

        private void OnMarginCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxMargin.SelectedIndex == 0)
                return;
            int size = m_comboBoxMargin.SelectedIndex - 1;
            m_textBoxLeftMargin.Value = m_textBoxTopMargin.Value = size;
        }

        private void OnSpacingCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxSpacing.SelectedIndex == 0)
                return;
            int size = m_comboBoxSpacing.SelectedIndex - 1;
            m_textBoxSpacingX.Value = m_textBoxSpacingY.Value = size;
        }

        private void OnBrowse(object sender, EventArgs eventArgs)
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
                m_customTabControl.SelectedTab = m_tabAlignment;
            }
            catch (Exception exception)
            {
                m_imageSourceErrorMessge = exception.Message;
            }
        }

        private void OnAutoDetect(object sender, EventArgs eventArgs)
        {
            if (m_bitmapImageSource == null)
                return;

            Cursor oldCuror = Cursor;
            Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            // determine tile intervals (width + spacing)
            const int MAX_OFFSET = 96;
            long leastDifferenceX = long.MaxValue, leastDifferenceY = long.MaxValue;
            int intervalX = 8, intervalY = 8;
            for (int offset = 8; offset < MAX_OFFSET; offset++)
            {
                long differenceX = 0, differenceY = 0;
                for (int y = 0; y < Math.Min(m_bitmapImageSource.Height, MAX_OFFSET); y++)
                    for (int x = 0; x < Math.Min(m_bitmapImageSource.Width, MAX_OFFSET); x++)
                    {
                        Color color = m_bitmapImageSource.GetPixel(x, y);

                        Color offsetColorX = x + offset < m_bitmapImageSource.Width ? m_bitmapImageSource.GetPixel(x + offset, y) : Color.Black;
                        differenceX +=
                            Math.Abs(offsetColorX.R - color.R)
                            + Math.Abs(offsetColorX.G - color.G)
                            + Math.Abs(offsetColorX.B - color.B);

                        Color offsetColorY = y + offset < m_bitmapImageSource.Height ? m_bitmapImageSource.GetPixel(x, y + offset) : Color.Black;
                        differenceY +=
                            Math.Abs(offsetColorY.R - color.R)
                            + Math.Abs(offsetColorY.G - color.G)
                            + Math.Abs(offsetColorY.B - color.B);
                    }

                if (leastDifferenceX > differenceX)
                {
                    leastDifferenceX = differenceX;
                    intervalX = offset;
                }

                if (leastDifferenceY > differenceY)
                {
                    leastDifferenceY = differenceY;
                    intervalY = offset;
                }
            }

            // determine top margin
            int topMargin = 0;
            bool topMarginFound = false;
            Color colorBackground = m_bitmapImageSource.GetPixel(0, 0);
            for (int y = 0; y < m_bitmapImageSource.Height && !topMarginFound; y++)
            {
                for (int x = 0; x < m_bitmapImageSource.Width; x++)
                {
                    if (m_bitmapImageSource.GetPixel(x, y) != colorBackground)
                    {
                        topMargin = y;
                        topMarginFound = true;
                        break;
                    }
                }
            }

            // determine left margin
            int leftMargin = 0;
            bool leftMarginFound = false;
            for (int x = 0; x < m_bitmapImageSource.Width && !leftMarginFound; x++)
            {
                for (int y = topMargin; y < m_bitmapImageSource.Height; y++)
                {
                    if (m_bitmapImageSource.GetPixel(x, y) != colorBackground)
                    {
                        leftMargin = x;
                        leftMarginFound = true;
                        break;
                    }
                }
            }

            // determine spacing
            int spacingX = 0;
            bool foundPadding = false;
            for (; spacingX < intervalX; spacingX++)
            {
                for (int x = leftMargin + intervalX - 1; x < m_bitmapImageSource.Width; x += intervalX)
                {
                    if (m_bitmapImageSource.GetPixel(x - spacingX, topMargin) != colorBackground)
                    {
                        foundPadding = true;
                        break;
                    }
                }
                if (foundPadding)
                    break;
            }

            int spacingY = 0;
            foundPadding = false;
            for (; spacingY < intervalY; spacingY++)
            {
                for (int y = topMargin + intervalY - 1; y < m_bitmapImageSource.Height; y += intervalY)
                {
                    if (m_bitmapImageSource.GetPixel(leftMargin, y - spacingY) != colorBackground)
                    {
                        foundPadding = true;
                        break;
                    }
                }
                if (foundPadding)
                    break;
            }

            m_textBoxTileWidth.Value = intervalX - spacingX;
            m_textBoxTileHeight.Value = intervalY - spacingY;

            m_textBoxLeftMargin.Value = leftMargin;
            m_textBoxTopMargin.Value = topMargin;

            m_textBoxSpacingX.Value = spacingX;
            m_textBoxSpacingY.Value = spacingY;

            this.Enabled = true;
            Cursor = oldCuror;
        }

        private void OnZoom(object sender, EventArgs eventArgs)
        {
            if (m_trackBar.Value == 1)
                m_labelZoom.Text = "Zoom";
            else
                m_labelZoom.Text = "Zoom (x " + m_trackBar.Value + ")";
            m_panelImage.Invalidate();
        }

        private void OnUpdateAlignment(object sender, EventArgs eventArgs)
        {
            UpdateComboBoxes();
            m_panelImage.Invalidate();
        }

        private void OnPreviewMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                m_previewMouseDown = true;
                m_previewGrip.X = mouseEventArgs.X;
                m_previewGrip.Y = mouseEventArgs.Y;
            }
        }

        private void OnPreviewMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_previewMouseDown && m_bitmapImageSource != null)
            {
                float deltaX = mouseEventArgs.X - m_previewGrip.X;
                float deltaY = mouseEventArgs.Y - m_previewGrip.Y;

                m_previewOffset.X -= deltaX / m_trackBar.Value;
                m_previewOffset.Y -= deltaY / m_trackBar.Value;

                m_previewOffset.X = Math.Min(m_previewOffset.X,
                    m_bitmapImageSource.Width * m_trackBar.Value - m_panelImage.Width);
                m_previewOffset.Y = Math.Min(m_previewOffset.Y,
                    m_bitmapImageSource.Height * m_trackBar.Value - m_panelImage.Height);

                m_previewOffset.X = Math.Max(0, m_previewOffset.X);
                m_previewOffset.Y = Math.Max(0, m_previewOffset.Y);

                m_previewGrip.X = mouseEventArgs.X;
                m_previewGrip.Y = mouseEventArgs.Y;

                m_panelImage.Invalidate();
            }
        }

        private void OnPreviewMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_previewMouseDown = false;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            string newId = m_textBoxId.Text;

            foreach (TileSheet tileSheet in m_tileSheet.Map.TileSheets)
            {
                if (tileSheet == m_tileSheet)
                    continue;
                if (newId == tileSheet.Id)
                {
                    MessageBox.Show(this, "The specified Id is already used by another tile sheet",
                        "Tile Sheet Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if ((m_tileSheet.TileSize.Width != m_textBoxTileWidth.Value
                || m_tileSheet.TileSize.Height != m_textBoxTileHeight.Value)
                && m_tileSheet.Map.DependsOnTileSheet(m_tileSheet))
            {
                    MessageBox.Show(this, "The tile size cannot be changed as this tile sheet is currently in use",
                        "Tile Sheet Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tiling.Dimensions.Size newTileSize = new Tiling.Dimensions.Size(
                (int)m_textBoxTileWidth.Value, (int)m_textBoxTileHeight.Value);

            Tiling.Dimensions.Size newMargin = new Tiling.Dimensions.Size(
                (int)m_textBoxLeftMargin.Value, (int)m_textBoxTopMargin.Value);

            Tiling.Dimensions.Size newSpacing = new Tiling.Dimensions.Size(
                (int)m_textBoxSpacingX.Value, (int)m_textBoxSpacingY.Value);

            Tiling.Dimensions.Size newSheetSize = Tiling.Dimensions.Size.Zero;
            if (m_bitmapImageSource != null)
            {
                newSheetSize.Width = (m_bitmapImageSource.Width - newMargin.Width)
                        / (newTileSize.Width + newSpacing.Width);
                newSheetSize.Height = (m_bitmapImageSource.Height - newMargin.Height)
                        / (newTileSize.Height + newSpacing.Height);
            }

            if (m_bitmapImageSource != null)
                m_bitmapImageSource.Dispose();

            Command command = null;

            if (m_isNewTileSheet)
            {
                m_tileSheet.Id = newId;
                m_tileSheet.Description = m_textBoxDescription.Text;
                m_tileSheet.TileSize = newTileSize;
                m_tileSheet.Margin = newMargin;
                m_tileSheet.Spacing = newSpacing;
                m_tileSheet.SheetSize = newSheetSize;
                m_tileSheet.ImageSource = m_textBoxImageSource.Text;
                m_tileSheet.Properties.Clear();
                m_tileSheet.Properties.CopyFrom(m_customPropertyGrid.NewProperties);
                command = new TileSheetNewCommand(m_tileSheet.Map, m_tileSheet, m_mapTreeView);
            }
            else
            {
                command = new TileSheetPropertiesCommand(m_tileSheet, newId, m_textBoxDescription.Text,
                    newTileSize, newMargin, newSpacing, newSheetSize, m_textBoxImageSource.Text,
                    m_customPropertyGrid.NewProperties);
            }

            CommandHistory.Instance.Do(command);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void OnPreviewPaint(object sender, PaintEventArgs paintEventArgs)
        {
            Graphics graphics = paintEventArgs.Graphics;

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
                graphics.PixelOffsetMode = PixelOffsetMode.Half;

                graphics.ScaleTransform(m_trackBar.Value, m_trackBar.Value);
                graphics.TranslateTransform(-m_previewOffset.X, -m_previewOffset.Y);

                int imageWidth = m_bitmapImageSource.Width;
                int imageHeight = m_bitmapImageSource.Height;

                graphics.DrawImage(m_bitmapImageSource, 0, 0, imageWidth, imageHeight);

                int marginLeft = (int)m_textBoxLeftMargin.Value;
                int marginTop = (int)m_textBoxTopMargin.Value;
                int tileWidth = (int)m_textBoxTileWidth.Value;
                int tileHeight = (int)m_textBoxTileHeight.Value;
                int tilePaddingX = (int)m_textBoxSpacingX.Value;
                int tilePaddingY = (int)m_textBoxSpacingY.Value;

                Pen pen = new Pen(SystemColors.ActiveCaption);
                float fZoomInverse = 1.0f / m_trackBar.Value;
                pen.Width = fZoomInverse;

                Brush brush = new SolidBrush(Color.FromArgb(64, SystemColors.ActiveBorder));

                for (int posY = marginTop; posY + tileHeight <= imageHeight; posY += tileHeight + tilePaddingY)
                    for (int posX = marginLeft; posX + tileWidth <= imageWidth; posX += tileWidth + tilePaddingX)
                    {
                        graphics.FillRectangle(brush, posX, posY, tileWidth, tileHeight);
                        graphics.DrawRectangle(pen, posX, posY, tileWidth, tileHeight);
                    }
            }

        }

        #endregion

        #region Public Methods

        public TileSheetPropertiesDialog(TileSheet tileSheet, bool isNewTileSheet, MapTreeView mapTreeView)
        {
            InitializeComponent();

            m_tileSheet = tileSheet;
            m_isNewTileSheet = isNewTileSheet;
            m_mapTreeView = mapTreeView;
        }

        #endregion
    }
}
