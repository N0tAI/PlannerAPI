using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Querying.Goals;

public class GoalModelMapper : ITypeMapper<GoalEntity, GoalCreateRequest>
{
    public GoalEntity Map(GoalCreateRequest input)
    {
        return new GoalEntity { Id = default, Name = input.Name, Description = input.Description };
    }
}
