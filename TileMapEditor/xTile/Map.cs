/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  LICENSE    Microsoft Reciprocal License (Ms-RL)                        //
//             http://www.opensource.org/licenses/ms-rl.html               //
//                                                                         //
//  AUTHOR     Colin Vella                                                 //
//                                                                         //
//  CODEBASE   http://tide.codeplex.com                                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.Display;
using XTile.Layers;
using XTile.ObjectModel;
using XTile.Tiles;

namespace XTile
{
    /// <summary>
    /// A multi-layer tile-based map implementation. The contained Layers are
    /// ordered by depth
    /// </summary>
    [Serializable]
    public class Map : DescribedComponent
    {
        #region Public Properties

        /// <summary>
        /// Display size of the map in pixels. Corresponds to the size of
        /// the largest layer
        /// </summary>
        public Size DisplaySize
        {
            get { return m_displaySize; }
        }

        /// <summary>
        /// Layer collection contained in the Map
        /// </summary>
        public ReadOnlyCollection<Layer> Layers
        {
            get { return m_layers.AsReadOnly(); }
        }

        /// <summary>
        /// TileSheet collection in the Map
        /// </summary>
        public ReadOnlyCollection<TileSheet> TileSheets
        {
            get { return m_tileSheets.AsReadOnly(); }
        }

