using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Querying.Tasks;

namespace TaskPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private PlannerDbContext _context;

        public TasksController(PlannerDbContext context) 
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var tasks = await Task.Run(new TaskReadQuery(_context).Execute);
            var numTasks = tasks.Count();
            var message = $"Found {numTasks} tasks";
            if(numTasks == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(tasks, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var tasks = await Task.Run(new TaskReadQuery(_context, [t => t.TaskId == id], 1).Execute);
            if(tasks.Count() < 1)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a task of id {id}"));
            
            var task = tasks.First();
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(task, $"Found task: {task.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostAsync([FromBody] TaskCreateRequest createRequest)
        {
            if(await Task.Run(() => new TaskCreateQuery(_context).Execute([ createRequest ])) == 1)
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(createRequest, "Could not add the model to the API"));
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> DeleteAsync(long id)
            => DeleteAsync(new TaskDeleteRequest{ Id = id });

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] TaskDeleteRequest request)
        {
            var numDeleted = await Task.Run(() => new TaskDeleteQuery(_context).Execute([ request ]));
            if(numDeleted == 0)
                return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
