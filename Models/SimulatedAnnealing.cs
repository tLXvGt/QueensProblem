namespace QueensProblem.Models
{
    public class SimulatedAnnealing
    {
        private Fitness BestPossibleFitness => FitnessCalculator.BestFitness;

        public Chessboard FinalChessboard { get; private set; }
        public string Result { get; set; }

        public void Simulate(int startTemperature, int boardSize)
        {
            int tenPercent = startTemperature / 10;
            Chessboard currentBestChessboard = Generators.IntelligentRandom(boardSize);
            Temperature currentTemperature = new Temperature(startTemperature);
            Fitness currentBestFitness = FitnessCalculator.WorstFitness;

            while (currentTemperature.IsNotZero
                && currentBestFitness.IsWorseThan(BestPossibleFitness))
            {
                Chessboard chessboard = Generators.IntelligentRandom(boardSize);
                Fitness currentFitness = FitnessCalculator.Calculate(chessboard);

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
Fitness: {FitnessCalculator.Calculate(FinalChessboard).Value}
{FinalChessboard.ToString()}
            ";
        }
    }
}