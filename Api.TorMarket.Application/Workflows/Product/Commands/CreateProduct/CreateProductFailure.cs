namespace Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

public record CreateProductFailure
{
    public required IEnumerable<ErrorType> Errors { get; set; }
}

public enum ErrorType
{
    InvalidName,
    InvalidCategoryId,
    InvalidPrice,
    UserDoesNotExist
}