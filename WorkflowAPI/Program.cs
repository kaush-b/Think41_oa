using Microsoft.EntityFrameworkCore;
using WorkflowAPI.Data;
using WorkflowAPI.Endpoints;
using WorkflowAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=workflow.db"));

var app = builder.Build();

app.MapWorkflowEndpoints();    // custom method you'll define next
app.MapGet("/workflows/{workflowStrId}/details", async (string workflowStrId, AppDbContext db) =>
{
    var workflow = await db.Workflows
        .Where(w => w.WorkflowStrId == workflowStrId)
        .Include(w => w.Steps)
        .ThenInclude(s => s.Dependencies)
        .FirstOrDefaultAsync();

    if (workflow is null)
        return Results.NotFound(new { message = "Workflow not found" });

    var stepDetails = workflow.Steps.Select(step => new StepDetailsDto
    {
        StepStrId = step.StepStrId,
        Description = step.Description,
        Prerequisites = step.Dependencies.Select(d => d.PrerequisiteStepStrId).ToList()
    }).ToList();

    var result = new WorkflowDetailsDto
    {
        WorkflowStrId = workflow.WorkflowStrId,
        Name = workflow.Name,
        Steps = stepDetails
    };

    return Results.Ok(result);
});

app.Run();
