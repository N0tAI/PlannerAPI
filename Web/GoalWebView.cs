namespace TaskPlanner.API.Web;

public record class GoalWebView
{
    public required ulong Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}
