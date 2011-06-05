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
            m_tileLocations = new List<Location>();
            m_bounds = new Rectangle(Location.Origin, Size.Zero);
            m_tileSelectionBorders = new Dictionary<Location, TileSelectionBorder>();
        }

        public TileSelection(TileSelection tileSelection)
        {
            m_tileLocations = new List<Location>(tileSelection.m_tileLocations);
            m_bounds = tileSelection.m_bounds;
            m_tileSelectionBorders = new Dictionary<Location, TileSelectionBorder>();
            UpdateSelectionBorders();
        }

        public bool IsEmpty() { return m_tileLocations.Count == 0; }

        public bool Contains(Location tileLocation)
        {
            return m_bounds.Contains(tileLocation)
                && m_tileLocations.Contains(tileLocation);
        }

        public TileSelectionBorder GetTileSelectionBorder(Location tileLocation)
        {
            TileSelectionBorder tileSelectionBorder = new TileSelectionBorder();
            m_tileSelectionBorders.TryGetValue(tileLocation, out tileSelectionBorder);
            return tileSelectionBorder;
        }

        public void Clear()
        {
            m_tileLocations.Clear();
            m_bounds.Size = Size.Zero;
            m_tileSelectionBorders.Clear();
        }

        public void AddLocation(Location tileLocation)
        {
            if (m_tileLocations.Count == 0)
            {
                m_tileLocations.Add(tileLocation);
                m_bounds.Location = tileLocation;
                m_bounds.Size.Width = m_bounds.Size.Height = 1;
            }
            else
            {
                if (m_bounds.Contains(tileLocation)
                    && m_tileLocations.Contains(tileLocation))
                    return;

                m_tileLocations.Add(tileLocation);
                m_bounds.ExtendTo(tileLocation);
            }
            UpdateSelectionBorders();
        }

        public void Merge(TileSelection tileSelection)
        {
            if (tileSelection.IsEmpty())
                return;

            if (m_tileLocations.Count == 0)
            {
                m_bounds = tileSelection.Bounds;
                m_tileLocations.AddRange(tileSelection.m_tileLocations);
                UpdateSelectionBorders();
                return;
            }

            if (m_bounds.Intersects(tileSelection.m_bounds))
            {
                // overlapping - add with bounds testing for speed
                foreach (Location tileLocation in tileSelection.m_tileLocations)
                {
                    if (m_bounds.Contains(tileLocation)
                        && m_tileLocations.Contains(tileLocation))
                        continue;

                    m_tileLocations.Add(tileLocation);
                }
            }
            else
            {
                // not overlapping - add indiscriminately
                m_tileLocations.AddRange(tileSelection.m_tileLocations);
            }

            m_bounds.ExtendTo(tileSelection.m_bounds);
            UpdateSelectionBorders();
        }

        public void SelectAll(Rectangle selectionContext)
        {
            m_bounds = selectionContext;
            Location location = selectionContext.Location;
            int maxX = location.X + selectionContext.Size.Width;
            int maxY = location.Y + selectionContext.Size.Height;

            m_tileLocations.Clear();
            for (; location.Y < maxY; location.Y++)
                for (location.X = selectionContext.Location.X; location.X < maxX; location.X++)
                    m_tileLocations.Add(location);
            UpdateSelectionBorders();
        }

        public void Invert(Rectangle selectionContext)
        {
            Location location = selectionContext.Location;
            int maxX = location.X + selectionContext.Size.Width ;
            int maxY = location.Y + selectionContext.Size.Height;

            List<Location> m_invertedSelections = new List<Location>();

            Location initialLocation = Location.Origin;
            for (; location.Y < maxY; location.Y++)
                for (location.X = selectionContext.Location.X; location.X < maxX; location.X++)
                    if (m_bounds.Contains(location))
                    {
                        if (!m_tileLocations.Contains(location))
                        {
                            m_invertedSelections.Add(location);
                            initialLocation = location;
                        }
                    }
                    else
                    {
                        m_invertedSelections.Add(location);
                        initialLocation = location;
                    }

            m_tileLocations = m_invertedSelections;

            m_bounds.Location = initialLocation;
            m_bounds.Size = Size.Zero;
            foreach (Location invertedLocation in m_invertedSelections)
                m_bounds.ExtendTo(invertedLocation);
            UpdateSelectionBorders();
        }

        public void EraseTiles(Layer layer)
        {
            foreach (Location tileLocation in m_tileLocations)
                if (layer.IsValidTileLocation(tileLocation))
                    layer.Tiles[tileLocation] = null;

            Clear();
        }
        
        #endregion

        #region Public Properties

        public ReadOnlyCollection<Location> Locations
        {
            get { return m_tileLocations.AsReadOnly(); }
        }

        public Rectangle Bounds { get { return new Rectangle(m_bounds); } }

        #endregion

        #region Private Methods

        private void UpdateSelectionBorders()
        {
            m_tileSelectionBorders.Clear();
            foreach (Location tileLocation in m_tileLocations)
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

                m_tileSelectionBorders[tileLocation] = tileSelectionBorder;
            }
        }

        #endregion

        #region Private Variables

        private List<Location> m_tileLocations;
        private Rectangle m_bounds;
        private Dictionary<Location, TileSelectionBorder> m_tileSelectionBorders;

        #endregion

    }

    public struct TileSelectionBorder
    {
        public bool Left, Right, Above, Below;
    }
}
