using Chess.Domain.Board;

namespace Chess.Domain.Abstractions;

public interface IMovementRules
{
    bool IsValidMove(Position newPosition);
}