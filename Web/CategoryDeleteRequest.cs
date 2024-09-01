namespace TaskPlanner.API.Web;

public record class CategoryDeleteRequest : IWebModel
{
    public long? Id { get; set; }
    public string? Name { get; set; }
}
