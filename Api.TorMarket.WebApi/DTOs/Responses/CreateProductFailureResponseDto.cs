namespace Api.TorMarket.WebApi.DTOs.Responses
{
    public class CreateProductFailureResponseDto
    {
        public required IEnumerable<string> Errors { get; set; }
    }
}
