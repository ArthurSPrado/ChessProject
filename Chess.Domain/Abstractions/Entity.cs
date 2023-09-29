namespace Chess.Domain.Abstractions;

public class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; init; }
}