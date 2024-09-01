namespace TaskPlanner.API.Web;

public record class GoalWebView : IWebModel
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}
