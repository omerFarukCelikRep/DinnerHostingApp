using DinnerHostingApp.Application.Common.Interfaces.Persistence;
using DinnerHostingApp.Domain.Menus;

namespace DinnerHostingApp.Infrastructure.Persistence;
public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
