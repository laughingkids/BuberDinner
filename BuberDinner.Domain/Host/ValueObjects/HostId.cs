using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private HostId(string value)
    {
        Value = value;
    }
 
    public string Value { get; }

    public static HostId Create(UserId userId)
    {
        return new HostId($"Host_{userId.Value}");
    }
    
    public static HostId Create(string hostId)
    {
        return new HostId(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}