using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private Graphics m_graphics;
        private Dictionary<TileSheet, Bitmap> m_tileSheetBitmaps;
        private Tiling.Rectangle m_viewPort;
        private int m_zoom;

        #endregion

        #region Private Methods

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
                m_horizontalScrollBar.LargeChange = clientRectangle.Width / m_zoom;
                m_horizontalScrollBar.Value
                    = Math.Min(m_horizontalScrollBar.Value, displaySize.Width);
                m_horizontalScrollBar.Visible = displaySize.Width > clientRectangle.Width;

                m_verticalScrollBar.Maximum = displaySize.Height;
                m_verticalScrollBar.LargeChange = clientRectangle.Height / m_zoom;
                m_verticalScrollBar.Value
                    = Math.Min(m_verticalScrollBar.Value, displaySize.Height);
                m_verticalScrollBar.Visible = displaySize.Height > clientRectangle.Height;
            }
        }

        private void m_horizontalScrollBar_Scroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewPort.Location.X = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void m_verticalScrollBar_Scroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewPort.Location.Y = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void m_innerPanel_Resize(object sender, EventArgs e)
        {
            System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
            m_viewPort.Size.Width = clientRectangle.Width / m_zoom;
            m_viewPort.Size.Height = clientRectangle.Height / m_zoom;
        }

        private void m_innerPanel_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            m_graphics = paintEventArgs.Graphics;

            if (m_map == null)
                return;

            UpdateScrollBars();

            m_map.Draw(this, m_viewPort);
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
            System.Drawing.Rectangle imageBoundsGDIP = new System.Drawing.Rectangle(
                imageBounds.Location.X, imageBounds.Location.Y,
                imageBounds.Size.Width, imageBounds.Size.Height);
            m_graphics.DrawImage(bitmap, location.X, location.Y, imageBoundsGDIP, GraphicsUnit.Pixel);
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
                    return;
                }

                if (value == null)
                {
                    m_selectedLayer = null;
                    Invalidate();
                    return;
                }

                if (!m_map.Layers.Contains(value))
                    throw new Exception("The specified Layer is not contained in the Map");
                m_selectedLayer = value;
                Invalidate();
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
                Invalidate(true);
            }
        }

        #endregion
    }
}
