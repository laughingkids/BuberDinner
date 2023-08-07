using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuId : ValueObject
{
    public Guid Value { get; }
    
    private MenuId(Guid value)
    {
        Value = value;
    }
    
    public static MenuId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
        
    public static MenuId Create(Guid menuId)
    {
        return new (menuId);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}