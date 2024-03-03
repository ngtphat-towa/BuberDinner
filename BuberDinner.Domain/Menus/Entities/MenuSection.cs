using BuberDinner.Domain.Commons.Models;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Menus.Entities;
public class MenuSection : Entity<MenuSectionId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuSection(MenuSectionId menuSectionId, string name, string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}