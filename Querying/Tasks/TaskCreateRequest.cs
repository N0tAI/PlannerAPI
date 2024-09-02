namespace TaskPlanner.API.Querying.Tasks;

public record class TaskCreateRequest : ICreateRequest
{
    public required string Name { get; init; }
    public int? Priority { get; init; }
}
