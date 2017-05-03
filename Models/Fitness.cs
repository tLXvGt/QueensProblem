namespace QueensProblem.Models
{
    public class Fitness
    {
        public int Value { get; private set; }

        public Fitness(int fitness)
        {
            Value = fitness;
        }

        public bool IsBetterThan(Fitness fitness)
        {
            return Value < fitness.Value;
        }

        public bool IsWorseThan(Fitness fitness)
        {
            return Value > fitness.Value;
        }
    }
}