namespace TaskPlanner.API.Querying.Categories;

public record class CategoryCreationRequest
{
    public required string Name { get; set; }
}
