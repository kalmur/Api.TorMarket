using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models.ViewModels;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed record GetUserByProviderIdQuery(
    [Required] string ProviderId
) : IQuery<ResultOrError<UserProfile, GetUserByProviderIdFailure>>;
