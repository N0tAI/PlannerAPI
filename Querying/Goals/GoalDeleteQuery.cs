using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Goals;

public class GoalDeleteQuery : IRepositoryDeleteQuery<GoalFilterParam>
{
    private PlannerDbContext _context;
    public GoalDeleteQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<GoalFilterParam> filters)
    {
        GoalRepository repo = new(_context);

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<GoalDbModel, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.GoalId == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            
            return expressions.AsEnumerable();
        });
        
        var items = repo.GetAll(filterExpressions, false);
        
        int numDeleted = repo.Delete(items);

        return numDeleted;
    }

}
