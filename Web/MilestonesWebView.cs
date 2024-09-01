using System.Text.Json.Serialization;

namespace TaskPlanner.API.Web;

public record class MilestonesWebView : GoalWebView
{
    public required long GoalId { get; init; }

}
