using BuberDinner.Domain.Commons.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; }
    public string Description { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    private Location(
        string name,
        string description,
        double latitude,
        double longitude)
    {
        Name = name;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
    }
#pragma warning disable CS8618 
    private Location() { }
#pragma warning restore CS8618 

    public static Location CreateNew(
        string name,
        string description,
        double latitude,
        double longitude)
    {
        return new(
            name,
            description,
            latitude,
            longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Description;
        yield return Latitude;
        yield return Longitude;
    }
}