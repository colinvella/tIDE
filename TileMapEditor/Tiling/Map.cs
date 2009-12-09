using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class Map: DescribedComponent
    {
        #region Private Variables

        private List<TileSheet> m_tileSheets;
        private List<Layer> m_layers;
        private long m_elapsedTime;
        private Size m_displaySize;

        #endregion

        #region Private Methods

        private void UpdateDisplaySize()
        {
            m_displaySize = Size.Zero;
            foreach (Layer layer in m_layers)
            {
                Size displaySize = layer.DisplaySize;
                m_displaySize.Width = Math.Max(m_displaySize.Width, displaySize.Width);
                m_displaySize.Height = Math.Max(m_displaySize.Height, displaySize.Height);
            }
        }

        #endregion

        #region Public Methods

        public Map()
            : base("Untiled map")
        {
            m_tileSheets = new List<TileSheet>();
            m_layers = new List<Layer>();
            m_elapsedTime = 0;
        }

        public Map(string id)
            :base(id)
        {
            m_tileSheets = new List<TileSheet>();
            m_layers = new List<Layer>();
            m_elapsedTime = 0;
            m_displaySize = Size.Zero;
        }

        public void AddLayer(Layer layer)
        {
            InsertLayer(layer, m_layers.Count);
        }

        public void InsertLayer(Layer layer, int layerIndex)
        {
            if (layer.Map != this)
                throw new Exception("The specified Layer was not created for use with this map");

            if (m_layers.Contains(layer))
                throw new Exception("The specified Layer is already associated with this map");

            if (layerIndex < 0 || layerIndex > m_layers.Count)
                throw new Exception("The specified layer index is out of range");

            m_layers.Insert(layerIndex, layer);

            UpdateDisplaySize();
        }

        public void RemoveLayer(Layer layer)
        {
            if (!m_layers.Contains(layer))
                throw new Exception("The specified Layer is not contained in this map");

            m_layers.Remove(layer);

            UpdateDisplaySize();
        }

        public void BringLayerForward(Layer layer)
        {
            int layerIndex = m_layers.IndexOf(layer);
            if (layerIndex < 0)
                throw new Exception("The specified Layer is not contained in this map");

            if (layerIndex == m_layers.Count - 1)
                return;

            m_layers[layerIndex] = m_layers[layerIndex + 1];
            m_layers[layerIndex + 1] = layer;            
        }

        public void SendLayerBackward(Layer layer)
        {
            int layerIndex = m_layers.IndexOf(layer);
            if (layerIndex < 0)
                throw new Exception("The specified Layer is not contained in this map");

            if (layerIndex == 0)
                return;

            m_layers[layerIndex] = m_layers[layerIndex - 1];
            m_layers[layerIndex - 1] = layer;
        }

        public bool DependsOnTileSheet(TileSheet tileSheet)
        {
            if (tileSheet.Map != this)
                return false;

            foreach (Layer layer in m_layers)
                if (layer.DependsOnTileSheet(tileSheet))
                    return true;

            return false;
        }

        public void AddTileSheet(TileSheet tileSheet)
        {
            if (tileSheet.Map != this)
                throw new Exception("The specified TileSheet was not created for use with this map");

            if (m_tileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is already associated with this map");

            m_tileSheets.Add(tileSheet);

            m_tileSheets.Sort(
                delegate(TileSheet tileSheet1, TileSheet tileSheet2)
                {
                    return tileSheet1.Id.CompareTo(tileSheet2.Id);
                });
        }

        public void RemoveTileSheet(TileSheet tileSheet)
        {
            if (!m_tileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is not contained in this map");

            foreach (Layer layer in m_layers)
                if (layer.DependsOnTileSheet(tileSheet))
                    throw new Exception("Cannot remove TileSheet as it is in use by Layer " + layer.Id);

            m_tileSheets.Remove(tileSheet);
        }

        public TileSheet GetTileSheet(string tileSheetId)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                if (tileSheet.Id == tileSheetId)
                    return tileSheet;
            return null;
        }

        public void Update(long timeInterval)
        {
            m_elapsedTime += timeInterval;
        }

        public void LoadTileSheets(IDisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.LoadTileSheet(tileSheet);
        }

        public void DisposeTileSheets(IDisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.DisposeTileSheet(tileSheet);
        }

        public void Draw(IDisplayDevice displayDevice, Rectangle mapViewPort)
        {
            Draw(displayDevice, Location.Origin, mapViewPort);
        }

        public void Draw(IDisplayDevice displayDevice, Location displayOffset, Rectangle mapViewPort)
        {
            displayDevice.BeginScene();

            Rectangle clippingRegion = new Rectangle(displayOffset, mapViewPort.Size);
            displayDevice.SetClippingRegion(clippingRegion);

            foreach (Layer layer in m_layers)
            {
                Rectangle layerViewPort = layer.ConvertMapToLayerViewPort(mapViewPort);
                layer.Draw(displayDevice, displayOffset, layerViewPort);
            }

            displayDevice.EndScene();
        }

        #endregion

        #region Public Properties

        public Size DisplaySize
        {
            get { return m_displaySize; }
        }

        public ReadOnlyCollection<Layer> Layers
        {
            get { return m_layers.AsReadOnly(); }
        }

        public ReadOnlyCollection<TileSheet> TileSheets
        {
            get { return m_tileSheets.AsReadOnly(); }
        }

        public long ElapsedTime
        {
            get { return m_elapsedTime; }
        }

        #endregion
    }
}
