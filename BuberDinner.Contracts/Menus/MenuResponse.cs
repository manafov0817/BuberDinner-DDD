﻿namespace BuberDinner.Contracts.Menus
{
    public record MenuResponse(Guid Id,
                               string Name,
                               string Description,
                               float? AverageRating,
                               string HostId,
                               List<string> DinnerIds,
                               List<string> MenuReviewIds,
                               List<MenuSectionResponse> Sections,
                               DateTime CreatedDateTime,
                               DateTime UpdatedDateTime);

    public record MenuSectionResponse(Guid Id,
                                      string Name,
                                      string Description,
                                      List<MenuItemResponse> Items);

    public record MenuItemResponse(Guid Id,
                                     string Name,
                                     string Description);
}
