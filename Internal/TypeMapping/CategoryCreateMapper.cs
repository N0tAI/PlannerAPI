using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Internal.TypeMapping;

public class CategoryCreateMapper : IModelViewMapper<CategoryDbModel, CategoryCreationRequest>
{
    public CategoryCreationRequest Map(CategoryDbModel model)
        => throw new NotImplementedException();

    public CategoryDbModel Map(CategoryCreationRequest view)
        => new CategoryDbModel { CategoryId = default, Name = view.Name };
}
