namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetCategoryByName;

public record GetCategoryByNameFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }
}

public enum ErrorType
{
    CategoryDoesNotExist,
    CategoryNameIsNotValid
}