        /// <summary>
        /// Elapsed time in milliseconds, used for tile animation
        /// </summary>
        public long ElapsedTime
        {
            get { return m_elapsedTime; }
            set { m_elapsedTime = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructs a map with a default "Untitled Map" ID
        /// </summary>
        public Map()
            : base("Untiled map")
        {
            m_tileSheets = new List<TileSheet>();
            m_layers = new List<Layer>();
            m_elapsedTime = 0;
        }

        /// <summary>
        /// Constructs a map with the given ID
        /// </summary>
        /// <param name="id">ID to assign to the Map</param>
        public Map(string id)
            :base(id)
        {
            m_tileSheets = new List<TileSheet>();
            m_layers = new List<Layer>();
            m_elapsedTime = 0;
            m_displaySize = Size.Zero;
        }

        /// <summary>
        /// Returns the Layer corresponding to the given layer ID or null
        /// if not matched
        /// </summary>
        /// <param name="layerId">ID of the Layer to retrieve</param>
        /// <returns>Layer corresponding to the given ID</returns>
        public Layer GetLayer(string layerId)
        {
            foreach (Layer layer in m_layers)
                if (layer.Id == layerId)
                    return layer;

            return null;
        }

        /// <summary>
        /// Adds the given Layer to this Map
        /// </summary>
        /// <param name="layer">Layer to add</param>
        public void AddLayer(Layer layer)
        {
            InsertLayer(layer, m_layers.Count);
        }

        /// <summary>
        /// Inserts the given Layer at the given index in the
        /// Layer collection
        /// </summary>
        /// <param name="layer">Layer to insert</param>
        /// <param name="layerIndex">Insertion index into this Map's Layer collection</param>
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

        /// <summary>
        /// Removes the given Layer from the Map
        /// </summary>
        /// <param name="layer">Layer to remove</param>
        public void RemoveLayer(Layer layer)
        {
            if (!m_layers.Contains(layer))
                throw new Exception("The specified Layer is not contained in this map");

            m_layers.Remove(layer);

            UpdateDisplaySize();
        }

        /// <summary>
        /// Moves the given Layer one index forward (higher) in this
        /// Map's Layer collection
        /// </summary>
        /// <param name="layer">Layer to bring forward</param>
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

        /// <summary>
        /// Moves the given Layer one index backward (lower) in this
        /// Map's Layer collection
        /// </summary>
        /// <param name="layer">Layer to send backward</param>
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

        /// <summary>
        /// Tests if the given TileSheet is used by this Map by testing
        /// if the Layers contain and dependent tiles
        /// </summary>
        /// <param name="tileSheet">TileSheet to test</param>
        /// <returns>True if dependent, False otherwise</returns>
        public bool DependsOnTileSheet(TileSheet tileSheet)
        {
            if (tileSheet.Map != this)
                return false;

            foreach (Layer layer in m_layers)
                if (layer.DependsOnTileSheet(tileSheet))
                    return true;

            return false;
        }

        /// <summary>
        /// Returns the TileSheet corresponding to the given ID, or null
        /// if not matched
        /// </summary>
        /// <param name="tileSheetId">ID of the TileSheet to retrieve</param>
        /// <returns>TileSheet corresponding to the given ID, or null if unmatched</returns>
        public TileSheet GetTileSheet(string tileSheetId)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                if (tileSheet.Id == tileSheetId)
                    return tileSheet;

            return null;
        }

        /// <summary>
        /// Adds the given TileSheet to this Map
        /// </summary>
        /// <param name="tileSheet">TileSheet to add</param>
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

        /// <summary>
        /// Removes the given TileSheet from this Map, subject to
        /// dependencies
        /// </summary>
        /// <param name="tileSheet">TileSheet to remove</param>
        public void RemoveTileSheet(TileSheet tileSheet)
        {
            if (!m_tileSheets.Contains(tileSheet))
                throw new Exception("The specified TileSheet is not contained in this map");

            foreach (Layer layer in m_layers)
                if (layer.DependsOnTileSheet(tileSheet))
                    throw new Exception("Cannot remove TileSheet as it is in use by Layer " + layer.Id);

            m_tileSheets.Remove(tileSheet);
        }

        /// <summary>
        /// Removes any dependencies on the given TileSheet by clearing out
        /// any tiles within all Layers that depend on the TileSheet
        /// </summary>
        /// <param name="tileSheet">TileSheet for which to remove dependencies</param>
        public void RemoveTileSheetDependencies(TileSheet tileSheet)
        {
            foreach (Layer layer in m_layers)
                layer.RemoveTileSheetDependency(tileSheet);
        }

        /// <summary>
        /// Updates the map's animation clock with the given time interval
        /// </summary>
        /// <param name="timeInterval">Time interval in milliseconds</param>
        public void Update(long timeInterval)
        {
            m_elapsedTime += timeInterval;
        }

        /// <summary>
        /// Loads all the TileSheets contained in this Map into the given
        /// display device
        /// </summary>
        /// <param name="displayDevice">Display device in which to load the TileSheets</param>
        public void LoadTileSheets(IDisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.LoadTileSheet(tileSheet);
        }

        /// <summary>
        /// Frees the resources of all the TileSheets contained in this Map
        /// from the given display device
        /// </summary>
        /// <param name="displayDevice">Display device from which to dispose the TileSheets</param>
        public void DisposeTileSheets(IDisplayDevice displayDevice)
        {
            foreach (TileSheet tileSheet in m_tileSheets)
                displayDevice.DisposeTileSheet(tileSheet);
        }

        /// <summary>
        /// Visually renders this Map using the given display device and
        /// viewport into the map. The viewport is rendered at the display
        /// device's origin
        /// </summary>
        /// <param name="displayDevice">Display device on which to render the Map</param>
        /// <param name="mapViewport">Viewport into the Map to be rendered</param>
        public void Draw(IDisplayDevice displayDevice, Rectangle mapViewport)
        {
            Draw(displayDevice, Location.Origin, mapViewport);
        }

        /// <summary>
        /// Visually renders this Map using the given display device and
        /// viewport into the map. The viewport is rendered at the given
        /// display offset
        /// </summary>
        /// <param name="displayDevice">Display device on which to render the Map</param>
        /// <param name="displayOffset">Pixel offset on the device where to render the map</param>
        /// <param name="mapViewport">Viewport into the Map to be rendered</param>
        public void Draw(IDisplayDevice displayDevice, Location displayOffset, Rectangle mapViewport)
        {
            displayDevice.BeginScene();

            Rectangle clippingRegion = new Rectangle(displayOffset, mapViewport.Size);
            displayDevice.SetClippingRegion(clippingRegion);

            foreach (Layer layer in m_layers)
            {
                if (!layer.Visible)
                    continue;
                    
                Rectangle layerViewport = layer.ConvertMapToLayerViewport(mapViewport);
                layer.Draw(displayDevice, displayOffset, layerViewport);
            }

            displayDevice.EndScene();
        }

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

        #region Private Variables

        private List<TileSheet> m_tileSheets;
        private List<Layer> m_layers;
        private long m_elapsedTime;
        private Size m_displaySize;

        #endregion
    }
}
