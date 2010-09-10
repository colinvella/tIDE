using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using xTile;

using TileMapEditor.Commands;
using TileMapEditor.TileBrushes;

namespace TileMapEditor.Dialogs
{
    internal partial class TileBrushDialog : Form
    {
        private Map m_map;
        private TileBrushCollection m_tileBrushCollection;
        private TileBrush m_newTileBrush;

        private void OnDialogLoad(object sender, EventArgs eventArgs)
        {
            if (m_newTileBrush == null
                && m_tileBrushCollection.TileBrushes.Count == 0)
                return;

            List<TileBrush> tileBrushes = new List<TileBrush>();
            foreach (TileBrush tileBrush in m_tileBrushCollection.TileBrushes)
                tileBrushes.Add(new TileBrush(tileBrush));

            if (m_newTileBrush != null)
                tileBrushes.Add(m_newTileBrush);

            int previewSize = 0;
            ImageList imageList = new ImageList();
            foreach (TileBrush tileBrush in tileBrushes)
            {
                Image image = tileBrush.ImageRepresentation;

                int size = Math.Max(image.Width, image.Height);
                if (image.Width != image.Height)
                {
                    Bitmap bitmap = new Bitmap(size, size);
                    int destX = (size - image.Width) / 2;
                    int destY = (size - image.Height) / 2;
                    Graphics.FromImage(bitmap).DrawImage(image, destX, destY);
                    image = bitmap;
                }

                if (size > 256)
                {
                    image = new Bitmap(image, 256, 256);
                    size = 256;
                }

                previewSize = Math.Max(previewSize, size);

                imageList.Images.Add(image);
            }
            imageList.ImageSize = new Size(previewSize, previewSize);

            m_listView.LargeImageList = imageList;

            int imageIndex = 0;
            foreach (TileBrush tileBrush in tileBrushes)
            {
                ListViewItem listViewItem = new ListViewItem(tileBrush.Id, imageIndex++);
                listViewItem.Tag = tileBrush;
                m_listView.Items.Add(listViewItem);
            }

            if (m_newTileBrush != null)
            {
                m_applyButton.Enabled = m_okButton.Enabled = true;

                foreach (ListViewItem listViewItem in m_listView.Items)
                {
                    if (listViewItem.Tag == m_newTileBrush)
                    {
                        listViewItem.EnsureVisible();
                        listViewItem.Selected = true;
                        listViewItem.BeginEdit();
                        break;
                    }
                }
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            bool selected = m_listView.SelectedIndices.Count > 0;
            m_renameButton.Enabled = m_deleteButton.Enabled = selected;
        }

        private void OnAfterLabelEdit(object sender, LabelEditEventArgs labelEditEventArgs)
        {
            string newLabel = labelEditEventArgs.Label;
            for (int index = 0; index < m_tileBrushCollection.TileBrushes.Count; index++)
            {
                if (index == labelEditEventArgs.Item)
                    continue;
                if (newLabel == m_listView.Items[index].Text)
                {
                    labelEditEventArgs.CancelEdit = true;
                    MessageBox.Show(this, 
                        "The tile brush ID '" + newLabel + "' is already in use.",
                        "Tile Brush Dialog",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            TileBrush tileBrush = (TileBrush)m_listView.Items[labelEditEventArgs.Item].Tag;
            tileBrush.Id = labelEditEventArgs.Label;

            m_okButton.Enabled = m_applyButton.Enabled = true;
        }

        private void OnTileBrushRename(object sender, EventArgs eventArgs)
        {
            if (m_listView.SelectedIndices.Count == 0)
                return;

            int index = m_listView.SelectedIndices[0];

            m_listView.Items[index].BeginEdit();
        }

        private void OnTileBrushDelete(object sender, EventArgs eventArgs)
        {
            if (m_listView.SelectedIndices.Count == 0)
                return;

            int index = m_listView.SelectedIndices[0];

            string tileBrushId = m_listView.Items[index].Text;
            if (MessageBox.Show(this,
                "Are you sure you want to delete this tile brush?",
                "Delete tile brush '" + tileBrushId + "'?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
                return;

            m_listView.Items.RemoveAt(index);

            m_okButton.Enabled = m_applyButton.Enabled = true;
        }

        private void OnDialogOk(object sender, EventArgs eventArgs)
        {
            OnDialogApply(sender, eventArgs);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void OnDialogApply(object sender, EventArgs eventArgs)
        {
            Command command = null;
            if (m_newTileBrush != null)
            {
                command = new EditTileBrushesCommand(m_map, m_tileBrushCollection, m_newTileBrush);
            }
            else
            {
                TileBrushCollection newTileBrushCollection = new TileBrushCollection();

                foreach (ListViewItem listViewItem in m_listView.Items)
                {
                    // extract corresponding brushes and apply new ids
                    TileBrush newTileBrush = (TileBrush)listViewItem.Tag;

                    // add to collection
                    newTileBrushCollection.TileBrushes.Add(newTileBrush);
                }

                command = new EditTileBrushesCommand(m_map, m_tileBrushCollection, newTileBrushCollection);
            }

            CommandHistory.Instance.Do(command);

            m_okButton.Enabled = m_applyButton.Enabled = false;
        }

        private void OnDialogCancel(object sender, EventArgs eventArgs)
        {
            if (m_newTileBrush != null)
                m_tileBrushCollection.TileBrushes.Remove(m_newTileBrush);
        }

        public TileBrushDialog(Map map, TileBrushCollection tileBrushCollection)
        {
            InitializeComponent();

            m_map = map;
            m_tileBrushCollection = tileBrushCollection;
            m_newTileBrush = null;
        }

        public TileBrushDialog(Map map,
            TileBrushCollection tileBrushCollection, TileBrush newTileBrush)
        {
            InitializeComponent();

            m_map = map;
            m_tileBrushCollection = tileBrushCollection;
            m_newTileBrush = newTileBrush;
        }
    }
}
