using WorkManagement.Domain.Entities;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task<List<Project>> GetAllAsync();
    Task AddAsync(Project project);
    void Update(Project project);
    void Delete(Project project);
}