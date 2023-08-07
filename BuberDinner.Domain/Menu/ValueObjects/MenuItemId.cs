using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuItemId : ValueObject
{
    public string Value { get; }
    
    private MenuItemId(string itemName)
    {
        Value = $"Item_{itemName}";
    }
    
    public static MenuItemId Create(string itemName)
    {
        return new MenuItemId(itemName);
    }
        
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}