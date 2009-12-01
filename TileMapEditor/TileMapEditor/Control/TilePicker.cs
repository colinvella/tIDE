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
    public partial class TilePicker : UserControl
    {
        #region Private Variables

        private Map m_map;
        private TileSheet m_tileSheet;
        private List<ListViewItem> m_tileListViewItems;
        private Bitmap m_tileSheetBitmap;

        #endregion

        #region Private Methods

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                return;

            string tileSheetId = m_comboBoxTileSheets.SelectedItem.ToString();
            m_tileSheet = m_map.GetTileSheet(tileSheetId);

            if (m_tileSheetBitmap != null)
                m_tileSheetBitmap.Dispose();
            m_tileSheetBitmap = new Bitmap(m_tileSheet.ImageSource);

            m_tileListView.Visible = false;
            System.Threading.Thread.Sleep(0);

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

            m_tileListView.Visible = true;
        }

        private void m_tileListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs retrieveVirtualItemEventArgs)
        {
            ListViewItem listViewItem = m_tileListViewItems[retrieveVirtualItemEventArgs.ItemIndex];

            if (listViewItem.ImageIndex == -1)
            {
                // update image list and assign new image
                Tiling.Rectangle sheetRectangle
                    = m_tileSheet.GetTileImageBounds(retrieveVirtualItemEventArgs.ItemIndex);

                System.Drawing.Rectangle pickerRectangle
                    = new System.Drawing.Rectangle(
                        sheetRectangle.Location.X, sheetRectangle.Location.Y,
                        sheetRectangle.Size.Width, sheetRectangle.Size.Height);

                listViewItem.ImageIndex = m_tileImageList.Images.Count;

                Bitmap tileBitmap = m_tileSheetBitmap.Clone(
                    pickerRectangle, m_tileSheetBitmap.PixelFormat);
                m_tileImageList.Images.Add(tileBitmap);
            }

            retrieveVirtualItemEventArgs.Item = listViewItem;
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

        #endregion
    }
}
