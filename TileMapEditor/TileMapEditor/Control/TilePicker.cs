using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;

namespace TileMapEditor.Control
{
    public delegate void TilePickerEventHandler(
            object sender, TilePickerEventArgs tilePickerEventArgs);

    public partial class TilePicker : UserControl
    {
        #region Private Variables

        private Map m_map;
        private TileSheet m_tileSheet;
        private List<ListViewItem> m_tileListViewItems;

        #endregion

        #region Private Methods

        private void OnRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs retrieveVirtualItemEventArgs)
        {
            int itemIndex = retrieveVirtualItemEventArgs.ItemIndex;
            ListViewItem listViewItem = m_tileListViewItems[itemIndex];

            if (listViewItem.ImageIndex == -1)
            {
                // update image list and assign new image
                Tiling.Rectangle sheetRectangle
                    = m_tileSheet.GetTileImageBounds(itemIndex);

                System.Drawing.Rectangle pickerRectangle
                    = new System.Drawing.Rectangle(
                        sheetRectangle.Location.X, sheetRectangle.Location.Y,
                        sheetRectangle.Size.Width, sheetRectangle.Size.Height);

                listViewItem.ImageIndex = m_tileImageList.Images.Count;

                Bitmap tileBitmap = TileImageCache.Instance.GetTileBitmap(m_tileSheet, itemIndex);

                m_tileImageList.Images.Add(tileBitmap);
            }

            retrieveVirtualItemEventArgs.Item = listViewItem;
        }

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
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

        private void OnSelectTile(object sender, EventArgs eventArgs)
        {
            if (TileSelected != null)
                TileSelected(this,
                    new TilePickerEventArgs(m_tileSheet, SelectedTileIndex));
        }

        #endregion

        #region Public Methods

        public TilePicker()
        {
            InitializeComponent();

            m_tileListViewItems = new List<ListViewItem>();
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
            else
                m_tileListView.VirtualListSize = 0;
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

                m_comboBoxTileSheets.SelectedText = value.Id;
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
            }
        }

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is selected")]
        public event TilePickerEventHandler TileSelected;

        #endregion
    }
}
