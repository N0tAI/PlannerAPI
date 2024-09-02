using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryReadQuery : IRepositoryReadQuery<CategoryWebView, CategoryFilterParam>
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;

    public CategoryReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public CategoryReadQuery(PlannerDbContext context, int max)
    {
        _context = context;
        _retrivalMax = max;
    }

    public IEnumerable<CategoryWebView> Execute(IEnumerable<CategoryFilterParam> filters)
    {
        CategoryRepository repo = new(_context);
        CategoryViewMapper mapper = new();

        var filterExpressions = filters.SelectMany(f => {
            List<Expression<Func<CategoryDbModel, bool>>> expressions = new();
            if(f.Id is not null)
                expressions.Add(m => m.CategoryId == f.Id);
            if(f.Name is not null)
                expressions.Add(m => m.Name == f.Name);
            return expressions.AsEnumerable();
        });
        
        return repo.GetAll(filterExpressions).Select(mapper.Map);
    }
    /*var filterSize = filters.Count();
        if(filterSize == 0)
            return 
        
        // Aggregate returns the initial value if the list has size 1
        var filter = filters.Aggregate((e1, e2) => {
            var combinedBody = Expression.AndAlso(e1.Body, e2.Body);
            return Expression.Lambda<Func<TModel, bool>>(combinedBody, e1.Parameters);
        });
    */
}
