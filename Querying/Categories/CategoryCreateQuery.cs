using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryCreateQuery : IRepositoryCreateQuery<CategoryCreateRequest>
{
    private PlannerDbContext _context;
    public CategoryCreateQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<CategoryCreateRequest> requests)
    {
        var repo = new CategoryRepository(_context);

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(new CategoryDbModel { CategoryId = default, Name = request.Name });

        return numCreated;
    }
}
