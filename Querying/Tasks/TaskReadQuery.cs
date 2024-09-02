using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskReadQuery : IRepositoryReadQuery<TaskWebView, TaskFilterParam>
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;

    public TaskReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public TaskReadQuery(PlannerDbContext context, int max)
    {
        _context = context;
        _retrivalMax = max;
    }

    public IEnumerable<TaskWebView> Execute(IEnumerable<TaskFilterParam> filters)
    {
        TaskRepository repo = new(_context);
        TaskViewMapper mapper = new();

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<TaskDbModel, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.TaskId == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            return expressions.AsEnumerable();
        });
        
        return repo.GetAll(filterExpressions).Select(mapper.Map);
    }

}
