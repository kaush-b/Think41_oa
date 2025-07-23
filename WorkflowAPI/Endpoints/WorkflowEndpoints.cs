using WorkflowAPI.Models;
using WorkflowAPI.Data;

namespace WorkflowAPI.Endpoints;

public static class WorkflowEndpoints
{
    public static void MapWorkflowEndpoints(this WebApplication app)
    {
        app.MapPost("/workflows", async (AppDbContext db, Workflow input) =>
        {
            var workflow = new Workflow
            {
                WorkflowStrId = input.WorkflowStrId,
                Name = input.Name
            };

            db.Workflows.Add(workflow);
            await db.SaveChangesAsync();

            return Results.Json(new
            {
                internal_db_id = workflow.Id,
                workflow_str_id = workflow.WorkflowStrId,
                status = "created"
            });
        });
    }
}
