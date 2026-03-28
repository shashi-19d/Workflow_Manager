using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestDto request)
    {
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

        if (result == null)
            return NotFound(ApiResponse<string>.Failure("Task not found"));

        return Ok(ApiResponse<TaskResponseDto>.SuccessResponse(result));
    }
}