namespace Api.TorMarket.WebApi.Extensions.Results;

public record UserDto
{
    public required int UserId { get; init; }
    public required string ProviderId { get; init; }
}
