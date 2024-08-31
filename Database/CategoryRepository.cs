using System;

namespace TaskPlanner.API.Database;

public class CategoryRepository(PlannerDbContext dbContext)
{
    private PlannerDbContext _context = dbContext;
}
