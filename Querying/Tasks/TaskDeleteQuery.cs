using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Querying.Tasks;

public class TaskDeleteQuery : IRepositoryDeleteQuery<TaskFilterParam>
{
    private PlannerDbContext _context;
    public TaskDeleteQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<TaskFilterParam> filters)
    {
        TaskRepository repo = new(_context);

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<TaskEntity, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.Id == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            return expressions.AsEnumerable();
        });
        
        var entities = repo.GetAll(filterExpressions, false);

        int numDeleted = repo.Delete(entities);

        return numDeleted;
    }
}
