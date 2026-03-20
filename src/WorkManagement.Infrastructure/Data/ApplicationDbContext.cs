using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using WorkManagement.Domain.Entities;
using User = WorkManagement.Domain.Entities.User;

namespace WorkManagement.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets (Tables)
    public DbSet<User> Users { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<TaskItem> Tasks { get; set; }

    public DbSet<TaskComment> TaskComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // We will configure relationships here (next step)
    }
}