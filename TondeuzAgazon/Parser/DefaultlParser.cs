using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TondeuzAgazon.Actors;

namespace TondeuzAgazon.Parser
{
    public class DefaultlParser : IParser<ParsingResult>
    {
        public ParsingResult Parse(FileInfo fi)
        {
            if (!fi.Exists)
            {
                throw new FileNotFoundException(nameof(fi));
            }

            using (var stream = new StreamReader(fi.Open(FileMode.Open)))
            {
                var result = new ParsingResult();

                var line = stream.ReadLine();

                // parse header (x & y value of lawn)
                var size = GetLawnSize(line);

                result.Width = size.X;
                result.Height = size.Y;

                // parse every lawnmower
                while ((line = stream.ReadLine()) != null)
                {
                    var upperLine = line;
                    var lowerLine = stream.ReadLine();

                    if (IsValidLawnMowerLine(upperLine) && IsValidLawnMowerActionsLine(lowerLine))
                    {
                        result.LawnMowers.Add(GetLawnMower(upperLine, lowerLine));
                    }
                }

                return result;
            }
        }

        private LawnSize GetLawnSize(string line)
        {
            var split = line.Split(" ");

            if (split.Length != 2)
            {
                throw new ParsingException("Bad file format at line 1");
            }

            if (Int32.TryParse(split[0], out var x) == false)
            {
                throw new ParsingException("X axis is not a number");
            }

            if (Int32.TryParse(split[1], out var y) == false)
            {
                throw new ParsingException("Y axis is not a number");
            }

            return new LawnSize
            { 
                X = x,
                Y = y
            };
        }

        private bool IsValidLawnMowerLine(string line)
        {
            if (line is null) return false;

            var split = line.Split(" ");

            if (split.Length != 3) return false;

            if (Int32.TryParse(split[0], out var x) && Int32.TryParse(split[1], out var y) && Enum.IsDefined(typeof(Orientation), split[2]))
            {
                return true;
            }

            return false;
        }

        private bool IsValidLawnMowerActionsLine(string line)
        {
            if (line is null) return false;

            if (line.All(c => "LR".Contains(c)))
            {
                return true;
            }

            return false;
        }

        private LawnMowerData GetLawnMower(string positionLine, string actionLine)
        {
            var lawnMower = new LawnMowerData();

            var split = positionLine.Split(" ");

            lawnMower.X = Int32.Parse(split[0]);
            lawnMower.Y = Int32.Parse(split[1]);
            lawnMower.Orientation = Enum.Parse<Orientation>(split[2]);

            foreach (var elem in actionLine)
            {
                lawnMower.Moves.Add(Enum.Parse<Rotation>(elem.ToString()));
            }

            return lawnMower;
        }

        private class LawnSize
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }

    public class ParsingException : Exception
    {
        public ParsingException(string message) : base(message)
        {

        }
    }
}
