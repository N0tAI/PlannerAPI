namespace TaskPlanner.API.Querying.Tasks;

public record class TaskFilterParam : IQueryFilterParam
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
