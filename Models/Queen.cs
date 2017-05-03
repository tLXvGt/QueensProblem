using System.Collections.Generic;

namespace QueensProblem.Models
{
    public class Queen
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coordinates Position { get; private set; }

        public Queen(int x, int y)
        {
            X = x;
            Y = y;
            Position = new Coordinates(x, y);
        }
    }
}