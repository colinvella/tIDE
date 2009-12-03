using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor.Control
{
    public partial class MapPanel : UserControl, DisplayDevice
    {
        #region Private Variables

        private Map m_map;
        private Layer m_selectedLayer;
        private TileSheet m_selectedTileSheet;
        private int m_selectedTileIndex;

        private Graphics m_graphics;
        private Dictionary<TileSheet, Bitmap> m_tileSheetBitmaps;
        private Tiling.Rectangle m_viewPort;
        private int m_zoom;
        private Brush m_veilBrush;
        private ImageAttributes m_imageAttributes;
        private ColorMatrix m_colorMatrix;

        private bool m_bMouseDown;

        #endregion

        #region Private Methods

        private void PlaceTile(MouseEventArgs mouseEventArgs)
        {
            if (m_selectedLayer == null)
                return;
            if (m_selectedTileIndex < 0)
                return;

            Location offset = new Location(
                mouseEventArgs.Location.X,
                mouseEventArgs.Location.Y);
            offset.X /= m_zoom;
            offset.Y /= m_zoom;

            Location pixelLocation = m_viewPort.Location;

            // scale due to parallax
            pixelLocation.X *= m_selectedLayer.DisplaySize.Width;
            pixelLocation.X /= m_map.DisplaySize.Width;
            pixelLocation.Y *= m_selectedLayer.DisplaySize.Height;
            pixelLocation.Y /= m_selectedLayer.DisplaySize.Height;

            pixelLocation += offset;

            Location tileLocation = m_selectedLayer.GetTileLocation(pixelLocation);

            if (m_selectedLayer.IsValidLocation(tileLocation))
            {
                m_selectedLayer.Tiles[tileLocation]
                    = new StaticTile(m_selectedLayer, m_selectedTileSheet, BlendMode.Alpha, m_selectedTileIndex);

                m_innerPanel.Invalidate();
            }
        }

        private void UpdateScrollBars()
        {
            if (m_map == null)
            {
                m_horizontalScrollBar.Maximum = 0;
                m_horizontalScrollBar.LargeChange = 1;
                m_horizontalScrollBar.Value = 0;
                m_horizontalScrollBar.Visible = false;

                m_verticalScrollBar.Maximum = 0;
                m_verticalScrollBar.LargeChange = 1;
                m_verticalScrollBar.Value = 0;
                m_verticalScrollBar.Visible = false;
            }
            else
            {
                System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
                Tiling.Size displaySize = m_map.DisplaySize;

                m_horizontalScrollBar.Maximum = displaySize.Width;
                m_horizontalScrollBar.LargeChange = 1 + (clientRectangle.Width - 1) / m_zoom;
                m_horizontalScrollBar.Value
                    = Math.Min(m_horizontalScrollBar.Value, displaySize.Width);
                m_horizontalScrollBar.Visible = displaySize.Width > clientRectangle.Width;

                m_verticalScrollBar.Maximum = displaySize.Height;
                m_verticalScrollBar.LargeChange = 1 + (clientRectangle.Height - 1) / m_zoom;
                m_verticalScrollBar.Value
                    = Math.Min(m_verticalScrollBar.Value, displaySize.Height);
                m_verticalScrollBar.Visible = displaySize.Height > clientRectangle.Height;
            }
        }

        private void BindLayerDrawEvents()
        {
            if (m_map == null)
                return;

            foreach (Layer layer in m_map.Layers)
            {
                layer.BeforeDraw -= OnBeforeLayerDraw;
                layer.BeforeDraw += OnBeforeLayerDraw;

                layer.AfterDraw -= OnAfterLayerDraw;
                layer.AfterDraw += OnAfterLayerDraw;
            }
        }

        private void OnHorizontalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewPort.Location.X = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void OnVerticalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewPort.Location.Y = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void OnResizeDisplay(object sender, EventArgs e)
        {
            System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
            m_viewPort.Size.Width = 1 + (clientRectangle.Width - 1)/ m_zoom;
            m_viewPort.Size.Height = 1 + (clientRectangle.Height - 1) / m_zoom;
        }

        private void OnBeforeLayerDraw(LayerEventArgs layerEventArgs)
        {
            if (layerEventArgs.Layer == m_selectedLayer
                && m_map.Layers.IndexOf(layerEventArgs.Layer) > 0)
            {
                m_graphics.FillRectangle(m_veilBrush, ClientRectangle);
            }
        }

        private void OnAfterLayerDraw(LayerEventArgs layerEventArgs)
        {
            if (layerEventArgs.Layer == m_selectedLayer)
            {
                // set translucency for upper layers
                m_colorMatrix.Matrix33 = 0.25f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            }
        }

        private void OnMapPaint(object sender, PaintEventArgs paintEventArgs)
        {
            m_graphics = paintEventArgs.Graphics;

            if (m_map != null)
            {

                UpdateScrollBars();
                BindLayerDrawEvents();

                m_map.Draw(this, m_viewPort);

                // reset translucency
                m_colorMatrix.Matrix33 = 1.0f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            }

            if (!Enabled)
            {
                m_graphics.FillRectangle(new SolidBrush(Color.FromArgb(224, SystemColors.Control)), ClientRectangle);
                SizeF stringSize = m_graphics.MeasureString("Add layers to this map", this.Font);
                m_graphics.DrawString("Add layers to this map", this.Font, SystemBrushes.ControlDark,
                    (ClientRectangle.Width - (int)stringSize.Width) / 2,
                    (ClientRectangle.Height - (int)stringSize.Height) / 2);
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            m_bMouseDown = true;
            if (mouseEventArgs.Button == MouseButtons.Left)
                PlaceTile(mouseEventArgs);
        }

        private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_bMouseDown && mouseEventArgs.Button == MouseButtons.Left)
                PlaceTile(mouseEventArgs);
        }

        private void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_bMouseDown = false;
        }

        #endregion

        #region Public Methods

        public MapPanel()
        {
            InitializeComponent();

            m_tileSheetBitmaps = new Dictionary<TileSheet, Bitmap>();
            m_viewPort = new Tiling.Rectangle(
                Tiling.Location.Origin, Tiling.Size.Zero);
            m_zoom = 1;

            m_veilBrush = new SolidBrush(Color.FromArgb(192, SystemColors.InactiveCaption));
            m_imageAttributes = new ImageAttributes();
            m_colorMatrix = new ColorMatrix();
        }

        public void LoadTileSheet(TileSheet tileSheet)
        {
            m_tileSheetBitmaps.Remove(tileSheet);

            Bitmap bitmap = new Bitmap(tileSheet.ImageSource);
            m_tileSheetBitmaps[tileSheet] = bitmap;
        }

        public void DisposeTileSheet(TileSheet tileSheet)
        {
            m_tileSheetBitmaps.Remove(tileSheet);
        }

        public void BeginScene()
        {
            m_graphics.ScaleTransform(m_zoom, m_zoom);
            m_graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            m_graphics.PixelOffsetMode = PixelOffsetMode.Half;
        }

        public void SetClippingRegion(Tiling.Rectangle clippingRegion)
        {
            if (m_graphics == null)
                return;

            m_graphics.SetClip(new RectangleF(
                    clippingRegion.Location.X, clippingRegion.Location.Y,
                    clippingRegion.Size.Width, clippingRegion.Size.Height));
        }

        public void DrawTile(Tile tile, Location location)
        {
            if (m_graphics == null)
                return;

            Tiling.Rectangle imageBounds = tile.TileSheet.GetTileImageBounds(tile.TileIndex);
            Bitmap bitmap = m_tileSheetBitmaps[tile.TileSheet];

            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(
                location.X, location.Y, imageBounds.Size.Width, imageBounds.Size.Height);

            m_graphics.DrawImage(bitmap,destRect,
                imageBounds.Location.X, imageBounds.Location.Y, imageBounds.Size.Width, imageBounds.Size.Height,
                GraphicsUnit.Pixel, m_imageAttributes);
        }

        public void EndScene()
        {
        }

        #endregion

        #region Public Properties

        [Description("The Map structure associated with this control"),
         Category("Data"), Browsable(true)
        ]
        public Map Map
        {
            get { return m_map; }
            set
            {
                m_map = value;

                if (m_map != null && !m_map.Layers.Contains(m_selectedLayer))
                    m_selectedLayer = null;

                UpdateScrollBars();

                Invalidate();
            }
        }

        [Description("The currently selected Layer"),
         Category("Data"), Browsable(true)
        ]
        public Layer SelectedLayer
        {
            get { return m_selectedLayer; }
            set
            {
                if (m_map == null)
                {
                    m_selectedLayer = null;
                    Invalidate(true);
                    return;
                }

                if (value == null)
                {
                    m_selectedLayer = null;
                    Invalidate(true);
                    return;
                }

                if (!m_map.Layers.Contains(value))
                    throw new Exception("The specified Layer is not contained in the Map");
                m_selectedLayer = value;
                Invalidate(true);
            }
        }

        [Description("The zoom level of the map display"),
         Category("Appearance"), Browsable(true), DefaultValue(1)
        ]
        public int Zoom
        {
            get { return m_zoom; }
            set
            {
                m_zoom = Math.Max(1, Math.Min(value, 10));

                System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
                m_viewPort.Size.Width = 1 + (clientRectangle.Width - 1) / m_zoom;
                m_viewPort.Size.Height = 1 + (clientRectangle.Height - 1) / m_zoom;

                Invalidate(true);
            }
        }

        public TileSheet SelectedTileSheet
        {
            get { return m_selectedTileSheet; }
            set { m_selectedTileSheet = value; }
        }

        public int SelectedTileIndex
        {
            get { return m_selectedTileIndex; }
            set { m_selectedTileIndex = value; }
        }

        #endregion
    }
}
