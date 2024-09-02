namespace TaskPlanner.API.Querying.Tasks;

public record class TaskCreateRequest
{
    public required string Name { get; init; }
    public int? Priority { get; init; }
}
