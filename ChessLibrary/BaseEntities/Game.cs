using ChessLibrary.Enums;

namespace ChessLibrary.BaseEntities;

public class Game
{
    public Board Board { get; }
    public Player Player1 { get; }
    public Player Player2 { get; }
    public PieceColor Turn { get; }
}