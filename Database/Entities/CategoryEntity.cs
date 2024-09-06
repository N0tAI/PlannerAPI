using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskPlanner.API.Database.Entities;

[Table("categories")]
public record class CategoryEntity : IKeyedDbEntity, IDbEntity
{
    [Column("category_id")]
    public required long Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }

    public ICollection<TaskEntity>? Tasks { get; set; }
    public ICollection<GoalEntity>? Goals { get; set; }
}
