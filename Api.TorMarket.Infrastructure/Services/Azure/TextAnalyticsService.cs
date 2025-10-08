using Api.TorMarket.Application.Abstractions.Azure;
using Azure;
using Azure.AI.TextAnalytics;

namespace Api.TorMarket.Infrastructure.Services.Azure;

public class TextAnalyticsService : ITextAnalyticsService
{
    private readonly TextAnalyticsClient _textAnalyticsClient;

    public TextAnalyticsService(TextAnalyticsClient textAnalyticsClient)
    {
        _textAnalyticsClient = textAnalyticsClient;
    }

    public async Task<IEnumerable<string>> ExtractKeyPhrasesAsync(string text, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Enumerable.Empty<string>();

        try
        {
            var response = await _textAnalyticsClient.ExtractKeyPhrasesAsync(text, cancellationToken: cancellationToken);
            return response.Value;
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine($"Key Phrase Extraction failed: {ex.Message}");
            return Enumerable.Empty<string>();
        }
    }

    public async Task<string> AnalyzeSentimentAsync(string text, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "Neutral";

        try
        {
            var response = await _textAnalyticsClient.AnalyzeSentimentAsync(text, cancellationToken: cancellationToken);
            return response.Value.Sentiment.ToString();
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine($"Sentiment Analysis failed: {ex.Message}");
            return "Neutral";
        }
    }
}
