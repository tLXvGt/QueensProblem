using System;
using System.Collections.Generic;
using System.Linq;
using QueensProblem.Calculators;
using QueensProblem.Generators;
using QueensProblem.Models;

namespace QueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            IntelligentRandom intelligentRandom = new IntelligentRandom();
            BasicFitnessCalculator basicCalculator = new BasicFitnessCalculator();

            var simulatedAnnealing = new SimulatedAnnealing();
            simulatedAnnealing.Simulate(
                startTemperature: 10000,
                boardSize: 10,
                generator: intelligentRandom,
                calculator: basicCalculator
            );
            Console.WriteLine(simulatedAnnealing.Result);

            var tabuSearch = new TabuSearch();
            tabuSearch.Simulate(
                maxTabuListCount: 1500,
                boardSize: 10,
                generator: intelligentRandom,
                calculator: basicCalculator
            );
            Console.WriteLine(tabuSearch.Result);
        }
    }
}