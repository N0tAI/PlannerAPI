namespace TaskPlanner.API.Querying.Categories;

public record class CategoryCreateRequest
{
    public required string Name { get; set; }
}
