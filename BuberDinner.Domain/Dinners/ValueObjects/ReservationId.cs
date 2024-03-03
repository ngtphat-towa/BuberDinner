using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public Guid Value { get; }
    private ReservationId(Guid value)
    {
        Value = value;
    }
    private ReservationId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static ReservationId CreateUnique() => new(Guid.NewGuid());
    public static ReservationId Create(Guid guid) => new(guid);
}