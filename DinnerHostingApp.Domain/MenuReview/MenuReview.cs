using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinner.ValueObjects;
using DinnerHostingApp.Domain.Guest.ValueObjects;
using DinnerHostingApp.Domain.Host.ValueObjects;
using DinnerHostingApp.Domain.Menu.ValueObjects;
using DinnerHostingApp.Domain.MenuReview.ValueObjects;

namespace DinnerHostingApp.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }

    private MenuReview(MenuReviewId menuReviewId,
                       Rating rating,
                       string comment,
                       DateTime createdDateTime,
                       DateTime updatedDateTime,
                       HostId hostId,
                       MenuId menuId,
                       GuestId guestId,
                       DinnerId dinnerId) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    public static MenuReview Create(Rating rating,
                                    string comment,
                                    HostId hostId,
                                    MenuId menuId,
                                    DinnerId dinnerId,
                                    GuestId guestId)
    {
        return new(MenuReviewId.CreateUnique(), rating, comment, DateTime.UtcNow, DateTime.UtcNow, hostId, menuId, guestId, dinnerId);
    }
}