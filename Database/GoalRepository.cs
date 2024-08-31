using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class GoalRepository(PlannerDbContext dbContext) : DbSetBasicRepository<GoalDbModel>(dbContext, dbContext.Goals!)
{
    private PlannerDbContext _context = dbContext;
}
