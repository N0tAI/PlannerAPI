using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryDeleteQuery : IRepositoryDeleteQuery<CategoryFilterParam>
{
    private PlannerDbContext _context;
    public CategoryDeleteQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<CategoryFilterParam> filters)
    {
        CategoryRepository repo = new(_context);

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<CategoryDbModel, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.CategoryId == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            return expressions.AsEnumerable();
        });
        
        var items = repo.GetAll(filterExpressions, false);
        
        int numDeleted = repo.Delete(items);

        return numDeleted;
    }
}
