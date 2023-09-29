using Chess.Domain.Abstractions;
using Chess.Domain.Board;
using Chess.Domain.Enums;

namespace Chess.Domain.Pieces;

public class Pawn : ChessPiece
{
    public Pawn(Color color, Position currentPosition) 
        : base(color, currentPosition)
    {
    }

    public bool HasMoved { get; set; } = false;
    
    public bool CanEnPassant { get; set; }

    public override bool IsValidMove(Position newPosition, Board.Board board)
    { 
        var direction = Direction.GetDirection(CurrentPosition, newPosition);
        
        //TODO - considerar en passant, captura de peças e promoção
        if((direction != DirectionType.N && Color is Color.White)
           || (direction != DirectionType.S && Color is Color.Black))
            return false;
        
        var distance = Direction.GetDistance(CurrentPosition, newPosition);
        
        switch (distance)
        {
            case 1:
            {
                if(board.IsPositionOccupied(newPosition))
                    return false;
                break;
            }
            case 2:
            {
                if(HasMoved || board.IsPositionOccupied(newPosition))
                    return false;
                break;
            }
            default:
                return false;
        }
    }

}