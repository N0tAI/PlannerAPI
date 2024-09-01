using System;
using TaskPlanner.API.Database;
using TaskPlanner.API.Internal.TypeMapping;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryCreateQuery : IRepositoryCreateQuery<CategoryCreationRequest>
{
    private PlannerDbContext _context;
    public CategoryCreateQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<CategoryCreationRequest> requests)
    {
        var mapper = new CategoryCreateMapper();
        var repo = new CategoryRepository(_context);

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(mapper.Map(request));

        return numCreated;
    }
}
