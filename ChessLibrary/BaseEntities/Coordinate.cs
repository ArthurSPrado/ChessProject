namespace ChessLibrary.BaseEntities;

public class Coordinate
{
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