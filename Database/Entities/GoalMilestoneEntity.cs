using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.API.Database.Entities;

[Table("goal_milestones")]
[PrimaryKey(nameof(GoalId), nameof(MilestoneId))]
public record class GoalMilestoneEntity : IDbEntity
{
    [ForeignKey(nameof(Goal))]
    public required long GoalId { get; set; }
    public GoalEntity? Goal { get; set; }

    [ForeignKey(nameof(Milestone))]
    public required long MilestoneId { get; set; }
    public GoalEntity? Milestone { get; set; }
}
