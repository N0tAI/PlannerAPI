using System;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Goals;

public class GoalCreateQuery : IRepositoryCreateQuery<GoalCreateRequest>
{
    private PlannerDbContext _context;
    public GoalCreateQuery(PlannerDbContext context)
    {
        _context = context;
    }

    public int Execute(IEnumerable<GoalCreateRequest> requests)
    {
        var repo = new GoalRepository(_context);

        int numCreated = 0;
        foreach(var request in requests)
            numCreated += repo.Create(new GoalDbModel { GoalId = default, Name = request.Name, Description = request.Description });

        return numCreated;
    }
}
