using WorkManagement.Domain.Entities;

public interface ITaskCommentRepository
{
    Task<List<TaskComment>> GetByTaskIdAsync(Guid taskId);
    Task AddAsync(TaskComment comment);
    void Delete(TaskComment comment);
}