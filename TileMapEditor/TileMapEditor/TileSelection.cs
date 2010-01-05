using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;
using Tiling.Dimensions;
using Tiling.Layers;

using TileMapEditor.Controls;

namespace TileMapEditor
{
    public class TileSelection
    {
        #region Private Variables

        private List<Location> m_tileLocations;
        private Rectangle m_bounds;

        #endregion

        #region Public Methods

        public TileSelection()
        {
            m_tileLocations = new List<Location>();
            m_bounds = new Rectangle(Location.Origin, Size.Zero);
        }

        public TileSelection(TileSelection tileSelection)
        {
            m_tileLocations = new List<Location>(tileSelection.m_tileLocations);
            m_bounds = tileSelection.m_bounds;
        }

        public bool IsEmpty() { return m_tileLocations.Count == 0; }

        public bool Contains(Location tileLocation)
        {
            return m_bounds.Contains(tileLocation)
                && m_tileLocations.Contains(tileLocation);
        }

        public void Clear()
        {
            m_tileLocations.Clear();
            m_bounds.Size = Size.Zero;
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
        }

        public void Merge(TileSelection tileSelection)
        {
            if (tileSelection.IsEmpty())
                return;

            if (m_tileLocations.Count == 0)
            {
                m_bounds = tileSelection.Bounds;
                m_tileLocations.AddRange(tileSelection.m_tileLocations);
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
    }
}
