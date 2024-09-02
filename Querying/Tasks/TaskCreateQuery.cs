using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskCreateQuery : IRepositoryCreateQuery<TaskCreateRequest>
{
    private PlannerDbContext _context;
    public TaskCreateQuery(PlannerDbContext context)
    {
        _context = context;
    }

    public int Execute(IEnumerable<TaskCreateRequest> requests)
    {
        var repo = new TaskRepository(_context);

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(new TaskDbModel { TaskId = default, Name = request.Name, Priority = request.Priority });

        return numCreated;
    }
}
