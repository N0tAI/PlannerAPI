using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Goals;

public class GoalModelMapper : ITypeMapper<GoalDbModel, GoalCreateRequest>
{
    public GoalDbModel Map(GoalCreateRequest input)
    {
        return new GoalDbModel { GoalId = default, Name = input.Name, Description = input.Description };
    }
}
