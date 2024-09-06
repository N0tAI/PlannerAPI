using TaskPlanner.API.Database.Entities;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Goals;

public class GoalViewMapper : ITypeMapper<GoalWebView, GoalEntity>
{
    public GoalWebView Map(GoalEntity input)
    {
        return new GoalWebView { Id = input.Id, Name = input.Name, Description = input.Description };
    }
}
