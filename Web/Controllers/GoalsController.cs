using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private GoalRepository _goalRepo;

        public GoalsController(GoalRepository repo) 
        {
            _goalRepo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var goals = await Task.Run(() => _goalRepo.GetAll());
            var numGoals = goals.Count();
            var message = $"Found {numGoals} goals";
            if(numGoals == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(goals, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var goal = await Task.Run(() => _goalRepo.TryGetOne(g => g.GoalId == id));
            if(goal is null)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a goal of id {id}"));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(goal, $"Found goal: ${goal.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] GoalCreationRequest goalRequest)
        {
            if(await Task.Run(() => _goalRepo.TryCreate(new GoalDbModel { GoalId = 0, Name = goalRequest.Name, Description = goalRequest.Description })))
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(goalRequest, "Could not add the model to the API"));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromQuery] long id)
        {
            var goal = await Task.Run(() => _goalRepo.TryGetOne(g => g.GoalId == id));
            if(goal is null)
                return StatusCode(StatusCodes.Status404NotFound);
            await Task.Run(() => _goalRepo.Delete(goal));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
