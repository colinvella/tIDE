using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling.Dimensions
{
    [Serializable]
    public struct Rectangle
    {
        public Location Location;
        public Size Size;

        public Rectangle(Location location, Size size)
        {
            Location = location;
            Size = size;
        }

        public Rectangle(Rectangle rectangle)
        {
            Location = rectangle.Location;
            Size = rectangle.Size;
        }

        public bool Contains(Location location)
        {
            return location.X >= Location.X && location.Y >= Location.Y
                && location.X < Location.X + Size.Width
                && location.Y < Location.Y + Size.Height;
        }

        public bool Intersects(Rectangle rectangle)
        {
            if (Location.X + Size.Width <= rectangle.Location.X)
                return false;

            if (Location.Y + Size.Height <= rectangle.Location.Y)
                return false;

            if (Location.X >= rectangle.Location.X + rectangle.Size.Width)
                return false;

            if (Location.Y >= rectangle.Location.Y + rectangle.Size.Height)
                return false;

            return true;
        }

        public void ExtendTo(Location location)
        {
            Location deltaLocation = location - Location;

            if (deltaLocation.X < 0)
            {
                Location.X = location.X;
                Size.Width -= deltaLocation.X;
            }
            else if (Size.Width <= deltaLocation.X)
                Size.Width = deltaLocation.X + 1;

            if (deltaLocation.Y < 0)
            {
                Location.Y = location.Y;
                Size.Height -= deltaLocation.Y;
            }
            else if (Size.Height <= deltaLocation.Y)
                Size.Height = deltaLocation.Y + 1;
        }

        public void ExtendTo(Rectangle rectangle)
        {
            Location corner = rectangle.Location;
            ExtendTo(corner);
            corner.X += rectangle.Size.Width - 1;
            ExtendTo(corner);
            corner.Y += rectangle.Size.Height - 1;
            ExtendTo(corner);
            corner.X -= rectangle.Size.Width - 1;
            ExtendTo(corner);
        }

        public Location MaxCorner
        {
            get
            {
                return new Location(
                    Location.X + Size.Width - 1,
                    Location.Y + Size.Height - 1);
            }
        }
    }
}
