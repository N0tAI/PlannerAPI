using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Internal.TypeMapping;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Goals;

public class GoalReadQuery
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;
    private IEnumerable<Expression<Func<GoalDbModel, bool>>> _filters;

    public GoalReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public GoalReadQuery(PlannerDbContext context, int max) : this(
        context,
        Enumerable.Empty<Expression<Func<GoalDbModel, bool>>>(),
        max
    )
    {
    }
    public GoalReadQuery(PlannerDbContext context,
                             IEnumerable<Expression<Func<GoalDbModel, bool>>> filters,
                             int max)
    {
        _context = context;
        _filters = filters;
        _retrivalMax = max;
    }

    public IEnumerable<GoalWebView> Execute()
    {
        var mapper = new GoalViewMapper();
        var repo = new GoalRepository(_context);

        //if(_retrivalMax > 0)
        return repo.GetAll(_filters).Select(mapper.Map);
    }
}
