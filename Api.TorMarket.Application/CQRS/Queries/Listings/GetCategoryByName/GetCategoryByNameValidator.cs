using Api.TorMarket.Application.Repositories.Interfaces;
using static Api.TorMarket.Application.CQRS.Queries.Listings.GetCategoryByName.GetCategoryByNameFailure;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetCategoryByName;

public class GetCategoryByNameValidator(
    IListingCategoryRepository categoryRepository
) : IValidator<GetCategoryByNameQuery, GetCategoryByNameFailure>
{
    public async Task<GetCategoryByNameFailure?> ValidateAsync(
        GetCategoryByNameQuery command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (string.IsNullOrWhiteSpace(command.Name))
            errors.Add(ErrorType.CategoryNameIsNotValid);

        if (await CategoryDoesNotExist(command.Name, cancellationToken))
            errors.Add(ErrorType.CategoryDoesNotExist);

        if (errors.Count > 0)
        {
            return new GetCategoryByNameFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> CategoryDoesNotExist(
        string categoryName,
        CancellationToken cancellationToken
    ) => 
        await categoryRepository.GetByNameAsync(
            categoryName,
            cancellationToken
        )
     is null;
}
