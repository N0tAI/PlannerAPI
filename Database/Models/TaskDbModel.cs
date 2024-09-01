using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskPlanner.API.Database.Models;

public class TaskDbModel : IDbModel
{
    public required long TaskId { get; set; }
    public required string? Name { get; set; }
    public int? Priority { get; set; } = 0;
    public long? GoalId { get; set; }
    public GoalDbModel? Goal { get; set; }
    public ICollection<TaskDbModel>? SubTasks { get; set; }
    public ICollection<CategoryDbModel>? Categories { get; set; }

    // Attachments feel far too varied to fit a relational db, will likely consider using a different db to eventually implement these
    internal static void ConfigureModel(EntityTypeBuilder<TaskDbModel> builder)
    {
        builder.ToTable("tasks")
            .HasKey(t => t.TaskId);

        builder.Property(p => p.TaskId)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.Priority)
            .HasDefaultValue(0)
            .HasComment("Lower number is lower priority");
        
        builder.HasOne(e => e.Goal)
            .WithMany(g => g.Tasks)
            .HasForeignKey(t => t.GoalId)
            .IsRequired(false);

        builder.HasMany(t => t.SubTasks)
            .WithMany()
            .UsingEntity<TaskToSubTaskJoinDbModel>(
                right => right.HasOne(st => st.ParentTask).WithMany().IsRequired(),
                left => left.HasOne(st => st.ChildTask).WithMany().IsRequired()
            )
            .ToTable("tasks_subtasks");
        
        builder.HasMany(t => t.Categories)
            .WithMany()
            .UsingEntity("task_categories");
    }
}
