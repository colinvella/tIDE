using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            m_autoTiles = new List<AutoTile>(
                AutoTileManager.Instance.GetAutoTiles(m_tileSheet));

            UpdateIdComboBox();

            m_selectedAutoTile = null;
            if (m_autoTiles.Count > 0)
            {
                m_cmbId.SelectedIndex = 0;
                m_selectedAutoTile = m_autoTiles[0];
            }
        }

        private void OnAutoTileSelected(object sender, EventArgs eventArgs)
        {
            m_selectedAutoTile = m_autoTiles[m_cmbId.SelectedIndex];
            m_panelTemplate.Invalidate();
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
            SplitterPanel panel = m_splitContainer.Panel2;
            int templateX = Math.Max(0, panel.Left + panel.Width / 2 - 128);
            int templateY = Math.Max(0, panel.Top + panel.Height / 2 - 128);

            templateX += m_splitContainer.Left;
            templateY += m_splitContainer.Top;

            Point dragPoint = new Point(dragEventArgs.X, dragEventArgs.Y);
            dragPoint = PointToClient(dragPoint);

            if (dragPoint.X >= templateX && dragPoint.Y >= templateY
                && dragPoint.X < templateX + 256 && dragPoint.Y < templateY + 256)
            {
                int displayX = (dragPoint.X - templateX) / 64;
                int displayY = (dragPoint.Y - templateY) / 64;
                int displayIndex = displayY * 4 + displayX;

                MessageBox.Show("Display index = " + displayIndex);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (Cursor != Cursors.Default
                && mouseEventArgs.Button != MouseButtons.Left)
                Cursor = Cursors.Default;
        }

        private void OnNewAutoTile(object sender, EventArgs eventArgs)
        {
            int[] indexSet = new int[16];
            for (int index = 0; index < 16; index++)
                indexSet[index] = -1;

            // determine unused name
            int nameIndex = 1;
            string newId = null;
            while (true)
            {
                newId = "Auto Tile #" + nameIndex;
                bool duplicate = false;
                foreach (AutoTile autoTile in m_autoTiles)
                    if (autoTile.Id == newId)
                    {
                        duplicate = true;
                        break;
                    }
                if (!duplicate)
                    break;
                ++nameIndex;
            }

            AutoTile newAutoTile = new AutoTile(newId, m_tileSheet, indexSet);

            m_autoTiles.Add(newAutoTile);
            m_selectedAutoTile = newAutoTile;

            SortAutoTiles();
            UpdateIdComboBox();

            m_cmbId.SelectedIndex = m_autoTiles.IndexOf(m_selectedAutoTile);
        }

        private void OnTemplatePaint(object sender, PaintEventArgs paintEventArgs)
        {
            if (m_selectedAutoTile == null)
                return;

            SplitterPanel panel = m_splitContainer.Panel2;
            int templateX = Math.Max(0, panel.Width / 2 - 128);
            int templateY = Math.Max(0, panel.Height / 2 - 128);

            Graphics graphics = paintEventArgs.Graphics;

            int displayIndex = 0;
            for (int displayY = 0; displayY < 4; displayY++)
            {
                for (int displayX = 0; displayX < 4; displayX++)
                {
                    int setIndex = s_displayToSet[displayIndex];
                    int tileIndex = m_selectedAutoTile.IndexSet[setIndex];

                    if (tileIndex >= 0)
                    {
                        Image tileImage = TileImageCache.Instance.GetTileBitmap(
                            m_tileSheet, tileIndex);
                        graphics.DrawImage(tileImage,
                            templateX + displayX * 64, templateY + displayY * 64,
                            64, 64);
                    }

                    ++displayIndex;
                }
            }

            graphics.DrawImage(Properties.Resources.AutoTileTemplate,
                templateX, templateY);
        }

        private void UpdateIdComboBox()
        {
            m_cmbId.Items.Clear();
            foreach (AutoTile autoTile in m_autoTiles)
                m_cmbId.Items.Add(autoTile.Id);
        }

        private void SortAutoTiles()
        {
            m_autoTiles.Sort(
                delegate(AutoTile autoTile1, AutoTile autoTile2)
                {
                    return autoTile1.Id.CompareTo(autoTile2.Id);
                });
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
        private AutoTile m_selectedAutoTile;
        private List<AutoTile> m_autoTiles;
    }
}
