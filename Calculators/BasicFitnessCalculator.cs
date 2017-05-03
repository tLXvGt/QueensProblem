using System;
using QueensProblem.Models;

namespace QueensProblem.Calculators
{
    public class BasicFitnessCalculator : IFitnessCalculator
    {
        public Fitness WorstFitness => new Fitness(int.MaxValue);
        public Fitness BestFitness => new Fitness(0);

        public Fitness CalculateFitness(Chessboard chessboard)
        {
            if (chessboard != null)
            {
                Fitness fitness = new Fitness(chessboard.GetConflictsCount());
                return fitness;
            }

            return WorstFitness;
        }
    }
}