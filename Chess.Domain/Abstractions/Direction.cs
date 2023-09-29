using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Abstractions;

public static class Direction
{
    public static DirectionType GetDirection(Position initial, Position final)
    {
        var rowDiff = initial.Row - final.Row;
        var colDiff = initial.Column - final.Column;

        switch (rowDiff)
        {
            case 0 when colDiff == 0:
                throw new InvalidOperationException("The initial and final positions are the same.");
            case 0:
                return colDiff > 0 ? DirectionType.W : DirectionType.E;
        }

        if (colDiff == 0) return rowDiff > 0 ? DirectionType.S : DirectionType.N;

        if (Math.Abs(rowDiff) == Math.Abs(colDiff))
            return (rowDiff, colDiff) switch
            {
                (> 0, > 0) => DirectionType.SW,
                (> 0, < 0) => DirectionType.SE,
                (< 0, > 0) => DirectionType.NW,
                _ => DirectionType.NE
            };

        throw new InvalidOperationException("The initial and final positions are not in the same direction.");
    }

    public static int GetDistance(Position currentPosition, Position newPosition)
    {
        var rowDistance = Math.Abs(currentPosition.Row - newPosition.Row);
        var columnDistance = Math.Abs((int)currentPosition.Column - (int)newPosition.Column);

        return Math.Max(rowDistance, columnDistance);
    }

    public static bool ScanPath(DirectionType direction, int distance, ChessPiece piece, Board.Board board)
    {
        return direction switch
        {
            DirectionType.N => IsValidMoveInDirection(board, piece, distance, 0, 1),
            DirectionType.NE => IsValidMoveInDirection(board, piece, distance, 1, 1),
            DirectionType.E => IsValidMoveInDirection(board, piece, distance, 1, 0),
            DirectionType.SE => IsValidMoveInDirection(board, piece, distance, 1, -1),
            DirectionType.S => IsValidMoveInDirection(board, piece, distance, 0, -1),
            DirectionType.SW => IsValidMoveInDirection(board, piece, distance, -1, -1),
            DirectionType.W => IsValidMoveInDirection(board, piece, distance, -1, 0),
            DirectionType.NW => IsValidMoveInDirection(board, piece, distance, -1, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    private static bool IsValidMoveInDirection(Board.Board board, ChessPiece piece, int distance, int rowIncrement, int columnIncrement)
    {
        for (var i = 1; i <= distance; i++)
        {
            var row = piece.CurrentPosition.Row + i * rowIncrement;
            var column = piece.CurrentPosition.Column + i * columnIncrement;
            var position = new Position(row, (int)column);
            if (board.IsPositionOccupied(position)
                && board.IsPositionOccupiedByAlly(position, piece.Color))
                return false;
        }

        return true;
    }
    
    private static bool IsInRange(int row, int col)
    {
        return row is >= 1 and <= 8 && col is >= 1 and <= 8;
    }
}