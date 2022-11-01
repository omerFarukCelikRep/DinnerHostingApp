using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinners.ValueObjects;
using DinnerHostingApp.Domain.Hosts.ValueObjects;
using DinnerHostingApp.Domain.Menus.ValueObjects;
using DinnerHostingApp.Domain.Reservations;

namespace DinnerHostingApp.Domain.Dinners;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner(DinnerId dinnerId,
                   string name,
                   string description,
                   DateTime startDateTime,
                   DateTime endDateTime,
                   string status,
                   bool isPublic,
                   int maxGuests,
                   Price price,
                   string imageUrl,
                   Location location,
                   DateTime createdDateTime,
                   DateTime updatedDateTime,
                   HostId hostId,
                   MenuId menuId) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        MenuId = menuId;
    }

    public static Dinner Create(string name,
                                string description,
                                DateTime startDateTime,
                                DateTime endDateTime,
                                string status,
                                bool isPublic,
                                int maxGuests,
                                Price price,
                                string imageUrl,
                                Location location,
                                HostId hostId,
                                MenuId menuId)
    {
        return new(DinnerId.CreateUnique(),
                   name,
                   description,
                   startDateTime,
                   endDateTime,
                   status,
                   isPublic,
                   maxGuests,
                   price,
                   imageUrl,
                   location,
                   DateTime.UtcNow,
                   DateTime.UtcNow,
                   hostId,
                   menuId);
    }
}