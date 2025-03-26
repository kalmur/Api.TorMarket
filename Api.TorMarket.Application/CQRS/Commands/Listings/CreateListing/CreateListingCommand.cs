using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public record CreateListingCommand : IRequest<ResultOrError<Listing, CreateListingFailure>>
{
    public required int UserId { get; set; }

    public required string Name { get; set; }

    public required int CategoryId { get; set; }

    public required decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset AvailableFrom { get; set; }

    internal CreateListingRequest ToRequest()
        => new()
        {
            UserId = UserId,
            Name = Name,
            CategoryId = CategoryId,
            Price = Price,
            Description = Description,
            AvailableFrom = AvailableFrom,
        };
}