using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public float Value { get; }
    private Rating(float value)
    {
        Value = value;
    }

    public static Rating CreateRating(float rating = 0)
    {
        return new(rating);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}