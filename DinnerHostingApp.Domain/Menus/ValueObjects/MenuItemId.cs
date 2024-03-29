using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Menus.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}