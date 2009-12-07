using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tiling;

namespace TileMapEditor.Control
{
    public class TileSelection
    {
        private List<Location> m_tileLocations;
        private Rectangle m_bounds;

        public TileSelection()
        {
            m_tileLocations = new List<Location>();
            m_bounds = new Rectangle(Location.Origin, Size.Zero);
        }

        public void Clear()
        {
            m_tileLocations.Clear();
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

        public void Invert(Rectangle selectionContext)
        {
            Location location = selectionContext.Location;
            int maxX = location.X + selectionContext.Size.Width - 1;
            int maxY = location.Y + selectionContext.Size.Height - 1;

            List<Location> m_invertedSelections = new List<Location>();

            for (; location.Y <= maxY; location.Y++)
                for (location.X = selectionContext.Location.X; location.X <= maxX; location.X++)
                    if (m_bounds.Contains(location))
                    {
                        if (!m_tileLocations.Contains(location))
                            m_invertedSelections.Add(location);
                    }
                    else
                        m_invertedSelections.Add(location);

            m_tileLocations = m_invertedSelections;
        }

        public ReadOnlyCollection<Location> Locations
        {
            get { return m_tileLocations.AsReadOnly(); }
        }

        public Rectangle Bounds { get { return new Rectangle(m_bounds); } }
    }
}
