namespace WorkflowAPI.DTOs;

public class StepDetailsDto
{
    public string StepStrId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Prerequisites { get; set; } = new();
}

public class WorkflowDetailsDto
{
    public string WorkflowStrId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<StepDetailsDto> Steps { get; set; } = new();
}
