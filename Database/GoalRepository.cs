using System;

namespace TaskPlanner.API.Database;

public class GoalRepository(PlannerDbContext dbContext)
{
    private PlannerDbContext _context = dbContext;
}
