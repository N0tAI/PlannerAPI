using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Database;

public class CategoryRepository(PlannerDbContext dbContext) : DbSetBasicRepository<CategoryEntity>(dbContext, dbContext.Categories!)
{
    private PlannerDbContext _context = dbContext;
}
