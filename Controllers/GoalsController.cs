using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Querying.Goals;

namespace TaskPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private PlannerDbContext _context;

        public GoalsController(PlannerDbContext context) 
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var goals = await Task.Run(new GoalReadQuery(_context).Execute);
            var numGoals = goals.Count();
            var message = $"Found {numGoals} goals";
            if(numGoals == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));

            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(goals, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var goals = await Task.Run(new GoalReadQuery(_context, [g => g.GoalId == id], 1).Execute);
            if(goals.Count() < 1)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a goal of id {id}"));

            var goal = goals.First();
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(goal, $"Found goal: {goal.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] GoalCreateRequest request)
        {
            if(await Task.Run(() => new GoalCreateQuery(_context).Execute([ request ])) == 1)
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(request, "Could not add the model to the API"));
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> DeleteAsync(long id)
            => DeleteAsync(new GoalDeleteRequest{ Id = id });

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] GoalDeleteRequest request)
        {
            var numDeleted = await Task.Run(() => new GoalDeleteQuery(_context).Execute([ request ]));
            if(numDeleted == 0)
                return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
