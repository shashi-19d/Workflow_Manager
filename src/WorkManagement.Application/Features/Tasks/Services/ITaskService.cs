public interface ITaskService
{
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskRequestDto request);
}