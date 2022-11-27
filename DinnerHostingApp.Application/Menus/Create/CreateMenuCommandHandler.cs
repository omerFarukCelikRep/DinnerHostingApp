using DinnerHostingApp.Application.Common.Interfaces.Persistence;
using DinnerHostingApp.Domain.Hosts.ValueObjects;
using DinnerHostingApp.Domain.Menus;
using DinnerHostingApp.Domain.Menus.Entities;

using ErrorOr;

using MediatR;

namespace DinnerHostingApp.Application.Menus.Create;
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section => MenuSection.Create
            (
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create
                (
                    item.Name,
                    item.Description
                ))
            )));

        _menuRepository.Add(menu);

        return menu;
    }
}
