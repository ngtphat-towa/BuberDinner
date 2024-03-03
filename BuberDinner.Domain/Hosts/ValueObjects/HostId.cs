namespace BuberDinner.Domain.Hosts.ValueObjects;
public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId(Guid value)
    {
        Value = value;
    }
    private HostId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static HostId CreateUnique() => new(Guid.NewGuid());
    public static HostId Create(Guid guid) => new(guid);
}