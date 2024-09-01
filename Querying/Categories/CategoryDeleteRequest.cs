namespace TaskPlanner.API.Querying.Categories;

public record class CategoryDeleteRequest
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
