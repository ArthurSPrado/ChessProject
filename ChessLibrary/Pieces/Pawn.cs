using ChessLibrary.BaseEntities;
using ChessLibrary.Enums;

namespace ChessLibrary.Pieces;

public class Pawn : Piece
{
    private readonly int _rowIncrement;
    private readonly int _startingRow;
    public bool CanCaptureEnPassant { get; set; } 
    
    public Pawn(PieceColor pieceColor, Coordinate position) : base(pieceColor, position)
    {
        CanCaptureEnPassant = false;
        _rowIncrement = (Color == PieceColor.White) ? -1 : 1;
        _startingRow = (Color == PieceColor.White) ? 6 : 1;
    }

    public override bool IsValidMove(Coordinate destination, Square[,] boardState)
    {
        GetValidMoves(boardState);
        return PossibleMoves.Contains(destination);
    }

    public override void GetValidMoves(Square[,] boardState)
    {
        PossibleMoves.Clear();
        
        VerifyFowardMoves(boardState);
        VerifyCaptureMoves(boardState);
        VerifyEnPassant(boardState);
    }

    private void VerifyCaptureMoves(Square[,] boardState)
    {
        int leftDiagonalRow = Position.Row + _rowIncrement;
        int leftDiagonalCol = Array.IndexOf(_columns,Position.Column) - 1;
        if (IsInRange(leftDiagonalRow, leftDiagonalCol) && boardState[leftDiagonalRow, leftDiagonalCol].Piece != null && boardState[leftDiagonalRow, leftDiagonalCol].Piece.Color != Color)
        {
            PossibleMoves.Add(new Coordinate(leftDiagonalRow, _columns[leftDiagonalCol]));
        }

        int rightDiagonalRow = Position.Row + _rowIncrement;
        int rightDiagonalCol = Array.IndexOf(_columns,Position.Column) + 1;
        if (IsInRange(rightDiagonalRow, rightDiagonalCol) && boardState[rightDiagonalRow, rightDiagonalCol].Piece != null && boardState[rightDiagonalRow, rightDiagonalCol].Piece.Color != Color)
        {
            PossibleMoves.Add(new Coordinate(rightDiagonalRow, _columns[rightDiagonalCol]));
        }
    }
    private void VerifyFowardMoves(Square[,] boardState)
    {
        int forwardRow = Position.Row + _rowIncrement;
        int column = Array.IndexOf(_columns, Position.Column);
        
        if (IsInRange(forwardRow, column) && boardState[forwardRow, column].Piece == null)
        {
            PossibleMoves.Add(new Coordinate(forwardRow, Position.Column)); 

            // Verifica o movimento duplo no primeiro movimento do peão
            if (Position.Row == _startingRow)
            {
                int doubleForwardRow = Position.Row + 2 * _rowIncrement;
                if (IsInRange(doubleForwardRow, column) && boardState[doubleForwardRow, column].Piece == null)
                {
                    PossibleMoves.Add(new Coordinate(doubleForwardRow, Position.Column));
                    CanCaptureEnPassant = true;
                }
            } 
        }
    }
    private void VerifyEnPassant(Square[,] boardState)
    {
        int column = Array.IndexOf(_columns, Position.Column);
        
        if (IsInRange(Position.Row, column - 1) && boardState[Position.Row, column - 1].Piece is Pawn leftAdjacentPawn && leftAdjacentPawn.CanCaptureEnPassant)
        {
            PossibleMoves.Add(new Coordinate(Position.Row + _rowIncrement, _columns[column-1]));
        }

        if (IsInRange(Position.Row, column + 1) && boardState[Position.Row, column + 1].Piece is Pawn rightAdjacentPawn && rightAdjacentPawn.CanCaptureEnPassant)
        {
            PossibleMoves.Add(new Coordinate(Position.Row + _rowIncrement, _columns[column+1]));
        }
    }
    private static bool IsInRange(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}