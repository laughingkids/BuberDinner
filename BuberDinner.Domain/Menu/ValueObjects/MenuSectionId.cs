using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    private MenuSectionId(string sectionName)
    {
        Value = $"Section_{sectionName}";
    }
    public string Value { get; }
    
    public static MenuSectionId Create(string sectionName)
    {
        return new MenuSectionId(sectionName);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}