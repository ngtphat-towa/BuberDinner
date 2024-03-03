namespace BuberDinner.Domain.Users.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private UserId(Guid value)
    {
        Value = value;
    }
    private UserId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static UserId CreateUnique() => new(Guid.NewGuid());
    public static UserId Create(Guid guid) => new(guid);

    public static implicit operator Guid(UserId data)
    => data.Value;
}