using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

public class Rook : ChessPiece
{
    public Rook(Color color, Position currentPosition) 
        : base(color, currentPosition)
    {
    }

    public override bool IsValidMove(Position newPosition, Board.Board board)
    {
        var direction = Direction.GetDirection(CurrentPosition, newPosition);
        
        if(direction != DirectionType.N
           && direction != DirectionType.S
           && direction != DirectionType.E
           && direction != DirectionType.W)
            return false;
        
        var distance = Direction.GetDistance(CurrentPosition, newPosition);

        return Direction.ScanPath(direction, distance, this, board);
    }
}