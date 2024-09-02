namespace TaskPlanner.API.Querying.Categories;

public record class CategoryCreateRequest : ICreateRequest
{
    public required string Name { get; set; }
}
