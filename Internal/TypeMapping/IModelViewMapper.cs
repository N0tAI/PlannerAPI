using TaskPlanner.API.Database;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Internal.TypeMapping;

public interface IModelViewMapper<TDbModel, TWebView>
    where TDbModel : IDbModel
    where TWebView : IWebModel
{
    TWebView Map(TDbModel model);
    TDbModel Map(TWebView view);
}
