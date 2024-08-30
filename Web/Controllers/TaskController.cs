using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Web.API;

namespace TaskPlanner.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAsync()
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
