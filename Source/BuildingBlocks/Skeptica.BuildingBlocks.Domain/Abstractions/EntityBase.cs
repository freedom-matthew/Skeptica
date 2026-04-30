namespace Skeptica.BuildingBlocks.Domain.Abstractions;

public abstract class EntityBase<TId>
    where TId : notnull
{
    public TId Id { get; protected set; } = default!;

    protected EntityBase(TId id)
    {
        Id = id;
    }

    protected EntityBase() { }

    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(EntityBase<TId>? left, EntityBase<TId>? right) => Equals(left, right);

    public static bool operator !=(EntityBase<TId>? left, EntityBase<TId>? right) => !Equals(left, right);
}
