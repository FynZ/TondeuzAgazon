using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TondeuzAgazon.Actors;
using TondeuzAgazon.Parser;

namespace TondeuzAgazon.Orchestrator
{
    public class LawnOrchestrator
    {
        private char[,] _lawn { get; set; }
        private IList<LawnMowerProxy> _lawnMowers { get; set; }

        public bool GameFinished { get; set; }

        public LawnOrchestrator(ParsingResult input)
        {
            _lawn = new char[input.Width, input.Height];

            _lawnMowers = input.LawnMowers.Select(x => new LawnMowerProxy(x)).ToList();
        }

        public void ExecuteNextTurn()
        {
            var atLeastOneMowerPlayed = false;

            foreach (var mower in _lawnMowers)
            {
                if (!mower.HasFinished)
                {
                    mower.MoveNext(_lawn);

                    atLeastOneMowerPlayed = true;
                }
            }

            if (atLeastOneMowerPlayed == false)
            {
                GameFinished = true;
            }
        }

        public void Draw()
        {
            var sb = new StringBuilder();
            int rowLength = _lawn.GetLength(0);
            int colLength = _lawn.GetLength(1);

            sb.Append(new string('-', rowLength + 2));
            sb.Append(Environment.NewLine);

            for (int i = 0; i < rowLength; i++)
            {
                sb.Append("|");

                for (int j = 0; j < colLength; j++)
                {
                    // a lawnMower is at the position we are drawing
                    if (_lawnMowers.Any(x => x.GetPosition().a == i && x.GetPosition().b == j))
                    {
                        sb.Append('X');
                    }

                    sb.Append("O");
                }

                sb.Append("|");

                sb.Append(Environment.NewLine);
            }

            sb.Append(new string('-', rowLength + 2));

            var result = sb.ToString();

            Console.Write(result);
        }
    }
}
