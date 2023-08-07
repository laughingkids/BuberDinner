using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Price : ValueObject
{
    public string Amount { get; }
    public string Currency { get; }
    private Price(string amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Price Create(string amount, string currency)
    {
        return new (amount, currency);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}