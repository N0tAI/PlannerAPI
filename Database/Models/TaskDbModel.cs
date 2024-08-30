using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.API.Database.Models;

[Table("task")]
public class TaskDbModel
{
    public string? Name { get; set; }
    public int? Priority { get; set; }
    public IEnumerable<TaskDbModel>? SubTasks { get; set; }
    public IEnumerable<TaskDbModel>? RequiredTasks { get; set; }
    public IEnumerable<CategoryDbModel>? Categories { get; set; }

    // Attachments feel far too varied to fit a relational db, will likely consider using a different db to eventually implement these
}
