namespace TaskPlanner.API.Web;

public record class CategoryCreationRequest : IWebModel
{
    public required string Name { get; set; }
}
