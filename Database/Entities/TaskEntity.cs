using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskPlanner.API.Database.Entities;

[Table("tasks")]
public class TaskEntity : IKeyedDbEntity, IDbEntity
{
    [Column("task_id")]
    public required long Id { get; set; }

    [MaxLength(50)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Comment("Lower number is lower priority")]
    [DefaultValue(0)]
    public int? Priority { get; set; }
    
    public ICollection<CategoryEntity>? Categories { get; set; }
    public ICollection<GoalEntity>? ParentGoals { get; set; }

    public ICollection<TaskEntity>? ParentTasks { get; set; }
    public ICollection<TaskEntity>? Subtasks { get; set; }

    // Attachments feel far too varied to fit a relational db, will likely consider using a different db to eventually implement these
}
