using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Display;
using Tiling.Layers;
using Tiling.Tiles;

using TileMapEditor.Commands;
using TileMapEditor.Dialogs;

namespace TileMapEditor.Controls
{
    public partial class MapPanel : UserControl, IDisplayDevice
    {
        #region Private Variables

        private Map m_map;

        private CommandHistory m_commandHistory;
        private Layer m_selectedLayer;
        private TileSheet m_selectedTileSheet;
        private int m_selectedTileIndex;
        private TileBrushCollection m_tileBrushCollection;
        private TileBrush m_selectedTileBrush;

        private LayerCompositing m_layerCompositing;
        private bool m_tileGuides;
        private EditTool m_editTool;
        private bool m_mouseInside;
        private Location m_mouseLocation;
        private Location m_tileLayerLocation;
        private Location m_dragTileStart;

        private TileSelection m_tileSelection;
        private bool m_ctrlKeyPressed;

        private Graphics m_graphics;
        private Tiling.Dimensions.Rectangle m_viewport;
        private bool m_autoScaleViewport; 
        private int m_zoom;
        private Brush m_veilBrush;
        private ImageAttributes m_imageAttributes;
        private ColorMatrix m_colorMatrix;
        private Pen m_tileSelectionPen;
        private Brush m_tileSelectionBrush;

        private Pen m_tileGuidePen;
        private float[] m_dashPattern;

        private Cursor m_singleTileCursor;
        private Cursor m_tileBlockCursor;
        private Cursor m_eraserCursor;
        private Cursor m_dropperCursor;

        private bool m_bMouseDown;

        private DateTime m_dtStart;

        #endregion

        #region Private Methods

        private Location ConvertViewportOffsetToLayerLocation(Location viewportOffset)
        {
            Location layerLocation
                = m_selectedLayer.ConvertMapToLayerLocation(m_viewport.Location, m_viewport.Size);

            layerLocation += viewportOffset / m_zoom;

            Tiling.Dimensions.Size tileSize = m_selectedLayer.TileSize;
            layerLocation.X /= tileSize.Width;
            layerLocation.Y /= tileSize.Height;

            return layerLocation;
        }

