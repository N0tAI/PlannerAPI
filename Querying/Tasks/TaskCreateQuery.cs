using TaskPlanner.API.Database;

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
        TaskRepository repo = new(_context);
        TaskModelMapper mapper = new(); 

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(mapper.Map(request));

        return numCreated;
    }
}
