using System.Text.Json.Serialization;

namespace TaskPlanner.API.Web;

// Adding the IWebModel inheritance just to ensure conformance in the unknown future
public record class MilestonesWebView : GoalWebView, IWebModel
{
    public required long GoalId { get; init; }

}
