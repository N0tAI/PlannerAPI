namespace TaskPlanner.API.Web;

public record class SubTaskWebView : TaskWebView, IWebModel
{
    public required long ParentId { get; set; }
}
