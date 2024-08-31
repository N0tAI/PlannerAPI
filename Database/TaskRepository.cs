using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class TaskRepository(PlannerDbContext dbContext) : DbSetBasicRepository<TaskDbModel>(dbContext, dbContext.Tasks!)
{
    private PlannerDbContext _context = dbContext;
}
