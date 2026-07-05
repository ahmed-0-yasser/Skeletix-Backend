using System.Text.Json.Serialization;

namespace Skeletix.Contracts.AI;

public class AiResultDto
{
    public string Prediction { get; set; } = string.Empty;

    public double Confidence { get; set; }

    public int Detections { get; set; }

    public AiRecommendationDto Recommendation { get; set; } = new();


    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = string.Empty;
}