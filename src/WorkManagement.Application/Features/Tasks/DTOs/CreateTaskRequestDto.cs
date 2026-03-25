using System.ComponentModel.DataAnnotations;

public class CreateTaskRequestDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public Guid ProjectId { get; set; }

    [Required]
    public Guid AssignedUserId { get; set; }
}