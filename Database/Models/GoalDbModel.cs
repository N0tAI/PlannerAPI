using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskPlanner.API.Database.Models;

public class GoalDbModel
{
    public long GoalId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ICollection<TaskDbModel>? Tasks { get; set; }
    public ICollection<GoalDbModel>? Milestones { get; set; }
    public ICollection<CategoryDbModel>? Categories { get; set; }


    internal static void ConfigureModel(EntityTypeBuilder<GoalDbModel> builder)
    {
        builder.ToTable("goals")
            .HasKey(c => c.GoalId);

        builder.Property(p => p.GoalId)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .HasMaxLength(240)
            .IsRequired(false);

        // Relation to tasks handled by the task model

        builder.HasMany(t => t.Milestones)
            .WithMany()
            .UsingEntity<GoalToMilestoneJoinDbModel>(
                right => right.HasOne(st => st.ParentGoal).WithMany().IsRequired(),
                left => left.HasOne(st => st.ChildGoal).WithMany().IsRequired()
            )
            .ToTable("goal_milestones");

        builder.HasMany(t => t.Categories)
            .WithMany()
            .UsingEntity("goal_categories");
    }
}
