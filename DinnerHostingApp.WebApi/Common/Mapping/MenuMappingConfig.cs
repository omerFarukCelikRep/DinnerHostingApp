using DinnerHostingApp.Application.Menus.Create;
using DinnerHostingApp.Contracts.Menus;
using DinnerHostingApp.Domain.Menus;
using Mapster;

using MenuSection = DinnerHostingApp.Domain.Menus.Entities.MenuSection;
using MenuItem = DinnerHostingApp.Domain.Menus.Entities.MenuItem;

namespace DinnerHostingApp.WebApi.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : default)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
           .Map(dest => dest.Id, src => src.Id.Value);
    }
}
