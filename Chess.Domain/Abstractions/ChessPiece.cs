using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Abstractions;

public abstract class ChessPiece : Entity
{
    protected ChessPiece(Color color, Position currentPosition)
        : base(Guid.NewGuid())
    {
        Color = color;
        CurrentPosition = currentPosition;
    }
    public Color Color { get; init; }
    public Position CurrentPosition { get; set; }

    public abstract bool IsValidMove(Position newPosition, Board.Board board);
}