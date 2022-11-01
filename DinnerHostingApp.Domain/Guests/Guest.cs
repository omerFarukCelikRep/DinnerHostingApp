using DinnerHostingApp.Domain.Bills.ValueObjects;
using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinners.ValueObjects;
using DinnerHostingApp.Domain.Guests.ValueObjects;
using DinnerHostingApp.Domain.MenuReviews.ValueObjects;
using DinnerHostingApp.Domain.Users.ValueObjects;

namespace DinnerHostingApp.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId>
{
    private List<DinnerId> _upcomingDinnerIds = new();
    private List<DinnerId> _pastDinnerIds = new();
    private List<DinnerId> _pendingDinnerIds = new();
    private List<BillId> _billIds = new();
    private List<MenuReviewId> _menuReviewIds = new();
    private List<Rating> _ratings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }

    public UserId UserId { get; }
}