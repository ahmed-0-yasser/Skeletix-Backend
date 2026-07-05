namespace Skeletix.Contracts.AI;

public class AiRecommendationDto
{
    public string Title { get; set; } = string.Empty;
    public string Urgency { get; set; } = string.Empty;

    public PhaseDto Phase_1_Emergency { get; set; } = new();
    public PhaseDto Phase_2_Hospital { get; set; } = new();
    public PhaseDto Phase_3_Recovery { get; set; } = new();

    public RedFlagsDto Red_Flags { get; set; } = new();
}

public class PhaseDto
{
    public string Label { get; set; } = string.Empty;
    public List<string> Steps { get; set; } = new();
}

public class RedFlagsDto
{
    public string Label { get; set; } = string.Empty;
    public List<string> Steps { get; set; } = new();
}