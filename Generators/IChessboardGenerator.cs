using QueensProblem.Models;

namespace QueensProblem.Generators
{
    public interface IChessboardGenerator
    {
        Chessboard Generate(int range);
    }
}