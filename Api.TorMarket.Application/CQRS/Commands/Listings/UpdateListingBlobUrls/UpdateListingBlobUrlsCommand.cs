using Api.TorMarket.Domain.Models;
using System.ComponentModel.DataAnnotations;
using Api.TorMarket.Application.Abstractions.Mediator;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;

public sealed record UpdateListingBlobUrlsCommand(
    [Required] int ListingId, 
    [Required] string BlobUrl
) : ICommand<Listing>;
