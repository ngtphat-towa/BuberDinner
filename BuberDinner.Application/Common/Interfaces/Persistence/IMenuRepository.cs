using BuberDinner.Domain.Menus;

namespace BuberDinner.Application.Common.Interfaces.Persistance;

public interface IMenuRepository
{
    Task Add(Menu menu);
}