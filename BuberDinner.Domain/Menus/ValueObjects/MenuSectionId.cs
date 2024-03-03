using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    private MenuSectionId() { }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    // Create id
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public static MenuSectionId Create(Guid guid) => new(guid);
}