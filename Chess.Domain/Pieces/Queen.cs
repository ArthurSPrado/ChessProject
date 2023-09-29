using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

internal class Queen : ChessPiece
{
    public Queen(Color color, Position currentPosition) 
        : base( color, currentPosition)
    {
    }

    public override bool IsValidMove(Position newPosition, Board.Board board)
    {
        var direction = Direction.GetDirection(CurrentPosition, newPosition);
        var distance = Direction.GetDistance(CurrentPosition, newPosition);

        return Direction.ScanPath(direction, distance, this, board);
    }
}