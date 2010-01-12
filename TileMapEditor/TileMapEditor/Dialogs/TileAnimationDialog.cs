using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;
using Tiling.Tiles;

using TileMapEditor.Controls;

namespace TileMapEditor.Dialogs
{
    public partial class TileAnimationDialog : Form
    {
        private struct IconInfo
        {
            public bool Icon;
            public int HotSpotX;
            public int HotSpotY;
            public IntPtr BitMaskHandle;
            public IntPtr PixelData;
        }

        private Map m_map;
        private Layer m_layer;
        private Location m_tileLocation;
        private TileSheet m_draggedTileSheet;
        private int m_draggedTileIndex;
        private int m_animationIndex;

        [DllImport("user32.dll")]
        private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        private void AddTileFrame(TileSheet tileSheet, int tileIndex)
        {
            StaticTile newTileFrame = new StaticTile(m_layer, tileSheet, BlendMode.Alpha, tileIndex);

            if (m_imageListAnimation.Images.Count == 0)
            {
                m_imageListAnimation.ImageSize = new System.Drawing.Size(
                    newTileFrame.TileSheet.TileSize.Width, newTileFrame.TileSheet.TileSize.Height);
            }

            // determine or add new image index
            int imageListIndex = -1;
            foreach (ListViewItem listViewItem in m_animationListView.Items)
            {
                StaticTile tileFrame = (StaticTile)listViewItem.Tag;
                if (tileFrame.TileSheet == tileSheet
                    && tileFrame.TileIndex == tileIndex)
                {
                    imageListIndex = listViewItem.ImageIndex;
                    break;
                }
            }
            if (imageListIndex == -1)
            {
                Image tileImage = TileImageCache.Instance.GetTileBitmap(tileSheet, tileIndex);
                m_imageListAnimation.Images.Add(tileImage);
                imageListIndex = m_imageListAnimation.Images.Count - 1;
            }

            ListViewItem newListViewItem = new ListViewItem(
                "Frame #" + m_animationListView.Items.Count, imageListIndex);
            newListViewItem.Tag = newTileFrame;
            m_animationListView.Items.Add(newListViewItem);
        }

        private void TileAnimationDialog_Load(object sender, EventArgs eventArgs)
        {
            m_tilePicker.Map = m_map;
            m_tilePicker.UpdatePicker();
        }

        private void OnDialogMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.None
                && Cursor != Cursors.Default)
                Cursor = Cursors.Default;
        }

        private void OnTileDrag(object sender, TileDragEventArgs tileDragEventArgs)
        {
            m_draggedTileSheet = tileDragEventArgs.TileSheet;
            m_draggedTileIndex = tileDragEventArgs.TileIndex;

            Bitmap tileImage = TileImageCache.Instance.GetTileBitmap(
                m_draggedTileSheet, m_draggedTileIndex);

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
            if (m_draggedTileSheet.TileSize != m_layer.TileSize)
            {
                MessageBox.Show(this, "Incompatible tile size", "Tile Animation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddTileFrame(m_draggedTileSheet, m_draggedTileIndex);
            m_draggedTileSheet = null;
            m_draggedTileIndex = -1;

            Cursor = Cursors.Default;
        }

        private void OnDeleteFrame(object sender, EventArgs eventArgs)
        {
            if (m_animationListView.SelectedIndices.Count == 0)
                return;

            List<ListViewItem> listViewItems = new List<ListViewItem>();
            foreach (ListViewItem listViewItem in m_animationListView.SelectedItems)
                listViewItems.Add(listViewItem);

            foreach (ListViewItem listViewItem in listViewItems)
                m_animationListView.Items.Remove(listViewItem);

            int frameIndex = 0;
            foreach (ListViewItem listViewItem in m_animationListView.Items)
                listViewItem.Text = "Frame #" + (frameIndex++);
        }

        private void OnAnimationTimer(object sender, EventArgs eventArgs)
        {
            long animationLength = m_animationListView.Items.Count * (long)m_frameIntervalTextbox.Value;
            if (animationLength == 0)
                return;

            long animationTime = (long)(DateTime.Now - new DateTime(0)).TotalMilliseconds;

            animationTime = animationTime % animationLength;
            m_animationIndex = m_frameIntervalTextbox.Value == 0
                ? 0 : (int)(animationTime / m_frameIntervalTextbox.Value);
            m_previewPanel.Invalidate();
        }

        private void OnPreviewPaint(object sender, PaintEventArgs paintEventArgs)
        {
            if (m_animationListView.Items.Count == 0)
                return;

            Graphics graphics = paintEventArgs.Graphics;
            Image tileImage = m_imageListAnimation.Images[m_animationListView.Items[m_animationIndex].ImageIndex];
            graphics.DrawImage(tileImage, 0, 0);
        }

        public TileAnimationDialog(Map map, Layer layer, Location tileLocation)
        {
            InitializeComponent();

            m_map = map;
            m_layer = layer;
            m_tileLocation = tileLocation;

            Tile tile = m_layer.Tiles[m_tileLocation];
            if (tile != null)
            {
                if (tile is StaticTile)
                {
                    m_frameIntervalTextbox.Value = 250;
                    AddTileFrame(tile.TileSheet, tile.TileIndex);
                }
                else if (tile is AnimatedTile)
                {
                    AnimatedTile animatedTile = tile as AnimatedTile;
                    m_frameIntervalTextbox.Value = animatedTile.FrameInterval;
                    foreach (StaticTile tileFrame in animatedTile.TileFrames)
                        AddTileFrame(tileFrame.TileSheet, tileFrame.TileIndex);
                }
            }
            else
            {
                m_frameIntervalTextbox.Value = 250;
            }
        }
    }
}
