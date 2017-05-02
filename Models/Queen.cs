using System.Collections.Generic;

namespace QueensProblem.Models
{
    public class Queen
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates Position { get; set; }

        public Queen(int x, int y)
        {
            X = x;
            Y = y;
            Position = new Coordinates(x, y);
        }
    }
}