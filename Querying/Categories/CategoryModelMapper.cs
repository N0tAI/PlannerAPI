using TaskPlanner.API.Database.Entities;

namespace TaskPlanner.API.Querying.Categories;

public class CategoryModelMapper : ITypeMapper<CategoryEntity, CategoryCreateRequest>
{
    public CategoryEntity Map(CategoryCreateRequest input)
    {
        return new CategoryEntity { Id = default, Name = input.Name };
    }
}
