using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskPlanner.API.Database.Entities;

[Table("goals")]
public record class GoalEntity : IKeyedDbEntity, IDbEntity
{
    [Column("goal_id")]
    public required long Id { get; set; }

    [MaxLength(50)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
    
    public ICollection<CategoryEntity>? Categories { get; set; }
    public ICollection<TaskEntity>? Tasks { get; set; }

    public ICollection<GoalEntity>? Milestones { get; set; }
    public ICollection<GoalEntity>? ParentGoals { get; set; }
}
