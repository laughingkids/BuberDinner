using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    
    public double Value { get; private set; }
    public int NumRatings { get; private set; }
    
    public static AverageRating CreateNew(double value = 0, int numRatings = 0)
    {
        return new AverageRating(value, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / (NumRatings + 1);
    }
    
    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / (NumRatings - 1);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}