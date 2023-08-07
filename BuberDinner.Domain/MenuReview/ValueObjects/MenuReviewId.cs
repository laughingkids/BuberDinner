using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject 
{
    public string Value { get; }
    
    private MenuReviewId(
        MenuId menuId, 
        DinnerId dinnerId, 
        GuestId guestId)
    {
        Value = $"MenuReview_{menuId.Value}_{dinnerId.Value}_{guestId.Value}";
    }
    
    private MenuReviewId(string value)
    {
        Value = value;
    }
    
    public static MenuReviewId Create(
        MenuId menuId, 
        DinnerId dinnerId, 
        GuestId guestId)
    {
        return new (menuId, dinnerId, guestId);
    }

    public static MenuReviewId Created(string value)
    {
        return new(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}