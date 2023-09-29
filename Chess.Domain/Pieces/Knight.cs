using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

public class Knight : ChessPiece
{
    public Knight(Color color, Position currentPosition) 
        : base(color, currentPosition)
    {
    }
    
    public override bool IsValidMove(Position newPosition, Board.Board board)
    {
        var directions = new (int, int)[]
        {
            new(1, 2), new(2, 1)
        };

        var rowDiff = Math.Abs(CurrentPosition.Row - newPosition.Row);
        var colDiff =Math.Abs(CurrentPosition.Column - newPosition.Column);

        if (!directions.Contains((rowDiff, colDiff)))
            return false;
        
        return !board.IsPositionOccupied(newPosition) || board.IsPositionOccupiedByOpponent(newPosition, Color);
    }
}