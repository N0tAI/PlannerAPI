namespace TaskPlanner.API.Web;

public record class TaskCreationRequest : IWebModel
{
    public required string Name { get; init; }
    public int? Priority { get; init; }
}
