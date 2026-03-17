using Microsoft.Build.Utilities;
using WorkManagement.Domain.Common;

namespace WorkManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public ICollection<TaskItem> AssignedTasks { get; set; }

    public ICollection<TaskComment> Comments { get; set; }
}