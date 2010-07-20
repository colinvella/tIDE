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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTile.Dimensions
{
    /// <summary>
    /// Rectangle representation structure
    /// </summary>
    [Serializable]
    public struct Rectangle
    {
        #region Public Methods

        /// <summary>
        /// Constructs a Rectangle given a Location and Size
        /// </summary>
        /// <param name="location">Location of the Top-left corner</param>
        /// <param name="size">Rectangle dimensions</param>
        public Rectangle(Location location, Size size)
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        /// Constructs a Rectangle with the given Size. The top-left
        /// corner is placed at the origin
        /// </summary>
        /// <param name="size">Recangle dimensions</param>
        public Rectangle(Size size)
        {
            Location = Location.Origin;
            Size = size;
        }

        /// <summary>
        /// Constructs a Rectangle from another one
        /// </summary>
        /// <param name="rectangle">Rectangle to clone</param>
        public Rectangle(Rectangle rectangle)
        {
            Location = rectangle.Location;
            Size = rectangle.Size;
        }

        /// <summary>
        /// Tests if a Location is inside the Rectangle
        /// </summary>
        /// <param name="location">Location to test</param>
        /// <returns>True if the Location is inside the Rectangle, False otherwise</returns>
        public bool Contains(Location location)
        {
            return location.X >= Location.X && location.Y >= Location.Y
                && location.X < Location.X + Size.Width
                && location.Y < Location.Y + Size.Height;
        }

        /// <summary>
        /// Tests if a Rectangle intersects this Rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle to test</param>
        /// <returns>True in case of intersection, False otherwise</returns>
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

        /// <summary>
        /// Extends the Rectangle bounds to contain the given Location
        /// </summary>
        /// <param name="location">Location to contain</param>
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

        /// <summary>
        /// Extends this Rectangle to contain the given Rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle to contain</param>
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

        /// <summary>
        /// Generates a string representation of the Rectangle
        /// </summary>
        /// <returns>String representation of the Rectangle</returns>
        public override string ToString()
        {
            return Location.ToString() + " - " + Size.ToString();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Horizontal coordinate of the top left corner
        /// </summary>
        public int X
        {
            get { return Location.X; }
            set { Location.X = value; }
        }

        /// <summary>
        /// Vertical coordinate of the top left corner
        /// </summary>
        public int Y
        {
            get { return Location.Y; }
            set { Location.Y = value; }
        }
 
        /// <summary>
        /// Rectangle width
        /// </summary>
        public int Width
        {
            get { return Size.Width; }
            set { Size.Width = value; }
        }

        /// <summary>
        /// Rectangle height
        /// </summary>
        public int Height
        {
            get { return Size.Height; }
            set { Size.Height = value; }
        }

        /// <summary>
        /// Coordinate of the bottom-right corner
        /// </summary>
        public Location MaxCorner
        {
            get
            {
                return new Location(
                    Location.X + Size.Width - 1,
                    Location.Y + Size.Height - 1);
            }
        }

        #endregion

        #region Public Variables

        /// <summary>
        /// Location of the rectangle's top-left corner
        /// </summary>
        public Location Location;

        /// <summary>
        /// Dimensions of the rectangle
        /// </summary>
        public Size Size;

        #endregion
    }
}
