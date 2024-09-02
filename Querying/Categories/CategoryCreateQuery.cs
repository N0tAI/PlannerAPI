using TaskPlanner.API.Database;

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
        CategoryRepository repo = new(_context);
        CategoryModelMapper mapper = new();

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(mapper.Map(request));

        return numCreated;
    }
}
