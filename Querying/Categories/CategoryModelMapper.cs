using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryModelMapper : ITypeMapper<CategoryDbModel, CategoryCreateRequest>
{
    public CategoryDbModel Map(CategoryCreateRequest input)
    {
        return new CategoryDbModel { CategoryId = default, Name = input.Name };
    }
}
