namespace BuberDinner.Domain.Guests.ValueObjects;
public sealed class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private GuestId(Guid value)
    {
        Value = value;
    }
    private GuestId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Create id
    public static GuestId CreateUnique() => new(Guid.NewGuid());
    public static GuestId Create(Guid guid) => new(guid);

}