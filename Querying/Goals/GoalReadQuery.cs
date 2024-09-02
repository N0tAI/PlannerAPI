using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Goals;

public class GoalReadQuery : IRepositoryReadQuery<GoalWebView, GoalFilterParam>
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;

    public GoalReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public GoalReadQuery(PlannerDbContext context, int max)
    {
        _context = context;
        _retrivalMax = max;
    }

    public IEnumerable<GoalWebView> Execute(IEnumerable<GoalFilterParam> filters)
    {
        GoalRepository repo = new(_context);
        GoalViewMapper mapper = new();

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<GoalDbModel, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.GoalId == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            return expressions.AsEnumerable();
        });
        
        return repo.GetAll(filterExpressions).Select(mapper.Map);
    }
}
