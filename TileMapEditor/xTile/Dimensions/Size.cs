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
    /// Size representation structure in two integral dimensions
    /// </summary>
    [Serializable]
    public struct Size
    {
        /// <summary>
        /// Parses a string representation of a Size object and returns a Size
        /// instance
        /// </summary>
        /// <param name="value">String representation to parse</param>
        /// <returns>Parsed Size object</returns>
        public static Size FromString(string value)
        {
            string[] elements = value.Split('x');
            if (elements.Length != 2)
                throw new FormatException("Size string format must be in the form 'N x N'");

            return new Size(int.Parse(elements[0]), int.Parse(elements[1]));
        }

        /// <summary>
        /// Static property for a single point
        /// </summary>
        public static Size Zero { get { return s_sizeZero; } }

        /// <summary>
        /// Horizontal dimension
        /// </summary>
        public int Width;

        /// <summary>
        /// Vertical dimension
        /// </summary>
        public int Height;

        /// <summary>
        /// Tests if the given Sizes are equal
        /// </summary>
        /// <param name="size1">First Size to compare</param>
        /// <param name="size2">Second Size to compare</param>
        /// <returns>True if the Sizes are equal, False otherwise</returns>
        public static bool operator==(Size size1, Size size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        /// <summary>
        /// Tests if the given Sizes are different
        /// </summary>
        /// <param name="size1">First Size to compare</param>
        /// <param name="size2">Second Size to compare</param>
        /// <returns>False if the Sizes are equal, True otherwise</returns>
        public static bool operator !=(Size size1, Size size2)
        {
            return size1.Width != size2.Width || size1.Height != size2.Height;
        }

        /// <summary>
        /// Constructs a new Size object from the given dimensions
        /// </summary>
        /// <param name="width">Horizontal dimension</param>
        /// <param name="height">Vertical dimensions</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Testts if the given object is equal to this Size
        /// </summary>
        /// <param name="other">Object to compare</param>
        /// <returns>Returns True if th object is a Size and if it matches this Size</returns>
        public override bool Equals(object other)
        {
            if (!(other is Size))
                return false;

            Size size = (Size)other;

            return Width == size.Width && Height == size.Height;
        }

        /// <summary>
        /// Computes a hash code for the Size
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Width + Height;
        }

        /// <summary>
        /// Constructs a Size object from the given Size
        /// </summary>
        /// <param name="size">Size object to clone</param>
        public Size(int size)
        {
            Width = Height = size;
        }

        /// <summary>
        /// Area of the rectangular region
        /// </summary>
        public int Area { get { return Width * Height; } }

        /// <summary>
        /// Tests if the Size represents a Square region
        /// </summary>
        public bool Square { get { return Width == Height; } }

        /// <summary>
        /// Generates a string representation of the Size
        /// </summary>
        /// <returns>String representation of the Size</returns>
        public override string ToString()
        {
            return Width + " x " + Height;
        }

        private static Size s_sizeZero = new Size(0, 0);
    }
}
