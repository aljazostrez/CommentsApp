using CommentsApp.Application.Comments;
using CommentsApp.Application.Users;
using CommentsApp.EFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add DB context
var startupPath = Directory.GetCurrentDirectory();
var dbPath = Path.Join(startupPath, "commentsAppDb.db");
builder.Services.AddDbContext<CommentsAppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

// dependency injection
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
