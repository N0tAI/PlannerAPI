using System;

namespace TaskPlanner.API.Internal.TypeMapping;

public interface IModelViewMapper<TDbModel, TWebView>
{
    TWebView Map(TDbModel model);
    TDbModel Map(TWebView view);
}
