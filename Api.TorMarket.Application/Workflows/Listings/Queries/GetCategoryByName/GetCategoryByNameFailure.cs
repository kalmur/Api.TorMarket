namespace Api.TorMarket.Application.Workflows.Product.Queries.GetCategoryByName;

public record GetCategoryByNameFailure
{
    public required IEnumerable<ErrorType> Errors { get; init; }
}

public enum ErrorType
{
    CategoryDoesNotExist,
    CategoryNameIsNotValid
}