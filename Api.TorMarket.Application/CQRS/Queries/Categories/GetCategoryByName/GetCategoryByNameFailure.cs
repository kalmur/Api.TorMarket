namespace Api.TorMarket.Application.CQRS.Queries.Categories.GetCategoryByName;

public record GetCategoryByNameFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }

    public enum ErrorType
    {
        CategoryDoesNotExist,
        CategoryNameIsNotValid
    }
}