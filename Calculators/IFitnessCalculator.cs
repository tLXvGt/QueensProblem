using QueensProblem.Models;

namespace QueensProblem.Calculators
{
    public interface IFitnessCalculator
    {
         Fitness CalculateFitness(Chessboard chessboard);
         Fitness BestFitness { get; }
         Fitness WorstFitness { get; }
    }
}