using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            // Menu Section
            sections: request.Sections.ConvertAll(
                section => MenuSection.Create(
                    name: section.Name,
                    description: section.Description,
                    // Menu Item
                    items: section.Items.ConvertAll(
                        item => MenuItem.Create(
                            name: item.Name,
                            description: item.Description
                        )
                    )
                )
            )
        );
        await _menuRepository.Add(menu);

        return menu;
    }
}