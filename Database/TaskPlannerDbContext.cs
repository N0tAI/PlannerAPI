using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class TaskPlannerDbContext : DbContext
{
    public virtual DbSet<GoalDbModel>? Goals { get; set; }
    public TaskPlannerDbContext() : base()
    {
    }

    public TaskPlannerDbContext(DbContextOptions options) : base(options)
    {
    }
    // Add DB Models here
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
