namespace Api.TorMarket.WebApi.DTOs.Responses;

public record UserProfileDto
{
    public required int UserId { get; init; }
    public required int RoleId { get; init; }
    public required string ProviderId { get; init; }
    public string? Email { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}
