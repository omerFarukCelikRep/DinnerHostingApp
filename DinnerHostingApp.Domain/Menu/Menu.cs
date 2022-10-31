using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinner.ValueObjects;
using DinnerHostingApp.Domain.Host.ValueObjects;
using DinnerHostingApp.Domain.Menu.Entities;
using DinnerHostingApp.Domain.Menu.ValueObjects;
using DinnerHostingApp.Domain.MenuReview.ValueObjects;

namespace DinnerHostingApp.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    private Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
    }
}