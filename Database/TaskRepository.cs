using Microsoft.EntityFrameworkCore;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Database;

public class TaskRepository(PlannerDbContext dbContext)
{
    private PlannerDbContext _context = dbContext;

    public virtual IEnumerable<TaskDbModel> GetAll()
        => _context.Tasks!.AsEnumerable();

}
