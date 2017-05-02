using System.Collections.Generic;

namespace QueensProblem.Models
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Coordinates> GetAdjacentFields(int boardSize)
        {
            var list = new List<Coordinates>();

            if (X != 1) list.Add(new Coordinates(X - 1, Y));
            if (Y != 1) list.Add(new Coordinates(X, Y - 1));

            if (X != boardSize) list.Add(new Coordinates(X + 1, Y));
            if (Y != boardSize) list.Add(new Coordinates(X, Y + 1));

            if (X != boardSize && Y != 1) list.Add(new Coordinates(X + 1, Y - 1));
            if (X != 1 && Y != boardSize) list.Add(new Coordinates(X - 1, Y + 1));

            if (X != 1 && Y != 1) list.Add(new Coordinates(X - 1, Y - 1));
            if (X != boardSize && Y != boardSize) list.Add(new Coordinates(X + 1, Y + 1));

            return list;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}