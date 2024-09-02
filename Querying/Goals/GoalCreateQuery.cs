using TaskPlanner.API.Database;

namespace TaskPlanner.API.Querying.Goals;

public class GoalCreateQuery : IRepositoryCreateQuery<GoalCreateRequest>
{
    private PlannerDbContext _context;
    public GoalCreateQuery(PlannerDbContext context)
    {
        _context = context;
    }

    public int Execute(IEnumerable<GoalCreateRequest> requests)
    {
        GoalRepository repo = new(_context);
        GoalModelMapper mapper = new();

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(mapper.Map(request));

        return numCreated;
    }
}
