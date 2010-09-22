using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using TileMapEditor.AutoTiles;
using TileMapEditor.Commands;
using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class TileSheetPropertiesDialog : Form
    {
        #region Private Variables

        private TileSheet m_tileSheet;
        private bool m_isNewTileSheet;
        private MapTreeView m_mapTreeView;
        private Bitmap m_bitmapImageSource;
        private string m_imageSourceErrorMessge;

        PreviewMode m_previewMode;
        bool m_previewMouseDown;
        private PointF m_previewOffset;
        private Location m_previewGrip;
        private int m_tileHoverIndex;
        private int m_swapTileIndex1;
        private int m_swapTileIndex2;

        #endregion

        #region Private Methods

        private Bitmap LoadUnlockedBitmap(string filename)
        {
            Bitmap unlockedBitmap = null;
            using (Bitmap lockedBitmap = new Bitmap(filename))
            {
                unlockedBitmap = new Bitmap(lockedBitmap.Width, lockedBitmap.Height, lockedBitmap.PixelFormat);
                unlockedBitmap.SetResolution(lockedBitmap.HorizontalResolution, lockedBitmap.VerticalResolution);
                using (Graphics graphics = Graphics.FromImage(unlockedBitmap))
                {
                    graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    graphics.DrawImageUnscaled(lockedBitmap, 0, 0);
                }
            }
            return unlockedBitmap;
        }

        private float[,] ComputeIntensityImage(Bitmap bitmap)
        {
            float[,] image = new float[bitmap.Width, bitmap.Height];
            for (int pixelY = 0; pixelY < bitmap.Height; pixelY++)
            {
                for (int pixelX = 0; pixelX < bitmap.Width; pixelX++)
                {
                    image[pixelX, pixelY] = bitmap.GetPixel(pixelX, pixelY).GetBrightness();
                }
            }
            return image;
        }

        private double ComputeLineMean(float[,] image, int start, bool horizontal)
        {
            int length = image.GetLength(horizontal ? 0 : 1);
            int deltaX = horizontal ? 1 : 0;
            int deltaY = horizontal ? 0 : 1;
            int posX = horizontal ? 0 : start;
            int posY = horizontal ? start : 0;
            double mean = 0.0;
            for (int pos = 0; pos < length; pos++)
            {
                mean += image[posX, posY];
                posX += deltaX;
                posY += deltaY;
            }

            mean /= length;

            return mean;
        }

        private int EstimateLinePeriod(float[,] image, int start, bool horizontal)
        {
            double mean = ComputeLineMean(image, start, horizontal);

            int length = image.GetLength(horizontal ? 0 : 1);
            int deltaX = horizontal ? 1 : 0;
            int deltaY = horizontal ? 0 : 1;
            double leastDifference = double.MaxValue;
            int period = 0;
            for (int offset = 8; offset < length; offset++)
            {
                int posX = horizontal ? 0 : start;
                int posY = horizontal ? start : 0;
                int offsetX = deltaX * offset;
                int offsetY = deltaY * offset;
                double sumDifference = 0.0;
                for (int pos = 0; pos < length; pos++)
                {
                    double value1 = image[posX, posY];
                    double value2 = pos + offset < length ? image[posX + offsetX, posY + offsetY] : 0.0;
                    sumDifference += Math.Abs(value2 - value1);
                }

                if (leastDifference > sumDifference)
                {
                    leastDifference = sumDifference;
                    period = offset;
                }
            }

            return period;
        }

        private void MarkAsModified()
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = m_buttonCancel.Visible = true;
            m_buttonClose.Visible = m_buttonSwapTiles.Enabled = false;
        }

        private void MarkAsApplied()
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = m_buttonCancel.Visible = false;
            m_buttonClose.Visible = m_buttonSwapTiles.Enabled = true;
        }

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
                m_bitmapImageSource = LoadUnlockedBitmap(m_tileSheet.ImageSource);
            }
            catch (Exception exception)
            {
                m_bitmapImageSource = null;
                m_imageSourceErrorMessge = exception.Message;
            }

            m_previewMode = PreviewMode.Preview;
            m_previewMouseDown = false;
            m_previewOffset = PointF.Empty;
            m_previewGrip = xTile.Dimensions.Location.Origin;

            if (m_isNewTileSheet)
                MarkAsModified();
            else
                MarkAsApplied();
        }

        private void OnSelectingTab(object sender,
            TabControlCancelEventArgs tabControlCancelEventArgs)
        {
            // prevent tab swtiching while in tile swap mode
            if (m_previewMode != PreviewMode.Preview)
                tabControlCancelEventArgs.Cancel = true;
        }

        private void OnTileSizeCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxTileSize.SelectedIndex == 0)
                return;
            int size = 4 * 1 << m_comboBoxTileSize.SelectedIndex;
            m_textBoxTileWidth.Value = m_textBoxTileHeight.Value = size;

            MarkAsModified();
        }

        private void OnMarginCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxMargin.SelectedIndex == 0)
                return;
            int size = m_comboBoxMargin.SelectedIndex - 1;
            m_textBoxLeftMargin.Value = m_textBoxTopMargin.Value = size;

            MarkAsModified();
        }

        private void OnSpacingCombo(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxSpacing.SelectedIndex == 0)
                return;
            int size = m_comboBoxSpacing.SelectedIndex - 1;
            m_textBoxSpacingX.Value = m_textBoxSpacingY.Value = size;

            MarkAsModified();
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
                m_bitmapImageSource = LoadUnlockedBitmap(m_textBoxImageSource.Text);
                m_customTabControl.SelectedTab = m_tabAlignment;
                MarkAsModified();
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
            float[,] intensityImage = ComputeIntensityImage(m_bitmapImageSource);

            Dictionary<int, int> sampleHistogram = new Dictionary<int, int>();
            for (int sampleLine = 0; sampleLine < m_bitmapImageSource.Height; sampleLine += m_bitmapImageSource.Height / 10)
            {
                int period = EstimateLinePeriod(intensityImage, sampleLine, true);
                if (!sampleHistogram.ContainsKey(period))
                    sampleHistogram[period] = 1;
                else
                    sampleHistogram[period] = sampleHistogram[period] + 1;
            }
            int intervalX = 0; int countX = 0;
            foreach (KeyValuePair<int, int> pair in sampleHistogram)
                if (countX < pair.Value)
                {
                    intervalX = pair.Key;
                    countX = pair.Value;
                }
            intervalX = Math.Max(intervalX, 8);

            sampleHistogram.Clear();
            for (int sampleLine = 0; sampleLine < m_bitmapImageSource.Height; sampleLine += m_bitmapImageSource.Height / 10)
            {
                int period = EstimateLinePeriod(intensityImage, sampleLine, false);
                if (!sampleHistogram.ContainsKey(period))
                    sampleHistogram[period] = 1;
                else
                    sampleHistogram[period] = sampleHistogram[period] + 1;
            }
            int intervalY = 0; int countY = 0;
            foreach (KeyValuePair<int, int> pair in sampleHistogram)
                if (countY < pair.Value)
                {
                    intervalY = pair.Key;
                    countY = pair.Value;
                }
            intervalY = Math.Max(intervalY, 8);


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

            MarkAsModified();

            this.Enabled = true;
            Cursor = oldCuror;
        }

        private void OnSwapTiles(object sender, EventArgs eventArgs)
        {
            switch (m_previewMode)
            {
                case PreviewMode.Preview:
                    m_groupBoxQuickSettings.Enabled = m_groupBoxCustomSettings.Enabled = false;

                    m_buttonSwapTiles.Visible = false;
                    m_buttonDoneSwapping.Visible = true;

                    m_previewMode = PreviewMode.PickFirst;
                    break;
            }
        }

        private void OnDoneSwapping(object sender, EventArgs eventArgs)
        {
            m_previewMode = PreviewMode.Preview;

            m_buttonDoneSwapping.Visible = false;
            m_buttonSwapTiles.Visible = true;

            m_groupBoxQuickSettings.Enabled = m_groupBoxCustomSettings.Enabled = true;
            m_customTabControl.Enabled = true;
        }

        private void OnZoom(object sender, EventArgs eventArgs)
        {
            if (m_trackBarZoom.Value == 1)
                m_labelZoom.Text = "Zoom";
            else
                m_labelZoom.Text = "Zoom (x " + m_trackBarZoom.Value + ")";
            m_panelImage.Invalidate();
        }

        private void OnUpdateAlignment(object sender, EventArgs eventArgs)
        {
            UpdateComboBoxes();
            m_panelImage.Invalidate();
            MarkAsModified();
        }

        private void OnPreviewMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                switch (m_previewMode)
                {
                    case PreviewMode.Preview:
                        m_previewMouseDown = true;
                        m_previewGrip.X = mouseEventArgs.X;
                        m_previewGrip.Y = mouseEventArgs.Y;
                        break;
                    case PreviewMode.PickFirst:
                        {
                            Location pixelLocation = new Location(mouseEventArgs.X, mouseEventArgs.Y);
                            pixelLocation.X /= m_trackBarZoom.Value;
                            pixelLocation.Y /= m_trackBarZoom.Value;
                            pixelLocation.X -= (int)m_previewOffset.X;
                            pixelLocation.Y -= (int)m_previewOffset.Y;
                            m_swapTileIndex1 = m_tileSheet.GetTileIndex(pixelLocation);
                            m_previewMode = PreviewMode.PickSecond;
                            m_panelImage.Invalidate();
                        }
                        break;
                    case PreviewMode.PickSecond:
                        {
                            Cursor oldCursor = this.Cursor;
                            this.Cursor = Cursors.WaitCursor;

                            Location pixelLocation = new Location(mouseEventArgs.X, mouseEventArgs.Y);
                            pixelLocation.X /= m_trackBarZoom.Value;
                            pixelLocation.Y /= m_trackBarZoom.Value;
                            pixelLocation.X -= (int)m_previewOffset.X;
                            pixelLocation.Y -= (int)m_previewOffset.Y;
                            m_swapTileIndex2 = m_tileSheet.GetTileIndex(pixelLocation);

                            if (m_swapTileIndex1 != m_swapTileIndex2)
                            {
                                Command command = new TileSheetSwapTilesCommand(m_tileSheet, m_swapTileIndex1, m_swapTileIndex2);
                                CommandHistory.Instance.Do(command);
                                m_bitmapImageSource = LoadUnlockedBitmap(m_tileSheet.ImageSource);
                            }

                            this.Cursor = oldCursor;

                            m_previewMode = PreviewMode.PickFirst;
                            m_panelImage.Invalidate();
                        }
                        break;
                }
            }
        }

        private void OnPreviewMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_bitmapImageSource == null)
                return;

            if (m_previewMouseDown)
            {
                float deltaX = mouseEventArgs.X - m_previewGrip.X;
                float deltaY = mouseEventArgs.Y - m_previewGrip.Y;

                m_previewOffset.X -= deltaX / m_trackBarZoom.Value;
                m_previewOffset.Y -= deltaY / m_trackBarZoom.Value;

                m_previewOffset.X = Math.Min(m_previewOffset.X,
                    m_bitmapImageSource.Width * m_trackBarZoom.Value - m_panelImage.Width);
                m_previewOffset.Y = Math.Min(m_previewOffset.Y,
                    m_bitmapImageSource.Height * m_trackBarZoom.Value - m_panelImage.Height);

                m_previewOffset.X = Math.Max(0, m_previewOffset.X);
                m_previewOffset.Y = Math.Max(0, m_previewOffset.Y);

                m_previewGrip.X = mouseEventArgs.X;
                m_previewGrip.Y = mouseEventArgs.Y;
            }

            if (m_previewMode != PreviewMode.Preview)
            {
                Location pixelLocation = new Location(mouseEventArgs.X, mouseEventArgs.Y);
                pixelLocation.X /= m_trackBarZoom.Value;
                pixelLocation.Y /= m_trackBarZoom.Value;
                pixelLocation.X += (int)m_previewOffset.X;
                pixelLocation.Y += (int)m_previewOffset.Y;
                pixelLocation.X = Math.Min(pixelLocation.X, m_tileSheet.SheetSize.Width * m_tileSheet.TileSize.Width - 1);
                pixelLocation.Y = Math.Min(pixelLocation.Y, m_tileSheet.SheetSize.Height * m_tileSheet.TileSize.Width - 1);
                m_tileHoverIndex = m_tileSheet.GetTileIndex(pixelLocation);
            }
            else
                m_tileHoverIndex = -1;

            m_panelImage.Invalidate();
        }

        private void OnPreviewMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_previewMouseDown = false;
        }

        private void OnFieldChanged(object sender, EventArgs eventArgs)
        {
            MarkAsModified();
        }

        private void OnPropertyChangedOrDeleted(object sender,
            CustomPropertyEventArgs customPropertyEventArgs)
        {
            MarkAsModified();
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            if (m_bitmapImageSource == null)
            {
                m_noImageSourceMessageBox.Show();
                DialogResult = DialogResult.None;
                return;
            }

            string newId = m_textBoxId.Text;

            foreach (TileSheet tileSheet in m_tileSheet.Map.TileSheets)
            {
                if (tileSheet == m_tileSheet)
                    continue;
                if (newId == tileSheet.Id)
                {
                    m_duplicateIdMessageBox.Show();
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            if ((m_tileSheet.TileSize.Width != m_textBoxTileWidth.Value
                || m_tileSheet.TileSize.Height != m_textBoxTileHeight.Value)
                && m_tileSheet.Map.DependsOnTileSheet(m_tileSheet))
            {
                m_tileSizeFixedMessageBox.Show();
                DialogResult = DialogResult.None;
                return;
            }

            xTile.Dimensions.Size newTileSize = new xTile.Dimensions.Size(
                (int)m_textBoxTileWidth.Value, (int)m_textBoxTileHeight.Value);

            xTile.Dimensions.Size newMargin = new xTile.Dimensions.Size(
                (int)m_textBoxLeftMargin.Value, (int)m_textBoxTopMargin.Value);

            xTile.Dimensions.Size newSpacing = new xTile.Dimensions.Size(
                (int)m_textBoxSpacingX.Value, (int)m_textBoxSpacingY.Value);

            xTile.Dimensions.Size newSheetSize = xTile.Dimensions.Size.Zero;
            if (m_bitmapImageSource != null)
            {
                newSheetSize.Width = (m_bitmapImageSource.Width + newSpacing.Width - newMargin.Width)
                        / (newTileSize.Width + newSpacing.Width);
                newSheetSize.Height = (m_bitmapImageSource.Height + newSpacing.Height - newMargin.Height)
                        / (newTileSize.Height + newSpacing.Height);
            }

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

                m_isNewTileSheet = false;
            }
            else
            {
                command = new TileSheetPropertiesCommand(m_tileSheet, newId, m_textBoxDescription.Text,
                    newTileSize, newMargin, newSpacing, newSheetSize, m_textBoxImageSource.Text,
                    m_customPropertyGrid.NewProperties);
            }

            CommandHistory.Instance.Do(command);

            AutoTileManager.Instance.Refresh(m_tileSheet);

            MarkAsApplied();
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

                graphics.ScaleTransform(m_trackBarZoom.Value, m_trackBarZoom.Value);
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

                Pen alignmentPen = new Pen(SystemColors.ActiveCaption);
                float fZoomInverse = 1.0f / m_trackBarZoom.Value;
                alignmentPen.Width = fZoomInverse;

                for (int posY = marginTop; posY + tileHeight <= imageHeight; posY += tileHeight + tilePaddingY)
                    for (int posX = marginLeft; posX + tileWidth <= imageWidth; posX += tileWidth + tilePaddingX)
                    {
                        graphics.DrawRectangle(alignmentPen, posX, posY, tileWidth, tileHeight);
                    }

                Pen selectionPen = Pens.Red;
                Brush selectionBrush = new SolidBrush(Color.FromArgb(128, Color.Red));
                if (m_previewMode != PreviewMode.Preview && m_tileHoverIndex != -1)
                {
                    xTile.Dimensions.Rectangle rectangle = m_tileSheet.GetTileImageBounds(m_tileHoverIndex);
                    graphics.FillRectangle(selectionBrush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                    graphics.DrawRectangle(selectionPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                }

                if (m_previewMode == PreviewMode.PickSecond)
                {
                    xTile.Dimensions.Rectangle rectangle = m_tileSheet.GetTileImageBounds(m_swapTileIndex1);
                    graphics.FillRectangle(selectionBrush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                    graphics.DrawRectangle(selectionPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
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

    public enum PreviewMode
    {
        Preview,
        PickFirst,
        PickSecond
    }
}
