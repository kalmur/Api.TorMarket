using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

public class CreateProductHandler(
    IValidator<CreateProductCommand, CreateProductFailure> validator,
    IListingRepository productRepository
) : IRequestHandler<CreateProductCommand, ResultOrError<Domain.Models.Listing, CreateProductFailure>>
{
    public async Task<ResultOrError<Domain.Models.Listing, CreateProductFailure>> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await validator.ValidateAsync(
            command,
            cancellationToken
        );

        if (validationErrors is not null)
            return validationErrors;

        return await productRepository.CreateAsync(
            command.ToRequest(),
            cancellationToken
        );
    }
}