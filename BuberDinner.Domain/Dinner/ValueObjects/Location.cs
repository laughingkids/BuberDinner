using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    public string Address { get; }
    public string Name { get; }
    public decimal Latitude { get; }
    public decimal Longitude { get; }
    
    private Location(string address, string name, decimal latitude, decimal longitude)
    {
        Address = address;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }
    
    public static Location Create(string address, string name, decimal latitude, decimal longitude)
    {
        return new (address, name, latitude, longitude);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
        yield return Name;
        yield return Latitude;
        yield return Longitude;
    }
}