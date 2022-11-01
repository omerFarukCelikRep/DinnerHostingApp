using DinnerHostingApp.Domain.Bills.ValueObjects;
using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Dinners.ValueObjects;
using DinnerHostingApp.Domain.Guests.ValueObjects;

namespace DinnerHostingApp.Domain.Dinners.Entities;

public sealed class DinnerReservation : Entity<DinnerReservationId>
{
    public int GuestCount { get; }
    public string ReservationStatus { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public GuestId GuestId { get; }
    public BillId BillId { get; }
    private DinnerReservation(DinnerReservationId dinnerReservationId, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime) : base(dinnerReservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        GuestId = guestId;
        BillId = billId;
    }

    public static DinnerReservation Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId)
    {
        return new(DinnerReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow);
    }
}