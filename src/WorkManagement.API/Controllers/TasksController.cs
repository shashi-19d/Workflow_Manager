using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    private readonly ILogger<TasksController> _logger;

    public TasksController(ITaskService taskService, ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Failure("Invalid request", ModelState));
        }

        var result = await _taskService.CreateTaskAsync(request);

        var response = ApiResponse<TaskResponseDto>.SuccessResponse(
            result,
            "Task created successfully"
        );

        return CreatedAtAction(nameof(GetTaskById), new { id = result.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var result = await _taskService.GetTaskByIdAsync(id);

        _logger.LogInformation("Fetching task with Id: {TaskId}", id);

        if (result == null)
            return NotFound(ApiResponse<string>.Failure("Task not found"));

        return Ok(ApiResponse<TaskResponseDto>.SuccessResponse(result));
    }
}