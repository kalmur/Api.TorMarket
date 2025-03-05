using Api.TorMarket.Application.Extensions;
using Api.TorMarket.Application.Interfaces.Repository;
using Api.TorMarket.Application.Unions;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

public class CreateProductHandler(
    IValidator<CreateProductCommand, CreateProductFailure> validator,
    IProductRepository productRepository
) : IRequestHandler<CreateProductCommand, ResultOrError<Domain.Models.Product, CreateProductFailure>>
{
    public async Task<ResultOrError<Domain.Models.Product, CreateProductFailure>> Handle(
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