
namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private MenuId(Guid value)
    {
        Value = value;
    }
    private MenuId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Create id
    public static MenuId CreateUnique() => new(Guid.NewGuid());
    public static MenuId Create(Guid guid) => new(guid);

}