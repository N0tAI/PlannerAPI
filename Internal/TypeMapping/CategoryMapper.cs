using System;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Internal.TypeMapping;

public class CategoryMapper : IModelViewMapper<CategoryDbModel, CategoryWebView>
{
    public CategoryWebView Map(CategoryDbModel model)
    {
        return new CategoryWebView { Id = model.CategoryId, Name = model.Name };
    }

    public CategoryDbModel Map(CategoryWebView view)
    {
        return new CategoryDbModel { CategoryId = view.Id, Name = view.Name };
    }
}
