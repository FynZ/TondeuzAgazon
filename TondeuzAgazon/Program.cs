﻿using System;
using System.Collections.Generic;
using TondeuzAgazon.Actors;
using TondeuzAgazon.Orchestrator;
using TondeuzAgazon.Parser;

namespace TondeuzAgazon
{
    class Program
    {
        static void Main(string[] args)
        {
            var lawn = new LawnOrchestrator(new ParsingResult
            {
                Width = 10,
                Height = 10,
                LawnMowers = new List<LawnMowerData>()
            });

            lawn.Draw();

            while (lawn.GameFinished == false)
            {
                Console.Clear();
                lawn.ExecuteNextTurn();
                lawn.Draw();

                Console.ReadKey();
            }
        }
    }
}
