using System.Linq.Expressions;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Internal.TypeMapping;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryReadQuery : IRepositoryReadQuery<CategoryWebView>
{
    private PlannerDbContext _context;
    private readonly int _retrivalMax;
    private IEnumerable<Expression<Func<CategoryDbModel, bool>>> _filters;

    public CategoryReadQuery(PlannerDbContext context) : this(context, -1)
    {
    }
    public CategoryReadQuery(PlannerDbContext context, int max) : this(
        context,
        Enumerable.Empty<Expression<Func<CategoryDbModel, bool>>>(),
        max
    )
    {
    }
    public CategoryReadQuery(PlannerDbContext context,
                             IEnumerable<Expression<Func<CategoryDbModel, bool>>> filters,
                             int max)
    {
        _context = context;
        _filters = filters;
        _retrivalMax = max;
    }

    public IEnumerable<CategoryWebView> Execute()
    {
        var mapper = new CategoryViewMapper();
        var repo = new CategoryRepository(_context);

        //if(_retrivalMax > 0)
        return repo.GetAll(_filters).Select(mapper.Map);
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
