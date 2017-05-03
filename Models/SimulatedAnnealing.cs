using QueensProblem.Calculators;
using QueensProblem.Generators;

namespace QueensProblem.Models
{
    public class SimulatedAnnealing
    {
        public Chessboard FinalChessboard { get; private set; }
        public string Result { get; private set; }

        public void Simulate(int startTemperature, int boardSize,
            IChessboardGenerator generator,
            IFitnessCalculator calculator)
        {
            Fitness BestPossibleFitness = calculator.BestFitness;
            int tenPercent = startTemperature / 10;
            Chessboard currentBestChessboard = generator.Generate(boardSize);
            Temperature currentTemperature = new Temperature(startTemperature);
            Fitness currentBestFitness = calculator.WorstFitness;

            while (currentTemperature.IsNotZero
                && currentBestFitness.IsWorseThan(BestPossibleFitness))
            {
                Chessboard chessboard = generator.Generate(boardSize);
                Fitness currentFitness = calculator.CalculateFitness(chessboard);

                if (currentFitness.IsBetterThan(currentBestFitness))
                {
                    currentBestFitness = currentFitness;
                    currentBestChessboard = chessboard;
                    currentTemperature.IncreaseBy(tenPercent);
                }
                else
                {
                    currentTemperature.DecreaseBy(1);
                }
            }

            FinalChessboard = currentBestChessboard;
            Result = $@"
-- Simulated Annealing Result --
Current Temperature: {currentTemperature.Value}
Fitness: {calculator.CalculateFitness(FinalChessboard).Value}
{FinalChessboard.ToString()}
            ";
        }
    }
}