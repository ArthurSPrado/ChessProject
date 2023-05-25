namespace ChessLibrary.BaseEntities;

public class Coordinate
{
    public static readonly string[] Columns = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
    public Coordinate()
    {
        
    }
    public Coordinate(int row, string column)
    {
        Row = row;
        Column = column;
    }
    
    public int Row { get; set; }
    public string Column { get; set; }
}