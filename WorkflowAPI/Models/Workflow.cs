namespace WorkflowAPI.Models;

public class Workflow
{
    public int Id { get; set; }
    public string WorkflowStrId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public ICollection<Step> Steps { get; set; } = new List<Step>();
}
