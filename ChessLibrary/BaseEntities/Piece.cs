using ChessLibrary.Enums;

namespace ChessLibrary.BaseEntities;

public abstract class Piece
{
    protected readonly string[] _columns = { "a", "b", "c", "d", "e", "f", "g", "h" };
    protected int[][] Directions;
    protected Piece(PieceColor pieceColor, Coordinate position)
    {
        Color = pieceColor;
        Position = position;
    }

    public PieceColor Color { get; set; }
    public Coordinate Position { get; set; }
    public List<Coordinate> PossibleMoves { get; set; }

    public abstract bool IsValidMove(Coordinate destination, Square[,] boardState);
    public abstract void GetValidMoves(Square[,] boardState);
    
    
}