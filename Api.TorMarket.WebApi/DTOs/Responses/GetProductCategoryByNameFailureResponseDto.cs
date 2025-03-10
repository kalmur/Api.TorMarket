namespace Api.TorMarket.WebApi.DTOs.Responses;

public record GetProductCategoryByNameFailureResponseDto
{
    public required IEnumerable<string> Errors { get; set; }
}
