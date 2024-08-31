using Microsoft.AspNetCore.Mvc;

namespace TaskPlanner.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            return StatusCode(StatusCodes.Status501NotImplemented, ApiResponse.Empty);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostAsync()
        {
            return StatusCode(StatusCodes.Status501NotImplemented, ApiResponse.Empty);
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> DeleteAsync()
        {
            return StatusCode(StatusCodes.Status501NotImplemented, ApiResponse.Empty);
        }
    }
}
