using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Dinners.ValueObjects;

public sealed class DinnerReservationId : ValueObject
{
    public Guid Value { get; }
    private DinnerReservationId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}