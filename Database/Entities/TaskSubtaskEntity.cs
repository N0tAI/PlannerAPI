using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.API.Database.Entities;

[Table("task_subtasks")]
[PrimaryKey(nameof(TaskId), nameof(SubtaskId))]
public record class TaskSubtaskEntity : IDbEntity
{
    [ForeignKey(nameof(Task))]
    public required long TaskId { get; set; }
    public TaskEntity? Task { get; set; }

    [ForeignKey(nameof(Subtask))]
    public required long SubtaskId { get; set; }
    public TaskEntity? Subtask { get; set; }
}
