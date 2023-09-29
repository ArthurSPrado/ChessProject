using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

public class Pawn : ChessPiece
{
    public Pawn(Color color, Position currentPosition) 
        : base(color, currentPosition)
    {
    }
    
    public bool HasMoved { get; set; }
    
    public bool CanEnPassant { get; set; }

    public override bool IsValidMove(Position newPosition, Board.Board board)
    {
        throw new NotImplementedException();
    }
}