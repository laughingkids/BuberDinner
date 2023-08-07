using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Bill.ValueObjects;

public class BillId : ValueObject
{
    public string Value { get; }
    
    private BillId(string value)
    {
        Value = value;
    }

    private BillId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Bill_{dinnerId.Value}_{guestId.Value}";
    }
    
    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new (dinnerId, guestId);
    }
    
    public static BillId Create(string value)
    {
        return new (value);
    }
        
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}