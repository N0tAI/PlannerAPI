namespace TaskPlanner.API.Web;

public record class GoalCreationRequest : IWebModel
{

    public required string Name { get; set; }
    public string? Description { get; set; } = null;
}
