using Api.TorMarket.Application.Errors;

namespace Api.TorMarket.Application.Workflows.Category.Commands.Update;

public class UpdateCategoryError
{
    public NotFound? NotFoundError { get; }
    public UnprocessableEntity? UnprocessableEntityError { get; }

    public UpdateCategoryError(NotFound? notFoundError = null, UnprocessableEntity? unprocessableEntityError = null)
    {
        NotFoundError = notFoundError;
        UnprocessableEntityError = unprocessableEntityError;
    }
}