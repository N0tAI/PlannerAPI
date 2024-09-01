namespace TaskPlanner.API.Web;

public record class CategoryWebView
{
    public required long Id { get; set; }
    public required string? Name { get; set; }
}
