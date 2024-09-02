using System;

namespace TaskPlanner.API.Querying;

public interface IRepositoryDeleteQuery<TParams>
    where TParams : class, IQueryFilterParam
{
    // Find by id(s) or value(s) then delete all matching
    public int Execute(IEnumerable<TParams> parameters);
}
