namespace TaskPlanner.API.Web;

public record class TaskWebView
{
    public required ulong Id { get; set; }
    public required string? Name { get; set; }
    public int Priority { get; set; } = 0;

}
