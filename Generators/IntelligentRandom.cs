using System;
using System.Collections.Generic;
using System.Linq;
using Medallion;
using QueensProblem.Models;

namespace QueensProblem.Generators
{
    public class IntelligentRandom : IChessboardGenerator
    {
        public Chessboard Generate(int range)
        {
            var queens = new List<Queen>();
            var numbers = Enumerable.Range(1, range).ToArray();
            
            numbers.Shuffle();
            for (int i = 0; i < range; i++)
            {
                Queen q = new Queen(numbers[i], i+1);
                queens.Add(q);
            }

            return new Chessboard(queens);
        }
    }
}