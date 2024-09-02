using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskModelMapper : ITypeMapper<TaskDbModel, TaskCreateRequest>
{
    public TaskDbModel Map(TaskCreateRequest input)
    {
        return new TaskDbModel { TaskId = default, Name = input.Name, Priority = input.Priority };
    }
}
