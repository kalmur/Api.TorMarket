using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Users.GetUserByProviderId;

public sealed record GetUserByProviderIdQuery(
    [Required] string ProviderId
) : IRequest<User>;
