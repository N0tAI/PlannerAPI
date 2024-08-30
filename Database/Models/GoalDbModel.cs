using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TaskPlanner.API.Database.Models;

[Table("goal")]
public class GoalDbModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public IEnumerable<GoalDbModel>? Milestones { get; set; }
    public IEnumerable<TaskDbModel>? Tasks { get; set; }
    public IEnumerable<CategoryDbModel>? Categories { get; set; }
}
