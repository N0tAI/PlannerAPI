namespace TaskPlanner.API.Web;

public record class TaskCreationRequest
{
    public required string Name { get; init; }
    public int? Priority { get; init; }
}
