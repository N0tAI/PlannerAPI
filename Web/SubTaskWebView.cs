namespace TaskPlanner.API.Web;

public record class SubTaskWebView : TaskWebView
{
    public required ulong ParentId { get; set; }
}
