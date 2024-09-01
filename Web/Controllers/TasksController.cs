using Microsoft.AspNetCore.Mvc;
using TaskPlanner.API.Database;
using TaskPlanner.API.Database.Models;

namespace TaskPlanner.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TaskRepository _taskRepo;

        public TasksController(TaskRepository repo) 
        {
            _taskRepo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var tasks = await Task.Run(() => _taskRepo.GetAll());
            var numTasks = tasks.Count();
            var message = $"Found {numTasks} goals";
            if(numTasks == 0)
                return StatusCode(StatusCodes.Status204NoContent, ApiResponse.WithMessage(message));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(tasks, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetAsync(long id)
        {
            var task = await Task.Run(() => _taskRepo.TryGetOne(t => t.TaskId == id));
            if(task is null)
                return StatusCode(StatusCodes.Status404NotFound, ApiResponse.WithMessage($"Could not find a task of id {id}"));
            return StatusCode(StatusCodes.Status200OK, ApiResponse.Create(task, $"Found goal: {task.Name}"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> PostAsync([FromBody] TaskCreationRequest taskRequest)
        {
            if(await Task.Run(() => _taskRepo.TryCreate(new TaskDbModel { TaskId = 0, Name = taskRequest.Name, Priority = taskRequest.Priority })))
                return StatusCode(StatusCodes.Status201Created);
            return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Create(taskRequest, "Could not add the model to the API"));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromQuery] long id)
        {
            var task = await Task.Run(() => _taskRepo.TryGetOne(t => t.TaskId == id));
            if(task is null)
                return StatusCode(StatusCodes.Status404NotFound);
            await Task.Run(() => _taskRepo.Delete(task));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
