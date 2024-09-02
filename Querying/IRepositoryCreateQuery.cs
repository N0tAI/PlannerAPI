using System;

namespace TaskPlanner.API.Querying;

public interface IRepositoryCreateQuery<TCreateRequest>
    where TCreateRequest : class, ICreateRequest
{
    // Validate and insert data
    public int Execute(IEnumerable<TCreateRequest> requests);
}
