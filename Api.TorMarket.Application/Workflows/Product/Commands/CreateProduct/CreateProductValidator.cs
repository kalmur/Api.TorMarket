using Api.TorMarket.Application.Repositories.Interfaces;

namespace Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

public class CreateProductValidator(
    ISiteUserRepository userRepository
) : IValidator<CreateProductCommand, CreateProductFailure>
{
    public async Task<CreateProductFailure> ValidateAsync(
        CreateProductCommand command, 
        CancellationToken cancellationToken
    )
    {
        var errors = new List<ErrorType>();

        if (await UserDoesNotExist(command.UserId, cancellationToken))
            errors.Add(ErrorType.UserDoesNotExist);


        if (string.IsNullOrWhiteSpace(command.Name))
            errors.Add(ErrorType.InvalidName);

        if (command.CategoryId == 0)
            errors.Add(ErrorType.InvalidCategoryId);

        if (command.Price <= 0)
            errors.Add(ErrorType.InvalidPrice);

        if (errors.Count > 0)
        {
            return new CreateProductFailure
            {
                Errors = errors
            };
        }

        return null;
    }

    private async Task<bool> UserDoesNotExist(
        int userId,
        CancellationToken cancellationToken
    ) => (
        await userRepository.GetByIdAsync(
            userId, 
            cancellationToken
        )
    ) is null;
}
