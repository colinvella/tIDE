using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class Map: DescribedComponent
    {
        private List<TileSheet> m_tileSheets;
        private List<Layer> m_layers;
        private long m_elapsedTime;

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
                layer.Draw(displayDevice, displayOffset, mapViewPort);

            displayDevice.EndScene();
        }

        public ReadOnlyCollection<TileSheet> TileSheets
        {
            get { return m_tileSheets.AsReadOnly(); }
        }

        public long ElapsedTime
        {
            get { return m_elapsedTime; }
        }
    }
}
