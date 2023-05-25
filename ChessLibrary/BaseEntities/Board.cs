using ChessLibrary.Pieces;
using ChessLibrary.Utils;
using System.Linq;

namespace ChessLibrary.BaseEntities
{
    public class Board
    {
        private Square[,] BoardState { get; set; }
        public int TurnCounter { get; set; }

        public Board()
        {
            BoardState = BoardInitializer.Initialize();
            TurnCounter = 1;
        }

        public void MovePiece(Coordinate origin, Coordinate destination)
        {
            if (!CanPieceOnOriginMoveToDestination(origin, destination))
            {
                //TODO tratamento de movimentação não possível
                return;
            }

            var originSquare = GetSquare(origin);
            var piece = originSquare.Piece;
            var destinationSquare = GetSquare(destination);

            if (IsPawnAndIsMovingTwoSquaresForward(piece, origin, destinationSquare))
            {
                ((Pawn)piece).CanCaptureEnPassant = true;
            }

            MovePieceToDestination(originSquare, destinationSquare, piece);
            TurnCounter++;
        }

        private Square GetSquare(Coordinate coordinate)
        {
            return BoardState[coordinate.Row, Array.IndexOf(Coordinate.Columns, coordinate.Column)];
        }

        private bool IsPawnAndIsMovingTwoSquaresForward(Piece piece, Coordinate origin, Square destinationSquare)
        {
            return piece is Pawn pawn && destinationSquare == GetSquare(new Coordinate(pawn.Position.Row + 2 * pawn.RowIncrement, origin.Column));
        }

        private void MovePieceToDestination(Square originSquare, Square destinationSquare, Piece piece)
        {
            originSquare.Piece = null;
            destinationSquare.Piece = piece;
            piece.Position = destinationSquare.Identity;
        }

        private bool CanPieceOnOriginMoveToDestination(Coordinate origin, Coordinate destination)
        {
            var originSquare = GetSquare(origin);
            var piece = originSquare.Piece;
            return piece.IsValidMove(destination, BoardState);
        }

        //TODO  Métodos não implementados 

        // public bool IsCheckMate()
        // public bool IsKingInCheck(King king)
        // public bool IsStaleMate(Player currentPlayer)

        private bool IsThereEnPassantPossibility()
        {
            return BoardState.Cast<Square>().Any(x => x.Piece is Pawn { CanCaptureEnPassant: true });
        }
    }
}