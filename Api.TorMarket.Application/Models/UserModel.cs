namespace Api.TorMarket.Application.Models;

public record UserModel(
    int UserId,
    int RoleId,
    string ExternalId
);
