using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using XTile.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class AutoTileDialog : Form
    {
        public AutoTileDialog(TileSheet tileSheet)
        {
            InitializeComponent();

            m_tileSheet = tileSheet;
            m_draggedTileIndex = -1;
        }

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            m_tilePicker.Map = m_tileSheet.Map;
            m_tilePicker.SelectedTileSheet = m_tileSheet;
            m_tilePicker.UpdatePicker();

            foreach (AutoTile autoTile in AutoTileManager.Instance.GetAutoTiles(m_tileSheet))
                m_cmbId.Items.Add(autoTile.Id);

            if (m_cmbId.Items.Count > 0)
                m_cmbId.SelectedIndex = 0;
        }

        private void OnTileDrag(object sender, TilePickerEventArgs tilePickerEventArgs)
        {
            m_draggedTileIndex = tilePickerEventArgs.TileIndex;

            Bitmap tileImage = TileImageCache.Instance.GetTileBitmap(
                m_tileSheet, m_draggedTileIndex);

            IconInfo iconInfo = new IconInfo();
            GetIconInfo(tileImage.GetHicon(), ref iconInfo);
            iconInfo.HotSpotX = tileImage.Width / 2;
            iconInfo.HotSpotY = tileImage.Height / 2;
            iconInfo.Icon = false;

            Cursor = new Cursor(CreateIconIndirect(ref iconInfo));
        }

        private void OnTileDragEnter(object sender, DragEventArgs dragEventArgs)
        {
            dragEventArgs.Effect = DragDropEffects.Copy;
        }

        private void OnTileDragDrop(object sender, DragEventArgs dragEventArgs)
        {
            MessageBox.Show("ok");
            Cursor = Cursors.Default;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        private static readonly int[] s_displayToSet
            = new int[] { 0, 12, 10,  5, 15,  3,  6,  9,  8,  4,  7, 11,  2,  1, 13, 14};
        private static readonly int[] s_setToDisplay
            = new int[] { 0, 13, 12,  5,  9,  3,  6, 10,  8,  7,  2, 11,  1, 14, 15,  4 };

        private TileSheet m_tileSheet;
        private int m_draggedTileIndex;

        private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button != MouseButtons.Left)
                Cursor = Cursors.Default;
        }
    }
}
