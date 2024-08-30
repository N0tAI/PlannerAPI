using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;


namespace TaskPlanner.API.Database.Models;

[Table("goal")]
public class GoalDbModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? Name { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
}
