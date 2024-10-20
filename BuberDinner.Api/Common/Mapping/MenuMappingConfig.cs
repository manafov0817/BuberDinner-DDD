﻿using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using Mapster;
using MenuSection = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace BuberDinner.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
                  .Map(dest => dest.HostId, src => src.HostId)
                  .Map(dest => dest, src => src.request);

            config.NewConfig<Menu, MenuResponse>()
                  .Map(dest => dest.Id, src => src.Id.Value)
                  .Map(dest => dest.AverageRating, src => src.AverageRating != null && src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0)
                  .Map(dest => dest.HostId, src => src.HostId.Value)
                  .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                  .Map(dest => dest.HostId, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                  .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
