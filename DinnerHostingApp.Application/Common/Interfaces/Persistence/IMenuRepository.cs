using DinnerHostingApp.Domain.Menus;

namespace DinnerHostingApp.Application.Common.Interfaces.Persistence;
public interface IMenuRepository
{
    void Add(Menu menu);
}
