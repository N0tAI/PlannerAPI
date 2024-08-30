using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TaskPlanner.API.Database.Models;

[Table("category")]
public class CategoryDbModel
{
    public string? Name { get; set; }
}
