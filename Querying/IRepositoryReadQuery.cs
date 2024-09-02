using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying;

public interface IRepositoryReadQuery<TWebView, TFilterParams>
    where TWebView : class, IWebModel
    where TFilterParams : class, IQueryFilterParam
{
    // find matching model(s) and return found
    // paginated query support
    public IEnumerable<TWebView> Execute(IEnumerable<TFilterParams> filters);
}
