using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Menus.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}