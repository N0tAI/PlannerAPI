using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskViewMapper : ITypeMapper<TaskWebView, TaskDbModel>
{
    public TaskWebView Map(TaskDbModel model)
    {
        return new TaskWebView { Id = model.TaskId, Name = model.Name, Priority = model.Priority ?? 0 };
    }
}
