using WorkManagement.Domain.Common;

namespace WorkManagement.Domain.Entities;

public class TaskComment : BaseEntity
{
    public string Content { get; set; }

    public Guid TaskItemId { get; set; }

    public TaskItem TaskItem { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}