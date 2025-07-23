namespace WorkflowAPI.Models;

public class Dependency
{
    public int Id { get; set; }

    public int StepId { get; set; }
    public Step Step { get; set; } = default!;

    public int PrerequisiteStepId { get; set; }
    public Step PrerequisiteStep { get; set; } = default!;
}
