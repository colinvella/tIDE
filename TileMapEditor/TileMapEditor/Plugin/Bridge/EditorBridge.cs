using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;

using TileMapEditor.Control;
using TileMapEditor.Plugin.Interface;

namespace TileMapEditor.Plugin.Bridge
{
    class EditorBridge : ElementBridge, IEditor
    {
        private MapPanel m_mapPanel;

        private EditorHandler m_mouseDown;
        private EditorHandler m_mouseMove;
        private EditorHandler m_mouseUp;

        private void OnMapPanelMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseDown == null)
                return;

            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Location layerDisplayLocation = layer.ConvertMapToLayerLocation(
                new Location(mouseEventArgs.X, mouseEventArgs.Y), Size.Zero);
            Location tileLocation = layer.GetTileLocation(layerDisplayLocation);

            m_mouseDown(mouseEventArgs, tileLocation);
        }

        private void OnMapPanelMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseMove == null)
                return;

            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Location layerDisplayLocation = layer.ConvertMapToLayerLocation(
                new Location(mouseEventArgs.X, mouseEventArgs.Y), Size.Zero);
            Location tileLocation = layer.GetTileLocation(layerDisplayLocation);

            m_mouseMove(mouseEventArgs, tileLocation);
        }

        private void OnMapPanelMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (m_mouseUp == null)
                return;

            Layer layer = m_mapPanel.SelectedLayer;
            if (layer == null)
                return;

            Location layerDisplayLocation = layer.ConvertMapToLayerLocation(
                new Location(mouseEventArgs.X, mouseEventArgs.Y), Size.Zero);
            Location tileLocation = layer.GetTileLocation(layerDisplayLocation);

            m_mouseUp(mouseEventArgs, tileLocation);
        }

        public EditorBridge(MapPanel mapPanel)
            : base(false)
        {
            m_mapPanel = mapPanel;
            Panel innerPanel = m_mapPanel.InnerPanel;
            innerPanel.MouseDown += OnMapPanelMouseDown;
            innerPanel.MouseMove += OnMapPanelMouseMove;
            innerPanel.MouseUp += OnMapPanelMouseUp;
        }

        public Map Map { get { return m_mapPanel.Map; } }

        public Layer Layer { get { return m_mapPanel.SelectedLayer; } }

        public EditorHandler MouseDown
        {
            set { m_mouseDown = value; }
        }

        public EditorHandler MouseMove
        {
            set { m_mouseMove = value; }
        }

        public EditorHandler MouseUp
        {
            set { m_mouseUp = value; }
        }
    }
}
