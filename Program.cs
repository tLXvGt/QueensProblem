using System;
using System.Collections.Generic;
using System.Linq;
using QueensProblem.Models;

namespace QueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulatedAnnealing = new SimulatedAnnealing();
            simulatedAnnealing.Simulate(
                startTemperature: 10000,
                boardSize: 8
            );
            Console.WriteLine(simulatedAnnealing.Result);

            var tabuSearch = new TabuSearch();
            tabuSearch.Simulate(
                maxTabuListCount: 1000,
                boardSize: 8
            );
            Console.WriteLine(tabuSearch.Result);
        }
    }
}