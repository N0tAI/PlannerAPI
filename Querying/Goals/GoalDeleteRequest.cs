namespace TaskPlanner.API.Querying.Goals;

public record class GoalDeleteRequest : IDeleteRequest
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
