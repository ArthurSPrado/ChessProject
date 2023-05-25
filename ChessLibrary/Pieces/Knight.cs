using ChessLibrary.BaseEntities;
using ChessLibrary.Enums;
using ChessLibrary.Utils;

namespace ChessLibrary.Pieces;

public class Knight : Piece
{
    public Knight(PieceColor pieceColor, Coordinate position) : base(pieceColor, position)
    {
        Directions = new[]
        {
            new[] { 1, 2 }, new[] { 2, 1 }, new[] { 2, -1 }, new[] { 1, -2 },
            new[] { -1, -2 }, new[] { -2, -1 }, new[] { -2, 1 }, new[] { -1, 2 }
        };
    }

    public override bool IsValidMove(Coordinate destination, Square[,] boardState)
    {
        GetValidMoves(boardState);
        return PossibleMoves.Contains(destination);
    }

    public override void GetValidMoves(Square[,] boardState)
    {
        PossibleMoves.Clear();

        foreach (var direction in Directions)
            SearchPatterns.VerifyUniquePointPossibilities(this, boardState, direction[0], direction[1]);
    }
}