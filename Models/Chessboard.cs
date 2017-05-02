using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensProblem.Models
{
    public class Chessboard
    {
        public List<Queen> Queens;
        public int BoardSize { get; set; }

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
                sb.Append("-" + i);
            }
            sb.AppendLine();

            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append((i < 10 ? $"0{i}" : $"{i}") + "|");
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
                sb.AppendLine("|");
            }
            
            sb.Append("   ");
            for (int i = 1; i < BoardSize + 1; i++)
            {
                sb.Append("--");
            }

            return sb.ToString();
        }
    
        private static List<Coordinates> GetConflictFields(int x, int y)
        {
            var coords = new List<Coordinates>();

            int tempX = x;
            int tempY = y;
            while (tempX < 8 && tempY < 8)
            {
                coords.Add(new Coordinates(++tempX, ++tempY));
            }

            tempX = x;
            tempY = y;
            while (tempX < 8 && tempY > 1)
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
            while (tempX > 1 && tempY < 8)
            {
                coords.Add(new Coordinates(--tempX, ++tempY));
            }

            for (int i = 1; i < 9; i++)
            {
                coords.Add(new Coordinates(x, i));
                coords.Add(new Coordinates(i, y));
            }
            coords.RemoveAll(c => c.X == x && c.Y == y);

            return coords;
        }
    }
}