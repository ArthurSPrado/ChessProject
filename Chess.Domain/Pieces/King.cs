using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

public class King : ChessPiece
{
    public King(Color color, Position currentPosition)
        : base( color, currentPosition)
    {
    }
    
    public bool HasMoved { get; set; }

    public override bool IsValidMove(Position newPosition, Board.Board board)
    {
        return Direction.GetDistance(CurrentPosition, newPosition) == 1
               && (board.IsPositionOccupiedByOpponent(newPosition, Color) 
                   || !board.IsPositionOccupied(newPosition));
    }
}