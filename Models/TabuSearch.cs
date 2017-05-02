using System.Collections.Generic;
using System.Linq;

namespace QueensProblem.Models
{
    public class TabuSearch
    {
        private Fitness BestPossibleFitness => FitnessCalculator.BestFitness;

        public Chessboard FinalChessboard { get; private set; }
        public string Result { get; private set; }

        public void Simulate(int maxTabuListCount, int boardSize)
        {
            Chessboard currentCentralPoint = Generators.IntelligentRandom(boardSize);
            Chessboard currentBestSolution = currentCentralPoint;
            HashSet<Chessboard> tabuList = new HashSet<Chessboard>();
            Fitness currentBestSolutionFitness = FitnessCalculator.WorstFitness;

            while (tabuList.Count < maxTabuListCount
                && currentBestSolutionFitness.IsWorseThan(BestPossibleFitness))
            {
                Chessboard bestCandidate = Tabu
                    .GetNeighbourhoodOf(currentCentralPoint)?
                    .Except(tabuList)
                    .OrderBy(ch => FitnessCalculator.Calculate(ch).Value)
                    .FirstOrDefault();

                var bestCandidateFitness = FitnessCalculator.Calculate(bestCandidate);
                currentBestSolutionFitness = FitnessCalculator.Calculate(currentBestSolution);

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
Fitness: {FitnessCalculator.Calculate(FinalChessboard).Value}
{FinalChessboard.ToString()}
            ";
        }
    }
}