using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskReadQuery : IRepositoryReadQuery<TaskWebView>
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;
    private IEnumerable<Expression<Func<TaskDbModel, bool>>> _filters;

    public TaskReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public TaskReadQuery(PlannerDbContext context, int max) : this(
        context,
        Enumerable.Empty<Expression<Func<TaskDbModel, bool>>>(),
        max
    )
    {
    }
    public TaskReadQuery(PlannerDbContext context,
                             IEnumerable<Expression<Func<TaskDbModel, bool>>> filters,
                             int max)
    {
        _context = context;
        _filters = filters;
        _retrivalMax = max;
    }

    public IEnumerable<TaskWebView> Execute()
    {
        TaskRepository repo = new(_context);
        TaskViewMapper mapper = new();

        //if(_retrivalMax > 0)
        return repo.GetAll(_filters).Select(mapper.Map);
    }

}
