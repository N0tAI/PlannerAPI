using TaskPlanner.API.Database.Entities;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryViewMapper : ITypeMapper<CategoryWebView, CategoryEntity>
{
    public CategoryWebView Map(CategoryEntity input)
    {
        return new CategoryWebView { Id = input.Id, Name = input.Name };
    }
}
