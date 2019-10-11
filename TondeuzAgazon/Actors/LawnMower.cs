using System;
using System.Collections.Generic;
using System.Text;

namespace TondeuzAgazon.Actors
{
    class LawnMower
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }

        public LawnMower(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}
