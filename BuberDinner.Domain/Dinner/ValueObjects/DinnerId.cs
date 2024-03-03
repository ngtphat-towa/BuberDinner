using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }
    private DinnerId(Guid value)
    {
        Value = value;
    }
    private DinnerId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static DinnerId CreateUnique() => new(Guid.NewGuid());
    public static DinnerId Create(Guid guid) => new(guid);
}