namespace SMA.Tools.Core.Interfaces;

public interface IAiService
{
    Task<string> GenerateCaptionAsync(string prompt);
    Task<string[]> GenerateHashtagsAsync(string topic);
}