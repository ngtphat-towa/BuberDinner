namespace BuberDinner.Domain.MenuReviews.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }
    private MenuReviewId() { }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Create Id
    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());
    public static MenuReviewId Create(Guid value) => new(value);


}