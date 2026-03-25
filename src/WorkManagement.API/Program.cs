using Microsoft.EntityFrameworkCore;
using WorkManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Controllers
builder.Services.AddControllers();

// 🔹 Swagger (MISSING IN YOUR CASE MOST LIKELY)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();

// 🔹 Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 🔹 Services
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// 🔹 Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Routing
app.UseHttpsRedirection();

app.MapControllers();

app.Run();