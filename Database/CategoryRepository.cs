using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class CategoryRepository(PlannerDbContext dbContext) : DbSetBasicRepository<CategoryDbModel>(dbContext, dbContext.Categories!)
{
    private PlannerDbContext _context = dbContext;
}
