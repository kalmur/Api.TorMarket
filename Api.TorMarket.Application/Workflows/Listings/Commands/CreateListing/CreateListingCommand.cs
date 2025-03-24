using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Listings.Commands.CreateListing;

public class CreateListingCommand : IRequest<ResultOrError<Listing, CreateListingFailure>>
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset AvailableFrom { get; set; }
}