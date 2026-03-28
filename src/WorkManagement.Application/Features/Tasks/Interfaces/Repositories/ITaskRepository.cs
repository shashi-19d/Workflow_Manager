using WorkManagement.Domain.Entities;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<List<TaskItem>> GetAllAsync();
    Task<List<TaskItem>> GetByUserIdAsync(Guid userId);
    Task<List<TaskItem>> GetByProjectIdAsync(Guid projectId);

    Task AddAsync(TaskItem task);
    void Update(TaskItem task);
    void Delete(TaskItem task);
}