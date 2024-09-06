using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Database;

public class TaskRepository(PlannerDbContext dbContext) : DbSetBasicRepository<TaskEntity>(dbContext, dbContext.Tasks!)
{
    private PlannerDbContext _context = dbContext;
}
