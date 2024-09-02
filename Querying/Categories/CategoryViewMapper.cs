using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryViewMapper : ITypeMapper<CategoryWebView, CategoryDbModel>
{
    public CategoryWebView Map(CategoryDbModel model)
    {
        return new CategoryWebView { Id = model.CategoryId, Name = model.Name };
    }
}