        private void PerformAutoScroll()
        {
            int deltaX = Math.Max(1, m_selectedLayer.TileSize.Width / 8);
            int deltaY = Math.Max(1, m_selectedLayer.TileSize.Height / 8);

            if (m_mouseLocation.X < m_selectedLayer.TileSize.Width)
            {
                int newScrollValue = Math.Max(m_horizontalScrollBar.Minimum, m_horizontalScrollBar.Value - deltaX);
                m_horizontalScrollBar.Value = newScrollValue;
                OnHorizontalScroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, newScrollValue));
            }
            else if (m_mouseLocation.X > m_viewport.Size.Width - m_selectedLayer.TileSize.Width)
            {
                int newScrollValue = Math.Min(
                    m_horizontalScrollBar.Maximum - m_horizontalScrollBar.LargeChange,
                    m_horizontalScrollBar.Value + deltaX);
                newScrollValue = Math.Max(m_horizontalScrollBar.Minimum, newScrollValue);
                m_horizontalScrollBar.Value = newScrollValue;
                OnHorizontalScroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, newScrollValue));
            }


            if (m_mouseLocation.Y < m_selectedLayer.TileSize.Height)
            {
                int newScrollValue = Math.Max(m_verticalScrollBar.Minimum, m_verticalScrollBar.Value - deltaY);
                m_verticalScrollBar.Value = newScrollValue;
                OnVerticalScroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, newScrollValue));
            }
            else if (m_mouseLocation.Y > m_viewport.Size.Height - m_selectedLayer.TileSize.Height)
            {
                int newScrollValue = Math.Min(
                    m_verticalScrollBar.Maximum - m_verticalScrollBar.LargeChange,
                    m_verticalScrollBar.Value + deltaY);
                newScrollValue = Math.Max(m_verticalScrollBar.Minimum, newScrollValue);
                m_verticalScrollBar.Value = newScrollValue;
                OnVerticalScroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, newScrollValue));
            }
        }

        private void SelectTiles()
        {
            if (m_selectedLayer == null)
                return;

            Tiling.Dimensions.Size layerSize = m_selectedLayer.LayerSize;
            int minX = Math.Max(0, Math.Min(m_tileLayerLocation.X, m_dragTileStart.X));
            int minY = Math.Max(0, Math.Min(m_tileLayerLocation.Y, m_dragTileStart.Y));
            int maxX = Math.Min(layerSize.Width - 1, Math.Max(m_tileLayerLocation.X, m_dragTileStart.X));
            int maxY = Math.Min(layerSize.Height - 1, Math.Max(m_tileLayerLocation.Y, m_dragTileStart.Y));

            Location tileLocation = new Location(minX, minY);
            TileSelection tileSelection = new TileSelection();
            for (; tileLocation.Y <= maxY; tileLocation.Y++)
                for (tileLocation.X = minX; tileLocation.X <= maxX; tileLocation.X++)
                    tileSelection.AddLocation(tileLocation);

            Command command = new ToolsSelectCommand(
                m_selectedLayer, m_tileSelection, tileSelection,
                !m_ctrlKeyPressed);
            m_commandHistory.Do(command);

            m_innerPanel.Invalidate();

            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        private void DrawSingleTile()
        {
            if (m_selectedLayer == null)
                return;
            if (m_selectedTileSheet == null)
                return;
            if (m_selectedTileIndex < 0)
                return;

            if (m_selectedLayer.TileSize != m_selectedTileSheet.TileSize)
            {
                MessageBox.Show(this, "Incompatible tile size", "Layer Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                return;

            Tile oldTile = m_selectedLayer.Tiles[m_tileLayerLocation];

            if (oldTile != null && oldTile.TileSheet == m_selectedTileSheet
                && oldTile.TileIndex == m_selectedTileIndex)
                return;

            Command command = new ToolsPlaceTileCommand(
                m_selectedLayer, m_selectedTileSheet,
                m_selectedTileIndex, m_tileLayerLocation);
            m_commandHistory.Do(command);

            m_innerPanel.Invalidate();

            if (MapChanged != null)
                MapChanged(this, EventArgs.Empty);
        }

        private void DrawTileBlock()
        {
            if (m_selectedLayer == null)
                return;
            if (m_selectedTileSheet == null)
                return;
            if (m_selectedTileIndex < 0)
                return;

            if (m_selectedLayer.TileSize != m_selectedTileSheet.TileSize)
            {
                MessageBox.Show(this, "Incompatible tile size", "Layer Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tiling.Dimensions.Size layerSize = m_selectedLayer.LayerSize;
            int minX = Math.Max(0, Math.Min(m_tileLayerLocation.X, m_dragTileStart.X));
            int minY = Math.Max(0, Math.Min(m_tileLayerLocation.Y, m_dragTileStart.Y));
            int maxX = Math.Min(layerSize.Width - 1, Math.Max(m_tileLayerLocation.X, m_dragTileStart.X));
            int maxY = Math.Min(layerSize.Height - 1, Math.Max(m_tileLayerLocation.Y, m_dragTileStart.Y));

            Command command = new ToolsTileBlockCommand(
                m_selectedLayer, m_selectedTileSheet, m_selectedTileIndex,
                new Location(minX, minY),
                new Tiling.Dimensions.Size(maxX - minX + 1, maxY - minY + 1));
            m_commandHistory.Do(command);

            m_innerPanel.Invalidate();

            if (MapChanged != null)
                MapChanged(this, EventArgs.Empty);
        }

        private void EraseTile()
        {
            if (m_selectedLayer == null)
                return;

            if (!m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                return;

            if (m_selectedLayer.Tiles[m_tileLayerLocation] == null)
                return;

            Command command = new ToolsEraseTileCommand(m_selectedLayer, m_tileLayerLocation);
            m_commandHistory.Do(command);
           
            m_innerPanel.Invalidate();

            if (MapChanged != null)
                MapChanged(this, EventArgs.Empty);
        }

        private void PickTile()
        {
            if (m_selectedLayer == null)
                return;

            if (!m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                return;

            Tile tile = m_selectedLayer.Tiles[m_tileLayerLocation];

            if (TilePicked != null)
                TilePicked(new MapPanelEventArgs(tile, m_tileLayerLocation));

            this.EditTool = tile == null ? EditTool.Eraser : EditTool.SingleTile;
        }

        private void ApplyTileBrush()
        {
            if (m_selectedLayer == null)
                return;

            if (m_selectedTileBrush == null)
                return;

            if (m_selectedTileBrush.TileSize != m_selectedLayer.TileSize)
            {
                MessageBox.Show(this, "Incompatible tile size", "Apply TileBrush", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tiling.Dimensions.Location brushLocation = m_tileLayerLocation;
            Tiling.Dimensions.Size brushSize = m_selectedTileBrush.BrushSize;
            brushLocation.X -= brushSize.Width / 2;
            brushLocation.Y -= brushSize.Height / 2;

            Command command = new EditPasteCommand(
                m_selectedLayer, m_selectedTileBrush,
                brushLocation, new TileSelection(), false);
            m_commandHistory.Do(command);

            if (MapChanged != null)
                MapChanged(this, EventArgs.Empty);
        }

        private void UpdateScrollBars()
        {
            if (m_map == null)
            {
                m_horizontalScrollBar.Maximum = 0;
                m_horizontalScrollBar.LargeChange = 1;
                m_horizontalScrollBar.Value = 0;
                m_horizontalScrollBar.Visible = false;

                m_verticalScrollBar.Maximum = 0;
                m_verticalScrollBar.LargeChange = 1;
                m_verticalScrollBar.Value = 0;
                m_verticalScrollBar.Visible = false;
            }
            else
            {
                System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
                Tiling.Dimensions.Size displaySize = m_map.DisplaySize;

                m_horizontalScrollBar.Maximum = displaySize.Width;
                m_horizontalScrollBar.LargeChange = 1 + (clientRectangle.Width - 1) / m_zoom;
                m_horizontalScrollBar.Value
                    = Math.Min(m_horizontalScrollBar.Value, displaySize.Width);
                m_horizontalScrollBar.Visible = displaySize.Width * m_zoom > clientRectangle.Width;

                m_verticalScrollBar.Maximum = displaySize.Height;
                m_verticalScrollBar.LargeChange = 1 + (clientRectangle.Height - 1) / m_zoom;
                m_verticalScrollBar.Value
                    = Math.Min(m_verticalScrollBar.Value, displaySize.Height);
                m_verticalScrollBar.Visible = displaySize.Height * m_zoom > clientRectangle.Height;
            }
        }

        private void BindLayerDrawEvents()
        {
            if (m_map == null)
                return;

            foreach (Layer layer in m_map.Layers)
            {
                layer.BeforeDraw -= OnBeforeLayerDraw;
                layer.BeforeDraw += OnBeforeLayerDraw;

                layer.AfterDraw -= OnAfterLayerDraw;
                layer.AfterDraw += OnAfterLayerDraw;
            }
        }

        private void OnHorizontalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewport.Location.X = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void OnVerticalScroll(object sender, ScrollEventArgs scrollEventArgs)
        {
            m_viewport.Location.Y = scrollEventArgs.NewValue;
            m_innerPanel.Invalidate();
        }

        private void OnResizeDisplay(object sender, EventArgs e)
        {
            if (m_autoScaleViewport)
            {
                System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
                m_viewport.Size.Width = 1 + (clientRectangle.Width - 1) / m_zoom;
                m_viewport.Size.Height = 1 + (clientRectangle.Height - 1) / m_zoom;
            }

            UpdateScrollBars();
        }

        private void OnBeforeLayerDraw(LayerEventArgs layerEventArgs)
        {
            m_graphics.PixelOffsetMode = PixelOffsetMode.Half;

            if (layerEventArgs.Layer != m_selectedLayer)
                return;

            if (m_layerCompositing == LayerCompositing.DimUnselected)
            {
                // set translucency for current layer
                m_colorMatrix.Matrix33 = 1.0f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            }

        }

        private void OnAfterLayerDraw(LayerEventArgs layerEventArgs)
        {
            if (layerEventArgs.Layer != m_selectedLayer)
                return;

            // alignment data
            Layer layer = layerEventArgs.Layer;
            Tiling.Dimensions.Rectangle viewport = layerEventArgs.Viewport;
            Tiling.Dimensions.Size tileSize = layer.TileSize;
            Tiling.Dimensions.Location layerViewportLocation
                = m_selectedLayer.ConvertMapToLayerLocation(viewport.Location, m_viewport.Size);

            // tile guide
            if (m_tileGuides)
            {
                int offsetX = layerViewportLocation.X % tileSize.Width;
                int offsetY = layerViewportLocation.Y % tileSize.Height;
                for (int guideY = -offsetY; guideY < viewport.Size.Height; guideY += tileSize.Height)
                    m_graphics.DrawLine(m_tileGuidePen, 0, guideY, m_viewport.Size.Width, guideY);

                m_graphics.PixelOffsetMode = PixelOffsetMode.None;

                for (int guideX = -offsetX; guideX < viewport.Size.Width; guideX += tileSize.Width)
                    m_graphics.DrawLine(m_tileGuidePen, guideX, 0, guideX, m_viewport.Size.Height);
            }

            // tile selections
            if (!m_tileSelection.IsEmpty())
            {
                Location tileViewportLocation = new Location(
                    layerViewportLocation.X / tileSize.Width, layerViewportLocation.Y / tileSize.Height);
                Tiling.Dimensions.Size tileViewportSize = viewport.Size;
                tileViewportSize.Width /= tileSize.Width;
                tileViewportSize.Height /= tileSize.Height;
                tileViewportSize.Width++;
                tileViewportSize.Height++;

                m_graphics.PixelOffsetMode = PixelOffsetMode.None;

                Location tileLocation = tileViewportLocation;
                for (;  tileLocation.Y <= tileViewportLocation.Y + tileViewportSize.Height; tileLocation.Y++)
                    for (tileLocation.X = tileViewportLocation.X; tileLocation.X <= tileViewportLocation.X + tileViewportSize.Width; tileLocation.X++)
                    {
                        if (m_tileSelection.Contains(tileLocation))
                        {
                            Tiling.Dimensions.Rectangle tileRectangle = m_selectedLayer.GetTileDisplayRectangle(viewport, tileLocation);
                            m_graphics.FillRectangle(m_tileSelectionBrush,
                                tileRectangle.Location.X, tileRectangle.Location.Y,
                                tileRectangle.Size.Width, tileRectangle.Size.Height);
                        }
                    }
            }

            // highlight tile under mouse cursor
            if (m_mouseInside)
            {
                Tiling.Dimensions.Rectangle tileDisplayRectangle
                    = m_selectedLayer.GetTileDisplayRectangle(m_viewport, m_tileLayerLocation);
                Tiling.Dimensions.Location tileDisplayLocation = tileDisplayRectangle.Location;

                if (m_bMouseDown && (m_editTool == EditTool.Select || m_editTool == EditTool.TileBlock) )
                {
                    Tiling.Dimensions.Rectangle tileDragRectangle
                        = m_selectedLayer.GetTileDisplayRectangle(m_viewport, m_dragTileStart);
                    Tiling.Dimensions.Location tileDragLocation = tileDragRectangle.Location;

                    int minX = Math.Min(tileDragLocation.X, tileDisplayLocation.X);
                    int minY = Math.Min(tileDragLocation.Y, tileDisplayLocation.Y);
                    int maxX = Math.Max(tileDragLocation.X, tileDisplayLocation.X);
                    int maxY = Math.Max(tileDragLocation.Y, tileDisplayLocation.Y);

                    if (m_editTool == EditTool.TileBlock
                        && m_selectedTileSheet != null && m_selectedTileIndex >= 0)
                    {
                        m_graphics.PixelOffsetMode = PixelOffsetMode.Half;

                        Bitmap tileBitmap = TileImageCache.Instance.GetTileBitmap(m_selectedTileSheet, m_selectedTileIndex);
                        for (int tileY = minY; tileY <= maxY; tileY += tileSize.Height)
                            for (int tileX = minX; tileX <= maxX; tileX += tileSize.Width)
                                m_graphics.DrawImage(tileBitmap, tileX, tileY, tileSize.Width, tileSize.Height);
                    }

                    m_graphics.PixelOffsetMode = PixelOffsetMode.None;

                    int selectionWidth = maxX + tileSize.Width - minX;
                    int selectionHeight = maxY + tileSize.Height - minY;
                    m_graphics.FillRectangle(m_tileSelectionBrush, minX, minY, selectionWidth, selectionHeight);
                    m_graphics.DrawRectangle(m_tileSelectionPen, minX, minY, selectionWidth, selectionHeight);
                }
                else if (m_editTool == EditTool.TileBrush)
                {
                    if (m_selectedTileBrush != null)
                    {
                        Tiling.Dimensions.Location location = tileDisplayRectangle.Location;
                        Tiling.Dimensions.Size brushSize = m_selectedTileBrush.BrushSize;
                        Tiling.Dimensions.Size displaySize = m_selectedTileBrush.DisplaySize;

                        location.X -= (brushSize.Width / 2) * tileSize.Width;
                        location.Y -= (brushSize.Height / 2) * tileSize.Height;

                        m_graphics.PixelOffsetMode = PixelOffsetMode.None;

                        m_colorMatrix.Matrix33 = 0.5f;
                        m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        System.Drawing.Rectangle destRect
                            = new System.Drawing.Rectangle(location.X, location.Y,
                                displaySize.Width, displaySize.Height);
                        m_graphics.DrawImage(m_selectedTileBrush.ImageRepresentation, destRect,
                            0, 0, displaySize.Width, displaySize.Height, GraphicsUnit.Pixel, m_imageAttributes);
                    }
                }
                else
                {
                    Tiling.Dimensions.Location location = tileDisplayRectangle.Location;
                    Tiling.Dimensions.Size size = tileDisplayRectangle.Size;

                    m_graphics.PixelOffsetMode = PixelOffsetMode.None;

                    m_graphics.FillRectangle(m_tileSelectionBrush,
                        location.X, location.Y, size.Width, size.Height);
                    m_graphics.DrawRectangle(m_tileSelectionPen,
                        location.X, location.Y, size.Width, size.Height);
                }
            }

            if (m_layerCompositing == LayerCompositing.DimUnselected)
            {
                // set translucency for upper layers
                m_colorMatrix.Matrix33 = 0.25f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            m_mouseLocation.X = mouseEventArgs.X;
            m_mouseLocation.Y = mouseEventArgs.Y;

            m_tileLayerLocation
                = ConvertViewportOffsetToLayerLocation(m_mouseLocation);

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                m_bMouseDown = true; 
                switch (m_editTool)
                {
                    case EditTool.Select:
                        m_dragTileStart = m_tileLayerLocation;
                        break;
                    case EditTool.SingleTile: DrawSingleTile(); break;
                    case EditTool.TileBlock: m_dragTileStart = m_tileLayerLocation; break;
                    case EditTool.Eraser: EraseTile(); break;
                    case EditTool.Dropper:
                        PickTile();
                        break;
                    case EditTool.TileBrush: ApplyTileBrush(); break;
                }
            }
            else if (mouseEventArgs.Button == MouseButtons.Middle)
            {
                PickTile();
            }
            else if (mouseEventArgs.Button == MouseButtons.Right)
            {
                if (m_selectedLayer != null)
                {
                    if (m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                    {
                        Tile tile = m_selectedLayer.Tiles[m_tileLayerLocation];
                        m_tilePropertiesMenuItem.Enabled = tile != null;
                        m_tileContextMenuStrip.Show(PointToScreen(mouseEventArgs.Location));
                    }
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            m_mouseInside = true;
            m_mouseLocation.X = mouseEventArgs.X;
            m_mouseLocation.Y = mouseEventArgs.Y;

            if (m_selectedLayer == null)
                return;

            PerformAutoScroll();

            m_tileLayerLocation
                = ConvertViewportOffsetToLayerLocation(m_mouseLocation);

            if (m_bMouseDown && mouseEventArgs.Button == MouseButtons.Left)
            {
                switch (m_editTool)
                {
                    case EditTool.SingleTile: DrawSingleTile(); break;
                    case EditTool.Eraser: EraseTile(); break;
                    case EditTool.Dropper:
                        PickTile();
                        break;
                }
            }

            if (TileHover != null)
            {
                Tile tile = m_selectedLayer.IsValidTileLocation(m_tileLayerLocation)
                    ? m_selectedLayer.Tiles[m_tileLayerLocation]
                    : null;
                TileHover(new MapPanelEventArgs
                    (tile, m_tileLayerLocation));
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                switch (m_editTool)
                {
                    case EditTool.Select: SelectTiles(); break;
                    case EditTool.TileBlock: DrawTileBlock(); break;
                }
            }

            m_bMouseDown = false;
        }

        private void OnMouseEnter(object sender, EventArgs eventArgs)
        {
            m_mouseInside = true;
        }

        private void OnMouseLeave(object sender, EventArgs eventArgs)
        {
            m_mouseInside = false;
        }

        private void OnTileProperties(object sender, EventArgs eventArgs)
        {
            if (m_selectedLayer == null)
                return;

            if (!m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                return;

            Tile tile = m_selectedLayer.Tiles[m_tileLayerLocation];
            if (tile == null)
                return;

            TilePropertiesDialog tilePropertiesDialog
                = new TilePropertiesDialog(tile);

            if (tilePropertiesDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (TilePropertiesChanged != null)
                TilePropertiesChanged(new MapPanelEventArgs(tile, m_tileLayerLocation));
        }

        private void OnTileAnimation(object sender, EventArgs eventArgs)
        {
            if (m_selectedLayer == null)
                return;

            if (!m_selectedLayer.IsValidTileLocation(m_tileLayerLocation))
                return;

            TileAnimationDialog tileAnimationDialog = new TileAnimationDialog(
                m_map, m_selectedLayer, m_tileLayerLocation);

            if (tileAnimationDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            if (MapChanged != null)
                MapChanged(this, EventArgs.Empty);
        }

        private void OnAnimationTimer(object sender, EventArgs eventArgs)
        {
            if (m_map == null)
                return;

            DateTime dtNow = DateTime.Now;
            m_map.ElapsedTime = (long)(dtNow - m_dtStart).TotalMilliseconds;
            m_innerPanel.Invalidate();
        }

        private void OnMapPaint(object sender, PaintEventArgs paintEventArgs)
        {
            m_graphics = paintEventArgs.Graphics;

            if (m_map != null)
            {
                // handle zero layer case
                if (m_map.Layers.Count == 0)
                {
                    m_graphics.Transform = new Matrix();
                    m_graphics.FillRectangle(new SolidBrush(Color.FromArgb(224, SystemColors.Control)), ClientRectangle);

                    SizeF stringSize = m_graphics.MeasureString("Add layers to this map", this.Font);
                    m_graphics.DrawString("Add layers to this map", this.Font, SystemBrushes.ControlDark,
                        (ClientRectangle.Width - (int)stringSize.Width) / 2,
                        (ClientRectangle.Height - (int)stringSize.Height) / 2);
                    return;
                }

                UpdateScrollBars();
                BindLayerDrawEvents();

                // set translucency
                m_colorMatrix.Matrix33 = m_layerCompositing == LayerCompositing.DimUnselected ? 0.25f : 1.0f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // draw map
                m_map.Draw(this, m_viewport);

                // reset transulency
                m_colorMatrix.Matrix33 = 1.0f;
                m_imageAttributes.SetColorMatrix(m_colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // reset clipping region
                m_graphics.SetClip(this.ClientRectangle);

                // map border
                Location borderCorner = -m_viewport.Location;
                borderCorner.X += m_map.DisplaySize.Width;
                borderCorner.Y += m_map.DisplaySize.Height;

                float inverseZoom = 1.0f / m_zoom;
                Pen borderPen = new Pen(Color.Black);
                borderPen.Width = inverseZoom;

                Pen shadowPen = new Pen(SystemColors.ControlDarkDark);
                shadowPen.Width = 2.0f * inverseZoom;

                if (borderCorner.X >= 0 && borderCorner.X < this.ClientRectangle.Width)
                {
                    m_graphics.FillRectangle(SystemBrushes.ControlDark, borderCorner.X, 0, this.Width - borderCorner.X, this.Height);
                    m_graphics.DrawLine(borderPen, borderCorner.X, 0, borderCorner.X, borderCorner.Y);
                    m_graphics.DrawLine(shadowPen, borderCorner.X + inverseZoom, 0, borderCorner.X + inverseZoom, borderCorner.Y + inverseZoom);
                }

                if (borderCorner.Y >= 0 && borderCorner.Y < this.ClientRectangle.Height)
                {
                    m_graphics.FillRectangle(SystemBrushes.ControlDark, 0, borderCorner.Y, this.Width, this.Height - borderCorner.Y);
                    m_graphics.DrawLine(borderPen, 0, borderCorner.Y, borderCorner.X, borderCorner.Y);
                    m_graphics.DrawLine(shadowPen, 0, borderCorner.Y + inverseZoom, borderCorner.X + inverseZoom, borderCorner.Y + inverseZoom);
                }
            }

            // viewport border
            Pen viewportPen = new Pen(SystemColors.ControlDarkDark, 1.0f / m_zoom);
            viewportPen.DashStyle = DashStyle.Dot;
            m_graphics.PixelOffsetMode = PixelOffsetMode.Half;
            m_graphics.DrawRectangle(Pens.Black, 0, 0, m_viewport.Size.Width, m_viewport.Size.Height);

            Brush viewportBrush = new SolidBrush(Color.FromArgb(128, SystemColors.ControlDarkDark));
            m_graphics.FillRectangle(SystemBrushes.ControlDarkDark, 0, m_viewport.Size.Height, ClientSize.Width, ClientSize.Height - m_viewport.Size.Height);
            m_graphics.FillRectangle(SystemBrushes.ControlDarkDark, m_viewport.Size.Width, 0, ClientSize.Width - m_viewport.Size.Width, m_viewport.Size.Height);

            // dim out control if disabled
            if (!Enabled)
            {
                m_graphics.Transform = new Matrix();
                m_graphics.FillRectangle(new SolidBrush(Color.FromArgb(64, SystemColors.ControlDarkDark)), ClientRectangle);
            }
        }

        #endregion

        #region Public Methods

        public MapPanel()
        {
            InitializeComponent();

            m_commandHistory = CommandHistory.Instance;

            m_singleTileCursor = new Cursor(new MemoryStream(Properties.Resources.ToolsSingleTileCursor));
            m_tileBlockCursor = new Cursor(new MemoryStream(Properties.Resources.ToolsTileBlockCursor));
            m_eraserCursor = new Cursor(new MemoryStream(Properties.Resources.ToolsEraserCursor));
            m_dropperCursor = new Cursor(new MemoryStream(Properties.Resources.ToolsDropperCursor));

            m_viewport = new Tiling.Dimensions.Rectangle(
                Tiling.Dimensions.Location.Origin, Tiling.Dimensions.Size.Zero);
            m_autoScaleViewport = true;

            m_zoom = 1;

            m_layerCompositing = LayerCompositing.DimUnselected;

            m_editTool = EditTool.SingleTile;
            m_innerPanel.Cursor = m_singleTileCursor;
            m_mouseInside = false;
            m_mouseLocation = new Location();
            m_tileLayerLocation = Tiling.Dimensions.Location.Origin;
            m_dragTileStart = Tiling.Dimensions.Location.Origin;

            m_tileSelection = new TileSelection();
            m_ctrlKeyPressed = false;

            m_tileGuides = false;

            m_veilBrush = new SolidBrush(Color.FromArgb(192, SystemColors.InactiveCaption));
            m_imageAttributes = new ImageAttributes();
            m_colorMatrix = new ColorMatrix();
            m_tileSelectionPen = new Pen(SystemColors.ActiveCaption);
            m_tileSelectionBrush = new SolidBrush(
                Color.FromArgb(128, SystemColors.ActiveCaption));

            m_dashPattern = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            m_tileGuidePen = new Pen(Color.Black);
            m_tileGuidePen.DashPattern = m_dashPattern;

            m_animationTimer.Enabled = !this.DesignMode;

            m_dtStart = DateTime.Now;
        }

        public Image GenerateImage(Layer layer)
        {
            Bitmap bitmap = new Bitmap(m_map.DisplaySize.Width, m_map.DisplaySize.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            Graphics oldGraphics = m_graphics;
            m_graphics = graphics;

            Tiling.Dimensions.Rectangle viewport = new Tiling.Dimensions.Rectangle(layer.DisplaySize);
            layer.Draw(this, Tiling.Dimensions.Location.Origin, viewport);

            m_graphics = oldGraphics;

            return bitmap;
        }

        public void LoadTileSheet(TileSheet tileSheet)
        {
            TileImageCache.Instance.Refresh(tileSheet);
        }

        public void DisposeTileSheet(TileSheet tileSheet)
        {
        }

        public void BeginScene()
        {
            m_graphics.ScaleTransform(m_zoom, m_zoom);
            m_graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            m_graphics.PixelOffsetMode = PixelOffsetMode.Half;
        }

        public void SetClippingRegion(Tiling.Dimensions.Rectangle clippingRegion)
        {
            if (m_graphics == null)
                return;

            m_graphics.SetClip(new RectangleF(
                    clippingRegion.Location.X, clippingRegion.Location.Y,
                    clippingRegion.Size.Width, clippingRegion.Size.Height));
        }

        public void DrawTile(Tile tile, Location location)
        {
            if (m_graphics == null)
                return;

            Bitmap tileBitmap = TileImageCache.Instance.GetTileBitmap(
                tile.TileSheet, tile.TileIndex);

            Tiling.Dimensions.Size tileSize = tile.TileSheet.TileSize;

            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(
                location.X, location.Y, tileSize.Width, tileSize.Height);

            m_graphics.DrawImage(tileBitmap, destRect,
                0, 0, tileSize.Width, tileSize.Height,
                GraphicsUnit.Pixel, m_imageAttributes);
        }

        public void EndScene()
        {
        }

        #endregion

        #region Internal Properties

        internal Panel InnerPanel { get { return m_innerPanel; } }

        #endregion

        #region Public Properties

        [Description("The Map structure associated with this control"),
         Category("Data"), Browsable(true)
        ]
        public Map Map
        {
            get { return m_map; }
            set
            {
                m_map = value;

                if (m_map != null && !m_map.Layers.Contains(m_selectedLayer))
                    SelectedLayer = null;
            }
        }

        [Description("The currently selected Layer"),
         Category("Data"), Browsable(true)
        ]
        public Layer SelectedLayer
        {
            get { return m_selectedLayer; }
            set
            {
                if (m_map == null)
                {
                    m_selectedLayer = null;
                    Invalidate(true);
                    return;
                }

                if (value == null)
                {
                    m_selectedLayer = null;
                    Invalidate(true);
                    return;
                }

                if (!m_map.Layers.Contains(value))
                    throw new Exception("The specified Layer is not contained in the Map");

                if (m_selectedLayer != value)
                {
                    m_selectedLayer = value;
                    m_tileSelection.Clear();
                    Invalidate(true);
                }
            }
        }

        [Description("The zoom level of the map display"),
         Category("Appearance"), Browsable(true), DefaultValue(1)
        ]
        public int Zoom
        {
            get { return m_zoom; }
            set
            {
                m_zoom = Math.Max(1, Math.Min(value, 10));

                System.Drawing.Rectangle clientRectangle = m_innerPanel.ClientRectangle;
                m_viewport.Size.Width = 1 + (clientRectangle.Width - 1) / m_zoom;
                m_viewport.Size.Height = 1 + (clientRectangle.Height - 1) / m_zoom;

                m_tileGuidePen.Width = m_tileSelectionPen.Width = 1.0f / m_zoom;
                m_dashPattern[0] = m_dashPattern[1] = m_dashPattern[2] = m_dashPattern[3] = 1.0f / m_zoom;
                m_tileGuidePen.DashPattern = m_dashPattern;

                Invalidate(true);
            }
        }

        [Description("The layer compositing mode for the map display"),
         Category("Appearance"), DefaultValue(LayerCompositing.DimUnselected)]
        public LayerCompositing LayerCompositing
        {
            get { return m_layerCompositing; }
            set
            {
                if (m_layerCompositing != value)
                {
                    m_layerCompositing = value;
                    m_innerPanel.Invalidate();
                }
            }
        }

        [Description("Show or hide the tile guides to assist editing"),
         Category("Appearance"), DefaultValue(false)]
        public bool TileGuides
        {
            get { return m_tileGuides; }
            set
            {
                if (m_tileGuides != value)
                {
                    m_tileGuides = value;
                    m_innerPanel.Invalidate();
                }
            }
        }

        [Description("The current editing tool"),
         Category("Behavior"), DefaultValue(EditTool.TileBlock)]
        public EditTool EditTool
        {
            get { return m_editTool; }
            set
            {
                m_editTool = value;
                switch (m_editTool)
                {
                    case EditTool.SingleTile: m_innerPanel.Cursor = m_singleTileCursor; break;
                    case EditTool.TileBlock: m_innerPanel.Cursor = m_tileBlockCursor; break;
                    case EditTool.Eraser: m_innerPanel.Cursor = m_eraserCursor; break;
                    case EditTool.Dropper: m_innerPanel.Cursor = m_dropperCursor; break;
                }
            }
        }

        public Tiling.Dimensions.Rectangle Viewport
        {
            get { return m_viewport; }
            set { m_viewport = value; }
        }

        public bool AutoScaleViewport
        {
            get { return m_autoScaleViewport; }
            set { m_autoScaleViewport = value; }
        }

        public TileSheet SelectedTileSheet
        {
            get { return m_selectedTileSheet; }
            set { m_selectedTileSheet = value; }
        }

        public int SelectedTileIndex
        {
            get { return m_selectedTileIndex; }
            set { m_selectedTileIndex = value; }
        }

        public TileSelection TileSelection
        {
            get { return m_tileSelection; }
        }

        internal TileBrushCollection TileBrushCollection
        {
            set
            {
                if (m_tileBrushCollection != value)
                {
                    m_tileBrushCollection = value;
                    m_selectedTileBrush = null;
                }
            }
        }

        internal TileBrush SelectedTileBrush
        {
            get { return m_selectedTileBrush; }
            set { m_selectedTileBrush = value; }
        }

        public bool CtrlKeyPressed
        {
            set { m_ctrlKeyPressed = value; }
        }

        #endregion

        #region Public Events

        [Category("Behavior"), Description("Occurs when the tile is picked from the map")]
        public event MapPanelEventHandler TilePicked;

        [Category("Behavior"), Description("Occurs when the map is changed")]
        public event EventHandler MapChanged;

        [Category("Behavior"), Description("Occurs when the mouse hovers over a tile")]
        public event MapPanelEventHandler TileHover;

        [Category("Behavior"), Description("Occurs when the tile selection is changed")]
        public event EventHandler SelectionChanged;

        [Category("Behavior"), Description("Occurs when the properties of a tile are changed")]
        public event MapPanelEventHandler TilePropertiesChanged;

        #endregion
    }

    public enum LayerCompositing
    {
        DimUnselected,
        ShowAll
    }

    public enum EditTool
    {
        None,
        Select,
        SingleTile,
        TileBlock,
        Eraser,
        Dropper,
        TileBrush
    }

    public delegate void MapPanelEventHandler(MapPanelEventArgs mapPanelEventArgs);
}
