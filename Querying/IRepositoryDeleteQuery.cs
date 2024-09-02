using System;

namespace TaskPlanner.API.Querying;

public interface IRepositoryDeleteQuery<TDeleteRequest>
    where TDeleteRequest : class, IDeleteRequest
{
    // Find by id(s) or value(s) then delete all matching
    public int Execute(IEnumerable<TDeleteRequest> requests);
}
