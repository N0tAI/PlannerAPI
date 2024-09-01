using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TaskPlanner.API.Database.Models;

public class CategoryDbModel
{
    public required long CategoryId { get; set; }
    public required string? Name { get; set; }

    internal static void ConfigureModel(EntityTypeBuilder<CategoryDbModel> builder)
    {
        builder.ToTable("categories")
            .HasKey(c => c.CategoryId);

        builder.Property(p => p.CategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
