using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xTile.Tiles;
using xTile;
using System.IO;

namespace TileMapEditor.Controls
{
    public partial class TilePickerNew : UserControl
    {
        private enum OrderMode
        {
            Indexed,
            MRU,
            Image
        }

        #region Public Methods

        public TilePickerNew()
        {
            InitializeComponent();

            m_autoUpdate = false;
            m_watchers = new Dictionary<TileSheet, FileSystemWatcher>();
            m_selectedTileIndex = -1;
            m_orderMode = OrderMode.Indexed;

            m_selectionBrush = new SolidBrush(Color.FromArgb(128, Color.SkyBlue));

            m_visibleSize = new Size();
            m_requiredSize = new Size();

            m_indexToMru = new List<int>();

            UpdateInternalDimensions();
        }

        public void UpdatePicker()
        {
            if (m_map == null)
            {
                m_comboBoxTileSheets.Items.Clear();
                return;
            }

            string selectedItem = m_comboBoxTileSheets.SelectedItem == null
                ? null : m_comboBoxTileSheets.SelectedItem.ToString();
            m_comboBoxTileSheets.Items.Clear();
            foreach (TileSheet tileSheet in m_map.TileSheets)
                m_comboBoxTileSheets.Items.Add(tileSheet.Id);
            m_comboBoxTileSheets.SelectedItem = selectedItem;

            if (m_comboBoxTileSheets.Items.Count > 0)
                m_comboBoxTileSheets.SelectedIndex = 0;

            UpdateWatchers();

            m_tilePanel.Invalidate();
        }

        public void RefreshSelectedTileSheet()
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                m_tileSheet = null;
            else
            {
                string tileSheetId = m_comboBoxTileSheets.SelectedItem.ToString();
                m_tileSheet = m_map.GetTileSheet(tileSheetId);
            }

            ResetMru();

            m_horizontalScrollBar.Visible = m_verticalScrollBar.Visible = false;
            m_horizontalScrollBar.Value = m_verticalScrollBar.Value = 0;
            UpdateInternalDimensions();
            m_tilePanel.Invalidate();

            /*
            // ensure tiles within 256 wide/high and preserve aspect ratio
            System.Drawing.Size tileSize = new System.Drawing.Size(
                m_tileSheet.TileSize.Width, m_tileSheet.TileSize.Height);
            int maxDimension = Math.Max(tileSize.Width, tileSize.Height);
            if (maxDimension > 256)
            {
                tileSize.Width = (tileSize.Width * 256) / maxDimension;
                tileSize.Height = (tileSize.Height * 256) / maxDimension;
            }*/
        }

        #endregion

        #region Public Properties

        public Map Map
        {
            get { return m_map; }
            set
            {
                m_map = value;
                UpdatePicker();
            }
        }

        public TileSheet SelectedTileSheet
        {
            get { return m_tileSheet; }
            set
            {
                if (m_tileSheet == value)
                    return;

                m_comboBoxTileSheets.SelectedIndex = m_map.TileSheets.IndexOf(value);
                OnSelectTileSheet(this, EventArgs.Empty);
            }
        }

        [Category("Behavior"),
         DefaultValue(-1),
         Description("The index of the selected tile")]
        public int SelectedTileIndex
        {
            get
            {
                return m_selectedTileIndex;
            }
            set
            {
                m_selectedTileIndex = value;
                m_focusOnTile = true;
                UpdateMru(m_selectedTileIndex);
                m_tilePanel.Invalidate();
            }
        }

        [Category("Behavior"),
         DefaultValue(false),
         Description("Automatically update tile sheets when they are updated on disk")]
        public bool AutoUpdate
        {
            get
            {
                return m_autoUpdate;
            }
            set
            {
                m_autoUpdate = value;
                UpdateWatchers();
            }
        }

        [Category("Behavior"),
         DefaultValue(false),
         Description("Prevents the user from switching tile sheets")]
        public bool LockTileSheet
        {
            get
            {
                return !m_comboBoxTileSheets.Enabled;
            }
            set
            {
                m_comboBoxTileSheets.Enabled = !value;
            }
        }

