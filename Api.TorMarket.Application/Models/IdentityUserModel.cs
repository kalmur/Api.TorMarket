namespace Api.TorMarket.Application.Models;

public record IdentityUserModel(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string ProviderSubjectId,
    string Provider
);