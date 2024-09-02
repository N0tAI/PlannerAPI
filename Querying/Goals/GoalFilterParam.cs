namespace TaskPlanner.API.Querying.Goals;

public record class GoalFilterParam : IQueryFilterParam
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
