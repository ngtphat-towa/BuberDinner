using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }
    private MenuItemId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());
    public static MenuItemId Create(Guid guid) => new(guid);
}