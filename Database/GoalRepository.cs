using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Database;

public class GoalRepository(PlannerDbContext dbContext) : DbSetBasicRepository<GoalEntity>(dbContext, dbContext.Goals!)
{
    private PlannerDbContext _context = dbContext;
}
