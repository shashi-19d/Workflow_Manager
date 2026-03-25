public class CreateTaskRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public Guid AssignedUserId { get; set; }
}