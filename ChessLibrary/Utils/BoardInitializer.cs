using ChessLibrary.BaseEntities;
using ChessLibrary.Enums;
using ChessLibrary.Pieces;

namespace ChessLibrary.Utils;

public class BoardInitializer
{
    public static Square[,] Initialize()
    {
        var squares = new Square[8, 8];
        string[] backRowColumns = { "a", "b", "c", "d", "e", "f", "g", "h" };

        for (var row = 0; row < 8; row++)
            for (var col = 0; col < 8; col++)
                squares[row, col] = new Square((row + col) % 2 == 0 ? SquareColor.White : SquareColor.Black)
                {
                    Identity = new Coordinate(row, backRowColumns[col])
                };

        SetPieces(squares, PieceColor.White, 7, backRowColumns);
        SetPieces(squares, PieceColor.Black, 0, backRowColumns);
        SetPawns(squares, PieceColor.White, 6, backRowColumns);
        SetPawns(squares, PieceColor.Black, 1, backRowColumns);

        return squares;
    }

    private static void SetPieces(Square[,] squares, PieceColor color, int row, string[] columns)
    {
        Type[] pieceTypes =
        {
            typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight),
            typeof(Rook)
        };

        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i];
            var pieceType = pieceTypes[i];
            squares[row, i].Piece =
                (Piece)Activator.CreateInstance(pieceType, color, new Coordinate { Column = column, Row = row + 1 });
        }
    }

    private static void SetPawns(Square[,] squares, PieceColor color, int row, string[] columns)
    {
        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i];
            squares[row, i].Piece = new Pawn(color, new Coordinate { Column = column, Row = row + 1 });
        }
    }
}