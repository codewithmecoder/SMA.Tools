using System.Net.Http.Headers;
using SMA.Tools.Core.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace SMA.Tools.Core.Services;

public class AiService : IAiService
{
    private readonly HttpClient _http;
    private const string ApiKey = "sk-your-api-key"; // Replace with your actual key

    public AiService(HttpClient httpClient)
    {
        _http = httpClient;
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
    }

    public async Task<string> GenerateCaptionAsync(string prompt)
    {
        var request = new
        {
            model = "gpt-3.5-turbo-instruct",
            prompt,
            max_tokens = 100
        };

        var response = await _http.PostAsJsonAsync("https://api.openai.com/v1/completions", request);
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("text").GetString()?.Trim() ?? "";
    }

    public async Task<string[]> GenerateHashtagsAsync(string topic)
    {
        var prompt = $"Generate a list of trending hashtags for {topic}.";
        var caption = await GenerateCaptionAsync(prompt);
        return [.. caption.Split('#').Skip(1).Select(h => "#" + h.Trim().Split(' ')[0])];
    }
}