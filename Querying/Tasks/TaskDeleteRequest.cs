namespace TaskPlanner.API.Querying.Tasks;

public record class TaskDeleteRequest : IDeleteRequest
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
