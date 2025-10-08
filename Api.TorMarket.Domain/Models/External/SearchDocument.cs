namespace Api.TorMarket.Domain.Models.External;

public record SearchDocument
{
    public required int ListingId { get; set; }
    public required string ListingTitle { get; set; } = string.Empty;
    public required string ListingDescription { get; set; } = string.Empty;
    public required List<string> TitleKeyPhrases { get; set; } = new();
    public required List<string> DescriptionKeyPhrases { get; set; } = new();
    public required string TitleSentiment { get; set; } = "Neutral";
    public required string DescriptionSentiment { get; set; } = "Neutral";
}