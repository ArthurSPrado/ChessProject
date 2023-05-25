using ChessLibrary.BaseEntities;

namespace ChessLibrary.Utils;

public class SearchPatterns
{
    private static readonly char[] _columns = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    
    public static void VerifyLongVectorPossibilities(Piece piece, Square[,] boardState, int rowIncrement,
        int colIncrement)
    {
        var row = piece.Position.Row;
        var col = Array.IndexOf(_columns, piece.Position.Column);

        while (IsInRange(row + rowIncrement, col + colIncrement))
        {
            row += rowIncrement;
            col += colIncrement;

            var square = boardState[row, col];

            if (square.Piece is null)
            {
                piece.PossibleMoves.Add(square.Identity);
            }
            else if (square.Piece.Color != piece.Color)
            {
                piece.PossibleMoves.Add(square.Identity);
                break;
            }
            else
            {
                break;
            }
        }
    }

    public static void VerifyUniquePointPossibilities(Piece piece, Square[,] boardState, int rowIncrement,
        int colIncrement)
    {
        var row = piece.Position.Row;;
        var col = Array.IndexOf(_columns, piece.Position.Column);

        row += rowIncrement;
        col += colIncrement;

        if (!IsInRange(row, col)) return;

        if (boardState[row, col].Piece is null)
            piece.PossibleMoves.Add(boardState[row, col].Identity);
        else if (boardState[row, col].Piece.Color != piece.Color)
            piece.PossibleMoves.Add(boardState[row, col].Identity);
    }

    private static bool IsInRange(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}