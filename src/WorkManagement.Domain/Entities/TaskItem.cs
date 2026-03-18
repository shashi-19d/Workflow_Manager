using WorkManagement.Domain.Common;
using WorkManagement.Domain.Entities;
using TaskStatus = WorkManagement.Domain.Enums.TaskStatus;

public class TaskItem : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public TaskStatus Status { get; private set; }

    public Guid ProjectId { get; set; }

    public Guid AssignedUserId { get; set; }

    public ICollection<TaskComment> Comments { get; set; }

    public TaskItem()
    {
        Status = TaskStatus.Todo;
    }

    public void Start()
    {
        if (Status != TaskStatus.Todo && Status != TaskStatus.Blocked)
            throw new InvalidOperationException("Invalid state transition.");

        Status = TaskStatus.InProgress;
    }

    public void Block()
    {
        if (Status != TaskStatus.InProgress)
            throw new InvalidOperationException("Invalid state transition.");

        Status = TaskStatus.Blocked;
    }

    public void Complete()
    {
        if (Status != TaskStatus.InProgress)
            throw new InvalidOperationException("Invalid state transition.");

        Status = TaskStatus.Completed;
    }
}