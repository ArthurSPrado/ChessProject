using Chess.Domain.Abstractions;
using Chess.Domain.Enums;
using Chess.Domain.Pieces;

namespace Chess.Domain.Board;

public class Board
{
    private Dictionary<Position, ChessPiece?> Squares { get; } = new();

    private ChessPiece? this[Position position]
    {
        get =>
            Squares.TryGetValue(position, out var chessPiece)
                ? chessPiece
                : null;

        set =>
            Squares[position] = value;
        
    }

    public void TryMove(Position currentPosition, Position newPosition)
    {
        
    }

    public bool IsPositionOccupiedByAlly(Position position, Color color)
    {
        if(!IsPositionOccupied(position))
            return false;
        
        return this[position]!.Color == color;
    }

    public bool IsPositionOccupiedByOpponent(Position position, Color color)
    {
        if(!IsPositionOccupied(position))
            return false;
        
        return this[position]!.Color != color;
    }

    public bool IsPositionOccupied(Position position)
    {
        return this[position] != null;
    }

    public void InitializeBoard()
    {
        for (var row = 1; row <= 8; row++)
        for (var column = 1; column <= 8; column++)
            switch (row)
            {
                case 2 or 7:
                {
                    var color = row == 7 ? Color.Black : Color.White;
                    this[new Position(row, column)] = new Pawn(color, new Position(row, column));
                    continue;
                }
                case 1 or 8:
                {
                    var color = row == 8 ? Color.Black : Color.White;

                    this[new Position(row, column)] = column switch
                    {
                        1 or 8 => new Rook(color, new Position(row, column)),
                        2 or 7 => new Knight(color, new Position(row, column)),
                        3 or 6 => new Bishop(color, new Position(row, column)),
                        4 => new Queen(color, new Position(row, column)),
                        5 => new King(color, new Position(row, column)),
                        _ => this[new Position(row, column)]
                    };
                    continue;
                }
            }
    }
}