using Api.TorMarket.Application.CQRS.Commands.Reviews.CreateListingReview;
using Api.TorMarket.WebApi.DTOs.Requests;

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
}
