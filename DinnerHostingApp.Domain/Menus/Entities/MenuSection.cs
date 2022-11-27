using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Menus.ValueObjects;

namespace DinnerHostingApp.Domain.Menus.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public string Name { get; }
    public string Description { get; }
    private readonly List<MenuItem> _items = new();
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }
}