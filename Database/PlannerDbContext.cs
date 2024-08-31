using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class PlannerDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<CategoryDbModel>? Categories { get; set; }
    public virtual DbSet<GoalDbModel>? Goals { get; set; }
    public virtual DbSet<TaskDbModel>? Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        TaskDbModel.ConfigureModel(modelBuilder.Entity<TaskDbModel>());
        CategoryDbModel.ConfigureModel(modelBuilder.Entity<CategoryDbModel>());
        GoalDbModel.ConfigureModel(modelBuilder.Entity<GoalDbModel>());
    }
}
