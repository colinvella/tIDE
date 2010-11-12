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
        #region Public Methods

        public TilePickerNew()
        {
            InitializeComponent();

            m_autoUpdate = false;
            m_watchers = new Dictionary<TileSheet, FileSystemWatcher>();
            m_selectedTileIndex = -1;

            m_selectionBrush = new SolidBrush(Color.FromArgb(128, Color.Aqua));
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
                m_tilePanel.Invalidate();

                //TODO ensure tile visible
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

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is selected")]
        public event TilePickerEventHandler TileSelected;

        [Category("Behavior"), Description("Occurs when a tile is dragged from the picker")]
        public event TilePickerEventHandler TileDrag;

        #endregion

        #region Private Methods

        private int GetTileIndex(Point panelPosition)
        {
            if (m_tileSheet == null)
                return -1;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;

            int tileCount = m_tileSheet.TileCount;
            int tilesAcross = (m_tilePanel.ClientRectangle.Width + 1) / slotWidth;
            int tilesDown = 1 + (tileCount - 1) / tilesAcross;

            int tileX = panelPosition.X / slotWidth;
            int tileY = panelPosition.Y / slotHeight;

            int tileIndex = tileY * tilesAcross + tileX;

            if (tileIndex >= tileCount)
                return -1;

            return tileIndex;
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

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            RefreshSelectedTileSheet();
        }

        private void OnTilePanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            /*
            if (TileSelected != null)
                TileSelected(this,
                    new TilePickerEventArgs(m_tileSheet, SelectedTileIndex));
            */
        }

        private void OnTilePanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            m_selectedTileIndex = GetTileIndex(mouseEventArgs.Location);
            if (m_selectedTileIndex >= 0 && TileSelected != null)
            {
                m_tilePanel.Invalidate();
                TileSelected(this,
                    new TilePickerEventArgs(m_tileSheet, m_selectedTileIndex));
            }
        }

        private void OnDragLeave(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                return;

            if (m_selectedTileIndex < 0)
                return;

            TilePickerEventArgs tilePickerEventArgs = new TilePickerEventArgs(
                m_map.TileSheets[m_comboBoxTileSheets.SelectedIndex],
                m_selectedTileIndex);

            if (TileDrag != null)
                TileDrag(this, tilePickerEventArgs);
        }

        private void OnDragGiveFeedback(object sender, GiveFeedbackEventArgs giveFeedbackEventArgs)
        {
            giveFeedbackEventArgs.UseDefaultCursors = false;
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

            //graphics.Clear(BackColor);

            if (m_tileSheet == null)
                return;

            TileImageCache tileImageCache = TileImageCache.Instance;

            int slotWidth = m_tileSheet.TileSize.Width + 1;
            int slotHeight = m_tileSheet.TileSize.Height + 1;
            int tilesAcross = Math.Max(1, (m_tilePanel.ClientRectangle.Width + 1) / slotWidth);
            int tilesDown = 1 + (m_tileSheet.TileCount - 1) / tilesAcross;
            for (int tileY = 0; tileY < tilesDown; tileY++)
            {
                for (int tileX = 0; tileX < tilesAcross; tileX++)
                {
                    int tileIndex = tileY * tilesAcross + tileX;
                    if (tileIndex >= m_tileSheet.TileCount)
                        break;
                    Bitmap tileBitmap = tileImageCache.GetTileBitmap(m_tileSheet, tileIndex);
                    graphics.DrawImageUnscaled(tileBitmap, tileX * slotWidth, tileY * slotHeight);

                    if (tileIndex == m_selectedTileIndex)
                    {
                        graphics.DrawRectangle(Pens.DarkCyan,
                            tileX * slotWidth - 1, tileY * slotHeight - 1,
                            slotWidth + 1, slotHeight + 1);
                        graphics.FillRectangle(m_selectionBrush,
                            tileX * slotWidth, tileY * slotHeight,
                            slotWidth, slotHeight);
                    }
                }
            }
        }

        #endregion

        #region Private Fields

        private Map m_map;
        private TileSheet m_tileSheet;
        private bool m_autoUpdate;
        private Dictionary<TileSheet, FileSystemWatcher> m_watchers;
        private int m_selectedTileIndex;
        private Brush m_selectionBrush;

        #endregion

    }
}
