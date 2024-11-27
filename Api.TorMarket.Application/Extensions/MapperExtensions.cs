using Api.TorMarket.Application.Models;
using Api.TorMarket.Application.Workflows.Review.CreateReview;
using Api.TorMarket.Domain.Entities;

namespace Api.TorMarket.Application.Extensions;

public static class MapperExtensions
{
    public static CategoryModel ToModel(this Category category)
    {
        return new CategoryModel(
            category.CategoryId, 
            category.Name
        );
    }

    public static ListingModel ToModel(this Listing listing)
    {
        return new ListingModel(
            listing.ListingId,
            listing.UserId,
            listing.CategoryId,
            listing.Name,
            listing.SellLease,
            listing.Description,
            listing.Price,
            listing.City,
            listing.Rating,
            listing.AvailableFrom
        );
    }

    public static IEnumerable<ListingModel> ToModel(this IEnumerable<Listing> listings) 
        => listings.Select(ToModel); 

    public static PhotoModel ToModel(this Photo photo)
    {
        return new PhotoModel(
            photo.PhotoId,
            photo.UserId,
            photo.ListingId,
            photo.Url,
            photo.IsPrimary
        );
    }

    public static ReviewModel ToModel(this Review reviewModel)
    {
        return new ReviewModel(
            reviewModel.ReviewId,
            reviewModel.UserId,
            reviewModel.ListingId,
            reviewModel.Rating,
            reviewModel.Comment
        );
    }

    public static RoleModel ToModel(this Role role)
    {
        return new RoleModel(
            role.RoleId,
            role.Name,
            role.Description
        );
    }

    public static UserModel ToModel(this User user)
    {
        return new UserModel(
            user.UserId,
            user.RoleId,
            user.ExternalId
        );
    }

    public static Listing ToEntity(this CreateListingModel model)
    {
        return new Listing
        {
            UserId = model.UserId,
            CategoryId = model.CategoryId,
            Name = model.Name,
            SellLease = model.SellLease,
            Description = model.Description,
            Price = model.Price,
            City = model.City,
            AvailableFrom = model.AvailableFrom
        };
    }

    //public static CreateListingRequest ToRequest(this CreateListingDto dto)
    //{
    //    return new CreateListingRequest(dto.UserId, dto.CategoryId, dto.Name, dto.SellLease, 
    //        dto.Description, dto.Price, dto.City, dto.Country, dto.AvailableFrom);
    //}

    public static ReviewModel ToEntity(this CreateReviewNotification notification)
    {
        return new ReviewModel
        {
            ListingId = notification.ListingId,
            UserId = notification.UserId,
            Rating = notification.Rating,
            Comment = notification.Comment
        };
    }
}