        [Category("Behavior"),
         DefaultValue(false),
         Description("Allows the user to drag tiles off the tile picker")]
        public bool AllowTileDragging
        {
            get
            {
                return m_allowTileDragging;
            }
            set
            {
                m_allowTileDragging = value;
            }
        }



        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is selected")]
        public event TilePickerEventHandler TileSelected;

        #endregion

        #region Private Methods

        private void UpdateInternalDimensions()
        {
            if (m_tileSheet == null)
                return;

            m_visibleSize.Width = m_tilePanel.ClientSize.Width - m_verticalScrollBar.Width;
            m_visibleSize.Width = Math.Max(0, m_visibleSize.Width);

            m_visibleSize.Height = m_tilePanel.ClientSize.Height - m_horizontalScrollBar.Height - m_toolStrip.Height;
            m_visibleSize.Height = Math.Max(0, m_visibleSize.Height);

            int tileCount = m_tileSheet.TileCount;
            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;

            switch (m_orderMode)
            {
                case OrderMode.Indexed:
                case OrderMode.MRU:
                    m_requiredSize.Width = m_visibleSize.Width;
                    m_requiredSize.Height = (tileCount * slotWidth * slotHeight) / m_visibleSize.Width;
                    break;
                case OrderMode.Image:
                    m_requiredSize.Width = m_tileSheet.SheetSize.Width * slotWidth;
                    m_requiredSize.Height = m_tileSheet.SheetSize.Height * slotHeight;
                    break;
            }

            m_horizontalScrollBar.Maximum = m_requiredSize.Width;
            m_verticalScrollBar.Maximum = m_requiredSize.Height;

            if (!m_horizontalScrollBar.Visible && m_requiredSize.Width > m_visibleSize.Width)
            {
                m_horizontalScrollBar.Visible = true;
                m_horizontalScrollBar.LargeChange = m_visibleSize.Width;
                UpdateInternalDimensions();
            }

            if (!m_verticalScrollBar.Visible && m_requiredSize.Height > m_visibleSize.Height)
            {
                m_verticalScrollBar.Visible = true;
                m_verticalScrollBar.LargeChange = m_visibleSize.Height;
                UpdateInternalDimensions();
            }
        }

        private int GetTileIndex(Point panelPosition)
        {
            if (m_tileSheet == null)
                return -1;

            if (m_horizontalScrollBar.Visible)
                panelPosition.X += m_horizontalScrollBar.Value;

            if (m_verticalScrollBar.Visible)
                panelPosition.Y += m_verticalScrollBar.Value;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;

            int tileCount = m_tileSheet.TileCount;
            int tilesAcross = Math.Max(1, m_requiredSize.Width / slotWidth);
            int tilesDown = 1 + (tileCount - 1) / tilesAcross;

            int tileX = panelPosition.X / slotWidth;
            int tileY = panelPosition.Y / slotHeight;

            int tileIndex = tileY * tilesAcross + tileX;

            if (tileIndex >= tileCount)
                return -1;

            return tileIndex;
        }

        private void ResetMru()
        {
            m_indexToMru.Clear();

            if (m_tileSheet == null)
                return;

            for (int index = 0; index < m_tileSheet.TileCount; index++)
                m_indexToMru.Add(index);
        }

        private void UpdateMru(int tileIndex)
        {
            if (tileIndex < 0)
                return;

            m_indexToMru.Remove(tileIndex);
            m_indexToMru.Insert(0, tileIndex);
        }

        private void UpdateOrderButtons()
        {
            m_indexOrderButton.Checked = m_orderMode == OrderMode.Indexed;
            m_mruOrderButton.Checked = m_orderMode == OrderMode.MRU;
            m_imageOrderButton.Checked = m_orderMode == OrderMode.Image;
        }

