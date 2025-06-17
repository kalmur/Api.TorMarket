using Api.TorMarket.Application.Mediator;
using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.CreateListing;

public sealed record CreateListingCommand : ICommand<ResultOrError<Listing, CreateListingFailure>>
{
    public required int UserId { get; init; }
    public required string CategoryName { get; init; }
    public required string Title { get; init; }
    public required decimal Price { get; init; }
    public string? Description { get; init; }

    internal CreateListingRequest ToRequest(
        int categoryId
    ) => new()
    {
        UserId = UserId,
        CategoryId = categoryId,
        ListingName = Title,
        Price = Price,
        Description = Description
    };
}