﻿using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(string Name,
                                    string Description,
                                    string HostId,
                                    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;
    public record MenuSectionCommand(string Name,
                                     string Description,
                                     List<MenuItemCommand> MenuItems);
    public record MenuItemCommand(string Name,
                                  string Description);
}
