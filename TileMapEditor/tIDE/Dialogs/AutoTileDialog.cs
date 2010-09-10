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

using xTile.Tiles;

using TileMapEditor.AutoTiles;
using TileMapEditor.Commands;
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

                m_btnRename.Enabled = true;
                m_tilePicker.Enabled = true;
                m_btnDelete.Enabled = true;
            }
        }

        private void OnAutoTileSelected(object sender, EventArgs eventArgs)
        {
            if (m_cmbId.SelectedIndex == -1)
            {
                m_selectedAutoTile = null;
                m_txtNewId.Clear();
            }
            else
            {
                m_selectedAutoTile = m_autoTiles[m_cmbId.SelectedIndex];
                m_txtNewId.Text = m_selectedAutoTile.Id;
            }

            m_panelTemplate.Invalidate();
        }

        private void OnRenameAutoTile(object sender, EventArgs eventArgs)
        {
            m_txtNewId.Text = m_selectedAutoTile.Id;

            m_cmbId.Visible = false;
            m_txtNewId.Visible = true;
            m_tilePicker.Enabled = m_btnRename.Enabled = m_btnNew.Enabled = m_btnDelete.Enabled
                = m_btnOk.Enabled = m_btnApply.Enabled = m_btnClose.Enabled = false;
        }

        private void OnLeaveNewId(object sender, EventArgs eventArgs)
        {
            // name must be specified, leading, trailing spaces ignored
            m_txtNewId.Text = m_txtNewId.Text.Trim();
            if (m_txtNewId.Text.Length == 0)
            {
                MessageBox.Show(this, "No ID specified", "Rename Auto Tile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtNewId.Focus();
                return;
            }

            // check new name not duplicate
            foreach (AutoTile autoTile in m_autoTiles)
            {
                if (autoTile == m_selectedAutoTile)
                    continue;
                if (autoTile.Id == m_txtNewId.Text)
                {
                    MessageBox.Show(this, "The ID '" + m_txtNewId.Text + "' is already in use",
                        "Rename Auto Tile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_txtNewId.Focus();
                    return;
                }
            }

            m_selectedAutoTile.Id = m_txtNewId.Text;
            SortAutoTiles();
            UpdateIdComboBox();
            m_cmbId.SelectedItem = m_selectedAutoTile.Id;

            m_txtNewId.Visible = false;
            m_cmbId.Visible = true;
            m_tilePicker.Enabled = m_btnRename.Enabled = m_btnNew.Enabled = m_btnDelete.Enabled
                = m_btnOk.Enabled = m_btnApply.Enabled = m_btnClose.Enabled = true;

            UpdateDialogState(true);
        }

        private void OnNewIdPreviewKeyDown(object sender, PreviewKeyDownEventArgs previewKeyDownEventArgs)
        {
            if (previewKeyDownEventArgs.KeyCode == Keys.Return)
                OnLeaveNewId(sender, EventArgs.Empty);
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

                int setIndex = s_displayToSet[displayIndex];

                m_selectedAutoTile.IndexSet[setIndex] = m_draggedTileIndex;
                m_panelTemplate.Invalidate();

                UpdateDialogState(true);
            }

            Cursor = Cursors.Default;
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

            UpdateDialogState(true);
            m_btnRename.Enabled = true;
            m_tilePicker.Enabled = true;
            m_btnDelete.Enabled = true;
        }

        private void OnDeleteAutoTile(object sender, EventArgs eventArgs)
        {
            if (MessageBox.Show(this, "Are you sure?",
                "Delete auto tile definition '" + m_selectedAutoTile.Id + "'",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            int currentIndex = m_autoTiles.IndexOf(m_selectedAutoTile);
            m_autoTiles.Remove(m_selectedAutoTile);

            UpdateIdComboBox();

            if (m_autoTiles.Count == 0)
            {
                m_selectedAutoTile = null;
                m_cmbId.SelectedIndex = -1;

                m_btnRename.Enabled = false;
                m_tilePicker.Enabled = false;
                m_btnDelete.Enabled = false;
            }
            else
            {
                if (currentIndex >= m_autoTiles.Count)
                    currentIndex = m_autoTiles.Count - 1;

                m_selectedAutoTile = m_autoTiles[currentIndex];
                m_cmbId.SelectedIndex = currentIndex;
            }

            m_panelTemplate.Invalidate();
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            Command command = new TileSheetAutoTilesCommand(m_tileSheet, m_autoTiles);
            CommandHistory.Instance.Do(command);
            UpdateDialogState(false);
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
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

        private void UpdateDialogState(bool changes)
        {
            m_btnOk.Enabled = m_btnApply.Enabled = changes;
            m_btnClose.Text = changes ? "&Cancel" : "&Close";
            m_btnClose.DialogResult = changes ? DialogResult.Cancel : DialogResult.Cancel;
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
