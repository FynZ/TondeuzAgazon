using System.Collections.Generic;

namespace TondeuzAgazon.Parser
{
    public class LawnMowerData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }
        public IList<Rotation> Moves { get; set; }
    }
}
