using System.Text.Json.Serialization;

namespace TaskPlanner.API.Web;

public record class MilestonesWebView : GoalWebView
{
    public required ulong GoalId { get; init; }

}
