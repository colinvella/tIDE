using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xTile;
using xTile.Dimensions;
using xTile.Layers;

using tIDE.Controls;

namespace tIDE
{
    public class TileSelection
    {
        #region Public Methods

        public TileSelection()
        {
            m_tileSelections = new Dictionary<Location, TileSelectionBorder>();
            m_bounds = new Rectangle(Location.Origin, Size.Zero);
        }

        public TileSelection(TileSelection tileSelection)
        {
            m_tileSelections = new Dictionary<Location, TileSelectionBorder>();
            foreach (KeyValuePair<Location, TileSelectionBorder> pair in tileSelection.m_tileSelections)
                m_tileSelections[pair.Key] = pair.Value;

            m_bounds = tileSelection.m_bounds;
        }

        public bool IsEmpty() { return m_tileSelections.Count == 0; }

        public bool Contains(Location tileLocation)
        {
            return m_bounds.Contains(tileLocation)
                && m_tileSelections.ContainsKey(tileLocation);
        }

        public TileSelectionBorder GetTileSelectionBorder(Location tileLocation)
        {
            TileSelectionBorder tileSelectionBorder = new TileSelectionBorder();
            m_tileSelections.TryGetValue(tileLocation, out tileSelectionBorder);
            return tileSelectionBorder;
        }

        public void Clear()
        {
            m_tileSelections.Clear();
            m_bounds.Size = Size.Zero;
        }

        public void AddLocation(Location tileLocation)
        {
            if (m_tileSelections.Count == 0)
            {
                m_tileSelections[tileLocation] = new TileSelectionBorder(); 
                m_bounds.Location = tileLocation;
                m_bounds.Size.Width = m_bounds.Size.Height = 1;
            }
            else
            {
                if (m_bounds.Contains(tileLocation)
                    && m_tileSelections.ContainsKey(tileLocation))
                    return;

                m_tileSelections[tileLocation] = new TileSelectionBorder();
                m_bounds.ExtendTo(tileLocation);
            }
            UpdateSelectionBorders();
        }

        public void Merge(TileSelection tileSelection)
        {
            if (tileSelection.IsEmpty())
                return;

            // dest selection is empty
            if (m_tileSelections.Count == 0)
            {
                m_bounds = tileSelection.Bounds;
                foreach (KeyValuePair<Location, TileSelectionBorder> pair in tileSelection.m_tileSelections)
                    m_tileSelections[pair.Key] = pair.Value;
                UpdateSelectionBorders();
                return;
            }

            // otherwise, merge with existing
            foreach (KeyValuePair<Location, TileSelectionBorder> pair in tileSelection.m_tileSelections)
                m_tileSelections[pair.Key] = pair.Value;

            m_bounds.ExtendTo(tileSelection.m_bounds);
            UpdateSelectionBorders();
        }

        public void SelectAll(Rectangle selectionContext)
        {
            m_bounds = selectionContext;
            Location location = selectionContext.Location;
            int maxX = location.X + selectionContext.Size.Width;
            int maxY = location.Y + selectionContext.Size.Height;

            m_tileSelections.Clear();
            for (; location.Y < maxY; location.Y++)
                for (location.X = selectionContext.Location.X; location.X < maxX; location.X++)
                    m_tileSelections[location] = new TileSelectionBorder();
            UpdateSelectionBorders();
        }

        public void Invert(Rectangle selectionContext)
        {
            Location location = selectionContext.Location;
            int maxX = location.X + selectionContext.Size.Width ;
            int maxY = location.Y + selectionContext.Size.Height;

            List<Location> invertedSelections = new List<Location>();

            Location initialLocation = Location.Origin;
            for (; location.Y < maxY; location.Y++)
                for (location.X = selectionContext.Location.X; location.X < maxX; location.X++)
                    if (m_bounds.Contains(location))
                    {
                        if (!m_tileSelections.ContainsKey(location))
                        {
                            invertedSelections.Add(location);
                            initialLocation = location;
                        }
                    }
                    else
                    {
                        invertedSelections.Add(location);
                        initialLocation = location;
                    }

            m_tileSelections.Clear();
            foreach (Location tileLocation in invertedSelections)
                m_tileSelections[tileLocation] = new TileSelectionBorder();

            m_bounds.Location = initialLocation;
            m_bounds.Size = Size.Zero;
            foreach (Location invertedLocation in invertedSelections)
                m_bounds.ExtendTo(invertedLocation);
            UpdateSelectionBorders();
        }

        public void EraseTiles(Layer layer)
        {
            foreach (Location tileLocation in m_tileSelections.Keys)
                if (layer.IsValidTileLocation(tileLocation))
                    layer.Tiles[tileLocation] = null;

            Clear();
        }
        
        #endregion

        #region Public Properties

        public IEnumerable<Location> Locations
        {
            get { return m_tileSelections.Keys; }
        }

        public Rectangle Bounds { get { return new Rectangle(m_bounds); } }

        #endregion

        #region Private Methods

        private void UpdateSelectionBorders()
        {
            List<Location> tileLocations = new List<Location>(m_tileSelections.Keys);
            foreach (Location tileLocation in tileLocations)
            {
                TileSelectionBorder tileSelectionBorder = new TileSelectionBorder();

                Location tileLocationNeighbour = new Location(tileLocation.X - 1, tileLocation.Y);
                if (!Contains(tileLocationNeighbour))
                    tileSelectionBorder.Left = true;

                tileLocationNeighbour.X += 2;
                if (!Contains(tileLocationNeighbour))
                    tileSelectionBorder.Right = true;

                --tileLocationNeighbour.X;
                --tileLocationNeighbour.Y;
                if (!Contains(tileLocationNeighbour))
                    tileSelectionBorder.Above = true;

                tileLocationNeighbour.Y += 2;
                if (!Contains(tileLocationNeighbour))
                    tileSelectionBorder.Below = true;

                m_tileSelections[tileLocation] = tileSelectionBorder;
            }
        }

        #endregion

        #region Private Variables

        private Rectangle m_bounds;
        private Dictionary<Location, TileSelectionBorder> m_tileSelections;

        #endregion

    }

    public struct TileSelectionBorder
    {
        public bool Left, Right, Above, Below;
    }
}
