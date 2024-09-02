using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Internal.TypeMapping;

public class TaskViewMapper : IModelViewMapper<TaskDbModel, TaskWebView>
{
    public TaskWebView Map(TaskDbModel model)
    {
        return new TaskWebView { Id = model.TaskId, Name = model.Name, Priority = model.Priority ?? 0 };
    }

    public TaskDbModel Map(TaskWebView view)
    {
        return new TaskDbModel { TaskId = view.Id, Name = view.Name, Priority = view.Priority };
    }
}
