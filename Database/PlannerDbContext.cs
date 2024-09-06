using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Database;

public class PlannerDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<CategoryEntity>? Categories { get; set; }
    public virtual DbSet<GoalEntity>? Goals { get; set; }
    public virtual DbSet<TaskEntity>? Tasks { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder confBuilder)
    {
        // Add convention to either remove the `entity` suffix or use the dbset name
        base.ConfigureConventions(confBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach(var entityType in modelBuilder.Model.GetEntityTypes())
        {
            const string tableSuffix = "Entity";
            var tableName = entityType.GetTableName()!;
            if(tableName.EndsWith(tableSuffix))
                entityType.SetTableName(tableName.Remove(tableName.Length - tableSuffix.Length));
        }

        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.Tasks)
            .WithMany(t => t.Categories)
            .UsingEntity("task_categories");
        
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.Goals)
            .WithMany(g => g.Categories)
            .UsingEntity("goal_categories");

        modelBuilder.Entity<GoalEntity>()
            .HasMany(g => g.Tasks)
            .WithMany(t => t.ParentGoals)
            .UsingEntity("goal_tasks");

        // Configure milestones
        modelBuilder.Entity<GoalEntity>()
            .HasMany(g => g.Milestones)
            .WithMany(g => g.ParentGoals)
            .UsingEntity<GoalMilestoneEntity>(
                r => r.HasOne(j => j.Goal).WithMany() ,
                l => l.HasOne(j => j.Milestone).WithMany()
            );

        // Configure subtasks
        modelBuilder.Entity<TaskEntity>()
            .HasMany(t => t.Subtasks)
            .WithMany(t => t.ParentTasks)
            .UsingEntity<TaskSubtaskEntity>(
                r => r.HasOne(j => j.Task).WithMany(),
                l => l.HasOne(j => j.Subtask).WithMany()
            );
        

        modelBuilder.Entity<TaskEntity>()
            .Property(p => p.Priority)
            .HasDefaultValue(0);
    }
}
