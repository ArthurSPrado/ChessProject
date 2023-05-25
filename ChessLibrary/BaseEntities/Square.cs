using ChessLibrary.Enums;

namespace ChessLibrary.BaseEntities;

public class Square
{
    public Square(SquareColor color)
    {
        Color = color;
    }
    
    public Coordinate Identity { get; set; }
    public SquareColor Color { get; set; }
    public Piece Piece { get; set; }
}