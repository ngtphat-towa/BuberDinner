namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class DinnerId : AggregateRootId<Guid>
{

    public override Guid Value { get; protected set; }

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