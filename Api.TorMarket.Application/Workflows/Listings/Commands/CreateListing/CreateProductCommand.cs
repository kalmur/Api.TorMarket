using Api.TorMarket.Application.Unions;
using MediatR;

namespace Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ResultOrError<Domain.Models.Listing, CreateProductFailure>>
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset AvailableFrom { get; set; }
}