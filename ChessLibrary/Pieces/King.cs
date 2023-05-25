using ChessLibrary.BaseEntities;
using ChessLibrary.Enums;
using ChessLibrary.Utils;

namespace ChessLibrary.Pieces;

public class King : Piece
{
    public King(PieceColor pieceColor, Coordinate position) : base(pieceColor, position)
    {
        Directions = new[]
        {
            new[] { 0, 1 }, new[] { 1, 1 }, new[] { 1, 0 }, new[] { 1, -1 }, new[] { 0, -1 }, new[] { -1, -1 },
            new[] { -1, 0 }, new[] { -1, 1 }
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