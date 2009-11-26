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
        private Size m_size;

        #endregion

        #region Private Methods

        private void UpdateSize()
        {
            m_size = Size.Zero;
            foreach (Layer layer in m_layers)
            {
                Size layerSize = layer.LayerSize;
                m_size.Width = Math.Max(m_size.Width, layerSize.Width);
                m_size.Height = Math.Max(m_size.Height, layerSize.Height);
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
            m_size = Size.Zero;
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

        public void Update(long timeInterval)
        {
            m_elapsedTime += timeInterval;
        }

        public void LoadTileSheets(DisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.LoadTileSheet(tileSheet);
        }

        public void DisposeTileSheets(DisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.DisposeTileSheet(tileSheet);
        }

        public void Draw(DisplayDevice displayDevice, Rectangle mapViewPort)
        {
            Draw(displayDevice, Location.Origin, mapViewPort);
        }

        public void Draw(DisplayDevice displayDevice, Location displayOffset, Rectangle mapViewPort)
        {
            displayDevice.BeginScene();

            Rectangle clippingRegion = new Rectangle(displayOffset, mapViewPort.Size);
            displayDevice.SetClippingRegion(clippingRegion);

            foreach (Layer layer in m_layers)
                layer.Draw(displayDevice, displayOffset, mapViewPort);

            displayDevice.EndScene();
        }

        #endregion

        #region Public Properties

        public Size Size
        {
            get { return m_size; }
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
