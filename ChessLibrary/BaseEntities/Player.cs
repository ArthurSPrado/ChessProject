using ChessLibrary.Enums;

namespace ChessLibrary.BaseEntities;

public class Player
{
    public Player(PieceColor color)
    {
        Color = color;
    }
    
    public PieceColor Color { get; set; }

    public void SuggestAMove(Coordinate coordinates)
    {
        
    }
}