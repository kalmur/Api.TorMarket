using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed record CreateListingCommand : IRequest<ResultOrError<Listing, CreateListingFailure>>
{
    public required int UserId { get; init; }

    public required string Name { get; init; }

    public required int CategoryId { get; init; }

    public required decimal Price { get; init; }

    public string? Description { get; init; }

    public List<string>? ImageUrls { get; init; }

    internal CreateListingRequest ToRequest()
        => new()
        {
            UserId = UserId,
            Name = Name,
            CategoryId = CategoryId,
            Price = Price,
            Description = Description,
            ImageUrls = ImageUrls,
        };
}