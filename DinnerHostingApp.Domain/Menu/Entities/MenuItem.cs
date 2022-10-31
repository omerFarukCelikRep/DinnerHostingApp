using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Menu.ValueObjects;

namespace DinnerHostingApp.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    private MenuItem(MenuId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuId.CreateUnique(), name, description);
    }
}