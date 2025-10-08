namespace Api.TorMarket.Application.Abstractions.Azure;

public interface ITextAnalyticsService
{
    Task<IEnumerable<string>> ExtractKeyPhrasesAsync(string text, CancellationToken cancellationToken);
    Task<string> AnalyzeSentimentAsync(string text, CancellationToken cancellationToken);
}
