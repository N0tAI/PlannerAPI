namespace TaskPlanner.API.Web;

public record class CategoryCreationRequest
{
    public required string Name { get; set; }
}
