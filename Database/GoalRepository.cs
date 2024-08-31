using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class GoalRepository(PlannerDbContext dbContext)
{
    private PlannerDbContext _context = dbContext;
}
