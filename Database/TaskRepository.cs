using System;

namespace TaskPlanner.API.Database;

public class TaskRepository(PlannerDbContext dbContext)
{
    private PlannerDbContext _context = dbContext;
}
