using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Goals;

public class GoalViewMapper : ITypeMapper<GoalWebView, GoalDbModel>
{
    public GoalWebView Map(GoalDbModel model)
    {
        return new GoalWebView { Id = model.GoalId, Name = model.Name, Description = model.Description };
    }
}
