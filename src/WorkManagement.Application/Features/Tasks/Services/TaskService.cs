using WorkManagement.Domain.Entities;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskRequestDto request)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            ProjectId = request.ProjectId,
            AssignedUserId = request.AssignedUserId
        };

        await _taskRepository.AddAsync(task);
        await _unitOfWork.SaveChangesAsync();

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Status = task.Status.ToString()
        };
    }
}