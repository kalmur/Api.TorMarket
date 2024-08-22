using Api.TorMarket.Application.DTOs;
using Api.TorMarket.Application.Workflows.Listing.CreateListing;
using Api.TorMarket.Application.Workflows.Review.CreateReview;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Extensions;

public static class MapperExtensions
{
    public static Listing ToEntity(this CreateListingRequest request)
    {
        return new Listing
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Name = request.Name,
            SellLease = request.SellLease,
            Description = request.Description,
            Price = request.Price,
            City = request.City,
            Country = request.Country,
            AvailableFrom = request.AvailableFrom
        };
    }

    public static CreateListingRequest ToRequest(this CreateListingDto dto)
    {
        return new CreateListingRequest(dto.UserId, dto.CategoryId, dto.Name, dto.SellLease, 
            dto.Description, dto.Price, dto.City, dto.Country, dto.AvailableFrom);
    }

    public static Review ToEntity(this CreateReviewNotification notification)
    {
        return new Review
        {
            ListingId = notification.ListingId,
            UserId = notification.UserId,
            Rating = notification.Rating,
            Comment = notification.Comment
        };
    }
}
