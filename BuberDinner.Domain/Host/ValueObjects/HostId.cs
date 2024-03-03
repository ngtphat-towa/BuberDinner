using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Hosts.ValueObjects;
public sealed class HostId : ValueObject
{
    public Guid Value { get; }

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