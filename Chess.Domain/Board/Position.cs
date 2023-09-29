using Chess.Domain.Enums;

namespace Chess.Domain.Board;

public readonly struct Position 
{
    public int Row { get;}
    public Column Column{ get;}

    public Position(string positionString)
    {
        if (positionString.Length != 2)
        {
            throw new ArgumentException("A posição deve ser uma string de 2 caracteres, por exemplo, 'A1'.");
        }

        Column = (Column)Enum.Parse(typeof(Column), positionString[0].ToString().ToUpper());
        Row = int.Parse(positionString[1].ToString());
    }
    
    public Position(int row, int column)
    {
        Row = row;
        Column = (Column)Enum.Parse(typeof(Column), column.ToString());
    }

    public override string ToString()
    {
        return $"{Column}{Row}";
    }
    
    public static Position ToObject(string positionString)
    {
        return new Position(positionString);
    }
}