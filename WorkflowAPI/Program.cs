using Microsoft.EntityFrameworkCore;
using WorkflowAPI.Data;
using WorkflowAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=workflow.db"));

var app = builder.Build();

app.MapWorkflowEndpoints();    // custom method you'll define next
app.Run();
