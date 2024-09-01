namespace TaskPlanner.API.Web;

public record class CategoryWebView
{
    public required ulong Id { get; set; }
    public required string? Name { get; set; }
}
