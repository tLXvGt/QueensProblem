using System.Collections.Generic;

namespace QueensProblem.Models
{
    public class Coordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Coordinates> GetAdjacentFields(int boardSize)
        {
            var adjFields = new List<Coordinates>();

            if (X != 1) adjFields.Add(new Coordinates(X - 1, Y));
            if (Y != 1) adjFields.Add(new Coordinates(X, Y - 1));

            if (X != boardSize) adjFields.Add(new Coordinates(X + 1, Y));
            if (Y != boardSize) adjFields.Add(new Coordinates(X, Y + 1));

            if (X != boardSize && Y != 1) adjFields.Add(new Coordinates(X + 1, Y - 1));
            if (X != 1 && Y != boardSize) adjFields.Add(new Coordinates(X - 1, Y + 1));

            if (X != 1 && Y != 1) adjFields.Add(new Coordinates(X - 1, Y - 1));
            if (X != boardSize && Y != boardSize) adjFields.Add(new Coordinates(X + 1, Y + 1));

            return adjFields;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}