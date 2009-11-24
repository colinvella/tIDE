using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public class Rectangle
    {
        public Location Location;
        public Size Size;

        public Rectangle(Location location, Size size)
        {
            Location = location;
            Size = size;
        }
    }
}
