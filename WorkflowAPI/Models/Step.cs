namespace WorkflowAPI.Models;

public class Step
{
    public int Id { get; set; }
    public string StepStrId { get; set; } = default!;
    public string Description { get; set; } = default!;

    public int WorkflowId { get; set; }
    public Workflow Workflow { get; set; } = default!;

    public ICollection<Dependency> Dependencies { get; set; } = new List<Dependency>();
    public ICollection<Dependency> Prerequisites { get; set; } = new List<Dependency>();
}
