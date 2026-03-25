public interface ITaskService
{
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskRequestDto request);

    Task<TaskResponseDto> GetTaskByIdAsync(Guid id);
}