        private void UpdateWatchers()
        {
            foreach (FileSystemWatcher fileSystemWatcher in m_watchers.Values)
                fileSystemWatcher.EnableRaisingEvents = false;
            m_watchers.Clear();

            if (!m_autoUpdate)
                return;

            foreach (TileSheet tileSheet in m_map.TileSheets)
            {
                string folder = Path.GetDirectoryName(tileSheet.ImageSource);
                string fileName = Path.GetFileName(tileSheet.ImageSource);
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(folder, fileName);
                m_watchers[tileSheet] = fileSystemWatcher;
                fileSystemWatcher.Changed += this.OnTileSheetImageSourceChanged;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        private void OnTilePanelResize(object sender, EventArgs eventArgs)
        {
            UpdateInternalDimensions();
            m_tilePanel.Invalidate();
        }

        private void OnHorizontalScroll(object sender, ScrollEventArgs e)
        {
            m_tilePanel.Invalidate();
        }

        private void OnVerticalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_tilePanel.Invalidate();
        }

        private void OnTilePanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left)
                return;
        }

        private void OnTilePanelMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.None)
            {
                int newHoverTileIndex = GetTileIndex(mouseEventArgs.Location);

                if (m_hoverTileIndex != newHoverTileIndex)
                {
                    m_hoverTileIndex = newHoverTileIndex;
                    m_tilePanel.Invalidate();
                }
            }
            else if (mouseEventArgs.Button == MouseButtons.Left
                && m_allowTileDragging)
            {
                if (m_tileSheet != null
                    && m_selectedTileIndex >= 0 && m_selectedTileIndex < m_tileSheet.TileCount)
                {
                    DoDragDrop(m_selectedTileIndex, DragDropEffects.All);
                }
            }
        }

        private void OnTilePanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left)
                return;

            m_selectedTileIndex = GetTileIndex(mouseEventArgs.Location);
            if (m_selectedTileIndex >= 0)
            {
                if (m_orderMode == OrderMode.MRU)
                    m_selectedTileIndex = m_indexToMru[m_selectedTileIndex];

                UpdateMru(m_selectedTileIndex);

                if (m_orderMode == OrderMode.MRU)
                    m_focusOnTile = true;

                if (TileSelected != null)
                    TileSelected(this,
                        new TilePickerEventArgs(m_tileSheet, m_selectedTileIndex));

                m_tilePanel.Invalidate();
            }
        }

        private void OnDragGiveFeedback(object sender, GiveFeedbackEventArgs giveFeedbackEventArgs)
        {
            giveFeedbackEventArgs.UseDefaultCursors = false;
        }

        private void OnOrderIndexed(object sender, EventArgs eventArgs)
        {
            m_orderMode = OrderMode.Indexed;
            UpdateOrderButtons();
            m_horizontalScrollBar.Visible = m_verticalScrollBar.Visible = false;
            m_horizontalScrollBar.Value = m_verticalScrollBar.Value = 0;
            UpdateInternalDimensions();
            m_tilePanel.Invalidate();
            SelectedTileIndex = SelectedTileIndex;
        }

        private void OnOrderMru(object sender, EventArgs eventArgs)
        {
            m_orderMode = OrderMode.MRU;
            UpdateOrderButtons();
            m_horizontalScrollBar.Visible = m_verticalScrollBar.Visible = false;
            m_horizontalScrollBar.Value = m_verticalScrollBar.Value = 0;
            UpdateInternalDimensions();
            m_tilePanel.Invalidate();
            SelectedTileIndex = SelectedTileIndex;
        }

        private void OnOrderImage(object sender, EventArgs eventArgs)
        {
            m_orderMode = OrderMode.Image;
            UpdateOrderButtons();
            m_horizontalScrollBar.Visible = m_verticalScrollBar.Visible = false;
            m_horizontalScrollBar.Value = m_verticalScrollBar.Value = 0;
            UpdateInternalDimensions();
            m_tilePanel.Invalidate();
            SelectedTileIndex = SelectedTileIndex;
        }

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            m_selectedTileIndex = -1;
            RefreshSelectedTileSheet();
        }

        private void OnTileSheetImageSourceChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            foreach (TileSheet tileSheet in m_map.TileSheets)
                if (tileSheet.ImageSource == fileSystemEventArgs.FullPath)
                {
                    for (int tries = 0; tries < 10; tries++)
                    {
                        try
                        {
                            System.Threading.Thread.Sleep(10);
                            TileImageCache.Instance.Refresh(tileSheet);
                            break;
                        }
                        catch
                        {
                        }
                    }
                }

            this.Invoke(new MethodInvoker(UpdatePicker));
            this.Invoke(new MethodInvoker(RefreshSelectedTileSheet));
        }

        private void OnTilePanelPaint(object sender, PaintEventArgs paintEventArgs)
        {
            Graphics graphics = paintEventArgs.Graphics;

            if (m_tileSheet == null)
                return;

            TileImageCache tileImageCache = TileImageCache.Instance;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;
            int tilesAcross = Math.Max(1, m_requiredSize.Width / slotWidth);
            int tilesDown = 1 + (m_tileSheet.TileCount - 1) / tilesAcross;
            int scrollOffsetX = -m_horizontalScrollBar.Value;
            int scrollOffsetY = -m_verticalScrollBar.Value;
            for (int tileY = 0; tileY < tilesDown; tileY++)
            {
                for (int tileX = 0; tileX < tilesAcross; tileX++)
                {
                    int tileIndex = tileY * tilesAcross + tileX;

                    if (tileIndex >= m_tileSheet.TileCount)
                        break;

                    int drawTileIndex = m_orderMode == OrderMode.MRU
                        ? m_indexToMru[tileIndex]
                        : tileIndex;

                    Bitmap tileBitmap = tileImageCache.GetTileBitmap(m_tileSheet, drawTileIndex);

                    int imageX = tileX * slotWidth + scrollOffsetX;
                    int imageY = tileY * slotHeight + scrollOffsetY;

                    graphics.DrawImageUnscaled(tileBitmap,
                        imageX, tileY * slotHeight + scrollOffsetY);

                    if (drawTileIndex == m_selectedTileIndex)
                    {
                        graphics.FillRectangle(m_selectionBrush,
                            imageX, imageY,
                            slotWidth, slotHeight);
                        graphics.DrawRectangle(Pens.DarkCyan,
                            imageX - 1, imageY - 1,
                            slotWidth, slotHeight);

                        // scroll and re-trigger paint until visible
                        if (m_focusOnTile)
                        {
                            m_focusOnTile = false;

                            if (imageX < 0)
                            {
                                m_horizontalScrollBar.Value += imageX;
                                m_tilePanel.Invalidate();
                            }

                            if (imageY < 0)
                            {
                                m_verticalScrollBar.Value += imageY;
                                m_tilePanel.Invalidate();
                            }

                            if (tilesAcross > 1
                                && imageX + slotWidth > m_visibleSize.Width)
                            {
                                m_horizontalScrollBar.Value += imageX + slotWidth - m_visibleSize.Width;
                                m_tilePanel.Invalidate();
                            }

                            if (tilesDown > 1
                                && imageY + slotHeight > m_visibleSize.Height)
                            {
                                m_verticalScrollBar.Value += imageY + slotHeight - m_visibleSize.Height;
                                m_tilePanel.Invalidate();
                            }
                        }
                    }

                    if (tileIndex == m_hoverTileIndex)
                    {
                        graphics.DrawRectangle(Pens.Black,
                            imageX - 1, imageY - 1, slotWidth, slotHeight);
                    }
                }
            }
        }

        #endregion

        #region Private Fields

        private Map m_map;
        private TileSheet m_tileSheet;
        private OrderMode m_orderMode;
        private bool m_autoUpdate;
        private bool m_allowTileDragging;
        private Dictionary<TileSheet, FileSystemWatcher> m_watchers;
        private int m_hoverTileIndex;
        private int m_selectedTileIndex;

        private Size m_visibleSize;
        private Size m_requiredSize;
        private bool m_focusOnTile;

        private Brush m_selectionBrush;

        private List<int> m_indexToMru;

        #endregion
    }
}
