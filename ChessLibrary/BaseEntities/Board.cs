using ChessLibrary.Pieces;
using ChessLibrary.Utils;

namespace ChessLibrary.BaseEntities;

public class Board
{
    private Square [,] BoardState { get; set; }
    public int TurnCounter { get; set; }

    public Board()
    {
        BoardState = BoardInitializer.Initialize();
        TurnCounter = 1;
    }

    public void MovePiece(Coordinate origin, Coordinate destination)
    {
        
    }

    public bool IsCheckMate()
    {
        
    }

    public bool IsKingInCheck(King king)
    {
        
    }

    public bool IsStaleMate(Player currentPlayer)
    {
        
    }
}