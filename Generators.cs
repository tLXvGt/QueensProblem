using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Medallion;
using QueensProblem.Models;

namespace QueensProblem
{
    public class Generators
    {
        public static Chessboard IntelligentRandom(int range)
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