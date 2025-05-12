using Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;
using Api.TorMarket.Application.CQRS.Queries.Reviews.GetReviewByUserAndListingId;
using Api.TorMarket.Domain.Models;
using Api.TorMarket.WebApi.DTOs.Requests;
using Api.TorMarket.WebApi.DTOs.Responses;

namespace Api.TorMarket.WebApi.Extensions.Models;

public static class ListingReviewExtensions
{
    public static CreateListingReviewCommand ToCommand(
        this CreateListingReviewDto dto
    ) => 
        new()
        {
            UserId = dto.UserId,
            ListingId = dto.ListingId,
            Value = dto.Value,
            Comment = dto.Comment
        };

    public static GetReviewByUserAndListingIdQuery ToQuery(
        this GetReviewByUserAndListingIdDto dto
    ) => new(
        dto.UserId, 
        dto.ListingId
    );

    //public static ListingWithReviewDto ToResponseDto(
    //    this ListingWithReviewAndCategory models
    //) => new()
    //{
    //    //TODO
    //}

    public static ReviewDto ToResponseDto(
        this ListingReview model
    ) => new()
    {
        RatingValue = model.Value,
        Comment = model.Comment
    };

    public static IEnumerable<ReviewDto> ToResponseDto(
        this IEnumerable<ListingReview> models
    ) => models.Select(ToResponseDto);
}
