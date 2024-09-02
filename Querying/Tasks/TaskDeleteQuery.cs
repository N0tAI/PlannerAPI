using TaskPlanner.API.Database;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskDeleteQuery : IRepositoryDeleteQuery<TaskDeleteRequest>
{
    private PlannerDbContext _context;
    public TaskDeleteQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<TaskDeleteRequest> requests)
    {
        var repo = new TaskRepository(_context);

        int numDeleted = 0;
        foreach(var request in requests)
        {
            // Todo merge all queries against non null values into one
            // (will likely benefit perf)
            if(request.Id is not null)
            {
                var items = repo.GetAll(false, m => m.TaskId == request.Id);
                foreach(var item in items)
                    numDeleted += repo.Delete(item);
            }
            if(request.Name is not null)
            {
                var items = repo.GetAll(false, m => m.Name == request.Name);
                foreach(var item in items)
                    numDeleted += repo.Delete(item);
            }
        }

        return numDeleted;
    }
}
