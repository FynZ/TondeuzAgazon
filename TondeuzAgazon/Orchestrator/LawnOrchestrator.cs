using System;
using System.Collections.Generic;
using System.Text;
using TondeuzAgazon.Actors;
using TondeuzAgazon.Parser;

namespace TondeuzAgazon.Orchestrator
{
    public class LawnOrchestrator
    {
        public char[,] Lawn { get; set; }
        public IList<LawnMower> LawnMowers { get; set; }

        public LawnOrchestrator(ParsingResult input)
        {
            Lawn = new char[input.Width, input.Height];

            LawnMowers = input.LawnMowers;
        }

        public void ExecuteNextTurn()
        {

        }

        public void Draw()
        {
            var sb = new StringBuilder();
            int rowLength = Lawn.GetLength(0);
            int colLength = Lawn.GetLength(1);

            sb.Append(new string('-', rowLength + 2));
            sb.Append(Environment.NewLine);

            for (int i = 0; i < rowLength; i++)
            {
                sb.Append("|");

                for (int j = 0; j < colLength; j++)
                {
                    //sb.Append(string.Format("{0}", Lawn[i, j]));
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
