using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using xTile;
using xTile.Dimensions;
using xTile.Layers;
using xTile.Tiles;

using tIDE.Commands;
using tIDE.Controls;

namespace tIDE.Dialogs
{
    public partial class TileAnimationDialog : Form
    {
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

        private void MarkAsModified()
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = true;
            m_buttonCancel.Visible = true;
            m_buttonClose.Visible = false;
        }

        private void MarkAsApplied()
        {
            m_buttonOk.Enabled = m_buttonApply.Enabled = false;
            m_buttonCancel.Visible = false;
            m_buttonClose.Visible = true;
        }

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

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
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

            m_tilePicker.Map = m_map;
            m_tilePicker.UpdatePicker();

            MarkAsApplied();
        }

        private void OnFrameIntervalChanged(object sender, EventArgs eventArgs)
        {
            MarkAsModified();
        }

        private void OnDialogMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.None
                && Cursor != Cursors.Default)
                Cursor = Cursors.Default;
        }

        private void OnTileDragEnter(object sender, DragEventArgs dragEventArgs)
        {
            dragEventArgs.Effect = DragDropEffects.Copy;

            m_draggedTileSheet = m_tilePicker.SelectedTileSheet;
            m_draggedTileIndex = m_tilePicker.SelectedTileIndex;

            Bitmap tileImage = TileImageCache.Instance.GetTileBitmap(
                m_draggedTileSheet, m_draggedTileIndex);

            IconInfo iconInfo = new IconInfo();
            GetIconInfo(tileImage.GetHicon(), ref iconInfo);
            iconInfo.HotSpotX = tileImage.Width / 2;
            iconInfo.HotSpotY = tileImage.Height / 2;
            iconInfo.Icon = false;

            Cursor = new Cursor(CreateIconIndirect(ref iconInfo));
        }

        private void OnTileDragDrop(object sender, DragEventArgs dragEventArgs)
        {
            if (m_draggedTileSheet.TileSize != m_layer.TileSize)
            {
                m_tileSizeMessageBox.Show();
                return;
            }

            AddTileFrame(m_draggedTileSheet, m_draggedTileIndex);
            m_draggedTileSheet = null;
            m_draggedTileIndex = -1;

            Cursor = Cursors.Default;
            MarkAsModified();
        }

        private void OnFrameProperties(object sender, EventArgs eventArgs)
        {
            if (m_animationListView.SelectedIndices.Count == 0)
                return;

            StaticTile tileFrame = (StaticTile)m_animationListView.SelectedItems[0].Tag;
            TilePropertiesDialog tilePropertiesDialog = new TilePropertiesDialog(tileFrame);

            if (tilePropertiesDialog.ShowDialog(this) == DialogResult.OK)
                MarkAsModified();
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

            MarkAsModified();
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            List<StaticTile> tileFrames = new List<StaticTile>();
            foreach (ListViewItem listViewItem in m_animationListView.Items)
                tileFrames.Add((StaticTile)listViewItem.Tag);
            AnimatedTile animatedTile = new AnimatedTile(
                m_layer, tileFrames.ToArray(), (long)m_frameIntervalTextbox.Value);

            Command command = new TileAnimationCommand(m_layer, m_tileLocation, animatedTile);
            CommandHistory.Instance.Do(command);

            MarkAsApplied();
        }

        private void OnAnimationTimer(object sender, EventArgs eventArgs)
        {
            long animationLength = m_animationListView.Items.Count * (long)m_frameIntervalTextbox.Value;
            if (animationLength == 0)
                return;

            DateTime dtNow = DateTime.Now;
            long animationTime = dtNow.Second * 1000L + dtNow.Millisecond;

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
        }
    }
}
