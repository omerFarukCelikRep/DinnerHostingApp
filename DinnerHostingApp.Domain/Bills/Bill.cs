using DinnerHostingApp.Domain.Bills.ValueObjects;
using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Common.ValueObjects;
using DinnerHostingApp.Domain.Dinners.ValueObjects;
using DinnerHostingApp.Domain.Guests.ValueObjects;
using DinnerHostingApp.Domain.Hosts.ValueObjects;

namespace DinnerHostingApp.Domain.Bills;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }

    private Bill(BillId billId, Price price, DateTime createdDateTime, DateTime updatedDateTime, HostId hostId, DinnerId dinnerId, GuestId guestId) : base(billId)
    {
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        HostId = hostId;
        DinnerId = dinnerId;
        GuestId = guestId;
    }

    public static Bill Create(Price price, HostId hostId, DinnerId dinnerId, GuestId guestId)
    {
        return new(BillId.CreateUnique(), price, DateTime.UtcNow, DateTime.UtcNow, hostId, dinnerId, guestId);
    }
}