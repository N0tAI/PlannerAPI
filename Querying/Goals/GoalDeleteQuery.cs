using System;
using TaskPlanner.API.Database;

namespace TaskPlanner.API.Querying.Goals;

public class GoalDeleteQuery : IRepositoryDeleteQuery<GoalDeleteRequest>
{
    private PlannerDbContext _context;
    public GoalDeleteQuery(PlannerDbContext context)
    {
        _context = context;
    }
    public int Execute(IEnumerable<GoalDeleteRequest> requests)
    {
        var repo = new GoalRepository(_context);

        int numDeleted = 0;
        foreach(var request in requests)
        {
            // Todo merge all queries against non null values into one
            // (will likely benefit perf)
            if(request.Id is not null)
            {
                var items = repo.GetAll(false, m => m.GoalId == request.Id);
                foreach(var item in items)
                    numDeleted += repo.Delete(item);
            }
            if(request.Name is not null)
            {
                var items = repo.GetAll(false, m => m.Name == request.Name);
                foreach(var item in items)
                    numDeleted += repo.Delete(item);
            }
            if(request.Description is not null)
            {
                var items = repo.GetAll(false, m => m.Description == request.Name);
                foreach(var item in items)
                    numDeleted += repo.Delete(item);
            }
        }

        return numDeleted;
    }

}
