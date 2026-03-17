using WorkManagement.Domain.Common;

namespace WorkManagement.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public TaskStatus Status { get; set; }

    public Guid ProjectId { get; set; }

    public Project Project { get; set; }

    public Guid AssignedUserId { get; set; }

    public User AssignedUser { get; set; }

    public DateTime? DueDate { get; set; }

    public ICollection<TaskComment> Comments { get; set; }
}