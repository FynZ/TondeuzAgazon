using System;
using System.Collections.Generic;
using System.Text;
using TondeuzAgazon.Actors;

namespace TondeuzAgazon.Parser
{
    public class ParsingResult
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<LawnMower> LawnMowers { get; set; }
    }
}
