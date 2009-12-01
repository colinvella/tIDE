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

        #endregion

        #region Private Methods

        private void OnSelectTileSheet(object sender, EventArgs eventArgs)
        {
            if (m_comboBoxTileSheets.SelectedIndex < 0)
                return;

            string tileSheetId = m_comboBoxTileSheets.SelectedItem.ToString();
            m_tileSheet = m_map.GetTileSheet(tileSheetId);
            Bitmap tileSheetBitmap = new Bitmap(m_tileSheet.ImageSource);

            m_tileListView.Visible = false;

            m_tileImageList.Images.Clear();

            System.Drawing.Size tileSize = new System.Drawing.Size(
                m_tileSheet.TileSize.Width, m_tileSheet.TileSize.Height); 
            m_tileImageList.ImageSize = tileSize;

            m_tileListViewItems.Clear();
            System.Drawing.Rectangle pickerRectangle
                = new System.Drawing.Rectangle();
            for (int tileIndex = 0; tileIndex < m_tileSheet.TileCount; tileIndex++)
            {
                Tiling.Rectangle sheetRectangle = m_tileSheet.GetTileImageBounds(tileIndex);

                pickerRectangle.X = sheetRectangle.Location.X;
                pickerRectangle.Y = sheetRectangle.Location.Y;
                pickerRectangle.Width = sheetRectangle.Size.Width;
                pickerRectangle.Height = sheetRectangle.Size.Height;

                Bitmap tileBitmap = tileSheetBitmap.Clone(
                    pickerRectangle, tileSheetBitmap.PixelFormat);
                m_tileImageList.Images.Add(tileBitmap);

                m_tileListViewItems.Add(new ListViewItem(tileIndex.ToString(), tileIndex));
            }

            m_tileListView.VirtualListSize = m_tileListViewItems.Count;

            tileSheetBitmap.Dispose();

            m_tileListView.Visible = true;
        }

        private void m_tileListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs retrieveVirtualItemEventArgs)
        {
            retrieveVirtualItemEventArgs.Item
                = m_tileListViewItems[retrieveVirtualItemEventArgs.ItemIndex];
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
