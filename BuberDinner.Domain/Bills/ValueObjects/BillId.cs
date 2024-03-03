namespace BuberDinner.Domain.Bills.ValueObjects;
public sealed class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private BillId(Guid value)
    {
        Value = value;
    }
    private BillId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Create id
    public static BillId CreateUnique() => new(Guid.NewGuid());
    public static BillId Create(Guid guid) => new(guid);

}