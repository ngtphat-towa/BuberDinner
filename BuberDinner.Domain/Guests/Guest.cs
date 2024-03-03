using BuberDinner.Domain.Commons.Models;
using BuberDinner.Domain.Guests.ValueObjects;

namespace BuberDinner.Domain.Guests;

// TODO: add more value and entites before touching this class
public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    public Guest(GuestId id) : base(id)
    {
    }

    private Guest() { }

}