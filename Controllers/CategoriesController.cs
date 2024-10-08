using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Querying.Categories;

namespace TaskPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private PlannerDbContext _context;

        public CategoriesController(PlannerDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var categories = await Task.Run(() => new CategoryReadQuery(_context).Execute(Enumerable.Empty<CategoryFilterParam>()));
            var numCategories = categories.Count();
            var message = $"Found {numCategories} categories";
            if(numCategories == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));

            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(categories, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var categories = await Task.Run(() => new CategoryReadQuery(_context, 1).Execute([ new CategoryFilterParam { Id = id } ]));
            if(categories.Count() < 1)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a category of id {id}"));

            var category = categories.First();
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(category, $"Found category: {category.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryCreateRequest createRequest)
        {
            if(await Task.Run(() => new CategoryCreateQuery(_context).Execute([ createRequest ])) == 1)
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(createRequest, "Could not add the model to the API"));
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> DeleteAsync(long id)
            => DeleteAsync(new CategoryFilterParam { Id = id });

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] CategoryFilterParam filter)
        {
            var numDeleted = await Task.Run(() => new CategoryDeleteQuery(_context).Execute([ filter ]));
            if(numDeleted == 0)
                return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
