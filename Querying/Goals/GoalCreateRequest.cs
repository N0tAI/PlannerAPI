namespace TaskPlanner.API.Querying.Goals;

public record class GoalCreateRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
