using DinnerHostingApp.Domain.Bills.ValueObjects;
using DinnerHostingApp.Domain.Common.Models;
using DinnerHostingApp.Domain.Guests.ValueObjects;
using DinnerHostingApp.Domain.Reservations.ValueObjects;

namespace DinnerHostingApp.Domain.Reservations;

public sealed class Reservation : AggregateRoot<ReservationId>
{
    public int GuestCount { get; }
    public string ReservationStatus { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public GuestId GuestId { get; }
    public BillId BillId { get; }
    private Reservation(ReservationId reservationId, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        GuestId = guestId;
        BillId = billId;
    }

    public static Reservation Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId)
    {
        return new(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow);
    }
}