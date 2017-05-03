using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensProblem.Models
{
    public class Chessboard
    {
        public List<Queen> Queens { get; private set; }
        public int BoardSize { get; private set; }

        public Chessboard(List<Queen> list)
        {
            BoardSize = list.Count;
            Queens = list;
        }

        public bool HasQueenOn(int x, int y)
        {
            return Queens.Any(q => q.X == x && q.Y == y);
        }

        public bool HasQueenOn(Coordinates coords)
        {
            return Queens.Any(q => q.X == coords.X && q.Y == coords.Y);
        }

        public int GetConflictsCount()
        {
            int conflicts = 0;
            foreach (var queen in Queens)
            {
                var fields = new List<Coordinates>();
                fields = GetConflictFields(queen.X, queen.Y);

                conflicts += fields.Where(field => HasQueenOn(field)).Count();
            }

            return conflicts / 2;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("   ");
            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append(" " + i);
            }
            sb.AppendLine("");
            sb.Append("  ┌");
            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append("──");
            }
            sb.AppendLine("─┐");

            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append((i < 10 ? $" {i}" : $"{i}") + "│");
                for (int j = 1; j < BoardSize + 1; j++)
                {
                    if (HasQueenOn(i, j))
                    {
                        sb.Append(" ♕");
                    }
                    else
                    {
                        sb.Append(" ·");
                    }
                }
                sb.AppendLine(" │");
            }
            
            sb.Append("  └");
            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append("──");
            }
            sb.Append("─┘");

            return sb.ToString();
        }

        public List<Chessboard> GetNeighbourhoodOf()
        {
            return Queens.SelectMany(queen => GetNeighbourhoodOf(queen)).ToList();
        }

        public List<Chessboard> GetNeighbourhoodOf(Queen queen)
        {
            var neighbourhood = new List<Chessboard>();

            neighbourhood.AddRange(queen
                .Position
                .GetAdjacentFields(BoardSize)
                .Where(coords => !HasQueenOn(coords))
                .Select(coords =>
                {
                    var newQueensList = Queens.Where(q => q != queen).ToList();
                    newQueensList.Add(new Queen(coords.X, coords.Y));
                    return new Chessboard(newQueensList);
                }));

            return neighbourhood;
        }
    
        private List<Coordinates> GetConflictFields(int x, int y)
        {
            var coords = new List<Coordinates>();

            int tempX = x;
            int tempY = y;
            while (tempX < BoardSize && tempY < BoardSize)
            {
                coords.Add(new Coordinates(++tempX, ++tempY));
            }

            tempX = x;
            tempY = y;
            while (tempX < BoardSize && tempY > 1)
            {
                coords.Add(new Coordinates(++tempX, --tempY));
            }

            tempX = x;
            tempY = y;
            while (tempX > 1 && tempY > 1)
            {
                coords.Add(new Coordinates(--tempX, --tempY));
            }

            tempX = x;
            tempY = y;
            while (tempX > 1 && tempY < BoardSize)
            {
                coords.Add(new Coordinates(--tempX, ++tempY));
            }

            for (int i = 1; i < BoardSize + 1; i++)
            {
                coords.Add(new Coordinates(x, i));
                coords.Add(new Coordinates(i, y));
            }
            coords.RemoveAll(c => c.X == x && c.Y == y);

            return coords;
        }
    }
}