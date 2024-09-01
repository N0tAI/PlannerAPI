namespace TaskPlanner.API.Web;

public record class SubTaskWebView : TaskWebView
{
    public required long ParentId { get; set; }
}
