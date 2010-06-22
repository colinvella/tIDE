using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTile.Dimensions
{
    [Serializable]
    public struct Size
    {
        private static Size s_sizeZero = new Size(0, 0);

        public static Size FromString(string value)
        {
            string[] elements = value.Split('x');
            if (elements.Length != 2)
                throw new FormatException("Size string format must be in the form 'N x N'");

            return new Size(int.Parse(elements[0]), int.Parse(elements[1]));
        }

        public static Size Zero { get { return s_sizeZero; } }

        public int Width;
        public int Height;

        public static bool operator==(Size size1, Size size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        public static bool operator !=(Size size1, Size size2)
        {
            return size1.Width != size2.Width || size1.Height != size2.Height;
        }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override bool Equals(object other)
        {
            if (!(other is Size))
                return false;

            Size size = (Size)other;

            return Width == size.Width && Height == size.Height;
        }

        public override int GetHashCode()
        {
            return Width + Height;
        }

        public Size(int size)
        {
            Width = Height = size;
        }

        public int Area { get { return Width * Height; } }

        public bool Square { get { return Width == Height; } }

        public override string ToString()
        {
            return Width + " x " + Height;
        }
    }
}
