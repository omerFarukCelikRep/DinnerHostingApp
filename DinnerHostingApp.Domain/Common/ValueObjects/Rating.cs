using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; }
    private Rating(double value)
    {
        Value = value;
    }

    public static Rating CreateRating(double rating = 0)
    {
        return new(rating);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}