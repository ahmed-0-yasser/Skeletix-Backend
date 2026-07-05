using Skeletix.Contracts.AI;
using Skeletix.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Skeletix.Services;

public class AiService : IAiService
{
    private readonly HttpClient _httpClient;

    public AiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AiResultDto> AnalyzeAsync(
        string filePath,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            throw new FileNotFoundException("Image file not found", filePath);

        using var form = new MultipartFormDataContent();

        // =========================
        // Read image safely
        // =========================
        var fileBytes = await File.ReadAllBytesAsync(filePath, cancellationToken);

        var fileContent = new ByteArrayContent(fileBytes);

        fileContent.Headers.ContentType =
            new MediaTypeHeaderValue("image/jpeg");

        form.Add(fileContent, "image", Path.GetFileName(filePath));

        // =========================
        // Call AI model
        // =========================
        var response = await _httpClient.PostAsync(
            "https://george-waheed-fracture1.hf.space/predict",
            form,
            cancellationToken);

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        // =========================
        // DEBUG (important in your case)
        // =========================
        Console.WriteLine("========== AI RAW RESPONSE ==========");
        Console.WriteLine(json);
        Console.WriteLine("====================================");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"AI Service failed. Status: {response.StatusCode}, Response: {json}");
        }

        // =========================
        // Deserialize
        // =========================
        var result = JsonSerializer.Deserialize<AiResultDto>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result == null)
            throw new Exception("Failed to deserialize AI response");

        // =========================
        // Normalize ImageUrl (important fix)
        // =========================
        result.ImageUrl ??= string.Empty;

        Console.WriteLine($"AI ImageUrl: {result.ImageUrl}");

        return result;
    }
}