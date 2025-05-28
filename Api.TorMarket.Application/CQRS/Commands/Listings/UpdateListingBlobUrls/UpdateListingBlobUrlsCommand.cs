using Api.TorMarket.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Api.TorMarket.Application.CQRS.Commands.Listings.UpdateListingBlobUrls;

public sealed record UpdateListingBlobUrlsCommand(
    [Required] int ListingId, 
    [Required] string BlobUrl
) : IRequest<Listing>;
