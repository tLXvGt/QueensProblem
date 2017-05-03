using System.Collections.Generic;
using System.Linq;
using QueensProblem.Calculators;
using QueensProblem.Generators;

namespace QueensProblem.Models
{
    public class TabuSearch
    {
        public Chessboard FinalChessboard { get; private set; }
        public string Result { get; private set; }

        public void Simulate(int maxTabuListCount, int boardSize,
            IChessboardGenerator generator,
            IFitnessCalculator calculator)
        {
            Fitness BestPossibleFitness = calculator.BestFitness;
            IntelligentRandom random = new IntelligentRandom();
            Chessboard currentCentralPoint = random.Generate(boardSize);
            Chessboard currentBestSolution = currentCentralPoint;
            HashSet<Chessboard> tabuList = new HashSet<Chessboard>();
            Fitness currentBestSolutionFitness = calculator.WorstFitness;

            while (tabuList.Count < maxTabuListCount
                && currentBestSolutionFitness.IsWorseThan(BestPossibleFitness))
            {
                Chessboard bestCandidate = currentCentralPoint?
                    .GetNeighbourhoodOf()
                    .Except(tabuList)
                    .OrderBy(ch => calculator.CalculateFitness(ch).Value)
                    .FirstOrDefault();

                Fitness bestCandidateFitness = calculator.CalculateFitness(bestCandidate);
                currentBestSolutionFitness = calculator.CalculateFitness(currentBestSolution);

                currentCentralPoint = bestCandidate;
                if (bestCandidateFitness.IsBetterThan(currentBestSolutionFitness))
                {
                    currentBestSolution = bestCandidate;
                }

                tabuList.Add(bestCandidate);
            }

            FinalChessboard = currentBestSolution;
            Result = $@"
-- Tabu Search Result --
Tabu List Count: {tabuList.Count}
Fitness: {calculator.CalculateFitness(FinalChessboard).Value}
{FinalChessboard.ToString()}
            ";
        }
    }
}