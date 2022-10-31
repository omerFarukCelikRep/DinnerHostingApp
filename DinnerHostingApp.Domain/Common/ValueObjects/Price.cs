using DinnerHostingApp.Domain.Common.Models;

namespace DinnerHostingApp.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public double Amount { get; }
    public string Currency { get; }

    public static Price CreateNew(double amount = 0, string currency = "USD")
    {
        return new(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}