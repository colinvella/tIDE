using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Tiles;

namespace TileMapEditor.Controls
{
    public delegate void TilePickerEventHandler(
            object sender, TilePickerEventArgs tilePickerEventArgs);

    public partial class TilePicker : UserControl
    {
        #region Private Variables

        private Map m_map;
        private TileSheet m_tileSheet;
        private List<ListViewItem> m_tileListViewItems;
        private bool m_autoUpdate;
        private Dictionary<TileSheet, FileSystemWatcher> m_watchers;

        #endregion

        #region Private Methods

        private void OnRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs retrieveVirtualItemEventArgs)
        {
            int itemIndex = retrieveVirtualItemEventArgs.ItemIndex;
            ListViewItem listViewItem = m_tileListViewItems[itemIndex];

            if (listViewItem.ImageIndex == -1)
            {
                // update image list and assign new image
                Rectangle sheetRectangle
                    = m_tileSheet.GetTileImageBounds(itemIndex);

                System.Drawing.Rectangle pickerRectangle
                    = new System.Drawing.Rectangle(
                        sheetRectangle.Location.X, sheetRectangle.Location.Y,
                        sheetRectangle.Size.Width, sheetRectangle.Size.Height);

                listViewItem.ImageIndex = m_tileImageList.Images.Count;

                System.Drawing.Bitmap tileBitmap = TileImageCache.Instance.GetTileBitmap(m_tileSheet, itemIndex);

                m_tileImageList.Images.Add(tileBitmap);
            }

            retrieveVirtualItemEventArgs.Item = listViewItem;
        }

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            RefreshSelectedTileSheet();
        }

        private void OnSelectTile(object sender, EventArgs eventArgs)
        {
            if (TileSelected != null)
                TileSelected(this,
                    new TilePickerEventArgs(m_tileSheet, SelectedTileIndex));
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
            this.Invoke(new MethodInvoker(m_tileListView.Invalidate));
        }

        private void OnItemDrag(object sender, ItemDragEventArgs itemDragEventArgs)
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                return;

            TileDragEventArgs tileDragEventArgs = new TileDragEventArgs(
                m_map.TileSheets[m_comboBoxTileSheets.SelectedIndex],
                m_tileListView.SelectedIndices[0]);

            if (TileDrag != null)
                TileDrag(this, tileDragEventArgs);

            m_tileListView.DoDragDrop(tileDragEventArgs, DragDropEffects.Copy);
        }

        private void OnDragGiveFeedback(object sender, GiveFeedbackEventArgs giveFeedbackEventArgs)
        {
            giveFeedbackEventArgs.UseDefaultCursors = false;
        }

        #endregion

        #region Public Methods

        public TilePicker()
        {
            InitializeComponent();

            m_tileListViewItems = new List<ListViewItem>();

            m_autoUpdate = false;
            m_watchers = new Dictionary<TileSheet, FileSystemWatcher>();
        }

        public void UpdatePicker()
        {
            if (m_map == null)
            {
                m_comboBoxTileSheets.Items.Clear();
                m_tileListView.Items.Clear();
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
            else
                m_tileListView.VirtualListSize = 0;

            UpdateWatchers();
        }

        public void RefreshSelectedTileSheet()
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
            {
                m_tileListView.VirtualListSize = 0;
                return;
            }

            string tileSheetId = m_comboBoxTileSheets.SelectedItem.ToString();
            m_tileSheet = m_map.GetTileSheet(tileSheetId);

            // reset image list
            m_tileImageList.Images.Clear();
            System.Drawing.Size tileSize = new System.Drawing.Size(
                m_tileSheet.TileSize.Width, m_tileSheet.TileSize.Height);
            m_tileImageList.ImageSize = tileSize;

            // populate item list for virtual mode with no image index
            m_tileListViewItems.Clear();
            for (int tileIndex = 0; tileIndex < m_tileSheet.TileCount; tileIndex++)
            {
                ListViewItem listViewItem = new ListViewItem(tileIndex.ToString(), -1);
                listViewItem.ToolTipText = tileIndex.ToString();
                m_tileListViewItems.Add(listViewItem);
            }

            m_tileListView.VirtualListSize = m_tileListViewItems.Count;

            if (m_tileListView.Items.Count > 0)
            {
                m_tileListView.SelectedIndices.Clear();
                m_tileListView.SelectedIndices.Add(0);
            }
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
                OnSelectTileSheet(this, new EventArgs());
            }
        }

        [Category("Behavior"),
         DefaultValue(-1),
         Description("The index of the selected tile")]
        public int SelectedTileIndex
        {
            get
            {
                return m_tileListView.SelectedIndices.Count > 0
                    ? m_tileListView.SelectedIndices[0]
                    : -1;
            }
            set
            {
                m_tileListView.SelectedIndices.Clear();
                m_tileListView.SelectedIndices.Add(value);
                m_tileListView.EnsureVisible(value);
            }
        }

        [Category("Behavior"),
         DefaultValue(-1),
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

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is selected")]
        public event TilePickerEventHandler TileSelected;

        [Category("Behavior"), Description("Occurs when a tile is dragged from the picker")]
        public event TileDragEventHandler TileDrag;

        #endregion
    }

    public class TileDragEventArgs
    {
        private TileSheet m_tileSheet;
        private int m_tileIndex;

        public TileDragEventArgs(TileSheet tileSheet, int tileIndex)
        {
            m_tileSheet = tileSheet;
            m_tileIndex = tileIndex;
        }

        public TileSheet TileSheet { get { return m_tileSheet; } }

        public int TileIndex { get { return m_tileIndex; } }
    }

    public delegate void TileDragEventHandler(object sender, TileDragEventArgs tileDragEventArgs);
}
