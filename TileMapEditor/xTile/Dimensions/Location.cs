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
    /// Represents a position in two integral dimensions
    /// </summary>
    [Serializable]
    public struct Location
    {
        /// <summary>
        /// Static Location property representing the origin [0, 0]
        /// </summary>
        public static Location Origin { get { return s_origin; } }

        /// <summary>
        /// Horizontal integral coordinate
        /// </summary>
        public int X;

        /// <summary>
        /// Vertical integral coordinate
        /// </summary>
        public int Y;

        /// <summary>
        /// Tests if two locations are identical (equality operator)
        /// </summary>
        /// <param name="location1">First location to test</param>
        /// <param name="location2">Second location to test</param>
        /// <returns>True if the given locations are equal, False otherwise</returns>
        public static bool operator ==(Location location1, Location location2)
        {
            return location1.X == location2.X && location1.Y == location2.Y;
        }

        /// <summary>
        /// Tests if two locations are different (inequality operator)
        /// </summary>
        /// <param name="location1">First location to test</param>
        /// <param name="location2">Second location to test</param>
        /// <returns>False if the given locations are equal, True otherwise</returns>
        public static bool operator !=(Location location1, Location location2)
        {
            return location1.X != location2.X || location1.Y != location2.Y;
        }

        /// <summary>
        /// Negates the location coordinates (vector negation)
        /// </summary>
        /// <param name="location">Location to negate</param>
        /// <returns>Negated location</returns>
        public static Location operator -(Location location)
        {
            return new Location(-location.X, -location.Y);
        }

        /// <summary>
        /// Adds two locations using vector addition
        /// </summary>
        /// <param name="location1">First location to add</param>
        /// <param name="location2">Second location to add</param>
        /// <returns>Vector sum of locations</returns>
        public static Location operator +(Location location1, Location location2)
        {
            return new Location(location1.X + location2.X, location1.Y + location2.Y);
        }

        /// <summary>
        /// Subtracts one location from another using vector subtraction
        /// </summary>
        /// <param name="location1">Location from which to subtruct</param>
        /// <param name="location2">Location to subtract</param>
        /// <returns>Vector difference of locations</returns>
        public static Location operator -(Location location1, Location location2)
        {
            return new Location(location1.X - location2.X, location1.Y - location2.Y);
        }

        /// <summary>
        /// Scales up the given location coordinates by the given integral factor
        /// using vector - scalar multiplication
        /// </summary>
        /// <param name="location">Location to scale up</param>
        /// <param name="scale">Scaling factor</param>
        /// <returns></returns>
        public static Location operator *(Location location, int scale)
        {
            return new Location(location.X * scale, location.Y * scale);
        }

        /// <summary>
        /// Scales up the given location coordinates by the given integral factor
        /// using scalar - vector multiplication
        /// </summary>
        /// <param name="scale">Scaling factor</param>
        /// <param name="location">Location to scale up</param>
        /// <returns></returns>
        public static Location operator *(int scale, Location location)
        {
            return new Location(location.X * scale, location.Y * scale);
        }

        /// <summary>
        /// Scales down the givel location using the given integral divisor
        /// </summary>
        /// <param name="location">Location to scale down</param>
        /// <param name="divisor">Divisor to apply for scaling down</param>
        /// <returns></returns>
        public static Location operator /(Location location, int divisor)
        {
            return new Location(location.X / divisor, location.Y / divisor);
        }

        /// <summary>
        /// Constructs a Location from the given integral coordinates
        /// </summary>
        /// <param name="x">Horizontal coordinate</param>
        /// <param name="y">Vertical coordinate</param>
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Computes a hash code of the location
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X + Y;
        }

        /// <summary>
        /// Compares the location with another object. The method returns true
        /// only if the object is a Location and its coordinates match with this
        /// Location
        /// </summary>
        /// <param name="obj">object to compare to this location</param>
        /// <returns>True if the object is a matching Location, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Location))
                return false;

            Location location = (Location) obj;
            return X == location.X && Y == location.Y;
        }

        /// <summary>
        /// Generates a string representatino of the Location
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }

        private static Location s_origin = new Location(0, 0);
    }
}
