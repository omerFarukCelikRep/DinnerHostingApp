using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinners.ValueObjects;
using DinnerHostingApp.Domain.Hosts.ValueObjects;
using DinnerHostingApp.Domain.Menus.Entities;
using DinnerHostingApp.Domain.Menus.ValueObjects;
using DinnerHostingApp.Domain.MenuReviews.ValueObjects;

namespace DinnerHostingApp.Domain.Menus;

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

    private Menu(MenuId menuId,
                 HostId hostId,
                 string name,
                 string description,
                 AverageRating averageRating,
                 DateTime createdDateTime,
                 DateTime updatedDateTime,
                 List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        AverageRating = averageRating;
        _sections = sections;
    }

    public static Menu Create(HostId hostId,
                              string name,
                              string description,
                              List<MenuSection>? sections = null)
    {
        return new(MenuId.CreateUnique(), hostId, name, description, AverageRating.CreateNew(),  DateTime.UtcNow, DateTime.UtcNow, sections ?? new());
    }
}