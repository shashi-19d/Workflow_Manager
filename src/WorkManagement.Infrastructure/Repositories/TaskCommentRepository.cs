using Microsoft.EntityFrameworkCore;
using WorkManagement.Domain.Entities;
using WorkManagement.Infrastructure.Data;

public class TaskCommentRepository : ITaskCommentRepository
{
    private readonly ApplicationDbContext _context;

    public TaskCommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskComment>> GetByTaskIdAsync(Guid taskId)
    {
        return await _context.TaskComments
            .Where(c => c.TaskItemId == taskId)
            .ToListAsync();
    }

    public async Task AddAsync(TaskComment comment)
    {
        await _context.TaskComments.AddAsync(comment);
    }

    public void Delete(TaskComment comment)
    {
        _context.TaskComments.Remove(comment);
    }
}