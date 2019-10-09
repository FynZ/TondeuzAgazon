using System;
using System.Collections.Generic;
using System.Text;

namespace TondeuzAgazon.Actors
{
    public class LawnMower
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }
        public IList<Rotation> Moves { get; set; }
    }
}
