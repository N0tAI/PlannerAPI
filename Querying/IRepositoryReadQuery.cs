using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying;

public interface IRepositoryReadQuery<TWebView>
    where TWebView : class, IWebModel
{
    // find matching model(s) and return found
    // paginated query support
    public IEnumerable<TWebView> Execute();
}
