namespace QueensProblem.Models
{
    public class Temperature
    {
        public int Value { get; private set; }
        public bool IsNotZero => Value != 0;

        public Temperature(int temperature)
        {
            Value = temperature;
        }

        public void IncreaseBy(int amount)
        {
            Value += amount;
        }

        public void DecreaseBy(int amount)
        {
            Value -= amount;
        }
    }
}