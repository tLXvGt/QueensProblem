using System.Collections.Generic;
using System.Linq;
using QueensProblem.Models;

namespace QueensProblem
{
    public static class Tabu
    {
        public static List<Chessboard> GetNeighbourhoodOf(Chessboard chessboard)
        {
            return chessboard?.Queens
                .SelectMany(queen => GetNeighbourhoodOf(queen, chessboard)).ToList();
        }

        public static List<Chessboard> GetNeighbourhoodOf(Queen queen, Chessboard chessboard)
        {
            var list = new List<Chessboard>();

            list.AddRange(queen
                .Position
                .GetAdjacentFields(chessboard.BoardSize)
                .Where(coords => !chessboard.HasQueenOn(coords))
                .Select(coords =>
                {
                    var newQueensList = chessboard.Queens.Where(q => q != queen).ToList();
                    newQueensList.Add(new Queen(coords.X, coords.Y));
                    return new Chessboard(newQueensList);
                }));

            return list;
        }
    }
}