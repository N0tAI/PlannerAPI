using TaskPlanner.API.Database.Entities;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskViewMapper : ITypeMapper<TaskWebView, TaskEntity>
{
    public TaskWebView Map(TaskEntity input)
    {
        return new TaskWebView { Id = input.Id, Name = input.Name, Priority = input.Priority ?? 0 };
    }
}
