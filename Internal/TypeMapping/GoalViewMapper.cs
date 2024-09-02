using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Internal.TypeMapping;

public class GoalViewMapper : IModelViewMapper<GoalDbModel, GoalWebView>
{
    public GoalWebView Map(GoalDbModel model)
    {
        return new GoalWebView { Id = model.GoalId, Name = model.Name, Description = model.Description };
    }

    public GoalDbModel Map(GoalWebView view)
    {
        return new GoalDbModel { GoalId = view.Id, Name = view.Name, Description = view.Description };
    }
}
