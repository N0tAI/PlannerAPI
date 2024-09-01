using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;
using TaskPlanner.API.Web;

namespace TaskPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CategoryRepository _categoryRepo;

        public CategoriesController(CategoryRepository repo) 
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var categories = await Task.Run(() => _categoryRepo.GetAll());
            var numCategories = categories.Count();
            var message = $"Found {numCategories} categories";
            if(numCategories == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(categories, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var category = await Task.Run(() => _categoryRepo.TryGetOne(c => c.CategoryId == id));
            if(category is null)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a category of id {id}"));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(category, $"Found category: ${category.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoryCreationRequest categoryRequest)
        {
            if(await Task.Run(() => _categoryRepo.TryCreate(new CategoryDbModel { CategoryId = 0, Name = categoryRequest.Name})))
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(categoryRequest, "Could not add the model to the API"));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromQuery] long id)
        {
            var category = await Task.Run(() => _categoryRepo.TryGetOne(c => c.CategoryId == id));
            if(category is null)
                return StatusCode(StatusCodes.Status404NotFound);
            await Task.Run(() => _categoryRepo.Delete(category));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
