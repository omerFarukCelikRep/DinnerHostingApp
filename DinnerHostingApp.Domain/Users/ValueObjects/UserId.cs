using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Users.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }
    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}