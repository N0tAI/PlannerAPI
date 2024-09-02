namespace TaskPlanner.API.Querying.Categories;

public record class CategoryFilterParam : IQueryFilterParam
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
