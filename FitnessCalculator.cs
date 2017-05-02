using System.Collections.Generic;
using System.Linq;
using QueensProblem.Models;

namespace QueensProblem
{
    public class FitnessCalculator
    {
        public static Fitness WorstFitness = new Fitness(int.MaxValue);
        public static Fitness BestFitness = new Fitness(0);

        public static Fitness Calculate(Chessboard chessboard)
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