using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Create Menu
            List<MenuSection> menuSections = command.Sections.ConvertAll(menuSection => MenuSection.Create(menuSection.Name,
                                                                                                           menuSection.Description,
                                                                                                           menuSection.MenuItems.ConvertAll(menuItem =>
                                                                                                                                    MenuItem.Create(menuItem.Name,
                                                                                                                                    menuItem.Description))));

            var menu = Menu.Create(command.Name, command.Description, HostId.Create(command.HostId), menuSections);

            // Persist Menu
            _menuRepository.Add(menu);

            // Return Menu
            return menu;
        }
    }
}
