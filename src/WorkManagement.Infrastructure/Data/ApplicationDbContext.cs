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

        modelBuilder.Entity<TaskItem>()
    .HasOne(t => t.AssignedUser)
    .WithMany(u => u.AssignedTasks)
    .HasForeignKey(t => t.AssignedUserId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TaskItem>()
    .HasOne(t => t.Project)
    .WithMany(p => p.Tasks)
    .HasForeignKey(t => t.ProjectId)
    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TaskComment>()
    .HasOne(c => c.TaskItem)
    .WithMany(t => t.Comments)
    .HasForeignKey(c => c.TaskItemId)
    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TaskComment>()
    .HasOne(c => c.User)
    .WithMany(u => u.Comments)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.Restrict);
    }
}