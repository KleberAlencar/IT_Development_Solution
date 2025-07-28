namespace Users.Domain.Shared.Entities;

public abstract class Entity(int id)
{
    public int Id { get; init; } = id;
}