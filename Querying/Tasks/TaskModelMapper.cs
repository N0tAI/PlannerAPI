using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskModelMapper : ITypeMapper<TaskEntity, TaskCreateRequest>
{
    public TaskEntity Map(TaskCreateRequest input)
    {
        return new TaskEntity { Id = default, Name = input.Name, Description = input.Description, Priority = input.Priority };
    }
}
