using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository _categoryRepo;

        public CategoryController(CategoryRepository repo) 
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var categories = await Task.Run(() => _categoryRepo.GetAll());
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(categories));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CategoryDbModel model)
        {
            if(await Task.Run(() => _categoryRepo.TryCreate(model)))
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(model, "Could not add the model to the API"));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var category = await Task.Run(() => _categoryRepo.TryGetOne(c => c.CategoryId == id));
            if(category is null)
                return StatusCode(StatusCodes.Status404NotFound);
            await Task.Run(() => _categoryRepo.Delete(category));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
